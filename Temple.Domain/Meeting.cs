using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// Meeting
    /// </summary>
	public partial class Meeting : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// Name
        /// </summary>
		public string  Name { get; set; }
		
		/// <summary>
        /// MeetingDate
        /// </summary>
		public string  MeetingDate { get; set; }
		
		/// <summary>
        /// Location
        /// </summary>
		public string  Location { get; set; }
		
		/// <summary>
        /// Info
        /// </summary>
		public string  Info { get; set; }
		
		/// <summary>
        /// Year
        /// </summary>
		public string  Year { get; set; }
		
		/// <summary>
        /// Remark
        /// </summary>
		public string  Remark { get; set; }
		
				
	}
}