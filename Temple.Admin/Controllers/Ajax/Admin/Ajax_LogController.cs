using Temple.Admin.Models;
using Temple.Domain;
using Temple.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Temple.Admin.Controllers.Ajax.Admin
{
    public class Ajax_LogController : BaseController
    {
        readonly ILoggerService loggerse;
        readonly IUserInfoService userse;
        // GET: /Ajax_Log/
        public Ajax_LogController(IUserInfoService _userse, ILoggerService _loggerse)
            : base(_userse)
        {
            userse = _userse;
            loggerse = _loggerse;
        }
        [HttpPost]
        public JsonResult GetLogList(int page, int size, string title, string desp)
        {
            int count = 0;
            List<Logger> list = loggerse.GetLogList(page, size, out count, title, desp);
            ResultModel model = new ResultModel();
            model.Count = count;
            model.Data = list.ToList<object>();
            model.Status = (list != null && list.Count > 0);
            return Json(model);
        }


    }
}
