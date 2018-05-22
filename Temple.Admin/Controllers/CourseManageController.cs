using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Temple.IService;

namespace Temple.Admin.Controllers
{
    /// <summary>
    /// 歷程管理
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

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Add(int? id)
        {
            ViewBag.PageTitle = id.HasValue ? "修改歷程" : "添加歷程";
            ViewBag.CourseId = id.HasValue ? id.Value : 0;
            return View();
        }

       

    }
}
