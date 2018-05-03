using Temple.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Temple.Admin.Controllers
{
    public class FeedbackManageController : BaseController
    {
        readonly IUserInfoService userse;
        public FeedbackManageController(IUserInfoService _userse)
            : base(_userse)
        {
            userse = _userse;
        }

        //
        // GET: /FeedbackManage/

        public ActionResult List()
        {
            return View();
        }
    }
}
