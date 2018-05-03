using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Domain.Model
{
    public class MeetingModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int meId { get; set; }

        /// <summary>
        /// 主题
        /// </summary>
        public string meTitle { get; set; }

        /// <summary>
        /// 会议图片
        /// </summary>
        public string meImg { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        public string meSummary { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string meContent { get; set; }

        /// <summary>
        /// 亮点
        /// </summary>
        public string meHighlights { get; set; }

        /// <summary>
        /// 指南
        /// </summary>
        public string meGuide { get; set; }

        /// <summary>
        /// 访问次数
        /// </summary>
        public int? meClick { get; set; }

        /// <summary>
        /// 企业ID 
        /// </summary>
        public int? meEid { get; set; }

        /// <summary>
        /// 推荐
        /// </summary>
        public int? isTop { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? meTopDate { get; set; }

        /// <summary>
        /// 推荐结束日期
        /// </summary>
        public DateTime? meTopEndDate { get; set; }

        /// <summary>
        /// 暂停置顶时间
        /// </summary>
        public DateTime? StopDate { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        public int? isPass { get; set; }

        /// <summary>
        /// 会议发布时间
        /// </summary>
        public DateTime? addDate { get; set; }

        /// <summary>
        /// 会议开始时间
        /// </summary>
        public DateTime? BeginDate { get; set; }

        public int? IsRemd { get; set; }
    }
}
