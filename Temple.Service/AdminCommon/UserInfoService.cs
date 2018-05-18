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
        private readonly IRepository<User_Role> _roleuserRepository; //用户角色
        private readonly IRepository<RolePermission> _authoritymenuRepository;//角色程式
        private readonly IRepository<SystemPro> _menuinfoRepository; //程式

        /// <summary>
        /// 内存缓存
        /// </summary>
        private MemoryCacheManager localCache = new MemoryCacheManager();

        public UserInfoService(IUnitOfWork unitofwork)
        {
            this._userinfoRepository = unitofwork.Repository<User>();
            this._roleuserRepository = unitofwork.Repository<User_Role>();
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
            query = query.Where(x => x.Status == true && x.Account != "superadmin");
            if (!string.IsNullOrEmpty(username))
            {
                query = query.Where(x => x.Name.Contains(username));
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
            if (string.IsNullOrEmpty(info.Account))
            {
                throw new ArgumentNullException("用户账号不能为空");
            }
            if (string.IsNullOrEmpty(info.FileName))
            {
                throw new ArgumentNullException("用户名称不能为空");
            }
            if (string.IsNullOrEmpty(info.Passwd))
            {
                throw new ArgumentNullException("用户密码不能为空");
            }
            if (_userinfoRepository.Entities.Where(x => x.Account == info.Account).FirstOrDefault() != null)
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
            if (string.IsNullOrEmpty(info.Account))
            {
                throw new ArgumentNullException("用户账号不能为空");
            }
            if (string.IsNullOrEmpty(info.Name))
            {
                throw new ArgumentNullException("用户名称不能为空");
            }
            if (string.IsNullOrEmpty(info.Passwd))
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
            return this._userinfoRepository.Entities.Where(x=>x.Name.Contains(name)).FirstOrDefault();
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public User LoginUser(User info)
        {
            if (string.IsNullOrEmpty(info.Account))
            {
                throw new ArgumentNullException("用户名不能为空");
            }
            if (string.IsNullOrEmpty(info.Passwd))
            {
                throw new ArgumentNullException("用户密码不能为空");
            }
            var query = this._userinfoRepository.Entities;
            query = query.Where(x => x.Account == info.Account && x.Passwd == info.Passwd);
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
                       join ru in roleUserList on ar.Role_Id equals ru.Role_Id
                       where ru.User_Id == UserID
                       select ar;
            List<int> aList = new List<int>();
            foreach (var item in list.Distinct().ToList())
            {
                aList.Add(item.SysPro_Id.Value);
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
                       join am in authorityMenuList on m.Id equals am.SysPro_Id
                       join ru in roleUserList on am.Role_Id equals ru.Role_Id
                       where ru.User_Id == UserID
                       select m;
            return list.Distinct().ToList();
        }
        public List<SystemPro> GetAllChildMenu()
        {
            string key = "GetAllChildMenuListData";

            if (localCache.HasKey(key))
                return localCache.Get<List<SystemPro>>(key);

            var query = this._menuinfoRepository.Entities;
            query = query.OrderByDescending(x => x.Code);


            localCache.Set(key, query.ToList(), 3600);
            return query.ToList();
        }


        public bool DeleteUserRole(int id)
        {
            return _roleuserRepository.Delete(t => t.Role_Id == id)>0;
        }

        public bool HasSave(int pid, int roleid)
        {
            var query = this._authoritymenuRepository.Entities;
            query = query.Where(x => x.Role_Id == roleid && x.SysPro_Id == pid);
            var sp = query.FirstOrDefault();
            return sp != null && sp.Id > 0 ? true : false;
        }

        /// <summary>
        /// 添加权限角色关联
        /// </summary>
        /// <param name="AuthorityIDs"></param>
        /// <param name="RoleID"></param>
        public void AddAuthorityRole(string[] AuthorityIDs, int RoleID)
        {
            foreach (var item in AuthorityIDs)
            {
                if (!HasSave(Convert.ToInt32(item), RoleID))
                {
                    RolePermission info = new RolePermission();
                    info.SysPro_Id = Convert.ToInt32(item);
                    info.Role_Id = RoleID;
                    this._authoritymenuRepository.Insert(info);
                }
            }
        }
        /// <summary>
        /// 根据角色ID查询该角色的权限
        /// </summary>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public List<RolePermission> GetAuthority_RoleListByRoleID(int RoleID)
        {
            var query = this._authoritymenuRepository.Entities;
            query = query.Where(x => x.Role_Id == RoleID);
            return query.ToList();
        }

        /// <summary>
        /// 获取所有权限列表
        /// </summary>
        /// <returns></returns>
        public List<SystemPro> GetAllProgramList(int pid)
        {
            var query = this._menuinfoRepository.Entities;
            if (pid > 0)
                query = query.Where(x => x.System_id == pid);
            query = query.Where(x => x.Status == 1);
            query = query.OrderBy(x => x.System_id).ThenBy(x => x.Id);
            return query.ToList();
        }
    }
}
