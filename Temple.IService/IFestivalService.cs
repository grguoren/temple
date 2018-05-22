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
    /// 法會
    /// </summary>
    public partial interface IFestivalService
    {
        #region 法會作業
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        IPagedList<Festival> GetFestivalList(int page, int size);

        /// <summary>
        /// 添加新法會
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool AddFestival(Festival info);

        /// <summary>
        /// 删除法會
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool DeleteFestival(int id);

        /// <summary>
        /// 更新法會
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool UpdateFestival(Festival info);

        /// <summary>
        /// 根据ID获取法會
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Festival GetFestivalByID(int id);
        #endregion

        #region 法會服務項目
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        IPagedList<Festival_service> GetFestivalServiceList(int page, int size);

        /// <summary>
        /// 添加新法會服務項目
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool AddFestivalService(Festival_service info);

        /// <summary>
        /// 删除法會服務項目
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool DeleteFestivalService(int id);

        /// <summary>
        /// 更新法會服務項目
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool UpdateFestivalService(Festival_service info);

        /// <summary>
        /// 根据ID获取法會服務項目
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Festival_service GetFestivalServiceByID(int id);
        #endregion



    }
}
