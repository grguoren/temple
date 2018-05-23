using Temple.Admin.Common;
using Temple.Admin.Models;
using Temple.Core.Pager;
using Temple.Domain;
using Temple.IService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Temple.Admin.Controllers.Ajax
{
    public class Ajax_MakeController : BaseController
    {
        readonly IUserInfoService userse;
        readonly IAngelService makese;

        public Ajax_MakeController(IUserInfoService _userse, IAngelService _makese)
            : base(_userse)
        {
            this.userse = _userse;
            this.makese = _makese;
        }


        #region 彎友叩問
        [HttpPost]
        public JsonResult GetMakeList(int page, int size)
        {
            IPagedList<Make_inquiries> list = makese.GetInquiriesList(page, size);

            ResultModel model = new ResultModel();
            model.Count = list.TotalCount;
            model.Data = list.ToList<object>();
            model.Status = (list != null && list.Count > 0);
            return Json(model);
        }

        /// <summary>
        /// 添加彎友叩問
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "彎友叩問-添加数据")]
        public string AddMake(string jsonModel)
        {
            bool res = false;
            Make_inquiries model = new Make_inquiries();
            model = Newtonsoft.Json.JsonConvert.DeserializeObject<Make_inquiries>(jsonModel);
            if (model.Ask_Date != null)
            {
                model.Ask_Date = StringHelper.TwDateToWestDate(model.Ask_Date.ToString());
            }
            if (model.Confirmation_date != null)
            {
                model.Confirmation_date = StringHelper.TwDateToWestDate(model.Confirmation_date.ToString());
            }

            res = makese.AddInquiries(model);
            return res.ToString();
        }


        /// <summary>
        /// 更新彎友叩問
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "彎友叩問-更新数据")]
        public string UpdateMake(string jsonModel)
        {
            bool res = false;
            Make_inquiries model = new Make_inquiries();
            model = Newtonsoft.Json.JsonConvert.DeserializeObject<Make_inquiries>(jsonModel);
            Make_inquiries info = makese.GetInquiriesByID(model.Id);

            info.Ask_Info = model.Ask_Info;
            info.Instructions = model.Instructions;
            info.Publish_YN = model.Publish_YN;
            info.Remark = model.Remark;
            if (model.Confirmation_date != null)
            {
                info.Confirmation_date = StringHelper.TwDateToWestDate(model.Confirmation_date.ToString());
            }
            info.Reply_YN = model.Reply_YN;
            res = makese.UpdateInquiries(info);
            return res.ToString();
        }
        [HttpPost]
        public JsonResult GetMakeById(int id)
        {
            Make_inquiries model = makese.GetInquiriesByID(id);
            model.Remark = Server.HtmlDecode(model.Remark);

            return Json(model);
        }

        [HttpPost]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "彎友叩問-删除数据")]
        public string DeleteMake(int id)
        {
            return makese.DeleteInquiries(id).ToString();
        }
        #endregion


    }
}
