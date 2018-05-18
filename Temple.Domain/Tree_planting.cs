using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// Tree_planting
    /// </summary>
	public partial class Tree_planting : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// 鸞友功德服務系統序號
        /// </summary>
		public string  Member_Good_project_id { get; set; }
		
		/// <summary>
        /// 醫仙稱謂
        /// </summary>
		public string  Angel_name { get; set; }
		
		/// <summary>
        /// 原靈樹編號
        /// </summary>
		public string  Number { get; set; }
		
		/// <summary>
        /// 靈樹位置
        /// </summary>
		public string  Location { get; set; }
		
		/// <summary>
        /// 植種年限
        /// </summary>
		public int ? Years { get; set; }
		
		/// <summary>
        /// 植種起始日期
        /// </summary>
		public string  Start_date { get; set; }
		
		/// <summary>
        /// 是否註籍
        /// </summary>
		public bool ? Address_YN { get; set; }
		
		/// <summary>
        /// 是否結案 Y/N
        /// </summary>
		public string  Finish_YN { get; set; }
		
		/// <summary>
        /// 備注
        /// </summary>
		public string  Remark { get; set; }
		
		/// <summary>
        /// 鸞友系統序號
        /// </summary>
		public int ? Member_Id { get; set; }
		
				
	}
}