using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// Friend
    /// </summary>
	public partial class Friend : EntityBase
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
        /// Gender
        /// </summary>
		public int ? Gender { get; set; }
		
		/// <summary>
        /// BirthDate
        /// </summary>
		public string  BirthDate { get; set; }
		
		/// <summary>
        /// Email
        /// </summary>
		public string  Email { get; set; }
		
		/// <summary>
        /// Telephone
        /// </summary>
		public string  Telephone { get; set; }
		
		/// <summary>
        /// Mobile
        /// </summary>
		public string  Mobile { get; set; }
		
		/// <summary>
        /// Fax
        /// </summary>
		public string  Fax { get; set; }
		
		/// <summary>
        /// Address
        /// </summary>
		public string  Address { get; set; }
		
		/// <summary>
        /// Postalcode
        /// </summary>
		public string  Postalcode { get; set; }
		
		/// <summary>
        /// Password
        /// </summary>
		public string  Password { get; set; }
		
		/// <summary>
        /// ShopNum
        /// </summary>
		public int ? ShopNum { get; set; }
		
		/// <summary>
        /// HourNum
        /// </summary>
		public int  HourNum { get; set; }
		
		/// <summary>
        /// Magazine
        /// </summary>
		public bool  Magazine { get; set; }
		
		/// <summary>
        /// Appreciation
        /// </summary>
		public bool  Appreciation { get; set; }
		
		/// <summary>
        /// Status
        /// </summary>
		public int  Status { get; set; }
		
		/// <summary>
        /// Remark
        /// </summary>
		public string  Remark { get; set; }
		
				
	}
}