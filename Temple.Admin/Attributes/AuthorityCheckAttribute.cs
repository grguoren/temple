using Temple.Core.Helper;
using Temple.Core.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Temple.Admin.Attributes
{
    public class AuthorityCheckAttribute : AuthorizeAttribute
    {
        //处理请求前验证action
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.CurrentExecutionFilePath != "/home/Agreement")
            {
                //if (HttpContext.Current.Request.Cookies["UserLogin"] == null)
                //{
                //    if (filterContext.HttpContext.Request.IsAjaxRequest())
                //    {
                //        filterContext.Result = new AjaxUnauthorizedResult();
                //        return;
                //    }
                //    else
                //    {
                //        filterContext.HttpContext.Response.Write("<script language=\"javascript\">window.location.href=\"/Login/Login\";</script>");
                //        filterContext.HttpContext.Response.End();
                //    }

                //    base.HandleUnauthorizedRequest(filterContext);
                   

                //}
                //else
                //{
                //    HttpCookie _cookie = HttpContext.Current.Request.Cookies["UserLogin"];
                //    if (_cookie != null)
                //    {
                //        int memberID = Convert.ToInt32(_cookie["userid"]);
                //        if (memberID <1)
                //        {
                //            if (filterContext.HttpContext.Request.IsAjaxRequest())
                //            {
                //                filterContext.Result = new AjaxUnauthorizedResult();
                //                return;
                //            }
                //            else
                //            {
                //                filterContext.HttpContext.Response.Write("<script language=\"javascript\">window.location.href=\"/Login/Login\";</script>");
                //                filterContext.HttpContext.Response.End();
                //            }

                //            base.HandleUnauthorizedRequest(filterContext);
                //        }
                        
                //    }
                //}
                UserCookie usercookie = new UserCookie("templeuser");
                //FileHelper.FileAdd(filterContext.HttpContext.Server.MapPath("/payEx.txt"), "时间：" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "，过滤器判断是否已登录：" + usercookie.Online + usercookie.Id + usercookie.Name + usercookie.IsWeek);
                if (!usercookie.Online)
                {

                    if (filterContext.HttpContext.Request.IsAjaxRequest())
                    {
                        filterContext.Result = new AjaxUnauthorizedResult();
                        return;
                    }
                    else
                    {
                        filterContext.HttpContext.Response.Write("<script language=\"javascript\">window.location.href=\"/Login/Login\";</script>");
                        filterContext.HttpContext.Response.End();
                    }

                    base.HandleUnauthorizedRequest(filterContext);
                }
            }
        }
    }
}