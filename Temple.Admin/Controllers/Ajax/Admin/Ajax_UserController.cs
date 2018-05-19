using Temple.Admin.Common;
using Temple.Admin.Models;
using Temple.Core.Pager;
using Temple.Core.Tools;
using Temple.Domain;
using Temple.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Temple.Admin.Controllers.Ajax
{
    public class Ajax_UserController : BaseController
    {
        readonly IUserInfoService userse;
        public Ajax_UserController(IUserInfoService _userse)
            : base(_userse)
        {
            userse = _userse;
        }

        //
        // GET: /Ajax_User/

        [HttpPost]
        public JsonResult GetUserList(int page, int size, string username, string FileName)
        {
            IPagedList<User> list = userse.GetUserList(page, size, username, FileName);
            foreach (User item in list)
            {
                if (item.Passwd.Length >= 16)
                {
                    item.Passwd = EncryptHelper.Decrypt(item.Passwd);
                }
            }
            ResultModel model = new ResultModel();
            model.Count = list.TotalCount;
            model.Data = list.ToList<object>();
            model.Status = (list != null && list.Count > 0);
            return Json(model);
        }

        [HttpPost]
        public string AddUser(string jsonModel)
        {
       
            bool res = false;
            User model = new User();
            model = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(jsonModel);
            if (model.OnBoardDate != null)
            {
                model.OnBoardDate = StringHelper.TwDateToWestDate(model.OnBoardDate.ToString());
            }
   
            model.Passwd = EncryptHelper.Encrypt(model.Passwd);
            res = userse.AddUser(model);
            return res.ToString();
        }
        

        [HttpPost]
        public string UpdateUser(string jsonModel)
        {
            bool res = false;
            User model = new User();
            model = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(jsonModel);
            User info = userse.GetUserInfoByID(model.Id);

            info.FileName = !string.IsNullOrEmpty(model.FileName)?model.FileName:"";
            info.Account = model.Account;
            info.Passwd = EncryptHelper.Encrypt(model.Passwd);
            info.Remark = model.Remark;
            if (model.ResignationDate != null)
            {
                info.ResignationDate = DateTime.Now;
            }
            info.Name = model.Name;
            return userse.UpdateUser(model).ToString();
        }

        [HttpPost]
        public JsonResult GetUserById(int id)
        {
            User model = userse.GetUserInfoByID(id);
            model.Passwd = EncryptHelper.Decrypt(model.Passwd);
            //model.OnBoardDate = Convert.ToDateTime(StringHelper.WestDateToTwDate(model.OnBoardDate.ToString()));

            return Json(model);
        }

        [HttpPost]
        public string DeleteUser(int id)
        {
            return userse.DeleteUser(id).ToString();
        }

    }
}
