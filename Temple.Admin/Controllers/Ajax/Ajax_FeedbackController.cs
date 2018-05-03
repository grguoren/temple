using Temple.Admin.Models;
using Temple.Domain;
using Temple.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Temple.Admin.Controllers.Ajax
{
    public class Ajax_FeedbackController : BaseController
    {
        readonly IUserInfoService userse;
        public Ajax_FeedbackController(IUserInfoService _userse)
            : base(_userse)
        {
            userse = _userse;
        }

        
    }
}
