using Temple.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.IService
{
    public partial interface IAuthorityInfoService
    {
        /// <summary>
        /// 获取所有权限列表
        /// </summary>
        /// <returns></returns>
        List<AuthorityInfo> GetAllAuthorityList();

        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool AddAuthority(AuthorityInfo info);

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteAuthority(int id);

        /// <summary>
        /// 更新权限
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool UpdateAuthority(AuthorityInfo info);

        /// <summary>
        /// 根据ID获取权限信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        AuthorityInfo GetAuthorityInfoByID(int ID);

        /// <summary>
        /// 添加权限菜单关联
        /// </summary>
        /// <param name="AuthorityID"></param>
        /// <param name="MenuID"></param>
        /// <returns></returns>
        void AddAuthorityMenu(string[] AuthorityIDs, int MenuID);

        /// <summary>
        /// 根据菜单ID查询该菜单的权限
        /// </summary>
        /// <param name="MenuID"></param>
        /// <returns></returns>
        List<Authority_Menu> GetAuthority_MenuListByMenuID(int MenuID);

        /// <summary>
        /// 删除菜单下关联的权限
        /// </summary>
        /// <param name="MenuID"></param>
        void DeleteAuthorityMenu(int MenuID);

        /// <summary>
        /// 添加权限角色关联
        /// </summary>
        /// <param name="AuthorityID"></param>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        void AddAuthorityRole(string[] AuthorityIDs, int RoleID);

        /// <summary>
        /// 根据角色ID查询该角色的权限
        /// </summary>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        List<Authority_Role> GetAuthority_RoleListByRoleID(int RoleID);

        /// <summary>
        /// 删除角色下关联的权限
        /// </summary>
        /// <param name="RoleID"></param>
        void DeleteAuthorityRole(int RoleID);
    }
}
