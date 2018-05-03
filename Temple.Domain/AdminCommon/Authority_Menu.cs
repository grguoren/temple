﻿using Temple.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Domain
{
    public class Authority_Menu : EntityBase
    {
        public Guid ID { get; set; }
        public int AuthorityID { get; set; }

        public int MenuID { get; set; }
    }
}
