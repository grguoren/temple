using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// Payment_item
    /// </summary>
	public partial class Payment_item : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// 付款方式名稱
        /// </summary>
		public string  Name { get; set; }
		
		/// <summary>
        /// 付款方式代號
        /// </summary>
		public string  Code { get; set; }
		
		/// <summary>
        /// 狀態 0 關 1 開
        /// </summary>
		public bool  Status { get; set; }
		
		/// <summary>
        /// 備注
        /// </summary>
		public string  Remark { get; set; }
		
				
	}
}