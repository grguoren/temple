using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Temple.IService;

namespace Temple.Admin.Controllers
{
    /// <summary>
    /// 帮助中心
    /// </summary>
    public class AngelManageController : BaseController
    {
        readonly IUserInfoService userse;
        public AngelManageController(IUserInfoService _userse)
            : base(_userse)
        {
            userse = _userse;
        }

        public ActionResult List(int? id)
        {
            ViewBag.aboutTypeId = id.HasValue ? id.Value : 0;
            return View();
        }
        public ActionResult TypeList()
        {
            return View();
        }
        public ActionResult Add(int? id)
        {
            ViewBag.PageTitle = id.HasValue ? "修改常见问题" : "添加常见问题";
            ViewBag.aboutId = id.HasValue ? id.Value : 0;
            return View();
        }
        public ActionResult TypeAdd(int? id)
        {
            ViewBag.PageTitle = id.HasValue ? "修改帮助中心分类" : "添加帮助中心分类";
            ViewBag.aboutTypeId = id.HasValue ? id.Value : 0;
            return View();
        }


    }
}
