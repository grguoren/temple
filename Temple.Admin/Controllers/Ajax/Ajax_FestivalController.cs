using Temple.Admin.Models;
using Temple.Domain;
using Temple.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Temple.Core.Pager;

namespace Temple.Admin.Controllers.Ajax
{
    public class Ajax_FestivalController : BaseController
    {
        readonly IUserInfoService userse;
        readonly IFestivalService festivalse;

        public Ajax_FestivalController(IUserInfoService _userse, IFestivalService _festivalse)
            : base(_userse)
        {
            this.userse = _userse;
            this.festivalse = _festivalse;
        }


        #region 法會
        [HttpPost]
        public JsonResult GetFestivalList(int page, int size)
        {
            IPagedList<Festival> list = festivalse.GetFestivalList(page, size);

            ResultModel model = new ResultModel();
            model.Count = list.TotalCount;
            model.Data = list.ToList<object>();
            model.Status = (list != null && list.Count > 0);
            return Json(model);
        }

        /// <summary>
        /// 添加法會
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "法會-添加数据")]
        public string AddFestival(string jsonModel)
        {
            bool res = false;
            Festival model = new Festival();
            model = Newtonsoft.Json.JsonConvert.DeserializeObject<Festival>(jsonModel);
            if (model.Date != null)
            {
                model.Date = StringHelper.TwDateToWestDate(model.Date.ToString());
            }
            res = festivalse.AddFestival(model);
            return res.ToString();
        }


        /// <summary>
        /// 更新法會
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "法會-更新数据")]
        public string UpdateFestival(string jsonModel)
        {
            bool res = false;
            Festival model = new Festival();
            model = Newtonsoft.Json.JsonConvert.DeserializeObject<Festival>(jsonModel);
            Festival info = festivalse.GetFestivalByID(model.Id);

            info.Code = model.Code;
            info.Info = model.Info;
            info.Location = model.Location;
            info.Remark = model.Remark;
            if (model.Date != null)
            {
                info.Date = StringHelper.TwDateToWestDate(model.Date.ToString());
            }
            info.Name = model.Name;
            res = festivalse.UpdateFestival(info);
            return res.ToString();
        }
        [HttpPost]
        public JsonResult GetFestivalById(int id)
        {
            Festival model = festivalse.GetFestivalByID(id);
            model.Remark = Server.HtmlDecode(model.Remark);

            return Json(model);
        }

        [HttpPost]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "法會-删除数据")]
        public string DeleteFestival(int id)
        {
            return festivalse.DeleteFestival(id).ToString();
        }
        #endregion
    }
}
