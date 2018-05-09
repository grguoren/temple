using Temple.Core.Cache;
using Temple.Core.Data;
using Temple.Core.Pager;
using Temple.Domain;
using Temple.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Service
{
    public partial class UserInfoService : IUserInfoService
    {
        private readonly IRepository<User> _userinfoRepository; //用户
        private readonly IRepository<UserRole> _roleuserRepository; //用户角色
        private readonly IRepository<RolePermission> _authoritymenuRepository;//角色程式
        private readonly IRepository<SystemPro> _menuinfoRepository; //程式

        /// <summary>
        /// 内存缓存
        /// </summary>
        private MemoryCacheManager localCache = new MemoryCacheManager();

        public UserInfoService(IUnitOfWork unitofwork)
        {
            this._userinfoRepository = unitofwork.Repository<User>();
            this._roleuserRepository = unitofwork.Repository<UserRole>();
            this._authoritymenuRepository = unitofwork.Repository<RolePermission>();
            this._menuinfoRepository = unitofwork.Repository<SystemPro>();
        }

        /// <summary>
        /// 获取用户列表(分页)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public IPagedList<User> GetUserList(int page, int size, string username, string UserName)
        {
            var query = this._userinfoRepository.Entities;
            query = query.Where(x => x.Status == true  && x.UserName != "superadmin");
            if (!string.IsNullOrEmpty(username))
            {
                query = query.Where(x => x.UserName.Contains(username));
            }
            if (!string.IsNullOrEmpty(UserName))
            {
                query = query.Where(x => x.UserName.Contains(UserName));
            }
            query = query.OrderByDescending(x => x.Id);
            IPagedList<User> list = new PagedList<User>(query, page, size);
            return list;
        }

        /// <summary>
        /// 添加新用户
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool AddUser(User info)
        {
            if (info == null)
            {
                throw new ArgumentNullException("用户对象不能为空");
            }
            if (string.IsNullOrEmpty(info.UserName))
            {
                throw new ArgumentNullException("用户账号不能为空");
            }
            if (string.IsNullOrEmpty(info.FileName))
            {
                throw new ArgumentNullException("用户名称不能为空");
            }
            if (string.IsNullOrEmpty(info.Password))
            {
                throw new ArgumentNullException("用户密码不能为空");
            }
            if (_userinfoRepository.Entities.Where(x => x.UserName == info.UserName).FirstOrDefault() != null)
            {
                return false;
            }
            else
            {
                return this._userinfoRepository.Insert(info) > 0;
            }
        }


        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool DeleteUser(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("用户ID不能小于等于0");
            }
            return this._userinfoRepository.Delete(id) > 0;
        }

        /// <summary>
        /// 用户更新
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool UpdateUser(User info)
        {
            if (info == null)
            {
                throw new ArgumentNullException("用户对象不能为空");
            }
            if (info.Id <= 0)
            {
                throw new ArgumentNullException("用户ID不能为空");
            }
            if (string.IsNullOrEmpty(info.UserName))
            {
                throw new ArgumentNullException("用户账号不能为空");
            }
            if (string.IsNullOrEmpty(info.UserName))
            {
                throw new ArgumentNullException("用户名称不能为空");
            }
            if (string.IsNullOrEmpty(info.Password))
            {
                throw new ArgumentNullException("用户密码不能为空");
            }
            return this._userinfoRepository.Update(info) > 0;
        }

        /// <summary>
        /// 根据ID获取用户信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public User GetUserInfoByID(int ID)
        {
            return this._userinfoRepository.GetByKey(ID);
        }

        public User GetUserInfoByName(string name)
        {
            return this._userinfoRepository.Entities.Where(x=>x.UserName.Contains(name)).FirstOrDefault();
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public User LoginUser(User info)
        {
            if (string.IsNullOrEmpty(info.UserName))
            {
                throw new ArgumentNullException("用户名不能为空");
            }
            if (string.IsNullOrEmpty(info.Password))
            {
                throw new ArgumentNullException("用户密码不能为空");
            }
            var query = this._userinfoRepository.Entities;
            query = query.Where(x => x.UserName == info.UserName && x.Password == info.Password);
            return query.FirstOrDefault();
        }

        /// <summary>
        /// 根据用户ID获取用户程式
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<int> GetUserAuthorityList(int UserID)
        {
            var roleUserList = _roleuserRepository.Entities;
            var authorityRoleList = _authoritymenuRepository.Entities;
            var list = from ar in authorityRoleList
                       join ru in roleUserList on ar.RoleId equals ru.RoleId
                       where ru.UserId == UserID
                       select ar;
            List<int> aList = new List<int>();
            foreach (var item in list.Distinct().ToList())
            {
                aList.Add(item.SysProId.Value);
            }
            return aList;
        }

        /// <summary>
        /// 获取用户菜单
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<SystemPro> GetUserMenu(int UserID)
        {
            var menuList = _menuinfoRepository.Entities;
            var roleUserList = _roleuserRepository.Entities;
            var authorityMenuList = _authoritymenuRepository.Entities;
            var list = from m in menuList
                       join am in authorityMenuList on m.Id equals am.SysProId
                       join ru in roleUserList on am.RoleId equals ru.RoleId
                       where ru.UserId == UserID
                       select m;
            return list.Distinct().ToList();
        }
        public List<SystemPro> GetAllChildMenu()
        {
            string key = "GetAllChildMenuListData";

            if (localCache.HasKey(key))
                return localCache.Get<List<SystemPro>>(key);

            var query = this._menuinfoRepository.Entities;
            query = query.OrderByDescending(x => x.SysCode);


            localCache.Set(key, query.ToList(), 3600);
            return query.ToList();
        }


        public bool DeleteUserRole(int id)
        {
            return _roleuserRepository.Delete(t => t.RoleId == id)>0;
        }
    }
}
