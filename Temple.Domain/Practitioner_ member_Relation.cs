using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// Practitioner_member_Relation
    /// </summary>
	public partial class Practitioner_member_Relation : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// 鸞友系統序號
        /// </summary>
		public int ? Member_id { get; set; }
		
		/// <summary>
        /// 被保舉人系統序號
        /// </summary>
		public int ? Practitioner_id { get; set; }
		
		/// <summary>
        /// 稱謂名稱系統序號
        /// </summary>
		public int ? Title_id { get; set; }
		
		/// <summary>
        /// 輸入日期
        /// </summary>
		public string  Add_date { get; set; }
		
				
	}
}