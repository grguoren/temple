using Temple.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.IService
{
    public partial interface IRoleInfoService
    {
        /// <summary>
        /// 获取所有角色列表
        /// </summary>
        /// <returns></returns>
        List<Role> GetAllRoleList();

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool AddRole(Role info);

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteRole(int id);

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool UpdateRole(Role info);

        /// <summary>
        /// 根据ID获取角色信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Role GetRoleInfoByID(int ID);

        /// <summary>
        /// 添加角色用户关联
        /// </summary>
        /// <param name="RoleIDs"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        void AddRoleUser(string[] RoleIDs, int UserID);

        /// <summary>
        /// 根据用户ID查询该用户的角色
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        List<Role_User> GetRole_UserListByUserID(int UserID);

        /// <summary>
        /// 删除用户下关联的角色
        /// </summary>
        /// <param name="UserID"></param>
        void DeleteRoleUser(int UserID);

    }
}
