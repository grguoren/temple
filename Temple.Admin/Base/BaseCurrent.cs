using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Temple.Admin.Common;
using Temple.Admin.Models;
using Temple.Admin.Models.LoginMember;
using Temple.Domain;
using Temple.IService;
using Autofac;
using Temple.Service;
using Temple.Core.Tools;

namespace Temple.Admin.Base
{
    public class BaseCurrent
    {
        readonly IUserInfoService userse;
        public BaseCurrent()
        {
            //var builder = new ContainerBuilder();
            ////builder.RegisterType<UserInfoService>();
            //builder.RegisterType<UserInfoService>().As<IUserInfoService>();
            //var container = builder.Build();
            //userse = container.Resolve<IUserInfoService>();
        }


        /// <summary>
        /// 获取当前用户登录数据
        /// </summary>
        /// <returns></returns>
        public CurrentModel GetCurrentUser()
        {
            CurrentModel current = null;
            //if (HttpContext.Current.Request.Cookies["UserLogin"] != null)
            //{
            //    HttpCookie _cookie = HttpContext.Current.Request.Cookies["UserLogin"];
            //    if (_cookie != null)
            //    {
            //         int memberID  = Convert.ToInt32(_cookie["userid"]);
            //         if (CurrentCache.IsExist(memberID))
            //         {
            //             current = CurrentCache.Get(memberID);
            //         }
            //         else
            //         {
            //             CurrentModel model = new CurrentModel();
            //             User user = new User();

            //             user = userse.GetUserInfoByID(memberID);
            //             model.Id = memberID;
            //             model.NickName = user.NickName;
            //             model.UserName = user.UserName;

            //             CurrentCache.Insert(model.Id, model);
            //         }
            //    }
               
            //}
            //改用Cookie
            UserCookie usercookie = new UserCookie("templeuser");
            if (usercookie.Online)
            {
                int memberID = Convert.ToInt32(usercookie.Id);
                if (CurrentCache.IsExist(memberID))
                {
                    current = CurrentCache.Get(memberID);
                }
                else
                {
                    CurrentModel model = new CurrentModel();
                    User user = new User();

                    user = userse.GetUserInfoByID(memberID);
                    model.Id = memberID;
                    model.NickName = user.FileName;
                    model.UserName = user.Name;

                    CurrentCache.Insert(model.Id, model);
                }
            }
            return current;
        }

        /// <summary>
        /// 清除当前用户登录数据
        /// </summary>
        public void ClearCurrentUser()
        {
            //if (HttpContext.Current.Request.Cookies["UserLogin"] != null)
            //{
            //    HttpCookie _cookie = HttpContext.Current.Request.Cookies["UserLogin"];

            //    _cookie.Expires = DateTime.Now.AddHours(-1);
            //    HttpContext.Current.Response.Cookies.Add(_cookie);
            //    HttpContext.Current.Request.Cookies.Clear();
            //    TimeSpan ts = new TimeSpan(0, 0, 0, 0);//时间跨度 
            //    _cookie.Expires = DateTime.Now.Add(ts);//立即过期 
            //    HttpContext.Current.Response.Cookies.Remove("UserLogin");//清除 
            //    HttpContext.Current.Response.Cookies.Add(_cookie);//写入立即过期的*/
            //}
            UserCookie usercookie = new UserCookie("templeuser");
            if (usercookie.Online)
            {
                int memberID = Convert.ToInt32(usercookie.Id);
                if (CurrentCache.IsExist(memberID))
                {
                    CurrentCache.Delete(memberID);
                }
            }
            usercookie.DelUserCookie("templeuser");
        }
    }
}