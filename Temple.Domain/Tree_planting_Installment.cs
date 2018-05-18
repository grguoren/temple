using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// Tree_planting_Installment
    /// </summary>
	public partial class Tree_planting_Installment : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// 鸞友功德服務系統序號
        /// </summary>
		public int  Member_Good_project_id { get; set; }
		
		/// <summary>
        /// 入帳編號
        /// </summary>
		public string  Member_Good_project_Receipt_number { get; set; }
		
		/// <summary>
        /// 繳納期數
        /// </summary>
		public int ? Installment_Times { get; set; }
		
		/// <summary>
        /// 備註
        /// </summary>
		public string  Remark { get; set; }
		
		/// <summary>
        /// 繳交金額
        /// </summary>
		public double  FeeMoney { get; set; }
		
		/// <summary>
        /// 付款方式系統序號
        /// </summary>
		public int  Payment_Id { get; set; }
		
		/// <summary>
        /// 入帳日期
        /// </summary>
		public string  Record_Date { get; set; }
		
				
	}
}