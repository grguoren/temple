using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Temple.Admin.Models;
using Temple.Domain;
using Temple.IService;

namespace Temple.Admin.Controllers.Ajax
{
    public class Ajax_MyUserController : BaseController
    {
        private readonly static string siteUrl = System.Web.Configuration.WebConfigurationManager.AppSettings["HostMechine"].ToString();

        readonly IUserInfoService userse;
        private int regCount = 0;
        public Ajax_MyUserController(IUserInfoService _userse)
            : base(_userse)
        {
            userse = _userse;

            regCount = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["RegCount"]);
        }

    }
}
