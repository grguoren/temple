using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// Member_Good_project
    /// </summary>
	public partial class Member_Good_project : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// 鸞友系統序號
        /// </summary>
		public int  Member_Id { get; set; }
		
		/// <summary>
        /// 被保舉人系統序號
        /// </summary>
		public int ? Practitioner_id { get; set; }
		
		/// <summary>
        /// 叩稟日期
        /// </summary>
		public string  Ask_Date { get; set; }
		
		/// <summary>
        /// 功德項目系統序號
        /// </summary>
		public int  Good_project_id { get; set; }
		
		/// <summary>
        /// 服務項目系統序號
        /// </summary>
		public int  Service_name_id { get; set; }
		
		/// <summary>
        /// 祈求事項
        /// </summary>
		public string  Ask_Info { get; set; }
		
		/// <summary>
        /// 聖示內容
        /// </summary>
		public string  Instructions { get; set; }
		
		/// <summary>
        /// 聖示日期
        /// </summary>
		public string  Confirmation_date { get; set; }
		
		/// <summary>
        /// 修士減修期
        /// </summary>
		public int ? DiscountPNumber { get; set; }
		
		/// <summary>
        /// 入帳單位系統序號
        /// </summary>
		public int ? Accounting_unit_id { get; set; }
		
		/// <summary>
        /// 付款方式系統序號
        /// </summary>
		public int ? Payment_item_id { get; set; }
		
		/// <summary>
        /// 入帳日期
        /// </summary>
		public string  Receipt_date { get; set; }
		
		/// <summary>
        /// 入帳編號
        /// </summary>
		public string  Receipt_number { get; set; }
		
		/// <summary>
        /// 功德金
        /// </summary>
		public int  Donate { get; set; }
		
		/// <summary>
        /// 發票號碼
        /// </summary>
		public string  Invoice_number { get; set; }
		
		/// <summary>
        /// 感謝狀編號
        /// </summary>
		public string  Thanks_number { get; set; }
		
		/// <summary>
        /// 手開感謝狀編號
        /// </summary>
		public string  Hand_Thanks_number { get; set; }
		
		/// <summary>
        /// 經手人系統序號
        /// </summary>
		public int ? User_Id { get; set; }
		
		/// <summary>
        /// 是否已印感謝狀
        /// </summary>
		public string  Thanks_number_YN { get; set; }
		
		/// <summary>
        /// 是否刊登 Y/N
        /// </summary>
		public string  Publish_YN { get; set; }
		
		/// <summary>
        /// 是否已結案 Y/N
        /// </summary>
		public bool  Finish_YN { get; set; }
		
		/// <summary>
        /// 是否分期 Ｙ/ N
        /// </summary>
		public string  Installment_YN { get; set; }
		
		/// <summary>
        /// 法會系統序號
        /// </summary>
		public int ? Testival_Id { get; set; }
		
		/// <summary>
        /// 繳納期數
        /// </summary>
		public int ? Installment_Times { get; set; }
		
		/// <summary>
        /// 每期金額
        /// </summary>
		public int ? Installment_Money { get; set; }
		
		/// <summary>
        /// 第一期日期
        /// </summary>
		public string  Installment_First_date { get; set; }
		
		/// <summary>
        /// 目前第幾期
        /// </summary>
		public double ? Installment_Now { get; set; }
		
		/// <summary>
        /// 下次繳款日期
        /// </summary>
		public string  Installment_Pay_Date { get; set; }
		
		/// <summary>
        /// 是否已轉護法神 Ｙ/ N 
        /// </summary>
		public string  Angel_YN { get; set; }
		
		/// <summary>
        /// 助印訂單號碼
        /// </summary>
		public string  Order_Id { get; set; }
		
		/// <summary>
        /// 衛道委員年限
        /// </summary>
		public int  Member_years { get; set; }
		
		/// <summary>
        /// 聖示護法系統序號
        /// </summary>
		public int ? Angel_Id { get; set; }
		
		/// <summary>
        /// 備註
        /// </summary>
		public string  Remark { get; set; }
		
				
	}
}