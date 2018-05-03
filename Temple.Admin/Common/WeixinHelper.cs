using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using WxPayAPI;

namespace Temple.Admin.Common
{
    public class WeixinHelper
    {
        /// <summary>
        /// 构造参数
        /// </summary>
        /// <returns></returns>
        public static string GetJsApiParameters(string openid,int money)
        {
            int iMin = 1000;
            int iMax = 9999;
            string pname = money == 200 ? "推荐奖" : (money == 800 ? "预约投保" : "投保返现");
            Random rd = new Random();//构造随机数
            string strMch_billno = WxPayConfig.MCHID + DateTime.Now.ToString("yyyyMMddHHmmss") + rd.Next(iMin, iMax).ToString();
            WxPayData jsApiParam = new WxPayData();
            jsApiParam.SetValue("act_name", "预约投保领红包");//活动名称
            jsApiParam.SetValue("client_ip", "120.26.69.175");//这里填写的是我本机的内网ip，实际应用不知道需不需要改。
            jsApiParam.SetValue("mch_billno", strMch_billno);//商户订单号,商户订单号（每个订单号必须唯一）组成：mch_id+yyyymmdd+10位一天内不能重复的数字。 接口根据商户订单号支持重入，如出现超时可再调用。
            jsApiParam.SetValue("mch_id", WxPayConfig.MCHID);//商户号,微信支付分配的商户号
            jsApiParam.SetValue("nonce_str", WxPayApi.GenerateNonceStr());//随机字符串，不长于32位
            jsApiParam.SetValue("remark", "备注信息，活动真实有效");//备注信息
            jsApiParam.SetValue("re_openid", openid);//接收者的openid
            jsApiParam.SetValue("send_name", pname);//商户名称,红包发送者名称
            jsApiParam.SetValue("total_amount", money);//红包金额，单位分
            jsApiParam.SetValue("total_num", 1);//红包发放总人数
            jsApiParam.SetValue("wishing", "感谢您参加活动，请领取红包！");//红包祝福语
            jsApiParam.SetValue("wxappid", WxPayConfig.APPID);//公众账号appid,微信分配的公众账号ID（企业号corpid即为此appId）。接口传入的所有appid应该为公众号的appid（在mp.weixin.qq.com申请的），不能为APP的appid（在open.weixin.qq.com申请的）。
            jsApiParam.SetValue("sign", jsApiParam.MakeSign());//签名,切记，这个签名参数必须放在最后，因为他生成的签名，跟前面的参数有关系

            string parameters = jsApiParam.ToXml();
            return parameters;
        }

        /// <summary>
        /// 提交请求
        /// </summary>
        /// <param name="posturl"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static string WxRedPackPost(string posturl, string postData)
        {
            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            Encoding encoding = Encoding.UTF8;

            WxPayData jsApiParam = new WxPayData();
            byte[] data = encoding.GetBytes(postData);
            // 准备请求...  
            try
            {
                //CerPath证书路径，这里是本机的路径，实际应用中，按照实际情况来填写
                string certPath = System.Web.HttpContext.Current.Server.MapPath(WxPayConfig.SSLCERT_PATH);
                //证书密码
                string password = WxPayConfig.SSLCERT_PASSWORD;
                X509Certificate2 cert = new System.Security.Cryptography.X509Certificates.X509Certificate2(certPath, password, X509KeyStorageFlags.MachineKeySet);

                // 设置参数  
                request = WebRequest.Create(posturl) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                request.CookieContainer = cookieContainer;//不可少（个人理解为，返回的时候需要验证）
                request.AllowAutoRedirect = true;
                request.Method = "POST";
                request.ContentType = "text/xml";
                request.ContentLength = data.Length;
                request.ClientCertificates.Add(cert);//添加证书请求
                outstream = request.GetRequestStream();
                outstream.Write(data, 0, data.Length);
                outstream.Close();
                //发送请求并获取相应回应数据  
                response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求  
                instream = response.GetResponseStream();
                sr = new StreamReader(instream, encoding);
                //返回结果网页（html）代码  
                string content = sr.ReadToEnd();
                string err = string.Empty;
                var model = jsApiParam.FromXml(content);

                return model != null?model["err_code_des"].ToString():"";

            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return string.Empty;
            }
            finally
            {
                outstream.Close();
                instream.Close();
                response.Close();
                if (request != null)
                {
                    request.Abort();
                }
            }
        }  
    }
}