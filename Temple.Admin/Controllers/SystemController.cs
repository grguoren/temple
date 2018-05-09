using Temple.Domain;
using Temple.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Temple.Admin.Controllers
{
    public class SystemController : BaseController
    {
        readonly IUserInfoService userse;
        public SystemController(IUserInfoService _userse)
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


        public ActionResult Menu()
        {
            return View();
        }

        public ActionResult Index()
        {
            ViewBag.ReplyName = currentMember.UserName;
            return View();
        }

        public ActionResult Role()
        {
            return View();
        }

        public ActionResult LogList()
        {
            return View();
        }

        public ActionResult LoginList()
        {
            return View();
        }
    }
}
