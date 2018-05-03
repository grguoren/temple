using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// Report
    /// </summary>
	public partial class Report : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// FriId
        /// </summary>
		public int  FriId { get; set; }
		
		/// <summary>
        /// ReportDate
        /// </summary>
		public string  ReportDate { get; set; }
		
		/// <summary>
        /// Info
        /// </summary>
		public string  Info { get; set; }
		
		/// <summary>
        /// Sanctuary
        /// </summary>
		public string  Sanctuary { get; set; }
		
		/// <summary>
        /// IfReply
        /// </summary>
		public bool  IfReply { get; set; }
		
		/// <summary>
        /// IfShowon
        /// </summary>
		public bool  IfShowon { get; set; }
		
		/// <summary>
        /// Remark
        /// </summary>
		public string  Remark { get; set; }
		
		/// <summary>
        /// SanDate
        /// </summary>
		public string  SanDate { get; set; }
		
				
	}
}