using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Domain.Model
{
    public class CashModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string RealName { get; set; }

        public string Telephone { get; set; }

        public string Pwd { get; set; }

        public string Qq { get; set; }

        public int Bid { get; set; }

        public DateTime RegTime { get; set; }

        public int PromotionType { get; set; }

        public decimal? Bonus { get; set; }

        public decimal? TotalMoney { get; set; }

        public int RegCount { get; set; }

        public decimal? AmountAll { get; set; }

        public int AmountNew { get; set; }

        public string InSource { get; set; }
    }
}
