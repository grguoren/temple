using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Domain.Model
{
    public class ResumeModel
    {
        /// <summary>
        /// 主键  
        /// </summary>
        public int reId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string reName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int reSex { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        public int reEduc { get; set; }

        /// <summary>
        /// 工作经验
        /// </summary>
        public int reExep { get; set; }

        /// <summary>
        /// 期望薪资
        /// </summary>
        public int reSalary { get; set; }

        /// <summary>
        /// 所在省份
        /// </summary>
        public int reProvinceId { get; set; }

        /// <summary>
        /// 所在城市
        /// </summary>
        public int reCityId { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime reBirth { get; set; }

        /// <summary>
        /// 加照
        /// </summary>
        public int reLicense { get; set; }

        /// <summary>
        /// 提交日期
        /// </summary>
        public DateTime reDate { get; set; }

        /// <summary>
        /// 招聘ID
        /// </summary>
        public int reRid { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string reTel { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string reEmail { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string reAddress { get; set; }

        /// <summary>
        /// 是否已读
        /// </summary>
        public int isRead { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        public string reduName { get; set; } 
        
        /// <summary>
        /// 薪资
        /// </summary>
        public string rsName { get; set; }

        public string rIntroduce { get; set; }
        public int? rUid { get; set; }
        public string username { get; set; }

        public string rImagePath { get; set; }

        public int? IsClose { get; set; }

        public string rContact { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string uRealName { get; set; }

        /// <summary>
        /// 加盟等级
        /// </summary>
        public string GradeName { get; set; }

        /// <summary>
        /// 所有省市
        /// </summary>
        public string FullName { get; set; }

        public string urmark { get; set; } 
        
        public string uName { get; set; }

        public string rNotes { get; set; }
    }
}
