using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// Ｍobile_worship_Practitioner
    /// </summary>
	public partial class Ｍobile_worship_Practitioner : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// 被保舉人系統序號
        /// </summary>
		public int ? Practitioner_Id { get; set; }
		
		/// <summary>
        /// 手機祭拜系統序號
        /// </summary>
		public int ? Ｍobile_worship_id { get; set; }
		
		/// <summary>
        /// 稱謂名稱系統序號
        /// </summary>
		public int ? Title_Id { get; set; }
		
				
	}
}