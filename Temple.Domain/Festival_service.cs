using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// Festival_service
    /// </summary>
	public partial class Festival_service : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// 服務項目系統序號
        /// </summary>
		public int  Service_name_id { get; set; }
		
		/// <summary>
        /// 法會系統序號
        /// </summary>
		public int  Festival_Id { get; set; }
		
		/// <summary>
        /// 功德金
        /// </summary>
		public double  Donate { get; set; }
		
				
	}
}