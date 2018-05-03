using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Domain.Model
{
    public class BaiduPromotionModel
    {
        /*
        BrandId
        BrandName
        UserId
        UserName
        UserGradeName
        UserGradeId
        Img
        KeywordCount
        Status
         */

        /// <summary>
        /// 品牌Id
        /// </summary>
        public int BrandId { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户等级Id
        /// </summary>
        public int UserGradeId { get; set; }

        /// <summary>
        /// 用户等级名称
        /// </summary>
        public string UserGradeName { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string Img { get; set; }

        /// <summary>
        /// 关键字数量
        /// </summary>
        public int KeywordCount { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
    }
}
