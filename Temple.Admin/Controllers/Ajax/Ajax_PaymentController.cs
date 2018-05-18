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
    public class Ajax_PaymentController : BaseController
    {
        readonly IUserInfoService userse;
        readonly IBasicService basicse;

        public Ajax_PaymentController(IUserInfoService _userse, IBasicService _basicse)
            : base(_userse)
        {
            this.userse = _userse;
            this.basicse = _basicse;
        }

        [HttpPost]
        public JsonResult GetPaymentList(int page, int size)
        {
            IPagedList<Payment_item> list = basicse.GetPaymentList(page, size);
            
            ResultModel model = new ResultModel();
            model.Count = list.TotalCount;
            model.Data = list.ToList<object>();
            model.Status = (list != null && list.Count > 0);
            return Json(model);
        }

        /// <summary>
        /// 添加付款方式
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "付款方式-添加数据")]
        public string AddPayment(string name, string remark, string code, int status = 1)
        {
            bool res = false;
            Payment_item model = new Payment_item();
            model.Name = name;
            model.Remark = Server.HtmlEncode(remark);
            model.Code = code;
            model.Status = status==1?true:false;

            res = basicse.AddPayment(model);
            return res.ToString();
        }
        /// <summary>
        /// 更新付款方式
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "付款方式-更新数据")]
        public string UpdatePayment(string name, int status, string remark, string code, int id)
        {
            bool res = false;
            Payment_item model = new Payment_item();
            model = basicse.GetPaymentByID(id);
            model.Code = code;
            model.Name = name;
            model.Remark = Server.HtmlEncode(remark);
            model.Status = status == 1 ? true : false;

            res = basicse.UpdatePayment(model);
            return res.ToString();
        }
        [HttpPost]
        public JsonResult GetPaymentById(int id)
        {
            Payment_item model = basicse.GetPaymentByID(id);
            model.Remark = Server.HtmlDecode(model.Remark);
            
            return Json(model);
        }

        [HttpPost]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "付款方式-删除数据")]
        public string DeletePayment(int id)
        {
            return basicse.DeletePayment(id).ToString();
        }

    }
}
