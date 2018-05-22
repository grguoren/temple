using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temple.Core.Pager;
using Temple.Domain;

namespace Temple.IService
{
    /// <summary>
    /// 時辰與彎友功德服務
    /// </summary>
    public partial interface IOtherService
    {

        #region 鸞友功德服務作業
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        IPagedList<Member_Good_project> GetMemGoodServiceList(int page, int size);

        /// <summary>
        /// 添加新鸞友功德服務
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool AddMemGoodService(Member_Good_project info);

        /// <summary>
        /// 删除鸞友功德服務
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool DeleteMemGoodService(int id);

        /// <summary>
        /// 更新鸞友功德服務
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool UpdateMemGoodService(Member_Good_project info);

        /// <summary>
        /// 根据ID获取鸞友功德服務
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Member_Good_project GetMemGoodServiceByID(int id);
        #endregion

        #region 中國時辰作業
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        IPagedList<China_time> GetChinaTimeList(int page, int size);

        /// <summary>
        /// 添加新中國時辰
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool AddChinaTime(China_time info);

        /// <summary>
        /// 删除中國時辰
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool DeleteChinaTime(int id);

        /// <summary>
        /// 更新中國時辰
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool UpdateChinaTime(China_time info);

        /// <summary>
        /// 根据ID获取中國時辰
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        China_time GetChinaTimeByID(int id);
        #endregion


    }
}
