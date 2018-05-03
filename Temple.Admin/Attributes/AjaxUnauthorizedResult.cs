using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Temple.Admin.Attributes
{
    public class AjaxUnauthorizedResult : JavaScriptResult
    {
        public AjaxUnauthorizedResult()
        {
            this.Script = "{'Data':[{'Id':'请重新登录'}]}";
            //var loginurl = "/Login/Recharge";
            //this.Script = "location.href='" + loginurl + "'";
        }
    }
}