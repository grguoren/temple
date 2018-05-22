using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Temple.Admin.Models;
using Temple.Core.Pager;
using Temple.Domain;
using Temple.IService;

namespace Temple.Admin.Controllers.Ajax
{
    public class Ajax_MyUserController : BaseController
    {
        private readonly static string siteUrl = System.Web.Configuration.WebConfigurationManager.AppSettings["HostMechine"].ToString();

        readonly IUserInfoService userse;
        readonly IMemberService memberse;
        private int regCount = 0;
        public Ajax_MyUserController(IUserInfoService _userse, IMemberService _memberse)
            : base(_userse)
        {
            userse = _userse;
            memberse = _memberse;
            regCount = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["RegCount"]);
        }

        #region 彎友
        [HttpPost]
        public JsonResult GetMemberList(int page, int size)
        {
            IPagedList<Member> list = memberse.GetMemberList(page, size);

            ResultModel model = new ResultModel();
            model.Count = list.TotalCount;
            model.Data = list.ToList<object>();
            model.Status = (list != null && list.Count > 0);
            return Json(model);
        }

        /// <summary>
        /// 添加彎友
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "彎友-添加数据")]
        public string AddMember(string name, string remark, string code, string type, int status = 1)
        {
            bool res = false;
            Member model = new Member();
            model.Name = name;
            model.Remark = Server.HtmlEncode(remark);
            model.Code = code;
            //model.Status = status == 1 ? true : false;
            //model.Type = type;
            res = memberse.AddMember(model);
            return res.ToString();
        }
        /// <summary>
        /// 更新彎友
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "彎友-更新数据")]
        public string UpdateMember(string name, int status, string remark, string code, string type, int id)
        {
            bool res = false;
            Member model = new Member();
            model = memberse.GetMemberByID(id);
            model.Code = code;
            model.Name = name;
            model.Remark = Server.HtmlEncode(remark);
            //model.Type = type;
            //model.Status = status == 1 ? true : false;

            res = memberse.UpdateMember(model);
            return res.ToString();
        }
        [HttpPost]
        public JsonResult GetMemberById(int id)
        {
            Member model = memberse.GetMemberByID(id);
            model.Remark = Server.HtmlDecode(model.Remark);

            return Json(model);
        }

        [HttpPost]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "彎友-删除数据")]
        public string DeleteMember(int id)
        {
            return memberse.DeleteMember(id).ToString();
        }
        #endregion

        #region 被保舉人
        [HttpPost]
        public JsonResult GetPractitionerList(int page, int size)
        {
            IPagedList<Practitioner> list = memberse.GetPractitionerList(page, size);

            ResultModel model = new ResultModel();
            model.Count = list.TotalCount;
            model.Data = list.ToList<object>();
            model.Status = (list != null && list.Count > 0);
            return Json(model);
        }

        /// <summary>
        /// 添加被保舉人
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "被保舉人-添加数据")]
        public string AddPractitioner(string name, string remark, string code, string type, int status = 1)
        {
            bool res = false;
            Practitioner model = new Practitioner();
            model.Name = name;
            model.Remark = Server.HtmlEncode(remark);
            model.Code = code;
            //model.Status = status == 1 ? true : false;
            //model.Type = type;
            res = memberse.AddPractitioner(model);
            return res.ToString();
        }
        /// <summary>
        /// 更新被保舉人
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "被保舉人-更新数据")]
        public string UpdatePractitioner(string name, int status, string remark, string code, string type, int id)
        {
            bool res = false;
            Practitioner model = new Practitioner();
            model = memberse.GetPractitionerByID(id);
            model.Code = code;
            model.Name = name;
            model.Remark = Server.HtmlEncode(remark);
            //model.Type = type;
            //model.Status = status == 1 ? true : false;

            res = memberse.UpdatePractitioner(model);
            return res.ToString();
        }
        [HttpPost]
        public JsonResult GetPractitionerById(int id)
        {
            Practitioner model = memberse.GetPractitionerByID(id);
            model.Remark = Server.HtmlDecode(model.Remark);

            return Json(model);
        }

        [HttpPost]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "被保舉人-删除数据")]
        public string DeletePractitioner(int id)
        {
            return memberse.DeletePractitioner(id).ToString();
        }
        #endregion
    }
}
