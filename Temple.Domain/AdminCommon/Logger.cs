using Temple.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Domain
{
    public class Logger : EntityBase
    {
        public Guid? Id { get; set; }

        public string Admin_Name { get; set; }

        public int? Admin_Id { get; set; }

        public DateTime? CreateTime { get; set; }

        public string Action { get; set; }

        public string FromIP { get; set; }

        public string Remark { get; set; }

        public string FromUrl { get; set; }

        public string Param { get; set; }
    }
}
