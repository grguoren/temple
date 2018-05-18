using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Temple.Admin.Models;
using Temple.Core.Pager;
using Temple.Domain;
using Temple.IService;

namespace Temple.Admin.Controllers.Ajax
{
    public class Ajax_AccountController : BaseController
    {
       readonly IUserInfoService userse;
        readonly IBasicService basicse;

        public Ajax_AccountController(IUserInfoService _userse, IBasicService _basicse)
            : base(_userse)
        {
            this.userse = _userse;
            this.basicse = _basicse;
        }

        #region 入帳單位
        [HttpPost]
        public JsonResult GetAccountList(int page, int size)
        {
            IPagedList<Accounting_unit> list = basicse.GetAccountList(page, size);
            
            ResultModel model = new ResultModel();
            model.Count = list.TotalCount;
            model.Data = list.ToList<object>();
            model.Status = (list != null && list.Count > 0);
            return Json(model);
        }

        /// <summary>
        /// 添加入帳單位
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "入帳單位-添加数据")]
        public string AddAccount(string name, string remark, string code, int status = 1)
        {
            bool res = false;
            Accounting_unit model = new Accounting_unit();
            model.Name = name;
            model.Remark = Server.HtmlEncode(remark);
            model.Code = code;
            model.Status = status==1?true:false;

            res = basicse.AddAccount(model);
            return res.ToString();
        }
        /// <summary>
        /// 更新入帳單位
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "入帳單位-更新数据")]
        public string UpdateAccount(string name, int status, string remark, string code, int id)
        {
            bool res = false;
            Accounting_unit model = new Accounting_unit();
            model = basicse.GetAccountByID(id);
            model.Code = code;
            model.Name = name;
            model.Remark = Server.HtmlEncode(remark);
            model.Status = status == 1 ? true : false;

            res = basicse.UpdateAccount(model);
            return res.ToString();
        }
        [HttpPost]
        public JsonResult GetAccountById(int id)
        {
            Accounting_unit model = basicse.GetAccountByID(id);
            model.Remark = Server.HtmlDecode(model.Remark);
            
            return Json(model);
        }

        [HttpPost]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "入帳單位-删除数据")]
        public string DeleteAccount(int id)
        {
            return basicse.DeleteAccount(id).ToString();
        }
        #endregion

        #region 服務項目
        [HttpPost]
        public JsonResult GetServiceList(int page, int size)
        {
            IPagedList<Service_name> list = basicse.GetServiceList(page, size);

            ResultModel model = new ResultModel();
            model.Count = list.TotalCount;
            model.Data = list.ToList<object>();
            model.Status = (list != null && list.Count > 0);
            return Json(model);
        }

        /// <summary>
        /// 添加服務項目
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "服務項目-添加数据")]
        public string AddService(string name, string remark, string code,int unitid,string type, int status = 1)
        {
            bool res = false;
            Service_name model = new Service_name();
            model.Name = name;
            model.Remark = Server.HtmlEncode(remark);
            model.Code = code;
            model.Status = status == 1 ? true : false;
            model.Type = type;
            model.Accounting_unit_id = unitid;
            res = basicse.AddService(model);
            return res.ToString();
        }
        /// <summary>
        /// 更新服務項目
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "服務項目-更新数据")]
        public string UpdateService(string name, int status, string remark, string code, int id, int unitid, string type)
        {
            bool res = false;
            Service_name model = new Service_name();
            model = basicse.GetServiceByID(id);
            model.Code = code;
            model.Name = name;
            model.Remark = Server.HtmlEncode(remark);
            model.Status = status == 1 ? true : false;
            model.Type = type;
            model.Accounting_unit_id = unitid;

            res = basicse.UpdateService(model);
            return res.ToString();
        }
        [HttpPost]
        public JsonResult GetServiceById(int id)
        {
            Service_name model = basicse.GetServiceByID(id);
            model.Remark = Server.HtmlDecode(model.Remark);

            return Json(model);
        }

        [HttpPost]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "服務項目-删除数据")]
        public string DeleteService(int id)
        {
            return basicse.DeleteService(id).ToString();
        }
        #endregion

        #region 功德項目
        [HttpPost]
        public JsonResult GetGoodList(int page, int size)
        {
            IPagedList<Good_project> list = basicse.GetGoodList(page, size);

            ResultModel model = new ResultModel();
            model.Count = list.TotalCount;
            model.Data = list.ToList<object>();
            model.Status = (list != null && list.Count > 0);
            return Json(model);
        }

        /// <summary>
        /// 添加功德項目
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "功德項目-添加数据")]
        public string AddGood(string name, string remark, string code,string type, int status = 1)
        {
            bool res = false;
            Good_project model = new Good_project();
            model.Name = name;
            model.Remark = Server.HtmlEncode(remark);
            model.Code = code;
            model.Status = status == 1 ? true : false;
            model.Type = type;
            res = basicse.AddGood(model);
            return res.ToString();
        }
        /// <summary>
        /// 更新功德項目
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "功德項目-更新数据")]
        public string UpdateGood(string name, int status, string remark, string code,string type, int id)
        {
            bool res = false;
            Good_project model = new Good_project();
            model = basicse.GetGoodByID(id);
            model.Code = code;
            model.Name = name;
            model.Remark = Server.HtmlEncode(remark);
            model.Type = type;
            model.Status = status == 1 ? true : false;

            res = basicse.UpdateGood(model);
            return res.ToString();
        }
        [HttpPost]
        public JsonResult GetGoodById(int id)
        {
            Good_project model = basicse.GetGoodByID(id);
            model.Remark = Server.HtmlDecode(model.Remark);

            return Json(model);
        }

        [HttpPost]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "功德項目-删除数据")]
        public string DeleteGood(int id)
        {
            return basicse.DeleteGood(id).ToString();
        }
        #endregion
    }
}
