using Temple.Domain;
using Temple.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Temple.Admin.Controllers
{
    /// <summary>
    /// 系统管理作业
    /// </summary>
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

        public ActionResult UserAdd(int? id)
        {
            ViewBag.PageTitle = id.HasValue ? "編輯使用者基本資料" : "新增使用者基本資料";
            ViewBag.NewDataId = id.HasValue ? id.Value : 0;
            return View();
        }

        public ActionResult MenuIndex()
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
