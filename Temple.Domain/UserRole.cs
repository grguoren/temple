using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// UserRole
    /// </summary>
	public partial class UserRole : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// RoleId
        /// </summary>
		public int  RoleId { get; set; }
		
		/// <summary>
        /// UserId
        /// </summary>
		public int  UserId { get; set; }
		
				
	}
}