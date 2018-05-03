using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Domain.Model
{
    public class ConsumeModel
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int cId { get; set; }

        /// <summary>
        /// 企业ID
        /// </summary>
        public int cEid { get; set; }

        /// <summary>
        /// 消费金额
        /// </summary>
        public int cMoney { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string cIp { get; set; }

        /// <summary>
        /// 消费时间
        /// </summary>
        public DateTime cDate { get; set; }

        /// <summary>
        /// 消费来源
        /// </summary>
        public string cSource { get; set; }

        /// <summary>
        /// 消费状态
        /// </summary>
        public int cState { get; set; }

        public string eEmail { get; set; }
    }
}
