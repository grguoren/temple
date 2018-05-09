using Temple.Admin.Models;
using Temple.Admin.Models.MenuView;
using Temple.Domain;
using Temple.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Temple.Admin.Controllers.Ajax
{
    public class Ajax_MenuController : BaseController
    {
        readonly IUserInfoService userse;
        readonly IMenuInfoService menuse;
        public Ajax_MenuController(IUserInfoService _userse, IMenuInfoService _menuse)
            : base(_userse)
        {
            userse = _userse;
            menuse = _menuse;
        }
        //
        // GET: /Ajax_Menu/

        [HttpPost]
        public JsonResult GetMenuList(int pid)
        {
            List<SystemPro> list = menuse.GetAllMenuListByPID(pid);
            List<MenuView> array = new List<MenuView>();
            foreach (var item in list)
            {
                MenuView model = new MenuView();

                //model.FID = item.FID;
                model.Id = item.Id;
                model.list = menuse.GetAllMenuListByPID(item.Id);
                //model.LinkUrl = item.LinkUrl;
                //model.MenuLevel = item.MenuLevel;
                model.CodeName = item.CodeName;
                //model.PID = item.PID;
                model.Status = item.Status;
                //model.Type = item.Type;
                //model.UpdateTime = item.UpdateTime;
                //model.Rank = item.Rank;
                //model.ImportantLevel = item.ImportantLevel;


                array.Add(model);
            }
            ResultModel refs = new ResultModel();
            refs.Count = array.Count();
            refs.Data = array.ToList<object>();
            refs.Status = (array != null && array.Count > 0);
            return Json(refs);
        }

        [HttpPost]
        public string AddMenu(string name, string linkurl, int pid, int fid, string rank, int status, int imlevel)
        {
            SystemPro model = new SystemPro();
            //model.CreateTime = DateTime.Now;
            //model.FID = fid;
            //model.LinkUrl = linkurl;
            //model.MenuLevel = 1;
            model.CodeName = name;
            //model.PID = pid;
            model.Status = status;
            model.SysCode = "sys";
            model.Remark = rank;
            model.SysId = imlevel;

           
            return menuse.AddMenu(model).ToString();
        }

        [HttpPost]
        public string DeleteMenu(int id)
        {
            menuse.DeleteRoleMenu(id);
            return menuse.DeleteMenu(id).ToString();
        }

        [HttpPost]
        public string UpdateMenu(int id, string name, string linkurl, string rank, int status, int imlevel)
        {
            SystemPro model = menuse.GetMenuInfoByID(id);
            //model.LinkUrl = linkurl;
            model.CodeName = name;

            model.SysCode = rank;
            model.Status = status;


            return menuse.UpdateMenu(model).ToString();
        }
    }
}
