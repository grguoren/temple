using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// RecFri
    /// </summary>
	public partial class RecFri : EntityBase
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
        /// RecId
        /// </summary>
		public int ? RecId { get; set; }
		
		/// <summary>
        /// AppId
        /// </summary>
		public int ? AppId { get; set; }
		
		/// <summary>
        /// RecFriDate
        /// </summary>
		public string  RecFriDate { get; set; }
		
				
	}
}