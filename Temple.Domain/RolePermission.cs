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
        /// 主鍵
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// 角色系統序號
        /// </summary>
		public int ? Role_Id { get; set; }
		
		/// <summary>
        /// 程式名稱序號
        /// </summary>
		public int ? SysPro_Id { get; set; }
		
				
	}
}