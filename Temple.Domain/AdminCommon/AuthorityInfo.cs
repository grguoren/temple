using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Temple.Core.Entity;
namespace Temple.Domain
{
	 	//admin_AuthorityInfo
    public class AuthorityInfo : EntityBase
	{
   		     
      	/// <summary>
		/// ID
        /// </summary>		
		private int _id;
        public int ID
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// 权限名称
        /// </summary>		
		private string _name;
        public string Name
        {
            get{ return _name; }
            set{ _name = value; }
        }        
		/// <summary>
		/// 权限别名,权限类型
        /// </summary>		
		private string _type;
        public string Type
        {
            get{ return _type; }
            set{ _type = value; }
        }        
		/// <summary>
		/// 权限级别
        /// </summary>		
		private int _authoritylevel;
        public int AuthorityLevel
        {
            get{ return _authoritylevel; }
            set{ _authoritylevel = value; }
        }        
		/// <summary>
		/// 父级ID
        /// </summary>		
		private int _fid;
        public int FID
        {
            get{ return _fid; }
            set{ _fid = value; }
        }        
		/// <summary>
		/// 上一级ID
        /// </summary>		
		private int _pid;
        public int PID
        {
            get{ return _pid; }
            set{ _pid = value; }
        }        
		/// <summary>
		/// 更新时间
        /// </summary>		
		private DateTime _updatetime;
        public DateTime UpdateTime
        {
            get{ return _updatetime; }
            set{ _updatetime = value; }
        }        
		/// <summary>
		/// 创建时间
        /// </summary>		
		private DateTime _createtime;
        public DateTime CreateTime
        {
            get{ return _createtime; }
            set{ _createtime = value; }
        }
        /// <summary>
        /// 权限状态
        /// </summary>		
        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        } 
	}
}

