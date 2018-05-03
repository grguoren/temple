using Temple.Admin.Common;
using Temple.Admin.Models.MenuView;
using Temple.Core.Helper;
using Temple.Domain;
using Temple.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Temple.Admin.Controllers
{
    public class HomeController : BaseController
    {
        readonly IUserInfoService userse;
        readonly IMenuInfoService menuse;
        readonly IRoleInfoService rolese;
        readonly IAuthorityInfoService authorityse;
        public HomeController(IUserInfoService _userse, IMenuInfoService _menuse, IRoleInfoService _rolese, IAuthorityInfoService _authorityse)
            : base(_userse)
        {
            userse = _userse;
            menuse = _menuse;
            rolese = _rolese;
            authorityse = _authorityse;
        }
        //
        // GET: /Home/
        
        public ActionResult Index()
        {
            ViewBag.LoginName = base.currentMember.NickName;
            return View();
        }

        public ActionResult Error()
        {
            string message = TempData["ExceptionAttributeMessages"].ToString();
            ViewBag.ErrorMsg = message;
            return View();
        }

        public ActionResult _MenuLeft()
        {
            List<MenuView> array = new List<MenuView>();
            List<WuxiSystem> list = new List<WuxiSystem>();
            list = menuse.GetTopMenuList();
            if (currentMember != null)
            {
                if (currentMember.Id == 1 || currentMember.Id == 45)
                {
                    foreach (var item in list)
                    {
                        MenuView model = new MenuView();
                        //model.CreateTime = item.CreateTime;
                        //model.FID = item.FID;
                        model.Id = item.Id;
                        model.list = menuse.GetAllMenuListByPID(item.Id);
                        //model.LinkUrl = item.LinkUrl;
                        model.CodeName = item.Name;
                        //model.PID = item.PID;
                        model.Status = item.Status == true ? 1 : 0;
                        //model.Type = item.Type;
                        //model.UpdateTime = item.UpdateTime;
                        //model.ImportantLevel = item.ImportantLevel;

                        array.Add(model);
                    }
                }
                else
                {
                    foreach (var item in list)
                    {
                        MenuView model = new MenuView();
       
                        model.Id = item.Id;
                        //model.LinkUrl = item.LinkUrl;

                        model.CodeName = item.Name;
                
                        model.Status = item.Status==true?1:0;
  
                        model.list = new List<SystemPro>();

                        array.Add(model);
                    }

                    //List<SystemPro> slist = menuse.GetUserMenu(currentMember.Id);
                    List<SystemPro> slist = ViewBag.UserMenuList;
                    foreach (var item in slist)
                    {
                        MenuView model = new MenuView();
  
                        model.Id = item.Id;
                        //model.LinkUrl = item.LinkUrl;
                        model.CodeName = item.CodeName;
                        //model.PID = item.PID;
                        model.Status = item.Status;
                        //model.Type = item.Type;
                        //model.UpdateTime = item.UpdateTime;
                        //model.ImportantLevel = item.ImportantLevel;

                        MenuView info = array.Where(x => x.Id == model.Id).FirstOrDefault();
                        if (info != null)
                        {
                            info.list.Add(model);
                        }
                    }
                    array = array.Where(x => x.list != null && x.list.Count > 0).ToList();
                }
            }
            ViewBag.List = array;
            string idstr = "153|157";
            if (Request.Cookies["ZHCloudMenuOpen"] != null)
            {
                HttpCookie closecok = Request.Cookies["ZHCloudMenuOpen"];
                if (closecok != null)
                {
                    idstr = closecok["openId"].ToString();
                }
            }
            else
            {
                HttpCookie _cookie = new HttpCookie("ZHCloudMenuOpen");//初使化并设置Cookie的名称
                DateTime dt = DateTime.Now;
                TimeSpan ts = new TimeSpan(1, 0, 0, 0, 0);//过期时间为1天
                _cookie.Expires = dt.Add(ts);//设置过期时间
                _cookie.Values.Add("openId", idstr);
                Response.AppendCookie(_cookie);
            }

            ViewBag.OpenList = idstr;
            return View();
        }

        /// <summary>
        /// 导航打开的cookie
        /// </summary>
        /// <param name="type">是否打开</param>
        /// <param name="id">对应的大类ID</param>
        /// <returns></returns>
        public string AddMenuCookie(int type, int id)
        {
            string idstr = "";
            string newidstr = "";
            if (type == 0)//关闭时，去掉cookie里面的值
            {
                //是否已有值
                if (Request.Cookies["ZHCloudMenuOpen"] != null)
                {
                    HttpCookie closecok = Request.Cookies["ZHCloudMenuOpen"];
                    if (closecok != null)
                    {
                        idstr = closecok["openId"].ToString();
                    }
                    if (!string.IsNullOrEmpty(idstr))
                    {
                        var list = idstr.Split('|');
                        foreach (string item in list)
                        {
                            if (item == id.ToString())//去掉
                            {
                                continue;
                            }
                            else
                            {
                                newidstr = item + '|'; 
                            }
                        }
                    }
                }
            }
            else//加入
            {
                if (Request.Cookies["ZHCloudMenuOpen"] != null)
                {
                    HttpCookie closecok = Request.Cookies["ZHCloudMenuOpen"];
                    if (closecok != null)
                    {
                        idstr = closecok["openId"].ToString();
                    }
                    newidstr = idstr + '|' +id;
                }
            }
            HttpCookie _cookie = new HttpCookie("ZHCloudMenuOpen");//初使化并设置Cookie的名称
            DateTime dt = DateTime.Now;
            TimeSpan ts = new TimeSpan(1, 0, 0, 0, 0);//过期时间为1天
            _cookie.Expires = dt.Add(ts);//设置过期时间
            _cookie.Values.Add("openId", newidstr);
            Response.AppendCookie(_cookie);
            return "true";
        }

        public ActionResult SendTestPaper(string mopenid,int money)
        {
            string strData = "", strUrl = "https://api.mch.weixin.qq.com/mmpaymkttransfers/sendredpack", strResult = "";
            strData = WeixinHelper.GetJsApiParameters(mopenid, money);
            strResult = WeixinHelper.WxRedPackPost(strUrl, strData);
            ViewBag.Result = strResult;
            return View();
        }
    }
}
