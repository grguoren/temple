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
        /// 使用者帐号
        /// </summary>
		public string  UserId { get; set; }
		
		/// <summary>
        /// 使用者姓名
        /// </summary>
		public string  UserName { get; set; }
		
		/// <summary>
        /// 移动手机
        /// </summary>
		public string  Mobile { get; set; }
		
		/// <summary>
        /// 到职日期
        /// </summary>
		public DateTime  OnBoardDate { get; set; }
		
		/// <summary>
        /// 离职日期
        /// </summary>
        public DateTime? ResignationDate { get; set; }
		
		/// <summary>
        /// 密码
        /// </summary>
		public string  Password { get; set; }
		
		/// <summary>
        /// 状态 0 关 1 开
        /// </summary>
		public bool  Status { get; set; }
		
		/// <summary>
        /// 备注
        /// </summary>
		public string  Remark { get; set; }
		
		/// <summary>
        /// 图片路径
        /// </summary>
		public string  FileName { get; set; }
		
				
	}
}