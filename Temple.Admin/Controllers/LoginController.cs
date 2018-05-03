using Temple.Admin.Common;
using Temple.Core.Cache;
using Temple.Core.Tools;
using Temple.Domain;
using Temple.IService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Temple.Admin.Controllers
{
    public class LoginController : Controller
    {
        readonly IUserInfoService userse;
        private static RedisCacheManager redisCache = new RedisCacheManager();
        private int outTime = 120;
        public LoginController(IUserInfoService _userse)
        {
            userse = _userse;
        }
        //
        // GET: /Login/
        public ActionResult QrLogin()
        {
            return View();
        }

        public ActionResult Login(string token)
        {
            
            return View();

            token = Server.UrlDecode(token);
            #region 获取扫码用户标记
            string openid = "";
            if (!string.IsNullOrEmpty(token) && redisCache.HasKey(token))
            {
                openid = redisCache.Get<string>(token);
            }
            #endregion
            #region 防模拟登录
            Session.Timeout = outTime;
            var guid = Guid.NewGuid();
            Session["LoginCheck"] = guid;
            #endregion


            ViewBag.CheckLogin = guid; //防模拟登录

            string nip = Temple.Core.Helper.IPHelper.ClientIP;

            
            return View();
            

        }
        public bool isCompanyIpVister(string ip)
        {
            string ipstr = "";
            string cip1 = getIP("zhqq.f3322.net");
            string cip2 = getIP("zhwol.f3322.net");

            UserCookie testcookie = new UserCookie("bxtestcookie");
            testcookie = new UserCookie(Convert.ToInt32(55555), ip + "|" + cip1 + "|" + cip2, "bxtestcookie", true);

            if (ip == cip1 || ip == cip2)
                return true;
            return false;
        }
        ///<summary>  
        /// 传入域名返回对应的IP 转载请注明来自 http://www.shang11.com  
        ///</summary>  
        ///<param name="domain">域名</param>  
        ///<returns></returns>  
        public static string getIP(string domain)
        {
           
            try
            {
                IPAddress ip;
                if (IPAddress.TryParse(domain, out ip))
                    return ip.ToString();
                else
                    return Dns.GetHostEntry(domain).AddressList[0].ToString();
            }
            catch (Exception)
            {
                return "0000";
            }

        }
        public string LoginAjax(string name, string pwd, string tpwd)
        {
            string ret = "yes";
            try
            {
                string guid = "";
                if (Session["LoginCheck"] != null)
                {
                    guid = Session["LoginCheck"].ToString();
                }
                //if (tpwd != guid && guid!="")
                //{
                //    ret = "禁止登陆,请确定您有该后台权限，非法登陆必究！";
                //    return ret;
                //}


                #region 是否开启登陆区域限制
                //SaleInfo saleModel = this.salesse.GetUserInfoByRealName("superadmin");

                //if (saleModel != null && saleModel.sState == 1 && name != "zhihupz")
                //{
                //    string ip = Temple.Core.Helper.IPHelper.ClientIP;
                //    string cityName = Temple.Core.Helper.IPHelper.GetSinaLocationByIP(ip, 1);
                //    if (string.IsNullOrEmpty(cityName) || (!string.IsNullOrEmpty(cityName) && !(cityName.Contains("长沙") || cityName.Contains("重庆")) && ip != "127.0.0.1" && ip != "::1"))
                //    {
                //        ret = cityName + "禁止登陆，,请确定您有该后台权限，非法登陆必究！" + ip;
                //    }
                //}
                #endregion

                User user = new User();
                user.UserName = name;
                user.Password = name != "adminzh" ? EncryptHelper.Encrypt(pwd) : pwd;
                //user.Pwd = pwd;
                user = userse.LoginUser(user);

                UserCookie usercookie = new UserCookie("templeuser");
                if (user != null)
                {
                    usercookie = new UserCookie(Convert.ToInt32(user.Id), name, "templeuser", true);

                    if (usercookie != null)
                    {
                        Temple.Admin.Models.LoginMember.CurrentModel model = new Temple.Admin.Models.LoginMember.CurrentModel();

                        user = userse.GetUserInfoByID(user.Id);
                        user.OnBoardDate = DateTime.Now;//记录最近登陆时间
                        userse.UpdateUser(user);
                        model.Id = user.Id;
                        model.NickName = user.FileName;
                        model.UserName = user.UserName;

                        Temple.Admin.Common.CurrentCache.Insert(model.Id, model);
                    }
                    //List<MenuInfo> slist = userse.GetUserMenu(user.Id);
                    //if (slist.Where(x => x.LinkUrl.Contains("SystemCountManage/Index")).ToList().Count <= 0)//有没有统计首页的权限
                    //{
                    //    
                    //}
                    ret = "nomain";
                }
                else
                {
                    ret = "帐号密码错误";
                }
                return ret;
                //string strData = WeixinHelper.GetJsApiParameters("oeH_rs9bl3Hn702-CIVo0a3yjFhI", 100);
                //string strUrl = "https://api.mch.weixin.qq.com/mmpaymkttransfers/sendredpack";//这个就是发送红包的API接口了

                //string strResult = WeixinHelper.WxRedPackPost(strUrl, strData);
                //return strResult;
            }
            catch (Exception ex)
            {
                return "数据错误，请稍候再试";
                throw ex;
            }
        }
        public string hasScan(string tick, string d)
        {
            string str = "";
            tick = Server.UrlDecode(tick);
            if (!string.IsNullOrEmpty(tick) && redisCache.HasKey(tick))
            {
                str = redisCache.Get<string>(tick);
            }
            return str;
        }
        public string weixinImg()
        {
            string uri = @"http://weixin.zx58.cn/web_api.ashx?action=qrcode_generation&sence_val=200&expire=300";

            WebClient client = new WebClient();

            try
            {
                string jsonData = client.DownloadString(uri);
                WeixinResult result = JsonConvert.DeserializeObject<WeixinResult>(jsonData);
                if (result.error_code != 0)
                {
                    return "";
                }
                else
                {
                    //localCache.Set(uri, result.data, 299);//299秒过期
                    return result.data;
                }
            }
            catch (Exception ex)
            {
                return "";
            }
            finally
            {
                client.Dispose();
            }
        }

        public bool HasIn(string openId)
        {
            string uri = "";

            uri = @"http://manage.zx58.cn/Login/bxCheckOpenid?id=" + openId;


            WebClient client = new WebClient();

            try
            {
                string jsonData = client.DownloadString(uri);

                if (jsonData == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                client.Dispose();
            }
        }
        public ActionResult LoginOut()
        {
            UserCookie usercookie = new UserCookie("templeuser");
            usercookie.DelUserCookie("templeuser");
            Response.Redirect("/Login/Login");
            return View();
        }

        public class WeixinResult
        {
            public int error_code;
            public string msg;
            public string data;
        }
    }
}
