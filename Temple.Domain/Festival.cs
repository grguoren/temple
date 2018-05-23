using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// Festival
    /// </summary>
	public partial class Festival : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// 年度
        /// </summary>
		public string  Code { get; set; }
		
		/// <summary>
        /// 法會名稱
        /// </summary>
		public string  Name { get; set; }
		
		/// <summary>
        /// 法會日期
        /// </summary>
		public DateTime  Date { get; set; }
		
		/// <summary>
        /// 法會地點
        /// </summary>
		public string  Location { get; set; }
		
		/// <summary>
        /// 法會內容
        /// </summary>
		public string  Info { get; set; }
		
		/// <summary>
        /// 備註
        /// </summary>
		public string  Remark { get; set; }
		
				
	}
}