using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// FriendSer
    /// </summary>
	public partial class FriendSer : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// FriId
        /// </summary>
		public int  FriId { get; set; }
		
		/// <summary>
        /// GoodId
        /// </summary>
		public int  GoodId { get; set; }
		
		/// <summary>
        /// SerId
        /// </summary>
		public int  SerId { get; set; }
		
		/// <summary>
        /// RecordDate
        /// </summary>
		public string  RecordDate { get; set; }
		
		/// <summary>
        /// RecordId
        /// </summary>
		public int ? RecordId { get; set; }
		
		/// <summary>
        /// RecordCode
        /// </summary>
		public string  RecordCode { get; set; }
		
		/// <summary>
        /// PaymentId
        /// </summary>
		public int ? PaymentId { get; set; }
		
		/// <summary>
        /// Tip
        /// </summary>
		public int  Tip { get; set; }
		
		/// <summary>
        /// Receipt
        /// </summary>
		public string  Receipt { get; set; }
		
		/// <summary>
        /// Appreciation
        /// </summary>
		public string  Appreciation { get; set; }
		
		/// <summary>
        /// AppreciationArtifi
        /// </summary>
		public string  AppreciationArtifi { get; set; }
		
		/// <summary>
        /// UserId
        /// </summary>
		public int ? UserId { get; set; }
		
		/// <summary>
        /// AppreciationPrint
        /// </summary>
		public bool  AppreciationPrint { get; set; }
		
		/// <summary>
        /// RecId
        /// </summary>
		public int ? RecId { get; set; }
		
		/// <summary>
        /// MeetingId
        /// </summary>
		public int ? MeetingId { get; set; }
		
		/// <summary>
        /// ReportDate
        /// </summary>
		public string  ReportDate { get; set; }
		
		/// <summary>
        /// Showinfo
        /// </summary>
		public string  Showinfo { get; set; }
		
		/// <summary>
        /// ShowDate
        /// </summary>
		public string  ShowDate { get; set; }
		
		/// <summary>
        /// Reduce
        /// </summary>
		public int ? Reduce { get; set; }
		
		/// <summary>
        /// IfPuton
        /// </summary>
		public bool  IfPuton { get; set; }
		
		/// <summary>
        /// IfFinish
        /// </summary>
		public bool  IfFinish { get; set; }
		
		/// <summary>
        /// PrayInfo
        /// </summary>
		public string  PrayInfo { get; set; }
		
		/// <summary>
        /// IfInstallment
        /// </summary>
		public bool  IfInstallment { get; set; }
		
		/// <summary>
        /// InstallmentTimes
        /// </summary>
		public int ? InstallmentTimes { get; set; }
		
		/// <summary>
        /// InstallmentMoney
        /// </summary>
		public int ? InstallmentMoney { get; set; }
		
		/// <summary>
        /// InstallmentFirstDate
        /// </summary>
		public string  InstallmentFirstDate { get; set; }
		
		/// <summary>
        /// InstallmentNow
        /// </summary>
		public int ? InstallmentNow { get; set; }
		
		/// <summary>
        /// InstallmentPayDate
        /// </summary>
		public string  InstallmentPayDate { get; set; }
		
		/// <summary>
        /// IfGod
        /// </summary>
		public bool  IfGod { get; set; }
		
		/// <summary>
        /// PrintNum
        /// </summary>
		public string  PrintNum { get; set; }
		
		/// <summary>
        /// MemberYear
        /// </summary>
		public int  MemberYear { get; set; }
		
		/// <summary>
        /// SanctuaryId
        /// </summary>
		public int ? SanctuaryId { get; set; }
		
		/// <summary>
        /// Remark
        /// </summary>
		public string  Remark { get; set; }
		
				
	}
}