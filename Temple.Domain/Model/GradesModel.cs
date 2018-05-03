using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Domain.Model
{
    public class GradesModel
    {
        /// <summary>
        /// 主键ID 
        /// </summary>
        public int gId { get; set; }

        /// <summary>
        /// 等级名称
        /// </summary>
        public string gTitle { get; set; }

        /// <summary>
        /// 年限
        /// </summary>
        public int gYear { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public int gPrice { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int gSort { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int gState { get; set; }
    }
}
