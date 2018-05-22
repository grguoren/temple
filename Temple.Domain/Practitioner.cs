using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// 被保興人
    /// </summary>
	public partial class Practitioner : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// 保舉人編號
        /// </summary>
		public string  Code { get; set; }
		
		/// <summary>
        /// 被保興人姓名
        /// </summary>
		public string  Name { get; set; }
		
		/// <summary>
        /// 性別    1.男        2.女
        /// </summary>
		public bool ? Gender { get; set; }
		
		/// <summary>
        /// 生日
        /// </summary>
		public string  BirthDate { get; set; }
		
		/// <summary>
        /// 往生日期
        /// </summary>
		public string  DeathDate { get; set; }
		
		/// <summary>
        /// 保舉日期
        /// </summary>
		public string  RecommendedDate { get; set; }
		
		/// <summary>
        /// 列位日期
        /// </summary>
		public string  TitleDate { get; set; }
		
		/// <summary>
        /// 列位年度
        /// </summary>
		public string  TitleYear { get; set; }
		
		/// <summary>
        /// 修行期數
        /// </summary>
		public int ? PracticeNumber { get; set; }
		
		/// <summary>
        /// 累積減修期
        /// </summary>
		public int ? DiscountPNumber { get; set; }
		
		/// <summary>
        /// 證道日期
        /// </summary>
		public string  ProveWayDate { get; set; }
		
		/// <summary>
        /// 證道季節  1.春     2.秋
        /// </summary>
		public int ? ProveWaySeason { get; set; }
		
		/// <summary>
        /// 最新證道果位
        /// </summary>
		public string  LatestTitle { get; set; }
		
		/// <summary>
        /// 被保舉人型態  1.修士  2.證道仙佛 
        /// </summary>
		public int ? RecommendedType { get; set; }
		
		/// <summary>
        /// 最新晉升日期
        /// </summary>
		public string  PromoteDate { get; set; }
		
		/// <summary>
        /// 晉升季節  1.春     2.秋
        /// </summary>
		public int ? PromoteSeason { get; set; }
		
		/// <summary>
        /// 晉升年度(農曆)
        /// </summary>
		public string  PromoteLunarYear { get; set; }
		
		/// <summary>
        /// 最新晉升仙佛果位
        /// </summary>
		public string  LatestBuddha { get; set; }
		
		/// <summary>
        /// 最新牌位位置
        /// </summary>
		public string  TitlePosition { get; set; }
		
		/// <summary>
        /// 照片路徑
        /// </summary>
		public string  FileName { get; set; }
		
		/// <summary>
        /// 備注
        /// </summary>
		public string  Remark { get; set; }
		
		/// <summary>
        /// 累積功德金(修士)
        /// </summary>
		public int  MonkAmount { get; set; }
		
		/// <summary>
        /// 累積功德金(證道)
        /// </summary>
		public int  ProveWayAmount { get; set; }
		
				
	}
}