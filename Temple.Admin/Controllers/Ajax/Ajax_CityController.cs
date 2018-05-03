using Temple.Admin.Common;
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
    public class Ajax_CityController : BaseController
    {
        readonly IUserInfoService userse;
        public Ajax_CityController(IUserInfoService _userse)
            : base(_userse)
        {
            userse = _userse;
        }
       
    }
}
