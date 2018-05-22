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
    /// 聖示護法 與 叩問
    /// </summary>
    public partial  interface IAngelService
    {
        #region 聖示護法作業
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        IPagedList<Angel> GetAngelList(int page, int size);

        /// <summary>
        /// 添加新聖示護法
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool AddAngel(Angel info);

        /// <summary>
        /// 删除聖示護法
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool DeleteAngel(int id);

        /// <summary>
        /// 更新聖示護法
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool UpdateAngel(Angel info);

        /// <summary>
        /// 根据ID获取聖示護法
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Angel GetAngelByID(int id);
        #endregion

        #region 叩問作業
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        IPagedList<Make_inquiries> GetInquiriesList(int page, int size);

        /// <summary>
        /// 添加新叩問
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool AddInquiries(Make_inquiries info);

        /// <summary>
        /// 删除叩問
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool DeleteInquiries(int id);

        /// <summary>
        /// 更新叩問
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool UpdateInquiries(Make_inquiries info);

        /// <summary>
        /// 根据ID获取叩問
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Make_inquiries GetInquiriesByID(int id);
        #endregion

    }
}
