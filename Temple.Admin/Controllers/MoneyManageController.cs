using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Temple.IService;

namespace Temple.Admin.Controllers
{
    /// <summary>
    /// 财务管理
    /// </summary>
    public class MoneyManageController : BaseController
    {
        readonly IUserInfoService userse;
        public MoneyManageController(IUserInfoService _userse)
            : base(_userse)
        {
            userse = _userse;
        }

        public ActionResult Index()
        {
            ViewBag.ReplyName = currentMember.UserName;
            return View();
        }

        public ActionResult Consume()
        {
            ViewBag.ReplyName = currentMember.UserName;
            return View();
        }

    }
}
