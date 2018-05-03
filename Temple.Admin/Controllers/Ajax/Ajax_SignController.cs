using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Temple.Admin.Models;
using Temple.Domain;
using Temple.IService;

namespace Temple.Admin.Controllers.Ajax
{
    public class Ajax_SignController : BaseController
    {
        readonly IUserInfoService userse;

        public Ajax_SignController(IUserInfoService _userse)
            : base(_userse)
        {
            this.userse = _userse;
        }
    }
}
