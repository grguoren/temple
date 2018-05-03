using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// Calendar
    /// </summary>
	public partial class Calendar : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// RecId
        /// </summary>
		public int ? RecId { get; set; }
		
		/// <summary>
        /// CheckDate
        /// </summary>
		public string  CheckDate { get; set; }
		
		/// <summary>
        /// ShowDate
        /// </summary>
		public string  ShowDate { get; set; }
		
		/// <summary>
        /// Title
        /// </summary>
		public string  Title { get; set; }
		
		/// <summary>
        /// Status
        /// </summary>
		public bool  Status { get; set; }
		
		/// <summary>
        /// Notice
        /// </summary>
		public bool  Notice { get; set; }
		
		/// <summary>
        /// Sanctuary
        /// </summary>
		public string  Sanctuary { get; set; }
		
		/// <summary>
        /// Remark
        /// </summary>
		public string  Remark { get; set; }
		
				
	}
}