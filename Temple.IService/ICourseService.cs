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
    /// 證道仙佛歷程
    /// </summary>
    public partial interface ICourseService
    {
        #region 證道仙佛歷程作業
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        IPagedList<Education_course> GetCourseList(int page, int size);

        /// <summary>
        /// 添加新證道仙佛歷程
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool AddCourse(Education_course info);

        /// <summary>
        /// 删除證道仙佛歷程
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool DeleteCourse(int id);

        /// <summary>
        /// 更新證道仙佛歷程
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool UpdateCourse(Education_course info);

        /// <summary>
        /// 根据ID获取證道仙佛歷程
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Education_course GetCourseByID(int id);
        #endregion

    }
}
