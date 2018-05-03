using Temple.Domain;
using Temple.IService;
using Temple.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Temple.Core.Data;
using Temple.Core.Tools;

namespace Temple.Admin.Attributes
{
    public class LoggingFilterAttribute : ActionFilterAttribute
    {
        public string Remark { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Temple.Admin.Models.LoginMember.CurrentModel currentMember = GetMemberInfo();
            if (currentMember != null)
            {
                Logger model = new Logger();
                model.Action = filterContext.HttpContext.Request.RawUrl;
                model.Admin_Id = currentMember.Id;
                model.Admin_Name = currentMember.NickName;
                model.CreateTime = DateTime.Now;
                model.FromIP = filterContext.HttpContext.Request.UserHostAddress;
                model.FromUrl = filterContext.HttpContext.Request.UrlReferrer.AbsoluteUri;
                model.Param = "";
                model.Remark = Remark;

                #region 获取参数
                int parametersCount=filterContext.ActionParameters.Count;
                if (parametersCount > 0)
                {
                    var keys = filterContext.ActionParameters.Keys;
                    if (null != keys)
                    {
                        foreach (string key in keys)
                        {
                            var value = filterContext.ActionParameters[key];
                            model.Param += "[" + key + ":" + value + "]";
                            if (null == value)
                                continue;
                        }
                    }
                }
                #endregion

                var builder = new ContainerBuilder();
                builder.RegisterType<EntityContext>().As<IDbContext>().InstancePerLifetimeScope();
                builder.RegisterType<UnitOfWorkContextBase>().As<IUnitOfWork>().InstancePerLifetimeScope();
                builder.RegisterType<LoggerService>(); 
                using (var container = builder.Build())
                {
                    var loggerse = container.Resolve<LoggerService>();
                    loggerse.AddLog(model);
                }
            }
        }
        

        #region 私有方法
        /// <summary>
        /// 获取登录会员信息
        /// </summary>
        /// <returns></returns>
        private Temple.Admin.Models.LoginMember.CurrentModel GetMemberInfo()
        {
            Temple.Admin.Models.LoginMember.CurrentModel current = null;
            //if (HttpContext.Current.Request.Cookies["UserLogin"] != null)
            //{
            //    HttpCookie _cookie = HttpContext.Current.Request.Cookies["UserLogin"];
            //    if (_cookie != null)
            //    {
            //        int memberID = Convert.ToInt32(_cookie["userid"]);
            //        if (Temple.Admin.Common.CurrentCache.IsExist(memberID))
            //        {
            //            current = Temple.Admin.Common.CurrentCache.Get(memberID);
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
            }
            return current;
        }
        #endregion
    }
}