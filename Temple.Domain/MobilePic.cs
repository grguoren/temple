using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// MobilePic
    /// </summary>
	public partial class MobilePic : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// WorshipId
        /// </summary>
		public int ? WorshipId { get; set; }
		
		/// <summary>
        /// MobId
        /// </summary>
		public int ? MobId { get; set; }
		
		/// <summary>
        /// Status
        /// </summary>
		public string  Status { get; set; }
		
				
	}
}