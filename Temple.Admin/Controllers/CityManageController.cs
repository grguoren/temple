using Temple.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Temple.Admin.Controllers
{
    /// <summary>
    /// 省份城市管理 
    /// </summary>
    public class CityManageController : BaseController
    {
        readonly IUserInfoService userse;
        public CityManageController(IUserInfoService _userse)
            : base(_userse)
        {
            userse = _userse;
        }

        public ActionResult List(int? pid)
        {
            ViewBag.Pid = 0;
            if (pid.HasValue && pid.Value > 0)
            {
                ViewBag.Pid = pid.Value;
            }
            return View();
        }

    }
}
