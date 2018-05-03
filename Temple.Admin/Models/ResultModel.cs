using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Temple.Admin.Models
{
    public class ResultModel
    {
        public int Count { get; set; }

        public List<object> Data { get; set; }

        public bool Status { get; set; }

        public string Name { get; set; }

        public string GName { get; set; }

        public string Price {get;set;}
    }
}