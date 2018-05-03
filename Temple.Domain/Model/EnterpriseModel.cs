using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Domain.Model
{
    public class EnterpriseModel
    {
        /// <summary>
        /// 主键唯一标识
        /// </summary>
        public int eId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string eName { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string eEmail { get; set; }

        /// <summary>
        /// 等级Id
        /// </summary>
        public int? eGrade { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string ePwd { get; set; }

        /// <summary>
        /// 余额
        /// </summary>
        public int? eMoney { get; set; }

        /// <summary>
        /// 积分
        /// </summary>
        public int? eIntegral { get; set; }

        /// <summary>
        /// VIP
        /// </summary>
        public int? isVip { get; set; }

        /// <summary>
        /// VIP开始时间
        /// </summary>
        public DateTime? vipBeginDate { get; set; }

        /// <summary>
        /// VIP结束时间
        /// </summary>
        public DateTime? vipEndDate { get; set; }

        /// <summary>
        /// isTop
        /// </summary>
        public int? isTop { get; set; }

        /// <summary>
        /// 置顶开始时间
        /// </summary>
        public DateTime? topBeginDate { get; set; }

        /// <summary>
        /// 置顶结束时间
        /// </summary>
        public DateTime? topEndDate { get; set; }

        /// <summary>
        /// 是否关闭
        /// </summary>
        public int? isClose { get; set; }

        /// <summary>
        /// 关闭时间
        /// </summary>
        public DateTime? vipCloseDate { get; set; }

        /// <summary>
        /// 用户类别
        /// </summary>
        public int? eType { get; set; }

        /// <summary>
        /// 样式
        /// </summary>
        public string eCss { get; set; }

        /// <summary>
        /// 用户类别
        /// </summary>
        public int? isCertificate { get; set; }

        /// <summary>
        /// 证件地址
        /// </summary>
        public string eCertificate { get; set; }

        /// <summary>
        /// 来路企业ID
        /// </summary>
        public int? ePersonId { get; set; }

        /// <summary>
        /// 来路
        /// </summary>
        public string eSource { get; set; }

        /// <summary>
        /// 访问次数
        /// </summary>
        public int? eClick { get; set; }

        /// <summary>
        /// 企业会员注册日期
        /// </summary>
        public DateTime? eRegDate { get; set; }

        /// <summary>
        /// 邮箱审核状态
        /// </summary>
        public int IsEmail { get; set; }

        /// <summary>
        /// QQ号码
        /// </summary>
        public string eQQ { get; set; }

        /// <summary>
        /// 邮件过期时间
        /// </summary>
        public DateTime? overdue { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        public int? eState { get; set; }

        /// <summary>
        /// 推荐
        /// </summary>
        public int? IsRemd { get; set; }

        //-------------基本信息--------------------//
        /// <summary>
        /// 企业名称
        /// </summary>
        public string enName { get; set; }

        /// <summary>
        /// 企业图片
        /// </summary>
        public string enImg { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string enContacts { get; set; }

        /// <summary>
        /// 电话1
        /// </summary>
        public string enTel { get; set; }

        /// <summary>
        /// 电话2
        /// </summary>
        public string enPhone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string enEmail { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string enAddress { get; set; }

        /// <summary>
        /// 所在省份
        /// </summary>
        public int? enProvinceId { get; set; }

        /// <summary>
        /// 所在城市
        /// </summary>
        public int? enCityId { get; set; }

        /// <summary>
        /// 所在区县
        /// </summary>
        public int? enCountyId { get; set; }

        /// <summary>
        /// 愿景
        /// </summary>
        public string enVision { get; set; }
    }
}
