using Temple.Core.Data;
using Temple.Domain;
using Temple.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Service
{
    public partial class MenuInfoService : IMenuInfoService
    {
        private readonly IRepository<SystemPro> _menuinfoRepository;
        private readonly IRepository<WuxiSystem> _topmenuinfoRepository;
        private readonly IRepository<Role_User> _roleuserRepository;
        private readonly IRepository<Authority_Role> _authorityroleRepository;
        private readonly IRepository<Authority_Menu> _authoritymenuRepository;

        public MenuInfoService(IUnitOfWork unitofwork)
        {
            this._menuinfoRepository = unitofwork.Repository<SystemPro>();
            this._roleuserRepository = unitofwork.Repository<Role_User>();
            this._authorityroleRepository = unitofwork.Repository<Authority_Role>();
            this._authoritymenuRepository = unitofwork.Repository<Authority_Menu>();
            this._topmenuinfoRepository = unitofwork.Repository<WuxiSystem>();
        }

        /// <summary>
        /// 根据上一级ID获取所有菜单列表(0为顶级菜单) 
        /// </summary>
        /// <param name="PID"></param>
        /// <returns></returns>
        public List<SystemPro> GetAllMenuListByPID(int PID)
        {
            var query = this._menuinfoRepository.Entities;
            query = query.Where(x => x.SysId == PID);
            query = query.OrderByDescending(x => x.SysCode);
            return query.ToList();
        }

        public List<WuxiSystem> GetTopMenuList()
        {
            var query = this._topmenuinfoRepository.Entities;
            query = query.Where(x => x.Status == true);
            query = query.OrderByDescending(x => x.Id);
            return query.ToList();
        }
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool AddMenu(SystemPro info)
        {
            if (info == null)
            {
                throw new ArgumentNullException("菜单对象不能为空");
            }
            if (string.IsNullOrEmpty(info.CodeName))
            {
                throw new ArgumentNullException("菜单名称不能为空");
            }
            return this._menuinfoRepository.Insert(info) > 0;
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteMenu(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("菜单ID不能小于等于0");
            }
            return this._menuinfoRepository.Delete(id) > 0;
        }

        /// <summary>
        /// 更新菜单
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool UpdateMenu(SystemPro info)
        {
            if (info == null)
            {
                throw new ArgumentNullException("菜单对象不能为空");
            }
            if (info.SysId <= 0)
            {
                throw new ArgumentNullException("菜单ID不能为空");
            }
            if (string.IsNullOrEmpty(info.CodeName))
            {
                throw new ArgumentNullException("菜单名称不能为空");
            }
            return this._menuinfoRepository.Update(info) > 0;
        }

        /// <summary>
        /// 根据ID获取菜单信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public SystemPro GetMenuInfoByID(int ID)
        {
            return this._menuinfoRepository.GetByKey(ID);
        }


        /// <summary>
        /// 根据用户ID获取该用户有权限访问的菜单
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<SystemPro> GetUserMenu(int UserID)
        {
            var menuList = _menuinfoRepository.Entities;
            var roleUserList = _roleuserRepository.Entities;
            var authorityRoleList = _authorityroleRepository.Entities;
            var authorityMenuList = _authoritymenuRepository.Entities;
            var list = from m in menuList
                       join am in authorityMenuList on m.Id equals am.MenuID 
                       join ar in authorityRoleList on am.AuthorityID equals ar.AuthorityID 
                       join ru in roleUserList on ar.RoleID equals ru.RoleID 
                       where ru.UserID == UserID 
                       select m;


            list = list.Distinct();
            list = list.OrderByDescending(x => x.SysCode);
            return list.ToList();
        }
    }
}
