using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Temple.Admin.Models;
using Temple.Core.Pager;
using Temple.Domain;
using Temple.IService;

namespace Temple.Admin.Controllers.Ajax
{
    public class Ajax_ServiceController : BaseController
    {
        readonly IUserInfoService userse;
        readonly IBasicService basicse;

        public Ajax_ServiceController(IUserInfoService _userse, IBasicService _basicse)
            : base(_userse)
        {
            this.userse = _userse;
            this.basicse = _basicse;
        }

        #region 圖片
        [HttpPost]
        public JsonResult GetPictureList(int page, int size)
        {
            IPagedList<Worship_pictures> list = basicse.GetPictureList(page, size);

            ResultModel model = new ResultModel();
            model.Count = list.TotalCount;
            model.Data = list.ToList<object>();
            model.Status = (list != null && list.Count > 0);
            return Json(model);
        }

        /// <summary>
        /// 添加圖片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "圖片-添加数据")]
        public string AddPicture(string jsonModel)
        {
            bool res = false;
            Worship_pictures model = new Worship_pictures();
            model = Newtonsoft.Json.JsonConvert.DeserializeObject<Worship_pictures>(jsonModel);

            res = basicse.AddPicture(model);
            return res.ToString();
        }
        /// <summary>
        /// 更新圖片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "圖片-更新数据")]
        public string UpdatePicture(string jsonModel)
        {
            bool res = false;
            Worship_pictures model = new Worship_pictures();
            model = Newtonsoft.Json.JsonConvert.DeserializeObject<Worship_pictures>(jsonModel);
            Worship_pictures info = basicse.GetPictureByID(model.Id);

            info.FileName = !string.IsNullOrEmpty(model.FileName) ? model.FileName : "";

            info.Code = model.Code;
            info.Name = model.Name;
            info.Remark = Server.HtmlEncode(model.Remark);
            info.Type = model.Type;
            info.Status = model.Status;

            res = basicse.UpdatePicture(info);
            return res.ToString();
        }
        [HttpPost]
        public JsonResult GetPictureById(int id)
        {
            Worship_pictures model = basicse.GetPictureByID(id);
            model.Remark = Server.HtmlDecode(model.Remark);

            return Json(model);
        }

        [HttpPost]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "圖片-删除数据")]
        public string DeletePicture(int id)
        {
            return basicse.DeletePicture(id).ToString();
        }
        #endregion
    }
}
