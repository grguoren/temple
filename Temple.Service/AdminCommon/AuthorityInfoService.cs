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
    public partial class AuthorityInfoService : IAuthorityInfoService
    {
        private readonly IRepository<AuthorityInfo> _authorityRepository;
        private readonly IRepository<Authority_Role> _roleRepository;
        private readonly IRepository<Authority_Menu> _menuRepository;

        public AuthorityInfoService(IUnitOfWork unitofwork)
        {
            this._authorityRepository = unitofwork.Repository<AuthorityInfo>();
            this._roleRepository = unitofwork.Repository<Authority_Role>();
            this._menuRepository = unitofwork.Repository<Authority_Menu>();
        }
        #region AuthorityInfo表基础信息方法
        /// <summary>
        /// 获取所有权限列表
        /// </summary>
        /// <returns></returns>
        public List<Domain.AuthorityInfo> GetAllAuthorityList()
        {
            var query = this._authorityRepository.Entities;
            query = query.Where(x => x.Status == 0);
            return query.ToList();
        }

        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool AddAuthority(Domain.AuthorityInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException("权限对象不能为空");
            }
            if (string.IsNullOrEmpty(info.Name))
            {
                throw new ArgumentNullException("权限名称不能为空");
            }
            return this._authorityRepository.Insert(info) > 0;
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteAuthority(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("权限ID不能小于等于0");
            }
            return this._authorityRepository.Delete(id) > 0;
        }

        /// <summary>
        /// 更新权限
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool UpdateAuthority(Domain.AuthorityInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException("权限对象不能为空");
            }
            if (info.ID <= 0)
            {
                throw new ArgumentNullException("权限ID不能为空");
            }
            if (string.IsNullOrEmpty(info.Name))
            {
                throw new ArgumentNullException("权限名称不能为空");
            }
            return this._authorityRepository.Update(info) > 0;
        }

        /// <summary>
        /// 根据ID获取权限信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Domain.AuthorityInfo GetAuthorityInfoByID(int ID)
        {
            return this._authorityRepository.GetByKey(ID);
        }
        #endregion

        #region 权限-角色关联方法
        /// <summary>
        /// 添加权限角色关联
        /// </summary>
        /// <param name="AuthorityIDs"></param>
        /// <param name="RoleID"></param>
        public void AddAuthorityRole(string[] AuthorityIDs, int RoleID)
        {
            var query = this._roleRepository.Entities;
            query = query.Where(x => x.RoleID == RoleID);
            if (query.ToList() != null && query.Count() > 0)
            {
                this._roleRepository.Delete(query);
            }
            foreach (var item in AuthorityIDs)
            {
                Authority_Role info = new Authority_Role();
                info.AuthorityID = Convert.ToInt32(item);
                info.RoleID = RoleID;
                this._roleRepository.Insert(info);
            }
        }
        /// <summary>
        /// 根据角色ID查询该角色的权限
        /// </summary>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public List<Authority_Role> GetAuthority_RoleListByRoleID(int RoleID)
        {
            var query = this._roleRepository.Entities;
            query = query.Where(x => x.RoleID == RoleID);
            return query.ToList();
        }
        /// <summary>
        /// 删除角色下关联的权限
        /// </summary>
        /// <param name="RoleID"></param>
        public void DeleteAuthorityRole(int RoleID)
        {
            var query = this._roleRepository.Entities;
            query = query.Where(x => x.RoleID == RoleID);
            if (query.ToList() != null && query.Count() > 0)
            {
                this._roleRepository.Delete(query);
            }
        }
        #endregion

        #region 权限-菜单关联方法
        /// <summary>
        /// 添加权限菜单关联
        /// </summary>
        /// <param name="AuthorityIDs"></param>
        /// <param name="MenuID"></param>
        /// <returns></returns>
        public void AddAuthorityMenu(string[] AuthorityIDs, int MenuID)
        {
            var query = this._menuRepository.Entities;
            query = query.Where(x => x.MenuID == MenuID);
            if (query.ToList() != null && query.Count() > 0)
            {
                this._menuRepository.Delete(query);
            }
            foreach (var item in AuthorityIDs)
            {
                Authority_Menu info = new Authority_Menu();
                info.AuthorityID = Convert.ToInt32(item);
                info.MenuID = MenuID;
                this._menuRepository.Insert(info);
            }
        }

        /// <summary>
        /// 根据菜单ID查询该菜单的权限
        /// </summary>
        /// <param name="MenuID"></param>
        /// <returns></returns>
        public List<Authority_Menu> GetAuthority_MenuListByMenuID(int MenuID)
        {
            var query = this._menuRepository.Entities;
            query = query.Where(x => x.MenuID == MenuID);
            return query.ToList();
        }

        /// <summary>
        /// 删除菜单下关联的权限
        /// </summary>
        /// <param name="MenuID"></param>
        public void DeleteAuthorityMenu(int MenuID)
        {
            var query = this._menuRepository.Entities;
            query = query.Where(x => x.MenuID == MenuID);
            if (query.ToList() != null && query.Count() > 0)
            {
                this._menuRepository.Delete(query);
            }
        }
        #endregion
    }
}
