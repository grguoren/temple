using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// Angel
    /// </summary>
	public partial class Angel : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// 鸞友系統序號
        /// </summary>
		public int ? Member_Id { get; set; }
		
		/// <summary>
        /// 護法神聖號
        /// </summary>
		public string  Name { get; set; }
		
		/// <summary>
        /// 隨護年限
        /// </summary>
		public int  Years { get; set; }
		
		/// <summary>
        /// 隨護起始日期
        /// </summary>
		public DateTime?  Start_date { get; set; }
		
		/// <summary>
        /// 建立日期
        /// </summary>
        public DateTime? Add_Date { get; set; }
		
		/// <summary>
        /// 是否結案 Y/N
        /// </summary>
		public string  Finish_YN { get; set; }
		
		/// <summary>
        /// 備註
        /// </summary>
		public string  Remark { get; set; }
		
				
	}
}