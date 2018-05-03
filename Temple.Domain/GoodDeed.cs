﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// GoodDeed
    /// </summary>
	public partial class GoodDeed : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// Code
        /// </summary>
		public string  Code { get; set; }
		
		/// <summary>
        /// Name
        /// </summary>
		public string  Name { get; set; }
		
		/// <summary>
        /// Status
        /// </summary>
		public bool  Status { get; set; }
		
		/// <summary>
        /// Remark
        /// </summary>
		public string  Remark { get; set; }
		
		/// <summary>
        /// Type
        /// </summary>
		public string  Type { get; set; }
		
				
	}
}