using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// User
    /// </summary>
	public partial class User : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// UserId
        /// </summary>
		public string  UserId { get; set; }
		
		/// <summary>
        /// UserName
        /// </summary>
		public string  UserName { get; set; }
		
		/// <summary>
        /// Mobile
        /// </summary>
		public string  Mobile { get; set; }
		
		/// <summary>
        /// OnBoardDate
        /// </summary>
		public DateTime  OnBoardDate { get; set; }
		
		/// <summary>
        /// ResignationDate
        /// </summary>
        public DateTime? ResignationDate { get; set; }
		
		/// <summary>
        /// Password
        /// </summary>
		public string  Password { get; set; }
		
		/// <summary>
        /// Status
        /// </summary>
		public bool  Status { get; set; }
		
		/// <summary>
        /// Remark
        /// </summary>
		public string  Remark { get; set; }
		
		/// <summary>
        /// FileName
        /// </summary>
		public string  FileName { get; set; }
		
				
	}
}