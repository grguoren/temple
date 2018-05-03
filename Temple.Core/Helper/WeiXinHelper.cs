using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Core.Helper
{
    public static class WeiXinHelper
    {
        /// <summary>
        /// 获取微信登录场景二维码
        /// </summary>
        /// <returns></returns>
        public static string GetWeixinImg()
        {
            string uri = @"https://weixin.zhihucn.com/web_api.ashx?action=qrcode_generation&sence_val=100&expire=300";

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
                    return result.data.Replace("https", "http");
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

        /// <summary>
        /// 获取微信扫码Openid
        /// </summary>
        /// <param name="tick"></param>
        /// <returns></returns>
        public static string CheckWeixinLogin(string tick)
        {
            string uri = @"https://weixin.zhihucn.com/web_api.ashx?action=qrcode_openid&ticket=" + tick;
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
                    return result.data;
                }
            }
            finally
            {
                client.Dispose();
            }
        }      
        
        public class WeixinResult
        {
            public int error_code;
            public string msg;
            public string data;
        }
    }
}
