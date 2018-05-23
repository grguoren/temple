using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Domain.Model
{
    public class CacheCount
    {
        /// <summary>
        /// 会员总数
        /// </summary>
        public int UserCount { get; set; }

        /// <summary>
        /// 开通的会员数
        /// </summary>
        public int OpenCount { get; set; }

        /// <summary>
        /// 今日註册人数
        /// </summary>
        public int RegCount { get; set; }

        /// <summary>
        /// 今日顾客评论数
        /// </summary>
        public int CusCoomentCount { get; set; }

        /// <summary>
        /// 今日顾客留言数
        /// </summary>
        public int CusMsgCount { get; set; }

        /// <summary>
        /// 今日顾客需求数
        /// </summary>
        public int CusDeMandCount { get; set; }

        /// <summary>
        /// 今日会员上传资讯数
        /// </summary>
        public int UserInfomationCount_Day { get; set; }

        /// <summary>
        /// 当月会员上传资讯数
        /// </summary>
        public int UserInfomationCount_Mon { get; set; }

        /// <summary>
        /// 今日总站上传资讯数
        /// </summary>
        public int WebSiteInfomationCount_Day { get; set; }

        /// <summary>
        /// 当月总站上传资讯数
        /// </summary>
        public int WebSiteInfomationCount_Mon { get; set; }

        /// <summary>
        /// 今日论坛发帖数
        /// </summary>
        public int BBSCount_Day { get; set; }

        /// <summary>
        /// 当月论坛发帖数
        /// </summary>
        public int BBSCount_Mon { get; set; }

        /// <summary>
        /// 今日论坛回帖数
        /// </summary>
        public int BBSReplyCount_Day { get; set; }

        /// <summary>
        /// 当月论坛回帖数
        /// </summary>
        public int BBSReplyCount_Mon { get; set; }

        /// <summary>
        /// 昨日会员总数
        /// </summary>
        public int UserCountYesterDay { get; set; }

        /// <summary>
        /// 昨日开通的会员数
        /// </summary>
        public int OpenCountYesterDay { get; set; }

        /// <summary>
        /// 昨日註册人数
        /// </summary>
        public int RegCountYesterDay { get; set; }
    }
}
