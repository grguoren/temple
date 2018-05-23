using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// SystemPro
    /// </summary>
	public partial class SystemPro : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// 序號
        /// </summary>
		public int  System_id { get; set; }
		
		/// <summary>
        /// 系統名稱代號
        /// </summary>
		public string  Code { get; set; }
		
		/// <summary>
        /// 程式名稱
        /// </summary>
		public string  Name { get; set; }
		
		/// <summary>
        /// 狀態 0 關 1 開
        /// </summary>
		public int ? Status { get; set; }
		
		/// <summary>
        /// 備註
        /// </summary>
		public string  Remark { get; set; }
		
		/// <summary>
        /// 程式鏈接
        /// </summary>
		public string  LinkUrl { get; set; }
		
				
	}
}