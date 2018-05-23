using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// Worship_pictures
    /// </summary>
	public partial class Worship_pictures : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// 圖片代號
        /// </summary>
		public string  Code { get; set; }
		
		/// <summary>
        /// 圖片名稱
        /// </summary>
		public string  Name { get; set; }
		
		/// <summary>
        /// 狀態 0 關閉 1 開放
        /// </summary>
		public bool  Status { get; set; }
		
		/// <summary>
        /// 備註
        /// </summary>
		public string  Remark { get; set; }
		
		/// <summary>
        /// 形態 1.上香  2.鮮花  3.水果  4.背景
        /// </summary>
		public string  Type { get; set; }
		
		/// <summary>
        /// 照片路徑
        /// </summary>
		public string  FileName { get; set; }
		
				
	}
}