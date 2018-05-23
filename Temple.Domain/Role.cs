using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// Role
    /// </summary>
	public partial class Role : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// 角色代碼
        /// </summary>
		public string  Code { get; set; }
		
		/// <summary>
        /// 角色名稱
        /// </summary>
		public string  Name { get; set; }
		
		/// <summary>
        /// 狀態  0 關 1 開
        /// </summary>
		public bool  Status { get; set; }
		
		/// <summary>
        /// 備註
        /// </summary>
		public string  Remark { get; set; }
		
				
	}
}