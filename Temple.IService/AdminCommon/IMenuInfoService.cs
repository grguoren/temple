using Temple.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.IService
{
    public partial interface IMenuInfoService
    {
        /// <summary>
        /// 根据上一级ID获取所有菜单列表(0为顶级菜单) 
        /// </summary>
        /// <param name="PID"></param>
        /// <returns></returns>
        List<SystemPro> GetAllMenuListByPID(int PID);
        List<WuxiSystem> GetTopMenuList();
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool AddMenu(SystemPro info);

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteMenu(int id);

        /// <summary>
        /// 更新菜单
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool UpdateMenu(SystemPro info);

        /// <summary>
        /// 根据ID获取菜单信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        SystemPro GetMenuInfoByID(int ID);

        /// <summary>
        /// 根据用户ID获取该用户有权限访问的菜单
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        List<SystemPro> GetUserMenu(int UserID);
    }
}
