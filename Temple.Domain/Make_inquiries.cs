using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// Make_inquiries
    /// </summary>
	public partial class Make_inquiries : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// 鸞友系統序號
        /// </summary>
		public int  Member_Id { get; set; }
		
		/// <summary>
        /// 叩問日期
        /// </summary>
		public DateTime  Ask_Date { get; set; }
		
		/// <summary>
        /// 叩問事項
        /// </summary>
		public string  Ask_Info { get; set; }
		
		/// <summary>
        /// 聖示內容
        /// </summary>
		public string  Instructions { get; set; }
		
		/// <summary>
        /// 是否已回覆
        /// </summary>
		public string  Reply_YN { get; set; }
		
		/// <summary>
        /// 是否刊登
        /// </summary>
		public string  Publish_YN { get; set; }
		
		/// <summary>
        /// 備註
        /// </summary>
		public string  Remark { get; set; }
		
		/// <summary>
        /// 聖示日期
        /// </summary>
        public DateTime? Confirmation_date { get; set; }
		
				
	}
}