using Temple.Admin.Models;
using Temple.Domain;
using Temple.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Temple.Core.Pager;

namespace Temple.Admin.Controllers.Ajax
{
    public class Ajax_AngelController : BaseController
    {
        readonly IUserInfoService userse;
        readonly IAngelService angelse;

        public Ajax_AngelController(IUserInfoService _userse, IAngelService _angelse)
            : base(_userse)
        {
            this.userse = _userse;
            this.angelse = _angelse;
        }


        #region 聖示護法
        [HttpPost]
        public JsonResult GetAngelList(int page, int size)
        {
            IPagedList<Angel> list = angelse.GetAngelList(page, size);

            ResultModel model = new ResultModel();
            model.Count = list.TotalCount;
            model.Data = list.ToList<object>();
            model.Status = (list != null && list.Count > 0);
            return Json(model);
        }

        /// <summary>
        /// 添加聖示護法
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "聖示護法-添加数据")]
        public string AddAngel(string jsonModel)
        {
            bool res = false;
            Angel model = new Angel();
            model = Newtonsoft.Json.JsonConvert.DeserializeObject<Angel>(jsonModel);
            if (model.Start_date != null)
            {
                model.Start_date = StringHelper.TwDateToWestDate(model.Start_date.ToString());
            }
            if (model.Add_Date != null)
            {
                model.Add_Date = StringHelper.TwDateToWestDate(model.Add_Date.ToString());
            }
            res = angelse.AddAngel(model);
            return res.ToString();
        }


        /// <summary>
        /// 更新聖示護法
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "聖示護法-更新数据")]
        public string UpdateAngel(string jsonModel)
        {
            bool res = false;
            Angel model = new Angel();
            model = Newtonsoft.Json.JsonConvert.DeserializeObject<Angel>(jsonModel);
            Angel info = angelse.GetAngelByID(model.Id);

            info.Years = model.Years;
            info.Finish_YN = model.Finish_YN;
            info.Remark = model.Remark;
            if (model.Start_date != null)
            {
                info.Start_date = StringHelper.TwDateToWestDate(model.Start_date.ToString());
            }
            if (model.Add_Date != null)
            {
                info.Add_Date = StringHelper.TwDateToWestDate(model.Add_Date.ToString());
            }
            info.Name = model.Name;
            res = angelse.UpdateAngel(info);
            return res.ToString();
        }
        [HttpPost]
        public JsonResult GetAngelById(int id)
        {
            Angel model = angelse.GetAngelByID(id);
            model.Remark = Server.HtmlDecode(model.Remark);

            return Json(model);
        }

        [HttpPost]
        [Temple.Admin.Attributes.LoggingFilter(Remark = "聖示護法-删除数据")]
        public string DeleteAngel(int id)
        {
            return angelse.DeleteAngel(id).ToString();
        }
        #endregion

    }
}
