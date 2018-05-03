using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Domain.Model
{
    public class NewsModel
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string nTitle { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string nDescn { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string nContent { get; set; }

        /// <summary>
        /// 分类ID
        /// </summary>
        public int? nColumnId { get; set; }

        /// <summary>
        /// 父级分类ID
        /// </summary>
        public int? nHighColumnId { get; set; }

        /// <summary>
        /// 企业ID
        /// </summary>
        public int? nEid { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? nDate { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        public int? isPass { get; set; }

        /// <summary>
        /// 置顶
        /// </summary>
        public int? isTop { get; set; }

        /// <summary>
        /// 推荐
        /// </summary>
        public int? isFocus { get; set; }

        /// <summary>
        /// 是否有图片
        /// </summary>
        public int? isImg { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string nImgPath { get; set; }

        /// <summary>
        /// 访问次数
        /// </summary>
        public int? nClick { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public string nTag { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int? nSort { get; set; }

        /// <summary>
        /// 编辑
        /// </summary>
        public string nAuthor { get; set; }

        /// <summary>
        /// 后台审核人员
        /// </summary>
        public int? nPassAdminId { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? nPassDate { get; set; }

        /// <summary>
        /// 修改人员ID
        /// </summary>
        public int? nEditAdminId { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? nEditDate { get; set; }

        /// <summary>
        /// 修改人姓名
        /// </summary>
        public string UpdateName { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        public int nId { get; set; }

        public string nSummary { get; set; }

        public Int16 isVip { get; set; }

        public string uname { get; set; }
        public string urealname { get; set; }
        public string uavator { get; set; }
        public string userhead { get; set; }
        public int uActive { get; set; }
        public int uGsid { get; set; }
        public string cname { get; set; }
      public string cpinyin { get; set; }
    }
}
