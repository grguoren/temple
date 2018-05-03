using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// MeritService
    /// </summary>
	public partial class MeritService : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// SerId
        /// </summary>
		public int ? SerId { get; set; }
		
		/// <summary>
        /// GoodId
        /// </summary>
		public int ? GoodId { get; set; }
		
		/// <summary>
        /// MerId
        /// </summary>
		public int ? MerId { get; set; }
		
				
	}
}