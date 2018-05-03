using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// MobilePray
    /// </summary>
	public partial class MobilePray : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// FriId
        /// </summary>
		public int ? FriId { get; set; }
		
		/// <summary>
        /// PrayDate
        /// </summary>
		public string  PrayDate { get; set; }
		
		/// <summary>
        /// Article
        /// </summary>
		public string  Article { get; set; }
		
				
	}
}