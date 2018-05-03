using Temple.Admin.Models;
using Temple.Domain;
using Temple.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Temple.Admin.Controllers.Ajax
{
    public class Ajax_RoleController : BaseController
    {
        readonly IUserInfoService userse;
        readonly IRoleInfoService rolese;
        readonly IAuthorityInfoService authormenuse;
        public Ajax_RoleController(IUserInfoService _userse, IRoleInfoService _rolese, IAuthorityInfoService _authormenuse)
            : base(_userse)
        {
            userse = _userse;
            rolese = _rolese;
        }
        //
        // GET: /Ajax_Role/

        [HttpPost]
        public JsonResult GetRoleList()
        {
            List<Role> list = rolese.GetAllRoleList();
            ResultModel refs = new ResultModel();
            refs.Count = list.Count();
            refs.Data = list.ToList<object>();
            refs.Status = (list != null && list.Count > 0);
            return Json(refs);
        }

        [HttpPost]
        public string AddRole(string name,string code, string describe)
        {
            Role model = new Role();
            //model.CreateTime = DateTime.Now;
            model.RoleId = code;
            model.RoleName = name;
            model.Status = true;
            model.Remark = describe;
            return rolese.AddRole(model).ToString();
        }

        [HttpPost]
        public string DeleteRole(int id)
        {
            authormenuse.DeleteAuthorityRole(id);
            return rolese.DeleteRole(id).ToString();
        }

        [HttpPost]
        public string UpdateRole(int id, string name, string describe)
        {
            Role model = rolese.GetRoleInfoByID(id);
            model.RoleName = name;
            model.Remark = describe;
            return rolese.UpdateRole(model).ToString();
        }

        #region 设置用户关联角色
        [HttpPost]
        public JsonResult GetRole_UserList(int userid)
        {
            List<Role_User> list = rolese.GetRole_UserListByUserID(userid);
            List<string> str = new List<string>();
            list.ForEach(x => str.Add(x.RoleID.ToString()));
            ResultModel refs = new ResultModel();
            refs.Count = str.Count();
            refs.Data = str.ToList<object>();
            refs.Status = (str != null && str.Count > 0);
            return Json(refs);
        }

        [HttpPost]
        public string AddRole_User(string roleids, int userid)
        {
            rolese.AddRoleUser(roleids.Split(','), userid);
            return "True";
        }
        #endregion

    }
}
