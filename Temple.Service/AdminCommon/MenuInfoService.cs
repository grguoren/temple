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
        private readonly IRepository<Temple.Domain.System> _topmenuinfoRepository;
        private readonly IRepository<User_Role> _roleuserRepository;
        private readonly IRepository<RolePermission> _authoritymenuRepository;

        public MenuInfoService(IUnitOfWork unitofwork)
        {
            this._menuinfoRepository = unitofwork.Repository<SystemPro>();
            this._roleuserRepository = unitofwork.Repository<User_Role>();
            this._authoritymenuRepository = unitofwork.Repository<RolePermission>();
            this._topmenuinfoRepository = unitofwork.Repository<Temple.Domain.System>();
        }

        /// <summary>
        /// 根据上一级ID获取所有菜单列表(0为顶级菜单) 
        /// </summary>
        /// <param name="PID"></param>
        /// <returns></returns>
        public List<SystemPro> GetAllMenuListByPID(int PID)
        {
            var query = this._menuinfoRepository.Entities;
            query = query.Where(x => x.System_id == PID && x.Status == 1);
            query = query.OrderByDescending(x => x.Code);
            return query.ToList();
        }

        public List<Temple.Domain.System> GetTopMenuList()
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
            if (string.IsNullOrEmpty(info.Name))
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
            if (info.Id <= 0)
            {
                throw new ArgumentNullException("菜单ID不能为空");
            }
            if (string.IsNullOrEmpty(info.Name))
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

        public bool DeleteRoleMenu(int id)
        {
            return _authoritymenuRepository.Delete(t => t.SysPro_Id == id) > 0;
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
            var authorityMenuList = _authoritymenuRepository.Entities;
            var list = from m in menuList
                       join am in authorityMenuList on m.Id equals am.SysPro_Id 
                       join ru in roleUserList on am.Role_Id equals ru.Role_Id 
                       where ru.User_Id == UserID 
                       select m;


            list = list.Distinct();
            list = list.OrderByDescending(x => x.Code);
            return list.ToList();
        }
    }
}
