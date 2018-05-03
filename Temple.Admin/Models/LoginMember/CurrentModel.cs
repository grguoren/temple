using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Temple.Admin.Models.LoginMember
{
    public class CurrentModel
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 所属部门
        /// </summary>
        public string DepartName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 权限IDs,List<int>
        /// </summary>
        public List<int> AuthorityList { get; set; }
        /// <summary>
        /// 获取用户菜单
        /// </summary>
        public List<Temple.Admin.Models.MenuView.MenuView> MenuList { get; set; }
    }
}