using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Temple.IService;

namespace Temple.Admin.Controllers
{
    public class AccountManageController : BaseController
    {
        readonly IUserInfoService userse;
        public AccountManageController(IUserInfoService _userse)
            : base(_userse)
        {
            userse = _userse;
        }

        /// <summary>
        /// 入帳單位 
        /// </summary>
        /// <returns></returns>
        public ActionResult AccountList()
        {
            return View();
        }

        /// <summary>
        /// 入帳單位新增資料
        /// </summary>
        /// <returns></returns>
        public ActionResult AccountAdd(int? id)
        {
            ViewBag.PageTitle = id.HasValue ? "修改入帳單位" : "添加入帳單位";
            ViewBag.NewDataId = id.HasValue ? id.Value : 0;
            return View();
        }
        
        /// <summary>
        /// 服務項目 
        /// </summary>
        /// <returns></returns>
        public ActionResult ServiceList()
        {
            return View();
        }

        /// <summary>
        /// 服務項目新增資料
        /// </summary>
        /// <returns></returns>
        public ActionResult ServiceAdd(int? id)
        {
            ViewBag.PageTitle = id.HasValue ? "修改服務項目" : "添加服務項目";
            ViewBag.NewDataId = id.HasValue ? id.Value : 0;
            return View();
        }

        


    }
}
