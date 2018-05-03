using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// SerMetting
    /// </summary>
	public partial class SerMetting : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// SerId
        /// </summary>
		public int  SerId { get; set; }
		
		/// <summary>
        /// MeetingId
        /// </summary>
		public int  MeetingId { get; set; }
		
				
	}
}