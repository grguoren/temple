using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Temple.Core.Helper
{
    public class IPHelp
    {
        #region IP地址互转整数
        /// <summary>
        /// 将IP地址转为整数形式
        /// </summary>
        /// <returns>整数</returns>
        public static long IP2Long(IPAddress ip)
        {
            int x = 3;
            long o = 0;
            foreach (byte f in ip.GetAddressBytes())
            {
                o += (long)f << 8 * x--;
            }
            return o;
        }
        /// <summary>
        /// 将整数转为IP地址
        /// </summary>
        /// <returns>IP地址</returns>
        public static IPAddress Long2IP(long l)
        {
            byte[] b = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                b[3 - i] = (byte)(l >> 8 * i & 255);
            }
            return new IPAddress(b);
        }
        #endregion
        /// <summary>
        /// 获得客户端IP
        /// </summary>
        public static string ClientIP
        {
            //get
            //{
            //    string ip;
            //    string[] temp;
            //    bool isErr = false;
            //    if (HttpContext.Current.Request.ServerVariables["HTTP_X_ForWARDED_For"] == null)
            //        ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            //    else
            //        ip = HttpContext.Current.Request.ServerVariables["HTTP_X_ForWARDED_For"].ToString();
            //    if (ip.Length > 15)
            //        isErr = true;
            //    else
            //    {
            //        temp = ip.Split('.');
            //        if (temp.Length == 4)
            //        {
            //            for (int i = 0; i < temp.Length; i++)
            //            {
            //                if (temp[i].Length > 3) isErr = true;
            //            }
            //        }
            //        else
            //            isErr = true;
            //    }

            //    if (isErr)
            //        return "1.1.1.1";
            //    else
            //        return ip;
            //}
            get
            {
                string result = String.Empty;
                result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (result != null && result != String.Empty)
                {
                    //可能有代理     
                    if (result.IndexOf(".") == -1)    //没有"."肯定是非IPv4格式     
                        result = null;
                    else
                    {
                        if (result.IndexOf(",") != -1) //有","，估计多个代理。取第一个不是内网的IP。
                        {
                            result = result.Replace(" ", "").Replace("\"", "");
                            string[] temparyip = result.Split(",;".ToCharArray());
                            for (int i = 0; i < temparyip.Length; i++)
                            {
                                if (IsIPAddress(temparyip[i]) && temparyip[i].Substring(0, 3) != "10." && temparyip[i].Substring(0, 7) != "192.168" && temparyip[i].Substring(0, 7) != "172.16.")
                                {
                                    return temparyip[i];    //到不是内网的地址     
                                }
                            }
                        }
                        else if (IsIPAddress(result)) //代理即是IP格式     
                            return result;
                        else
                            result = null;    //代理中的内容 非IP，取IP     
                    }
                }
                string IpAddress = (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null && HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != String.Empty) ? HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] : HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                if (null == result || result == String.Empty)
                    result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                if (result == null || result == String.Empty)
                    result = HttpContext.Current.Request.UserHostAddress;


                return !string.IsNullOrEmpty(result) ? result : "127.0.0.1";
            }
        }

        public static string SftClientIP
        {

            get
            {
                string result = String.Empty;
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]; ;
                if (result != null && result != String.Empty)
                {
                    String clientIP = "";
                    if (System.Web.HttpContext.Current != null)
                    {
                        clientIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                        if (string.IsNullOrEmpty(clientIP) || (clientIP.ToLower() == "unknown"))
                        {
                            clientIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_REAL_IP"];
                            if (string.IsNullOrEmpty(clientIP))
                            {
                                clientIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                            }
                        }
                        else
                        {
                            clientIP = clientIP.Split(',')[0];
                        }
                    }
                    return clientIP;
                }
                //string IpAddress = (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null && HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != String.Empty) ? HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] : HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                //if (null == result || result == String.Empty)
                //    result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                //if (result == null || result == String.Empty)
                //    result = HttpContext.Current.Request.UserHostAddress;


                return !string.IsNullOrEmpty(result) ? result : "127.0.0.1";
            }
        }

        /// <summary>
        ///判断是否是IP格式 
        ///判断是否是IP地址格式 0.0.0.0 
        /// </summary>
        public static bool IsIPAddress(string str1)
        {
            if (str1 == null || str1 == string.Empty || str1.Length < 7 || str1.Length > 15) return false;
            string regformat = @"^\d{1,3}[\.]\d{1,3}[\.]\d{1,3}[\.]\d{1,3}$";
            Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);
            return regex.IsMatch(str1);
        }
    }
}
