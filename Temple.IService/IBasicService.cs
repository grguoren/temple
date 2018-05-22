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
    /// 基本資料維護作業
    /// </summary>
    public partial interface IBasicService
    {
        #region 付款方式作業
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        IPagedList<Payment_item> GetPaymentList(int page, int size);

        /// <summary>
        /// 添加新付款方式
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool AddPayment(Payment_item info);

        /// <summary>
        /// 删除付款方式
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool DeletePayment(int id);

        /// <summary>
        /// 更新付款方式
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool UpdatePayment(Payment_item info);

        /// <summary>
        /// 根据ID获取付款方式
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Payment_item GetPaymentByID(int id);
        #endregion

        #region 稱謂方式作業
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        IPagedList<Title> GetTitleList(int page, int size);

        /// <summary>
        /// 添加新稱謂
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool AddTitle(Title info);

        /// <summary>
        /// 删除稱謂
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool DeleteTitle(int id);

        /// <summary>
        /// 更新稱謂
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool UpdateTitle(Title info);

        /// <summary>
        /// 根据ID获取稱謂
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Title GetTitleByID(int id);
        #endregion 
        
        #region 入帳單位作業
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        IPagedList<Accounting_unit> GetAccountList(int page, int size);

        /// <summary>
        /// 添加新入帳單位
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool AddAccount(Accounting_unit info);

        /// <summary>
        /// 删除入帳單位
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool DeleteAccount(int id);

        /// <summary>
        /// 更新入帳單位
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool UpdateAccount(Accounting_unit info);

        /// <summary>
        /// 根据ID获取入帳單位
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Accounting_unit GetAccountByID(int id);
        #endregion

        #region 服務項目作業
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        IPagedList<Service_name> GetServiceList(int page, int size);

        /// <summary>
        /// 添加新服務項目
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool AddService(Service_name info);

        /// <summary>
        /// 删除服務項目
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool DeleteService(int id);

        /// <summary>
        /// 更新服務項目
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool UpdateService(Service_name info);

        /// <summary>
        /// 根据ID获取服務項目
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Service_name GetServiceByID(int id);
        #endregion

        #region 功德項目作業
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        IPagedList<Good_project> GetGoodList(int page, int size);

        /// <summary>
        /// 添加新功德項目
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool AddGood(Good_project info);

        /// <summary>
        /// 删除功德項目
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool DeleteGood(int id);

        /// <summary>
        /// 更新功德項目
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool UpdateGood(Good_project info);

        /// <summary>
        /// 根据ID获取功德項目
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Good_project GetGoodByID(int id);
        #endregion

        #region 祭拜圖片作業
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        IPagedList<Worship_pictures> GetPictureList(int page, int size);

        /// <summary>
        /// 添加新祭拜圖片
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool AddPicture(Worship_pictures info);

        /// <summary>
        /// 删除祭拜圖片
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool DeletePicture(int id);

        /// <summary>
        /// 更新祭拜圖片
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool UpdatePicture(Worship_pictures info);

        /// <summary>
        /// 根据ID获取祭拜圖片
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Worship_pictures GetPictureByID(int id);
        #endregion 
        
        #region 功德服務項目作業
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        IPagedList<Good_project_service> GetGoodServiceList(int page, int size);

        /// <summary>
        /// 添加新功德服務項目
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool AddGoodService(Good_project_service info);

        /// <summary>
        /// 删除功德服務項目
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool DeleteGoodService(int id);

        /// <summary>
        /// 更新功德服務項目
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool UpdateGoodService(Good_project_service info);

        /// <summary>
        /// 根据ID获取功德服務項目
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Good_project_service GetGoodServiceByID(int id);
        #endregion


    }
}
