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
                if (item.Password.Length >= 16)
                {
                    item.Password = EncryptHelper.Decrypt(item.Password);
                }
            }
            ResultModel model = new ResultModel();
            model.Count = list.TotalCount;
            model.Data = list.ToList<object>();
            model.Status = (list != null && list.Count > 0);
            return Json(model);
        }

        [HttpPost]
        public string AddUser(string UserId,string UserName, string FileName, string Remark, string Password)
        {
            User model = new User();
            model.OnBoardDate = DateTime.Now;
            model.FileName = FileName;
            model.UserId = UserId;
            model.Remark = Remark;
            model.Password = Password;
            model.Password = EncryptHelper.Encrypt(Password);
            model.Status = true;
            model.ResignationDate = model.ResignationDate;
            model.UserName = UserName;

            return userse.AddUser(model).ToString();
        }
        

        [HttpPost]
        public string UpdateUser(int ID, string UserId, string UserName,string ResignationDate, string FileName, string Remark, string Password)
        {
            User model = userse.GetUserInfoByID(ID);
            model.FileName = FileName;
            model.UserId = UserId;
            model.Password = Password;
            model.Password = EncryptHelper.Encrypt(Password);
            model.Remark = Remark;
            model.ResignationDate = DateTime.Now;
            model.UserName = UserName;
            return userse.UpdateUser(model).ToString();
        }

        [HttpPost]
        public string DeleteUser(int id)
        {
            return userse.DeleteUser(id).ToString();
        }

    }
}
