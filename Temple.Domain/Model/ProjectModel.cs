using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Domain.Model
{
    public class ProjectModel
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int pId { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string pTitle { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string pDescn { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string pContent { get; set; }

        /// <summary>
        /// 加盟条件
        /// </summary>
        public string pCondition { get; set; }

        /// <summary>
        /// 发展前景
        /// </summary>
        public string pProspect { get; set; }

        /// <summary>
        /// 企业ID
        /// </summary>
        public int? pEid { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string pImg { get; set; }

        /// <summary>
        /// 是否推荐
        /// </summary>
        public int? isTop { get; set; }

        /// <summary>
        /// 推荐日期
        /// </summary>
        public DateTime? pTopDate { get; set; }

        /// <summary>
        /// 推荐结束日期
        /// </summary>
        public DateTime? pTopEndDate { get; set; }

        /// <summary>
        /// 暂停置顶时间
        /// </summary>
        public DateTime? StopDate { get; set; }

        /// <summary>
        /// 新增日期
        /// </summary>
        public DateTime? pDate { get; set; }

        /// <summary>
        /// 访问次数
        /// </summary>
        public int? pClick { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        public int? isPass { get; set; }

        /// <summary>
        /// 介绍
        /// </summary>
        public string pSummary { get; set; }

        public int? IsRemd { get; set; }

        public int? IsHot { get; set; }
    }
}
