using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// RolePermission
    /// </summary>
	public partial class RolePermission : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// RoleId
        /// </summary>
		public int ? RoleId { get; set; }
		
		/// <summary>
        /// SysProId
        /// </summary>
		public int ? SysProId { get; set; }
		
		/// <summary>
        /// Remark
        /// </summary>
		public string  Remark { get; set; }
		
				
	}
}