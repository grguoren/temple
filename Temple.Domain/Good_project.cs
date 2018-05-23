using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// Good_project
    /// </summary>
	public partial class Good_project : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// 代號
        /// </summary>
		public string  Code { get; set; }
		
		/// <summary>
        /// 名稱
        /// </summary>
		public string  Name { get; set; }
		
		/// <summary>
        /// 狀態 0 關 1 開
        /// </summary>
		public bool  Status { get; set; }
		
		/// <summary>
        /// 備註
        /// </summary>
		public string  Remark { get; set; }
		
		/// <summary>
        /// 形態種類 1.一般服務 2.法會服務
        /// </summary>
		public string  Type { get; set; }
		
				
	}
}