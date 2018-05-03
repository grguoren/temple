using Temple.Domain;
using Temple.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Temple.Admin.Controllers
{
    public class SystemManageController : BaseController
    {
        readonly IUserInfoService userse;
        public SystemManageController(IUserInfoService _userse)
            : base(_userse)
        {
            userse = _userse;
        }
        //
        // GET: /SystemManage/
        public ActionResult UserIndex()
        {
            ViewBag.ReplyName = currentMember.UserName;
            return View();
        }

        public ActionResult SalesIndex()
        {
            ViewBag.ReplyName = currentMember.UserName;
            return View();
        }

        public ActionResult MenuIndex()
        {
            return View();
        }

        public ActionResult AuthorityIndex()
        {
            ViewBag.ReplyName = currentMember.UserName;
            return View();
        }

        public ActionResult RoleIndex()
        {
            return View();
        }

        public ActionResult LogList()
        {
            return View();
        }

        public ActionResult UserQuota()
        {
            return View();
        }

        public ActionResult LoginList()
        {
            return View();
        }
    }
}
