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
            List<Temple.Domain.System> list = menuse.GetTopMenuList();
            List<MenuView> array = new List<MenuView>();
            foreach (var item in list)
            {
                MenuView model = new MenuView();

                //model.FID = item.FID;
                model.Id = item.Id;
                model.list = menuse.GetAllMenuListByPID(item.Id);
                //model.LinkUrl = item.LinkUrl;
                //model.MenuLevel = item.MenuLevel;
                model.Name = item.Name;
                //model.PID = item.PID;
                //model.Type = item.Type;
                model.Status = item.Status==true?1:0;
                model.Remark = item.Remark;
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
        public JsonResult GetTopMenuList()
        {
            List<Temple.Domain.System> list = menuse.GetTopMenuList();
            ResultModel model = new ResultModel();
            model.Count = 0;
            model.Data = list.ToList<object>();
            model.Status = (list != null && list.Count > 0);
            return Json(model);
        }

        [HttpPost]
        public string AddMenu(string name, string linkurl, int pid, string code, int status, string remark)
        {
            SystemPro model = new SystemPro();
            //model.CreateTime = DateTime.Now;
            //model.FID = fid;
            //model.LinkUrl = linkurl;
            //model.MenuLevel = 1;
            model.Name = name;
            model.LinkUrl = linkurl;
            //model.PID = pid;
            model.Status = status;
            model.Code = code;
            model.Remark = remark;
            model.System_id = pid;

           
            return menuse.AddMenu(model).ToString();
        }

        [HttpPost]
        public string DeleteMenu(int id)
        {
            menuse.DeleteRoleMenu(id);
            return menuse.DeleteMenu(id).ToString();
        }

        [HttpPost]
        public string UpdateMenu(int id, string name, string linkurl, string code, int status)
        {
            SystemPro model = menuse.GetMenuInfoByID(id);
            //model.LinkUrl = linkurl;
            model.Name = name;
            model.LinkUrl = linkurl;
            model.Code = code;
            model.Status = status;


            return menuse.UpdateMenu(model).ToString();
        }
    }
}
