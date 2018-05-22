using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Temple.IService;

namespace Temple.Admin.Controllers
{
    /// <summary>
    /// 彎友
    /// </summary>
    public class MemberManageController : BaseController
    {
        readonly IUserInfoService userse;
        public MemberManageController(IUserInfoService _userse)
            : base(_userse)
        {
            userse = _userse;
        }
        //彎友
        public ActionResult Index()
        {
            ViewBag.ReplyName = currentMember.UserName;
            return View();
        }

        public ActionResult Add()
        {
            ViewBag.ReplyName = currentMember.UserName;
            return View();
        }

        //被保舉人
        public ActionResult PractitionerList()
        {
            ViewBag.ReplyName = currentMember.UserName;
            return View();
        }

        public ActionResult PractitionerAdd()
        {
            ViewBag.ReplyName = currentMember.UserName;
            return View();
        }

    }
}
