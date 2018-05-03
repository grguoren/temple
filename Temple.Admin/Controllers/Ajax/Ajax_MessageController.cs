using Temple.Admin.Models;
using Temple.Core.Helper;
using Temple.Domain;
using Temple.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Temple.Admin.Controllers.Ajax
{
    public class Ajax_MessageController : BaseController
    {
        readonly IUserInfoService userse;

        public Ajax_MessageController(IUserInfoService _userse)
            : base(_userse)
        {
            this.userse = _userse;
        }
       

    }
}
