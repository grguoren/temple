using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Temple.IService;

namespace Temple.Admin.Controllers
{
    /// <summary>
    /// 基本管理作業
    /// </summary>
    public class BasicManageController : BaseController
    {
        readonly IUserInfoService userse;
        public BasicManageController(IUserInfoService _userse)
            : base(_userse)
        {
            userse = _userse;
        }

        /// <summary>
        /// 付款方式 
        /// </summary>
        /// <returns></returns>
        public ActionResult Payment()
        {
            return View();
        }

        /// <summary>
        /// 付款方式新增資料
        /// </summary>
        /// <returns></returns>
        public ActionResult Add(int? id)
        {
            ViewBag.PageTitle = id.HasValue ? "修改付款方式" : "添加付款方式";
            ViewBag.NewDataId = id.HasValue ? id.Value : 0;
            return View();
        }

        /// <summary>
        /// 稱謂
        /// </summary>
        /// <returns></returns>
        public ActionResult Title()
        {
            return View();
        }

        /// <summary>
        /// 稱謂新增資料
        /// </summary>
        /// <returns></returns>
        public ActionResult AddTitle(int? id)
        {
            ViewBag.PageTitle = id.HasValue ? "修改稱謂" : "添加稱謂";
            ViewBag.NewDataId = id.HasValue ? id.Value : 0;
            return View();
        }

    }
}
