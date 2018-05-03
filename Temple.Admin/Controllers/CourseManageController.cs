using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Temple.IService;

namespace Temple.Admin.Controllers
{
    /// <summary>
    /// 课程管理
    /// </summary>
    public class CourseManageController : BaseController
    {
        readonly IUserInfoService userse;
        public CourseManageController(IUserInfoService _userse)
            : base(_userse)
        {
            userse = _userse;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdviceList()
        {
            return View();
        }

        public ActionResult TopicList()
        {
            return View();
        }

        public ActionResult CourseAdd(int? id)
        {
            ViewBag.PageTitle = id.HasValue ? "修改课程" : "添加课程";
            ViewBag.CourseId = id.HasValue ? id.Value : 0;
            return View();
        }

        public ActionResult WareAdd(int? id,int? cid=0)
        {
            ViewBag.PageTitle = id.HasValue ? "修改课节" : "添加课节";
            ViewBag.WareId = id.HasValue ? id.Value : 0;
            ViewBag.CourseId = cid.Value;
            return View();
        }

    }
}
