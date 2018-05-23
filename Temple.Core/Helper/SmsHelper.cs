using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using System.Threading;

namespace Temple.Core.Helper
{
    public class SmsHelper
    {
        private SmsHelper() { }

        private static string url = "http://sendcloud.sohu.com/smsapi/send";
        private static string smsUser = "SMS_MSG";
        private static string smsKey = "Bus02uzHlnQCSfC6TgQAn4ZhuvOS46Mj";
        public static ReturnModel SendMsg(int tempid, string phone, string vars)
        {
            url = "http://sendcloud.sohu.com/smsapi/send";
            SortedList sl = new SortedList();
            sl["smsUser"] = smsUser;
            sl["templateId"] = tempid;
            sl["phone"] = phone;
            sl["vars"] = vars;

            string para = string.Empty;
            foreach (DictionaryEntry item in sl)
            {
                para += "&" + item.Key + "=" + item.Value;
            }

            string signature = smsKey + para + "&" + smsKey;
            para += "&signature=" + EncryptHelper.MD5_Encrypt(signature);
            string post_data = para.Trim('&');

            url = url + "?" + post_data;

            ReturnModel model = new ReturnModel();

            string errInfo;
            string res = HttpHelper.SendHttpGet(url, "", out errInfo);
            if (!string.IsNullOrEmpty(errInfo))
            {
                model.statusCode = -100;
                model.message = errInfo;
            }
            else
            {
                if (string.IsNullOrEmpty(res))
                {
                    model.statusCode = -101;
                    model.message = "接口返回值为空";
                }
                else
                {
                    model = JsonConvert.DeserializeObject<ReturnModel>(res);
                }
            }

            return model;
        }

        #region 阿里云短信平台发送
        //产品名称:云通信短信API产品,开发者无需替换
        const String product = "Dysmsapi";
        //产品域名,开发者无需替换
        const String domain = "dysmsapi.aliyuncs.com";

        // TODO 此处需要替换成开发者自己的AK(在阿里云访问控制台寻找)
        const String accessKeyId = "LTAIn07UwJRln5Ay";
        const String accessKeySecret = "YhfASPZ7pO6hjcIIN31ckGOBJGrATP";

        /// <summary>
        /// 调用阿里云短信发送服务
        /// </summary>
        /// <param name="tempid">必填:短信模板-可在短信控制台中找到 SMS_129295067</param>
        /// <param name="phone">必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为1000个手机号码</param>
        /// <param name="vars">可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为{\"小明\":\"123\"}</param>
        /// <returns></returns>
        public static SendSmsResponse sendSms(string tempid, string phone, string vars)
        {
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId, accessKeySecret);
            DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", product, domain);
            IAcsClient acsClient = new DefaultAcsClient(profile);
            SendSmsRequest request = new SendSmsRequest();
            SendSmsResponse response = null;
            try
            {

                //必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为1000个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式
                request.PhoneNumbers = phone;
                //必填:短信签名-可在短信控制台中找到
                request.SignName = "芳华教育";
                //必填:短信模板-可在短信控制台中找到
                request.TemplateCode = tempid;
                //可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为
                request.TemplateParam = vars;
                //可选:outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者
                request.OutId = "yourOutId";
                //请求失败这里会抛ClientException异常
                response = acsClient.GetAcsResponse(request);

            }
            catch (ServerException e)
            {
                Console.WriteLine(e.ErrorCode);
            }
            catch (ClientException e)
            {
                Console.WriteLine(e.ErrorCode);
            }
            return response;

        }
        /// <summary>
        /// 批量短信发送
        /// </summary>
        /// <returns></returns>
        public static SendBatchSmsResponse sendSms()
        {
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId, accessKeySecret);
            DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", product, domain);

            IAcsClient acsClient = new DefaultAcsClient(profile);
            SendBatchSmsRequest request = new SendBatchSmsRequest();
            //request.Protocol = ProtocolType.HTTPS;
            //request.TimeoutInMilliSeconds = 1;

            SendBatchSmsResponse response = null;
            try
            {

                //必填:待发送手机号。支持JSON格式的批量调用，批量上限为100个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式
                request.PhoneNumberJson = "[\"1500000000\",\"1500000001\"]";
                //必填:短信签名-支持不同的号码发送不同的短信签名
                request.SignNameJson = "[\"云通信\",\"云通信\"]";
                //必填:短信模板-可在短信控制台中找到
                request.TemplateCode = "SMS_1000000";
                //必填:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为
                //友情提示:如果JSON中需要带换行符,请参照标准的JSON协议对换行符的要求,比如短信内容中包含\r\n的情况在JSON中需要表示成\\r\\n,否则会导致JSON在服务端解析失败
                request.TemplateParamJson = "[{\"name\":\"Tom\", \"code\":\"123\"},{\"name\":\"Jack\", \"code\":\"456\"}]";
                //可选-上行短信扩展码(扩展码字段控制在7位或以下，无特殊需求用户请忽略此字段)
                //request.SmsUpExtendCodeJson = "[\"90997\",\"90998\"]";

                //请求失败这里会抛ClientException异常
                response = acsClient.GetAcsResponse(request);

            }
            catch (ServerException e)
            {
                Console.Write(e.ErrorCode);
            }
            catch (ClientException e)
            {
                Console.Write(e.ErrorCode);
                Console.Write(e.Message);
            }
            return response;

        }
        #endregion

        public static string GetTemp(int tempid, string vars)
        {
            string temp = "";
            var model = JsonConvert.DeserializeObject<ParaModel>(vars);
            switch (tempid)
            {
                case 462:
                    temp = string.Format("尊敬的{0}：你在無極證道的登录信息如下：登录帐号：{1} 密码：{2} 请妥善保管。【無極證道】", model.name, model.uname, model.password);
                    break;
                case 461:
                    temp = string.Format("尊敬的{0}：您收到了一条新伙伴加盟通知。{1}的{2}（{3}、{4}）于{5}在您的网站申请了加盟事业，请及时回复。【無極證道】", model.name1, model.area, model.name2, model.phone, model.qq, model.time);
                    break;
                case 460:
                    temp = string.Format("尊敬的{0}：您于{1}成功申请了無極證道名片设计{2}，我们将尽快与您取得联系并提供相应服务。【無極證道】", model.name, model.date, model.type);
                    break;
                case 459:
                    temp = string.Format("尊敬的{0}：{1}您收到了一条新的留言。客户{2}（手机{3}、QQ{4}）对您网站上的{5}感兴趣并留言。请及时登录网站查看并回复！【無極證道】", model.name, model.date, model.uname, model.mobile, model.qq, model.brand);
                    break;
                case 458:
                    temp = string.Format("尊敬的{0}：您有一笔新的订单。{1}{2}{3}（{4}）在您网站订购了{5}，请抓紧联系！【無極證道】", model.name1, model.time, model.area, model.name2, model.phone, model.product);
                    break;
                case 457:
                    temp = string.Format("尊敬的{0}：{1}{2}{3}（{4}、{5}）在無極證道发布了{6}需求信息。请及时登录网站查看详情并回复！【無極證道】", model.name, model.dtime, model.area, model.uname, model.phone, model.qq, model.title);
                    break;
                case 456:
                    temp = string.Format("尊敬的{0}：您好，您的会员即将到期，请及时续费。您的無極證道会员有效期至{1}【無極證道】", model.name, model.date);
                    break;
                case 453:
                    temp = string.Format("恭喜您成功註册了無極證道免费会员（您的用户名：{0} 密码：{1}）,请妥善保管。【無極證道】", model.name, model.password);
                    break;
                case 452:
                    temp = string.Format("验证码：{0}，您正在通过手机号註册無極證道会员账号。30分钟内有效，请勿泄露。【無極證道】", model.code);
                    break;
                default:
                    break;
            }
            return temp;
        }
    }


    public enum SmsType : int
    {
        //找回密码通知 tp=尊敬的%name%：你在無極證道的登录信息如下：登录帐号：%uname% 密码：%password%  请妥善保管。
        FindPassword = 462,
        //新加盟通知 tp=尊敬的%name%：您收到了一条新伙伴加盟通知。%content%在您的网站申请了加盟事业，请及时回复。
        Joino = 461,
        //名片设计通知 tp=尊敬的%name%：您于%date%成功申请了無極證道名片设计%type%，我们将尽快与您取得联系并提供相应服务。
        CardDesign = 460,
        //新留言通知  tp=尊敬的%name%：%date%您收到了一条新的留言。客户%uname%（手机%mobile%、QQ%qq%）对您网站上的%brand%感兴趣并留言。请及时登录网站查看并回复！
        Message = 459,
        //新订单通知 tp=尊敬的%name%：您有一笔新的订单。%content%在您网站订购了%product%，请抓紧联系！
        Order = 458,
        //新需求通知 tp=尊敬的%name%：%content%在無極證道发布了%title%需求信息。请及时登录网站查看详情并回复！
        Demand = 457,
        //到期提醒通知 tp=尊敬的%name%：您好，您的会员即将到期，请及时续费。您的無極證道会员有效期至%date%
        UserExpired = 456,
        //会员註册成功通知 tp=恭喜您成功註册了無極證道免费会员（您的用户名：%name%   密码：%password%）,请妥善保管。
        RegisterSuccess = 453,
        //手机号註册验证码  tp=验证码：%code%，您正在通过手机号註册無極證道会员账号。30分钟内有效，请勿泄露。
        Code = 452
    }
    public class ParaModel
    {
        public string name { get; set; }
        public string uname { get; set; }
        public string password { get; set; }
        public string name1 { get; set; }
        public string name2 { get; set; }
        public string area { get; set; }
        public string phone { get; set; }
        public string qq { get; set; }
        public string time { get; set; }
        public string date { get; set; }
        public string type { get; set; }
        public string mobile { get; set; }
        public string brand { get; set; }
        public string product { get; set; }
        public string dtime { get; set; }
        public string title { get; set; }
        public string code { get; set; }
    }
    public class ReturnModel
    {
        public string message { get; set; }
        public object info { get; set; }
        public bool result { get; set; }
        public int statusCode { get; set; }
    }
}
