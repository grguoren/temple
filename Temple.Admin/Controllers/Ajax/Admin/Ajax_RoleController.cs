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
        public Ajax_RoleController(IUserInfoService _userse, IRoleInfoService _rolese)
            : base(_userse)
        {
            userse = _userse;
            rolese = _rolese;
        }
        //
        // GET: /Ajax_Role/

        [HttpPost]
        public JsonResult GetRoleList(int pid)
        {
            List<Role> list = rolese.GetAllRoleList(pid);
            ResultModel refs = new ResultModel();
            refs.Count = list.Count();
            refs.Data = list.ToList<object>();
            refs.Status = (list != null && list.Count > 0);
            return Json(refs);
        }

        [HttpPost]
        public string AddRole(string name, string Remark, string code, int status)
        {
            Role model = new Role();
            //model.CreateTime = DateTime.Now;
            model.Code = code;
            model.Name = name;
            model.Status = status == 1 ? true : false;
            model.Remark = Remark;
            return rolese.AddRole(model).ToString();
        }

        [HttpPost]
        public string DeleteRole(int id)
        {
            userse.DeleteUserRole(id);//删除角色绑定的用户
            return rolese.DeleteRole(id).ToString();
        }

        [HttpPost]
        public string UpdateRole(int id, string name, string Remark, string code,int status)
        {
            Role model = rolese.GetRoleInfoByID(id);
            model.Name = name;
            model.Code = code;
            model.Status = status == 1 ? true : false;
            model.Remark = Remark;
            return rolese.UpdateRole(model).ToString();
        }

        #region 设置用户关联角色
        [HttpPost]
        public JsonResult GetRole_UserList(int userid)
        {
            List<User_Role> list = rolese.GetRole_UserListByUserID(userid);
            List<string> str = new List<string>();
            list.ForEach(x => str.Add(x.Role_Id.ToString()));
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

        #region 设置角色关联程式
        [HttpPost]
        public JsonResult GetProgramList(int pid)
        {
            List<SystemPro> list = userse.GetAllProgramList(pid);
            ResultModel refs = new ResultModel();
            refs.Count = list.Count();
            refs.Data = list.ToList<object>();
            refs.Status = (list != null && list.Count > 0);
            return Json(refs);
        }

        [HttpPost]
        public JsonResult GetProgram_RoleList(int roleid)
        {
            List<RolePermission> list = userse.GetAuthority_RoleListByRoleID(roleid);
            List<string> str = new List<string>();
            list.ForEach(x => str.Add(x.SysPro_Id.ToString()));
            ResultModel refs = new ResultModel();
            refs.Count = str.Count();
            refs.Data = str.ToList<object>();
            refs.Status = (str != null && str.Count > 0);
            return Json(refs);
        }

        [HttpPost]
        public string AddProgramList_Role(string authorityids, int roleid)
        {
            userse.AddAuthorityRole(authorityids.Split(','), roleid);
            return "True";
        }
        #endregion

    }
}
