using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// 程序名称
    /// </summary>
	public partial class SystemPro : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// SysId
        /// </summary>
		public int ? SysId { get; set; }
		
		/// <summary>
        /// SysCode
        /// </summary>
		public string  SysCode { get; set; }
		
		/// <summary>
        /// CodeName
        /// </summary>
		public string  CodeName { get; set; }
		
		/// <summary>
        /// Status
        /// </summary>
		public int ? Status { get; set; }
		
		/// <summary>
        /// Remark
        /// </summary>
		public string  Remark { get; set; }
		
				
	}
}