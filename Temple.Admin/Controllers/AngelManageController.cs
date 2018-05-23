using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Temple.IService;

namespace Temple.Admin.Controllers
{
    /// <summary>
    /// 聖示護法
    /// </summary>
    public class AngelManageController : BaseController
    {
        readonly IUserInfoService userse;
        public AngelManageController(IUserInfoService _userse)
            : base(_userse)
        {
            userse = _userse;
        }

        public ActionResult List()
        {
            return View();
        }
        public ActionResult TypeList()
        {
            return View();
        }
        public ActionResult Add(int? id)
        {
            ViewBag.PageTitle = id.HasValue ? "修改聖示護法" : "添加聖示護法";
            ViewBag.NewDataId = id.HasValue ? id.Value : 0;
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
