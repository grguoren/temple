using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// Education_course
    /// </summary>
	public partial class Education_course : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// 被保舉人系統序號
        /// </summary>
		public int ? Practitioner_Id { get; set; }
		
		/// <summary>
        /// 被保舉人型態  1.修士  2.證道仙佛
        /// </summary>
		public bool  Practitioner_Status { get; set; }
		
		/// <summary>
        /// 考核日期
        /// </summary>
		public string  Assessment_date { get; set; }
		
		/// <summary>
        /// 聖示日期
        /// </summary>
		public string  Confirmation_date { get; set; }
		
		/// <summary>
        /// 聖 示内容
        /// </summary>
		public string  Instructions { get; set; }
		
		/// <summary>
        /// 頒賜果位
        /// </summary>
		public string  Degree_name { get; set; }
		
		/// <summary>
        /// 是否已發通知 1:Y        2:N
        /// </summary>
		public bool  Notice_YN { get; set; }
		
		/// <summary>
        /// 備       註
        /// </summary>
		public string  Remark { get; set; }
		
				
	}
}