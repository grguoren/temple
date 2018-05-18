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
    public class Ajax_TitleController : BaseController
    {
        readonly IUserInfoService userse;
        readonly IBasicService basicse;

        public Ajax_TitleController(IUserInfoService _userse, IBasicService _basicse)
            : base(_userse)
        {
            this.userse = _userse;
            this.basicse = _basicse;
        }

        [HttpPost]
        public JsonResult GetTitleList(int page, int size)
        {
            IPagedList<Title> list = basicse.GetTitleList(page, size);
            
            ResultModel model = new ResultModel();
            model.Count = list.TotalCount;
            model.Data = list.ToList<object>();
            model.Status = (list != null && list.Count > 0);
            return Json(model);
        }

        /// <summary>
        /// 添加稱謂
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "稱謂-添加数据")]
        public string AddTitle(string name, string remark, string code, int status = 1)
        {
            bool res = false;
            Title model = new Title();
            model.Name = name;
            model.Remark = Server.HtmlEncode(remark);
            model.Code = code;
            model.Status = status==1?true:false;

            res = basicse.AddTitle(model);
            return res.ToString();
        }
        /// <summary>
        /// 更新稱謂
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "稱謂-更新数据")]
        public string UpdateTitle(string name, int status, string remark, string code, int id)
        {
            bool res = false;
            Title model = new Title();
            model = basicse.GetTitleByID(id);
            model.Code = code;
            model.Name = name;
            model.Remark = Server.HtmlEncode(remark);
            model.Status = status == 1 ? true : false;

            res = basicse.UpdateTitle(model);
            return res.ToString();
        }
        [HttpPost]
        public JsonResult GetTitleById(int id)
        {
            Title model = basicse.GetTitleByID(id);
            model.Remark = Server.HtmlDecode(model.Remark);
            
            return Json(model);
        }

        [HttpPost]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "稱謂-删除数据")]
        public string DeleteTitle(int id)
        {
            return basicse.DeleteTitle(id).ToString();
        }
    }
}
