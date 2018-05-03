using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// Tree
    /// </summary>
	public partial class Tree : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// FriSerId
        /// </summary>
		public string  FriSerId { get; set; }
		
		/// <summary>
        /// Name
        /// </summary>
		public string  Name { get; set; }
		
		/// <summary>
        /// Code
        /// </summary>
		public string  Code { get; set; }
		
		/// <summary>
        /// Location
        /// </summary>
		public string  Location { get; set; }
		
		/// <summary>
        /// Year
        /// </summary>
		public int ? Year { get; set; }
		
		/// <summary>
        /// DateStart
        /// </summary>
		public string  DateStart { get; set; }
		
		/// <summary>
        /// Ifaddress
        /// </summary>
		public bool ? Ifaddress { get; set; }
		
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
		
				
	}
}