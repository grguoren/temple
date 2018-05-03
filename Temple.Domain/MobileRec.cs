using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// MobileRec
    /// </summary>
	public partial class MobileRec : EntityBase
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
        /// MobId
        /// </summary>
		public int ? MobId { get; set; }
		
		/// <summary>
        /// AppId
        /// </summary>
		public int ? AppId { get; set; }
		
				
	}
}