using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// Sanctuary
    /// </summary>
	public partial class Sanctuary : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// CreateDate
        /// </summary>
		public string  CreateDate { get; set; }
		
		/// <summary>
        /// Num
        /// </summary>
		public string  Num { get; set; }
		
		/// <summary>
        /// Deadline
        /// </summary>
		public string  Deadline { get; set; }
		
		/// <summary>
        /// DateStart
        /// </summary>
		public string  DateStart { get; set; }
		
		/// <summary>
        /// IfFinish
        /// </summary>
		public bool  IfFinish { get; set; }
		
		/// <summary>
        /// Remark
        /// </summary>
		public string  Remark { get; set; }
		
		/// <summary>
        /// FriId
        /// </summary>
		public int ? FriId { get; set; }
		
		/// <summary>
        /// DateFinish
        /// </summary>
		public string  DateFinish { get; set; }
		
				
	}
}