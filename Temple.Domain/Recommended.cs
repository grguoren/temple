using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// Recommended
    /// </summary>
	public partial class Recommended : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// RecommendedId
        /// </summary>
		public string  RecommendedId { get; set; }
		
		/// <summary>
        /// RecommendedName
        /// </summary>
		public string  RecommendedName { get; set; }
		
		/// <summary>
        /// Gender
        /// </summary>
		public bool ? Gender { get; set; }
		
		/// <summary>
        /// BirthDate
        /// </summary>
		public string  BirthDate { get; set; }
		
		/// <summary>
        /// DeathDate
        /// </summary>
		public string  DeathDate { get; set; }
		
		/// <summary>
        /// RecommendedDate
        /// </summary>
		public string  RecommendedDate { get; set; }
		
		/// <summary>
        /// TitleDate
        /// </summary>
		public string  TitleDate { get; set; }
		
		/// <summary>
        /// TitleYear
        /// </summary>
		public string  TitleYear { get; set; }
		
		/// <summary>
        /// PracticeNumber
        /// </summary>
		public int ? PracticeNumber { get; set; }
		
		/// <summary>
        /// DiscountPNumber
        /// </summary>
		public int ? DiscountPNumber { get; set; }
		
		/// <summary>
        /// MonkAmount
        /// </summary>
		public int ? MonkAmount { get; set; }
		
		/// <summary>
        /// ProveWayDate
        /// </summary>
		public string  ProveWayDate { get; set; }
		
		/// <summary>
        /// ProveWaySeason
        /// </summary>
		public int ? ProveWaySeason { get; set; }
		
		/// <summary>
        /// LatestTitle
        /// </summary>
		public string  LatestTitle { get; set; }
		
		/// <summary>
        /// RecommendedType
        /// </summary>
		public int ? RecommendedType { get; set; }
		
		/// <summary>
        /// PromoteDate
        /// </summary>
		public string  PromoteDate { get; set; }
		
		/// <summary>
        /// PromoteSeason
        /// </summary>
		public int ? PromoteSeason { get; set; }
		
		/// <summary>
        /// PromoteLunarYear
        /// </summary>
		public string  PromoteLunarYear { get; set; }
		
		/// <summary>
        /// LatestBuddha
        /// </summary>
		public string  LatestBuddha { get; set; }
		
		/// <summary>
        /// ProveWayAmount
        /// </summary>
		public int ? ProveWayAmount { get; set; }
		
		/// <summary>
        /// TitlePosition
        /// </summary>
		public string  TitlePosition { get; set; }
		
		/// <summary>
        /// FileName
        /// </summary>
		public string  FileName { get; set; }
		
		/// <summary>
        /// Remark
        /// </summary>
		public string  Remark { get; set; }
		
				
	}
}