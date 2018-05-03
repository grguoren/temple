using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Temple.Core.Helper
{
    public class IPHelper
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
        /// 取得客户端真实IP。如果有代理则取第一个非内网地址   
        /// </summary>
        public static string ClientIP
        {
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
                                    return temparyip[i];    //不是内网的地址     
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
                return string.IsNullOrEmpty(result) ? "127.0.0.1" : result;
            }
        }

        public static string NewClientIP
        {
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
                                    return temparyip[i];    //找到不是内网的地址     
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
                return result;
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

        /// <summary>
        /// 获取公网IP
        /// </summary>
        /// <returns></returns>
        public static string GetIP()
        {
            string tempip = "";
            WebRequest wr = null;
            try
            {
                wr = WebRequest.Create("http://www.ip138.com/ips138.asp");
                Stream s = wr.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.Default);
                string all = sr.ReadToEnd(); //读取网站的数据

                int start = all.IndexOf("您的IP地址是：[") + 9;
                int end = all.IndexOf("]", start);
                tempip = all.Substring(start, end - start);
                sr.Close();
                s.Close();
            }
            catch
            {
            }
            finally
            {
                if (wr != null)
                {
                    wr.Abort();
                }
            }
            if (string.IsNullOrEmpty(tempip))
            {
                if (System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList.Length > 1)
                    tempip = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[1].ToString();
            }
            return tempip;
        }
        #region 根据访问者IP获取省份
        /// <summary>
        /// 根据IP获取省份 （调用的是淘宝的接口，可能会依赖别人的接口）
        /// </summary>
        /// <param name="IPAddress">访问者IP地址</param>
        /// <param name="level">显示地址层级（1 城市，2 省市，3 省市区县，4 省份 ）</param>
        /// <returns></returns>
        public static string GetProvicesByIP(string IPAddress, int? level)
        {
            string uri = @"http://ip.taobao.com/service/getIpInfo.php?ip=" + IPAddress;

            try
            {
                var Province = "";
                WebClient client = new WebClient();

                string jsonData = client.DownloadString(uri);
                IPCheckResult result = JsonConvert.DeserializeObject<IPCheckResult>(jsonData);
                if (result.code != 0)
                {
                    return "";
                }
                else
                {
                    switch (level)
                    {
                        case 1:
                            Province = result.data.city;
                            break;
                        case 2:
                            Province = result.data.region + result.data.city;
                            break;
                        case 3:
                            Province = result.data.region + result.data.city + result.data.county;
                            break;
                        case 4:
                            Province = result.data.region;
                            break;
                        default:
                            Province = "";
                            break;
                    }
                }
                return Province;
            }
            catch (Exception ex)
            {
                return "";//出现异常返回空就好，不要返回错误界面
            }
        }

        public static string GetSinaLocationByIP(string IPAddress, int? level)
        {
            string uri = @"http://int.dpool.sina.com.cn/iplookup/iplookup.php?format=js&ip=" + IPAddress;

            try
            {
                var Province = "";
                WebClient client = new WebClient();

                string jsonData = client.DownloadString(uri);
                jsonData = jsonData.Replace("var remote_ip_info =", "");
                jsonData = jsonData.Replace(";", "");
                SinaIPData result = JsonConvert.DeserializeObject<SinaIPData>(jsonData);

                switch (level)
                {
                    case 1:
                        Province = result.city == null ? "" : result.city;
                        break;
                    case 2:
                        Province = (result.province == null ? "" : result.province) + (result.city == null ? "" : result.city);
                        break;
                    case 3:
                        Province = (result.province == null ? "" : result.province) + (result.city == null ? "" : result.city) + result.country;
                        break;
                    case 4:
                        Province = result.province == null ? "" : result.province; 
                        break;
                    default:
                        Province = "";
                        break;
                }
                return Province;
            }
            catch (Exception ex)
            {
                return "";//出现异常返回空就好，不要返回错误界面
            }
        }

        public static string GetWeixinImg()
        {
            string uri = @"http://weixin.zx58.cn/web_api.ashx?action=qrcode_generation&sence_val=100&expire=300";


            WebClient client = new WebClient();

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

        public static string CheckWeixinLogin(string tick)
        {
            string uri = @"http://weixin.zx58.cn/web_api.ashx?action=qrcode_login&ticket=" + tick;
            WebClient client = new WebClient();

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

        public class WeixinResult
        {
            public int error_code;
            public string msg;
            public string data;
        }
        public class SinaIPData
        {
            public int ret;
            public int start;
            public int end;
            public string country;
            public string province;
            public string city;
            public string district;
            public string isp;
            public string type;
            public string desc;
        }
        /// <summary>
        /// 接口返回结果类
        /// </summary>
        public class IPCheckResult
        {

            /// <summary>
            /// 返回状态 
            /// </summary>
            public int code;

            /// <summary>
            /// 返回数据
            /// </summary>
            public IPAdderssData data;
        }

        public class SmSChcekResult
        {
            /// <summary>
            /// 返回状态 
            /// </summary>
            public int error_code;

            /// <summary>
            /// 返回原因
            /// </summary>
            public string reason;

            /// <summary>
            /// 返回结果
            /// </summary>
            public int? result;
        }

        /// <summary>
        /// IP所在地址信息
        /// </summary>
        public class IPAdderssData
        {
            /// <summary>
            /// 国家
            /// </summary>
            public string country;
            /// <summary>
            /// 国家ID
            /// </summary>
            public string country_id;
            /// <summary>
            /// 区域(华中、华北等)
            /// </summary>
            public string area;
            /// <summary>
            /// 区域ID
            /// </summary>
            public string area_id;
            /// <summary>
            /// 省份
            /// </summary>
            public string region;
            /// <summary>
            /// 省份ID
            /// </summary>
            public string region_id;
            /// <summary>
            /// 城市
            /// </summary>
            public string city;
            /// <summary>
            /// 城市ID
            /// </summary>
            public string city_id;
            /// <summary>
            /// 区县
            /// </summary>
            public string county;
            /// <summary>
            /// 区县ID
            /// </summary>
            public string county_id;
            public string isp;
            public string isp_id;
            public string ip;
        }
        #endregion

    }
}
