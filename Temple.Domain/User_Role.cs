using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// User_Role
    /// </summary>
	public partial class User_Role : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// 角色序號
        /// </summary>
		public int  Role_Id { get; set; }
		
		/// <summary>
        /// 使用者序號
        /// </summary>
		public int  User_Id { get; set; }
		
				
	}
}