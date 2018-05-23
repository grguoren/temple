using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Temple.Core.Tools;
using Temple.Domain;
using Temple.IService;

namespace Temple.Admin.Controllers
{
    public class MakeManageController : BaseController
    {
         // GET: /Article/
        readonly IUserInfoService userse;
        public MakeManageController(IUserInfoService _userse)
            : base(_userse)
        {
            userse = _userse;

        }

        /// <summary>
        /// 彎友叩問
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            ViewBag.ReplyName = currentMember.UserName;
            return View();
        }

        public ActionResult Add(int? id)
        {
            ViewBag.PageTitle = id.HasValue ? "編輯彎友叩問基本資料" : "新增彎友叩問基本資料";
            ViewBag.NewDataId = id.HasValue ? id.Value : 0;
            return View();
        }
    }
}
