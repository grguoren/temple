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
        /// RoleId
        /// </summary>
		public string  RoleId { get; set; }
		
		/// <summary>
        /// RoleName
        /// </summary>
		public string  RoleName { get; set; }
		
		/// <summary>
        /// Status
        /// </summary>
		public bool  Status { get; set; }
		
		/// <summary>
        /// Remark
        /// </summary>
		public string  Remark { get; set; }
		
				
	}
}