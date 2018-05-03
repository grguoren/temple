using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// Maintain
    /// </summary>
	public partial class Maintain : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// TreeId
        /// </summary>
		public int  TreeId { get; set; }
		
		/// <summary>
        /// Date
        /// </summary>
		public string  Date { get; set; }
		
		/// <summary>
        /// TreeMoney
        /// </summary>
		public double ? TreeMoney { get; set; }
		
		/// <summary>
        /// Remark
        /// </summary>
		public string  Remark { get; set; }
		
		/// <summary>
        /// FriSerId
        /// </summary>
		public int ? FriSerId { get; set; }
		
				
	}
}