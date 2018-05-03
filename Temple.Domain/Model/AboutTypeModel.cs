using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Domain.Model
{
    public class AboutTypeModel
    {
        /// <summary>
        /// 主键唯一标识
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 分类名称（例如：关于我们，最新公告，会员类型，商务合作，网站排名，联系方式）
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 栏目介绍
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 总站显示
        /// </summary>
        public byte? IsDisplayWeb { get; set; }

        /// <summary>
        /// 品牌显示
        /// </summary>
        public byte? IsDisplayBrand { get; set; }

        /// <summary>
        /// 栏目排序
        /// </summary>
        public int? Sort { get; set; }

        /// <summary>
        /// 新增时间
        /// </summary>
        public DateTime? AddTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        public int? AddId { get; set; }

        public string AddName { get; set; }

        public int? UpdateId { get; set; }

        public string UpdateName { get; set; }

        public int? AboutCount { get; set; }
    }
}
