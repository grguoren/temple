using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Domain.Model
{
    public class CacheCountBrand
    {
        public string BrandName { get; set; }

        public int OpenCount { get; set; }

        public int RegCount { get; set; }

        public string Success { get; set; }
    }
}
