using Autofac;
using Autofac.Integration.Mvc;
using Temple.Core.Data;
using Temple.IService;
using Temple.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Temple.Admin
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Autofac初始化过程
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());//注册所有的Controller
            builder.RegisterType<EntityContext>().As<IDbContext>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWorkContextBase>().As<IUnitOfWork>().InstancePerLifetimeScope();
            //做好一个service需在这里注册下
            builder.RegisterType<UserInfoService>().As<IUserInfoService>();
            builder.RegisterType<MenuInfoService>().As<IMenuInfoService>();
            builder.RegisterType<RoleInfoService>().As<IRoleInfoService>();
            builder.RegisterType<LoggerService>().As<ILoggerService>(); 
            builder.RegisterType<BasicService>().As<IBasicService>();
          
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}