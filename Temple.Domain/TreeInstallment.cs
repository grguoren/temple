using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// TreeInstallment
    /// </summary>
	public partial class TreeInstallment : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// FriSerId
        /// </summary>
		public int  FriSerId { get; set; }
		
		/// <summary>
        /// FeeMoney
        /// </summary>
		public double ? FeeMoney { get; set; }
		
		/// <summary>
        /// PaymentId
        /// </summary>
		public int ? PaymentId { get; set; }
		
		/// <summary>
        /// RecordDate
        /// </summary>
		public string  RecordDate { get; set; }
		
		/// <summary>
        /// Installment
        /// </summary>
		public int ? Installment { get; set; }
		
		/// <summary>
        /// Remark
        /// </summary>
		public string  Remark { get; set; }
		
		/// <summary>
        /// RecordNum
        /// </summary>
		public string  RecordNum { get; set; }
		
				
	}
}