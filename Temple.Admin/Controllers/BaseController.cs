using Temple.Admin.Base;
using Temple.Core.Tools;
using Temple.Domain;
using Temple.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Temple.Admin.Controllers
{
    public class BaseController : Controller
    {
        public static string istest = "false";//判断是否测试,默认不是
        public static string hosturl = "";
        readonly IUserInfoService userse;
        public BaseCurrent currUser = null;
        public BaseController(IUserInfoService _userse)
        {
            userse = _userse;
            currUser = new BaseCurrent();
            object obj = System.Web.Configuration.WebConfigurationManager.AppSettings["IsTest"];
            object domain = System.Web.Configuration.WebConfigurationManager.AppSettings["domain"];
            if (obj != null)
            {
                istest = System.Web.Configuration.WebConfigurationManager.AppSettings["IsTest"].ToString();
            }
            if (domain != null)
            {
                hosturl = System.Web.Configuration.WebConfigurationManager.AppSettings["domain"].ToString();
            }
        }
        /// <summary>
        /// 当前登录的会员
        /// </summary>
        public Temple.Admin.Models.LoginMember.CurrentModel currentMember
        {
            get { return GetMemberInfo(); }
        }

     
        /// <summary>
        /// 控制器的Executing的方法
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //ViewBag.WebUrl = siteConfig.WebUrl;
            //ViewBag.LoginWebUrl = siteConfig.LoginWebUrl;
            //ViewBag.PlatformWebUrl = siteConfig.PlateformWebUrl;
            //ViewBag.ImageWebUrl = siteConfig.ImageWebUrl + "/";
            if (!filterContext.HttpContext.Request.CurrentExecutionFilePath.ToLower().Contains("/home/agreement"))
            {
                
                UserCookie usercookie = new UserCookie("templeuser");
                if (!usercookie.Online)  //if (Session["UserID"] == null)
                {
                    if (filterContext.HttpContext.Request.IsAjaxRequest())//是ajax请求超时
                    {
                        //filterContext.Result = new Temple.Admin.Attributes.AjaxUnauthorizedResult();
                        //return;
                        filterContext.HttpContext.Response.Headers.Set("sessionstatus", "timeout");//在响应头设置session状态 
                        filterContext.HttpContext.Response.Write("timeout"); //打印一个返回值，没这一行，在tabs页中无法跳出（导航栏能跳出），具体原因不明
                        //filterContext.HttpContext.Response.Write("<script language=\"javascript\">alert('登陆超时，请重新登陆！');window.location.href=\"/Login/Login\";</script>");
                        //filterContext.HttpContext.Response.End();
                        return;
                    }
                    else
                    {
                        filterContext.HttpContext.Response.Write("<script language=\"javascript\">window.location.href=\"/Login/Login\";</script>");
                        filterContext.HttpContext.Response.End();
                    }
                    base.OnActionExecuting(filterContext);
                }
                else
                {
                    UserCookie empcookie = new UserCookie("zxmanageemp");
                    empcookie.getUserCookie("zxmanageemp");
                    ViewBag.LoginName = empcookie.Online && !string.IsNullOrEmpty(empcookie.Name) ? empcookie.Name : currentMember.UserName;
                    ViewBag.LoginId = currentMember.Id;
                    if (currentMember.Id != 11 && currentMember.Id != 1)
                    {
                        List<SystemPro> slist = userse.GetUserMenu(currentMember.Id);//防止直接输入链接
                        List<SystemPro> clist = userse.GetAllChildMenu();
                        string link = RouteData.Route.GetRouteData(this.HttpContext).Values["controller"] + "/" + RouteData.Route.GetRouteData(this.HttpContext).Values["action"];
                        ViewBag.UserMenuList = slist; int i = link.IndexOf("Ajax");
                        //if (clist.Where(x => x.LinkUrl.Contains(link)).ToList().Count > 0 && slist.Where(x => x.LinkUrl.Contains(link)).ToList().Count <= 0)
                        //{
                        //    filterContext.HttpContext.Response.Write("<script language=\"javascript\">alert('您没有权限访问');window.location.href=\"/Home/Index\";</script>");
                        //    filterContext.HttpContext.Response.End();
                        //}
                    }
                }
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            string message = string.Format("消息类型：{0}<br>消息内容：{1}<br>引发异常的方法：{2}<br>引发异常源：{3}"
                , filterContext.Exception.GetType().Name
                , filterContext.Exception.Message
                 , filterContext.Exception.TargetSite
                 , filterContext.Exception.Source + filterContext.Exception.StackTrace
                 );

            //记录日志
            //Temple.Core.Helper.Log4Net.LogDebug(message);

            //抛出异常信息
            filterContext.Controller.TempData["ExceptionAttributeMessages"] = message;

            //转向
            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectResult(Url.Content("~/Home/Error"));
        }

        /// <summary>
        /// 获取登录会员信息
        /// </summary>
        /// <returns></returns>
        private Temple.Admin.Models.LoginMember.CurrentModel GetMemberInfo()
        {
            Temple.Admin.Models.LoginMember.CurrentModel current = null;
            //if (Request.Cookies["UserLogin"] != null)
            //{
            //    HttpCookie _cookie = Request.Cookies["UserLogin"];
            //    if (_cookie != null)
            //    {
            //        int memberID = Convert.ToInt32(_cookie["userid"]);
            //        if (Temple.Admin.Common.CurrentCache.IsExist(memberID))
            //        {
            //            current = Temple.Admin.Common.CurrentCache.Get(memberID);
            //        }
            //        else
            //        {
            //            Temple.Admin.Models.LoginMember.CurrentModel model = new Temple.Admin.Models.LoginMember.CurrentModel();
            //            Temple.Domain.UserInfo user = new Temple.Domain.UserInfo();

            //            user = userse.GetUserInfoByID(memberID);
            //            model.Id = memberID;
            //            model.NickName = user.NickName;
            //            model.UserName = user.UserName;
            //            //model.AuthorityList = userse.GetUserAuthorityList(memberID);

            //            Temple.Admin.Common.CurrentCache.Insert(model.Id, model);
            //            current = model;
            //        }
            //    }

            //}
            UserCookie usercookie = new UserCookie("templeuser");
            if (usercookie.Online)
            {
                int memberID = Convert.ToInt32(usercookie.Id);
                if (Temple.Admin.Common.CurrentCache.IsExist(memberID))
                {
                    current = Temple.Admin.Common.CurrentCache.Get(memberID);
                }
                else
                {
                    Temple.Admin.Models.LoginMember.CurrentModel model = new Temple.Admin.Models.LoginMember.CurrentModel();
                    Temple.Domain.User user = new Temple.Domain.User();

                    user = userse.GetUserInfoByID(memberID);
                    model.Id = memberID;
                    model.NickName = user.FileName;
                    model.UserName = user.Name;
                    //model.DepartName = user.DepartName;

                    Temple.Admin.Common.CurrentCache.Insert(model.Id, model);
                    current = model;
                }
            }
            //if (Session["UserID"] != null)
            //{
            //    int memberID = Convert.ToInt32(Session["UserID"]);
            //    if (Temple.Admin.Common.CurrentCache.IsExist(memberID))
            //    {
            //        current = Temple.Admin.Common.CurrentCache.Get(memberID);
            //    }
            //    else
            //    {
            //        Temple.Admin.Models.LoginMember.CurrentModel model = new Temple.Admin.Models.LoginMember.CurrentModel();
            //        Temple.Domain.UserInfo user = new Temple.Domain.UserInfo();

            //        user = userse.GetUserInfoByID(memberID);
            //        model.Id = memberID;
            //        model.NickName = user.NickName;
            //        model.UserName = user.UserName;
            //        //model.AuthorityList = userse.GetUserAuthorityList(memberID);

            //        Temple.Admin.Common.CurrentCache.Insert(model.Id, model);
            //        current = model;
            //    }
            //}
            return current;
        }
    }
}
