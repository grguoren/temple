using Temple.Admin.Models;
using Temple.Domain;
using Temple.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Temple.Admin.Controllers.Ajax
{
    public class Ajax_ForumController : BaseController
    {
        readonly IUserInfoService userse;


        public Ajax_ForumController(IUserInfoService _userse)
            : base(_userse)
        {
            this.userse = _userse;
            
        }
       

    }
}
