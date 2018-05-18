using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// Ｍobile_worship
    /// </summary>
	public partial class Ｍobile_worship : EntityBase
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
        /// 祭拜日期
        /// </summary>
		public string  Date { get; set; }
		
		/// <summary>
        /// 祈禱文
        /// </summary>
		public string  Article { get; set; }
		
				
	}
}