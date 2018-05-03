using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Domain.Model
{
    public class RechargeModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int rId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string rTitle { get; set; }

        /// <summary>
        /// 充值金额
        /// </summary>
        public int rMoney { get; set; }

        /// <summary>
        /// 充值日期
        /// </summary>
        public DateTime rDate { get; set; }

        /// <summary>
        /// IP
        /// </summary>
        public string rIp { get; set; }

        /// <summary>
        /// 充值项目
        /// </summary>
        public string rSource { get; set; }

        /// <summary>
        /// 企业ID
        /// </summary>
        public int rEid { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int rState { get; set; }

        /// <summary>
        /// 匹配订单
        /// </summary>
        public string rOrderNo { get; set; }

        public string eEmail { get; set; }
    }
}
