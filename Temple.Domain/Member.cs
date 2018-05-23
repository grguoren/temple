using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// Member
    /// </summary>
	public partial class Member : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// 鸞友編號
        /// </summary>
		public string  Code { get; set; }
		
		/// <summary>
        /// 鸞友姓名
        /// </summary>
		public string  Name { get; set; }
		
		/// <summary>
        /// 性別 1 男 2 女
        /// </summary>
		public int ? Gender { get; set; }
		
		/// <summary>
        /// 生日
        /// </summary>
		public string  BirthDate { get; set; }
		
		/// <summary>
        /// 中國時辰系統序號
        /// </summary>
		public int  China_time_id { get; set; }
		
		/// <summary>
        /// 行動電話
        /// </summary>
		public string  Mobilephone { get; set; }
		
		/// <summary>
        /// 傳真
        /// </summary>
		public string  Fax { get; set; }
		
		/// <summary>
        /// 聯系電話
        /// </summary>
		public string  Telephone { get; set; }
		
		/// <summary>
        /// 郵箱
        /// </summary>
		public string  Email { get; set; }
		
		/// <summary>
        /// 郵遞區號
        /// </summary>
		public string  Postalcode { get; set; }
		
		/// <summary>
        /// 聯絡地址
        /// </summary>
		public string  Address { get; set; }
		
		/// <summary>
        /// 祭拜卡編號
        /// </summary>
		public string  Worship_code { get; set; }
		
		/// <summary>
        /// 寄雜誌 Y/N
        /// </summary>
		public string  Magazine_YN { get; set; }
		
		/// <summary>
        /// 寄感謝狀
        /// </summary>
		public string  Appreciation_YN { get; set; }
		
		/// <summary>
        /// 密碼
        /// </summary>
		public string  Password { get; set; }
		
		/// <summary>
        /// 狀態  0:關 1:開
        /// </summary>
		public string  Status { get; set; }
		
		/// <summary>
        /// 電商系統編號
        /// </summary>
		public int ? Shopcode { get; set; }
		
		/// <summary>
        /// 備註
        /// </summary>
		public string  Remark { get; set; }
		
				
	}
}