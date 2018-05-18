using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// Ｍobile_worship_pictures
    /// </summary>
	public partial class Ｍobile_worship_pictures : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// 祭拜圖片序號
        /// </summary>
		public int ? Worship_pictures_id { get; set; }
		
		/// <summary>
        /// 手機祭拜系統序號
        /// </summary>
		public int ? Ｍobile_worship_id { get; set; }
		
		/// <summary>
        /// 型  態 1.背景  2.上香  3.鮮花  4.水果
        /// </summary>
		public string  Type { get; set; }
		
				
	}
}