using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// Service_name
    /// </summary>
	public partial class Service_name : EntityBase
	{
        #region 入帳單位
        public virtual Accounting_unit Account { get; set; }
        #endregion

		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// 服務代號
        /// </summary>
		public string  Code { get; set; }
		
		/// <summary>
        /// 服務名稱
        /// </summary>
		public string  Name { get; set; }
		
		/// <summary>
        /// 狀態 0 關 1 開
        /// </summary>
		public bool ? Status { get; set; }
		
		/// <summary>
        /// 備注
        /// </summary>
		public string  Remark { get; set; }
		
		/// <summary>
        /// 型態種類  1.一般服務 2.法會服務
        /// </summary>
		public string  Type { get; set; }
		
		/// <summary>
        /// 入帳單位系統序號
        /// </summary>
		public int  Accounting_unit_id { get; set; }
		
				
	}
}