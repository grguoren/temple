using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Temple.Core.Entity;

namespace Temple.Domain
{
	/// <summary>
    /// Tree_maintenance
    /// </summary>
	public partial class Tree_maintenance : EntityBase
	{
		/// <summary>
        /// Id
        /// </summary>
		public int  Id { get; set; }
		
		/// <summary>
        /// 原靈樹植種系統序號
        /// </summary>
		public int  Tree_planting_id { get; set; }
		
		/// <summary>
        /// 養護日期
        /// </summary>
		public string  Maintenance_date { get; set; }
		
		/// <summary>
        /// 養護金額
        /// </summary>
		public double  Money { get; set; }
		
		/// <summary>
        /// 備註
        /// </summary>
		public string  Remark { get; set; }
		
		/// <summary>
        /// 鸞友功德服務系統序號
        /// </summary>
		public int ? Member_Good_project_id { get; set; }
		
				
	}
}