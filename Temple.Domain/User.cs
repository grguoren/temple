using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// User
    /// </summary>
	public partial class User : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// 使用者帳號
        /// </summary>
		public string  Account { get; set; }
		
		/// <summary>
        /// 使用者名稱
        /// </summary>
		public string  Name { get; set; }
		
		/// <summary>
        /// 行動電話
        /// </summary>
		public string  Mobile { get; set; }
		
		/// <summary>
        /// 到職日期
        /// </summary>
        public DateTime OnBoardDate { get; set; }
		
		/// <summary>
        /// 離職日期
        /// </summary>
        public DateTime? ResignationDate { get; set; }
		
		/// <summary>
        /// 密碼
        /// </summary>
		public string  Passwd { get; set; }
		
		/// <summary>
        /// 狀態 0 關 1 開
        /// </summary>
		public bool  Status { get; set; }
		
		/// <summary>
        /// 備注
        /// </summary>
		public string  Remark { get; set; }
		
		/// <summary>
        /// 照片路徑
        /// </summary>
		public string  FileName { get; set; }
		
				
	}
}