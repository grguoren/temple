using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// Good_project_service
    /// </summary>
	public partial class Good_project_service : EntityBase
	{
		/// <summary>
        /// 服務項目序號
        /// </summary>
		public int ? Service_name_id { get; set; }
		
		/// <summary>
        /// 功德項目序號
        /// </summary>
		public int ? Good_project_id { get; set; }
		
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
				
	}
}