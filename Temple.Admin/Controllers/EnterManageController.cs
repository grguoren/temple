using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Temple.IService;

namespace Temple.Admin.Controllers
{
    /// <summary>
    /// 入驻管理
    /// </summary>
    public class EnterManageController : BaseController
    {
        readonly IUserInfoService userse;
        public EnterManageController(IUserInfoService _userse)
            : base(_userse)
        {
            userse = _userse;
        }
        public ActionResult Index()
        {
            ViewBag.ReplyName = currentMember.UserName;
            return View();
        }

        public ActionResult CompanyList()
        {
            ViewBag.ReplyName = currentMember.UserName;
            return View();
        }

        /// <summary>
        /// 机构与平台讲师
        /// </summary>
        /// <returns></returns>
        public ActionResult CTeacherList()
        {
            ViewBag.ReplyName = currentMember.UserName;
            return View();
        }

        public ActionResult TeacherAdd(int? id)
        {
            ViewBag.PageTitle = id.HasValue ? "修改讲师" : "添加讲师";
            ViewBag.teacherId = id.HasValue ? id.Value : 0;
            return View();
        }

    }
}
