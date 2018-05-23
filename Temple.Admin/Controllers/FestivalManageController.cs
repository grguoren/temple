using Temple.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Temple.Admin.Controllers
{
    public class FestivalManageController : BaseController
    {
        readonly IUserInfoService userse;
        public FestivalManageController(IUserInfoService _userse)
            : base(_userse)
        {
            userse = _userse;
        }

        //
        // GET: /法會/
        public ActionResult List()
        {
            return View();
        }

        public ActionResult Add(int? id)
        {
            ViewBag.PageTitle = id.HasValue ? "編輯法會基本資料" : "新增法會基本資料";
            ViewBag.NewDataId = id.HasValue ? id.Value : 0;
            return View();
        }
    }
}
