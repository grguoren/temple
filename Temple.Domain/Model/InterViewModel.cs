using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Domain.Model
{
    public class InterViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set;
            get;
        }
        /// <summary>
        /// 商家Id
        /// </summary>
        public int? uId
        {
            set;
            get;
        }
        public string uName { set; get; }
        public string Title
        {
            set;
            get;
        }
        /// <summary>
        /// 访谈直播
        /// </summary>
        public string Icontent
        {
            set;
            get;
        }
        /// <summary>
        /// 对话嘉宾
        /// </summary>
        public string Idialogue
        {
            set;
            get;
        }
        /// <summary>
        /// 视频地址一
        /// </summary>
        public string videoUrl0
        {
            set;
            get;
        }
        /// <summary>
        /// 视频地址二
        /// </summary>
        public string videoUrl1
        {
            set;
            get;
        }
        /// <summary>
        /// 事业宣言
        /// </summary>
        public string declaration
        {
            set;
            get;
        }
        /// <summary>
        /// 辉煌历程
        /// </summary>
        public string course
        {
            set;
            get;
        }
        /// <summary>
        /// 审核
        /// </summary>
        public int? IsPass
        {
            set;
            get;
        }
        /// <summary>
        /// 置顶
        /// </summary>
        public int? IsTop
        {
            set;
            get;
        }
        /// <summary>
        /// 置顶开始日期
        /// </summary>
        public DateTime? topBeginTime
        {
            set;
            get;
        }
        /// <summary>
        /// 置顶结束日期
        /// </summary>
        public DateTime? topEndTime
        {
            set;
            get;
        }

        /// <summary>
        /// 采访视频默认图片
        /// </summary>
        public string VideoImg0
        {
            set;
            get;
        }

        /// <summary>
        /// 采访视频默认图片
        /// </summary>
        public string VideoImg1
        {
            set;
            get;
        }

        /// <summary>
        ///   --采访编号（第几期）
        /// </summary>
        public string Period
        {
            set;
            get;
        }

        public DateTime DateTime
        {
            set;
            get;
        }


        /// <summary>
        /// 赞
        /// </summary>
        public int iGood
        {
            set;
            get;
        }

        public string uRealname { set; get; }
        public string uqq { set; get; }
        public int uCity { set; get; }
        public int uProvice { set; get; }
        public string uAvator { set; get; }
        public int uGsid { set; get; }
        public string cName { set; get; }
        public string cpinyin { set; get; }
     
    }
}
