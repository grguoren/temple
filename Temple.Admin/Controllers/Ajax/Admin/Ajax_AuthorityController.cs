using Temple.Admin.Models;
using Temple.Domain;
using Temple.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Temple.Admin.Controllers.Ajax
{
    public class Ajax_AuthorityController : BaseController
    {

        readonly IUserInfoService userse;
        readonly IAuthorityInfoService authorityse;
        public Ajax_AuthorityController(IUserInfoService _userse, IAuthorityInfoService _authorityse)
            : base(_userse)
        {
            userse = _userse;
            authorityse = _authorityse;
        }
        //
        // GET: /Ajax_Authority/
        #region 权限基础信息操作
        [HttpPost]
        public JsonResult GetAuthorityList()
        {
            List<AuthorityInfo> list = authorityse.GetAllAuthorityList();
            ResultModel refs = new ResultModel();
            refs.Count = list.Count();
            refs.Data = list.ToList<object>();
            refs.Status = (list != null && list.Count > 0);
            return Json(refs);
        }

        //[HttpPost]
        //public JsonResult GetLimitCity()
        //{
        //    //string strXmlFile = System.Web.HttpContext.Current.Server.MapPath("~/Config/website.config");
        //    //XmlControl XmlTool = new XmlControl(strXmlFile);
        //    //string limitCity = XmlTool.GetText(string.Format("Index/{1}/Li[Id='{0}']", 1, "limitcity"), "Name");
        //    SaleInfo saleModel = this.salesse.GetUserInfoByRealName("superadmin");

        //    ResultModel refs = new ResultModel();
        //    refs.Count = saleModel == null?0:saleModel.sState.Value;
        //    refs.Data = null;
        //    refs.Status = true;
        //    return Json(refs);
        //}

        //[HttpPost]
        //public JsonResult UpdateLimitCity(int pid)
        //{
        //    ResultModel refs = new ResultModel();
        //    refs.Count = 0;
        //    refs.Data = null;
        //    refs.Status = true;
        //    //UpdateXmlNode(pid);
        //    try
        //    {
        //        SaleInfo saleModel = this.salesse.GetUserInfoByRealName("superadmin");
        //        saleModel.sState = pid;
        //        this.salesse.UpdateUser(saleModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        refs.Name = ex.Message;
        //    }

           
        //    return Json(refs);
        //}
        //private void UpdateXmlNode(int con)
        //{
        //    SaleInfo saleModel = this.salesse.GetUserInfoByRealName("superadmin");
        //    saleModel.sState = con;
        //    this.salesse.UpdateUser(saleModel);
        //}
        [HttpPost]
        public string AddAuthority(string name, string type)
        {
            AuthorityInfo model = new AuthorityInfo();
            model.CreateTime = DateTime.Now;
            model.FID = 0;
            model.AuthorityLevel = 1;
            model.Name = name;
            model.PID = 0;
            model.Status = 0;
            model.Type = type;
            model.UpdateTime = model.CreateTime;
            return authorityse.AddAuthority(model).ToString();
        }

        [HttpPost]
        public string DeleteAuthority(int id)
        {
            return authorityse.DeleteAuthority(id).ToString();
        }

        [HttpPost]
        public string UpdateAuthority(int id, string name, string type)
        {
            AuthorityInfo model = authorityse.GetAuthorityInfoByID(id);
            model.Name = name;
            model.Type = type;
            model.UpdateTime = DateTime.Now;
            return authorityse.UpdateAuthority(model).ToString();
        }
        #endregion

        #region 权限角色关联操作
        [HttpPost]
        public JsonResult GetAuthority_RoleList(int roleid)
        {
            List<Authority_Role> list = authorityse.GetAuthority_RoleListByRoleID(roleid);
            List<string> str = new List<string>();
            list.ForEach(x => str.Add(x.AuthorityID.ToString()));
            ResultModel refs = new ResultModel();
            refs.Count = str.Count();
            refs.Data = str.ToList<object>();
            refs.Status = (str != null && str.Count > 0);
            return Json(refs);
        }

        [HttpPost]
        public string AddAuthority_Role(string authorityids, int roleid)
        {
            authorityse.AddAuthorityRole(authorityids.Split(','), roleid);
            return "True";
        }
        #endregion

        #region 权限菜单关联操作
        [HttpPost]
        public JsonResult GetAuthority_MenuList(int menuid)
        {
            List<Authority_Menu> list = authorityse.GetAuthority_MenuListByMenuID(menuid);
            List<string> str = new List<string>();
            list.ForEach(x => str.Add(x.AuthorityID.ToString()));
            ResultModel refs = new ResultModel();
            refs.Count = str.Count();
            refs.Data = str.ToList<object>();
            refs.Status = (str != null && str.Count > 0);
            return Json(refs);
        }

        [HttpPost]
        public string AddAuthority_Menu(string authorityids, int menuid)
        {
            authorityse.AddAuthorityMenu(authorityids.Split(','), menuid);
            return "True";
        }
        #endregion

    }
}
