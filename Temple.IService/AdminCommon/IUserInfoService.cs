using Temple.Core.Pager;
using Temple.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.IService
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public partial interface IUserInfoService
    {
        /// <summary>
        /// 获取用户列表(分页)
        /// </summary>
        /// <returns></returns>
        IPagedList<User> GetUserList(int page, int size, string username, string nickname);

      //  List<UserFocusWx> GetFocusUserList(int page, int size, string title, out int total);
        /// <summary>
        /// 添加新用户
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool AddUser(User info);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool DeleteUser(int id);

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool UpdateUser(User info);

        /// <summary>
        /// 根据ID获取用户信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        User GetUserInfoByID(int ID);
        User GetUserInfoByName(string name);
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        User LoginUser(User info);

        /// <summary>
        /// 根据用户ID获取用户权限
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        List<int> GetUserAuthorityList(int UserID);

        /// <summary>
        /// 获取用户菜单
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        List<SystemPro> GetUserMenu(int UserID);
        List<SystemPro> GetAllChildMenu();

        bool DeleteUserRole(int id);

        List<RolePermission> GetAuthority_RoleListByRoleID(int RoleID);

        void AddAuthorityRole(string[] AuthorityIDs, int RoleID);

        List<SystemPro> GetAllProgramList(int pid);

    }
}
