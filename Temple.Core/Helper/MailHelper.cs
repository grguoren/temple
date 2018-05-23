using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Core.Helper
{
    /// <summary>
    /// 邮件发送帮助类
    /// </summary>
    public class MailHelper
    {
        private MailHelper() { }


        private static void SendEmail(string clientHost, string emailAddress, string receiveAddress,
          string userName, string password, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(emailAddress);
            mail.To.Add(new MailAddress(receiveAddress));
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            SmtpClient client = new SmtpClient();
            client.Host = clientHost;
            client.Credentials = new NetworkCredential(userName, password);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                client.SendAsync(mail, null);
            }
            catch (Exception)
            {

            }
        }

        public static void SendEmail(string subject, string content)
        {
            //TODO
            return;
        }



        /// <summary>
        /// 发送测试成功邮件
        /// </summary>
        /// <param name="email"></param>
        /// <param name="userName"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        public static string SendZXEmail(string email,string body,string subject)
        {
            try
            {
                MailMessage mailMsg = new MailMessage();

                // 收件人地址，用正确邮件地址替代
                mailMsg.To.Add(new MailAddress(email));
                // 发信人，用正确邮件地址替代
                mailMsg.From = new MailAddress(Mail.Plugin.EmailConfig.SMTPUserName, "無極證道");

                // 邮件主题
                mailMsg.Subject = subject;
                string html = body;
                // 邮件正文内容
                string text = "来自無極證道的一封邮件！";
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                // 添加附件
                //string file = "C:\\file.pdf ";
                //Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
                //mailMsg.Attachments.Add(data);

                // 连接到sendcloud服务器
                SmtpClient smtpClient = new SmtpClient("smtpcloud.sohu.com", Mail.Plugin.EmailConfig.SMTPPort);
                // 使用api_user和api_key进行验证
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("zhihumail", Mail.Plugin.EmailConfig.SMTPPassword);
                smtpClient.Credentials = credentials;

                smtpClient.Send(mailMsg);
                return "true";//发送成功 
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// 找回密码邮件提醒
        /// </summary>
        /// <param name="realname">用户姓名</param>
        /// <param name="username">用户名</param>
        /// <param name="pwd">密码</param>
        /// <param name="email">邮件地址</param>
        /// <returns></returns>
        public static string getfindpwdbody(string realname, string username, string pwd, string email, string key)
        {
            StringBuilder strText = new StringBuilder();
            strText.Append(getpublichead(username, pwd))

                .AppendFormat(" <div class=\"mail-m\"><h2>尊敬的{0}：</h2><div class=\"mail-m1\">", realname)
                .AppendFormat("<p>您在{0}提交了邮箱重置密码请求，请点击下面的链接修改密码。</p>", DateTime.Now.ToString("yyyy年MM月dd日  HH:mm:ss"))
                .AppendFormat("<p><a href=\"http://www.zx58.cn/home/ChangePwd?key={1}&uname={0}\" class=\"red\">http://www.zx58.cn/home/ChangePwd?key={1}&uname={0} </a></p>", username, key)
                .AppendFormat("<p>(如果您无法点击此链接，请将它复制到浏览器地址栏后访问)</p>")
                .Append("<p>为了保证您用户名的安全，该链接有效期为24小时，并且点击一次后失效！</p><div class=\"height\"></div>")
                .AppendFormat("<div class=\"mail-m2\"><p>芳华云同城团队敬上</p><p><a href=\"http://www.bx58.com/\">http://www.bx58.com/</a></p><p>{0}</p></div></div></div>", DateTime.Now.ToString("yyyy年MM月dd日"))
                .Append(getpublicfoot());
            return strText.ToString();
        }

        /// <summary>
        /// 新订单邮件提醒
        /// </summary>
        /// <param name="realname">用户姓名</param>
        /// <param name="username">用户名</param>
        /// <param name="pwd">密码</param>
        /// <param name="ordertime">定购时间 年月日 时：分</param>
        /// <param name="custname">客户姓名</param>
        /// <param name="fullname">省市名称</param> 
        /// <param name="phone">手机号码</param>
        /// <param name="productstr">产品信息</param>
        /// <returns></returns>
        public static string getneworderbody(string realname, string username, string pwd, string ordertime, string custname, string fullname, string phone, string productstr)
        {
            StringBuilder strText = new StringBuilder();
            strText.Append(getpublichead(username, pwd))
                .AppendFormat(" <div class=\"mail-m\"><h2>尊敬的{0}：</h2><div>", realname)
                .AppendFormat("<p>您好，您的网站收到了一条<em class=\"red\">新的订单</em>。订购信息如下：</p>")
                .AppendFormat("<p>订购时间：{0}</p>", ordertime)
                .AppendFormat("<p>客户信息：{0} {1} {2}</p>", fullname, custname, phone)
                .AppendFormat("<p>订购产品：{0}</p>", productstr)
                .AppendFormat("<p>请及时<a href=\"{0}\" class=\"red\">登录网站</a>查看并回复顾客。</p>", "http://www.bx58.com/login.html")
                .Append("<p>服务热线：0731- 84122129&nbsp;&nbsp;&nbsp;&nbsp;客服QQ：800024819</p></div></div>")
                .Append(getpublicfoot());
            return strText.ToString();
        }

        /// <summary>
        /// 新加盟邮件提醒
        /// </summary>
        /// <param name="realname">姓名</param>
        /// <param name="username">用户名</param>
        /// <param name="pwd">密码</param>
        /// <param name="custname">客户姓名</param>
        /// <param name="intime">加盟时间 月日 时：分</param>
        /// <param name="fullname">所在地</param>
        /// <param name="phone">手机</param>
        /// <param name="qq">QQ号码</param>
        /// <returns></returns>
        public static string getnewjoinbody(string realname, string username, string pwd, string custname, string intime, string fullname, string phone, string qq)
        {
            StringBuilder strText = new StringBuilder();
            strText.Append(getpublichead(username, pwd))
                .AppendFormat(" <div class=\"mail-m\"><h2>尊敬的{0}：</h2><div>", realname)
                .AppendFormat("<p>您好，{0}您的网站收到了一条<em class=\"red\">新的加盟信息</em>。</p>", intime)
                .AppendFormat("<p>客户信息：<em class=\"red\">{0} {1} 手机{2} QQ{3}</em></p>", fullname, custname, phone, qq)
                .AppendFormat("<p>请及时与客户取得联系，谢谢！</p>")
                .Append("<p>服务热线：0731- 84122129&nbsp;&nbsp;&nbsp;&nbsp;客服QQ：800024819</p></div></div>")
                .Append(getpublicfoot());
            return strText.ToString();
        }

        /// <summary>
        /// 註册成功发送邮件
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public static string getregister(string username, string pwd)
        {
            StringBuilder strText = new StringBuilder();
            strText.Append(getpublichead(username, pwd))
                    .AppendFormat("<div class=\"mail-m\"><h2>尊敬的{0}：</h2><div class=\"mail-m1\"><p>您好，恭喜您成功註册了無極證道免费会员。", username)
                    .AppendFormat("（您的<em class=\"red\">用户名：{0}</em>&nbsp;&nbsp;&nbsp;<em class=\"red\">密码：{1}</em>）</p>", username, pwd)
                    .Append("<div class=\"height\">&nbsp;</div><p>温馨提醒您，您的网站还不能显示联系资料，并只能预览网站功能。</p>")
                    .Append("<p>如果需要显示联系资料和获得更多服务，请成为我们的正式会员。<a href=\"http://www.bx58.com/aboutlist.aspx?cid=5\">最新收费标准和优惠政策！</a></p>")
                    .Append("<p>服务热线：0731- 84122129&nbsp;&nbsp;&nbsp;&nbsp;客服QQ：800024819</p></div></div><div class=\"mail-b\"><p>無極證道&mdash;無極證道科技（湖南）股份有限公司</p>")
                    .Append("<em>此为系统邮件请勿回复</em></div><div class=\"mail-f clear\"><ul class=\"list\"><li><span><img src=\"http://img.zx58.cn/mail/pic2.jpg\" /></span>")
                    .Append("<div><p>官方公众平台</p><em>关註微信<br />随时随地做芳华云</em></div></li><li><span><img src=\"http://img.zx58.cn/mail/pic3.jpg\" /></span>")
                    .Append("<div><p>芳华云讯息订阅</p><em>关註微信<br />更多商机等着您</em></div></li></ul>")
                    .Append("<span class=\"txt\">Copyright&copy;2012 無極證道版权所有</span></div></div></body>");
            return strText.ToString();
        }

        /// <summary>
        /// 公共的头部
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        protected static string getpublichead(string username, string pwd)
        {
            StringBuilder strText = new StringBuilder();
            strText.Append("<body><style>body,img,span,p,a,b,h2,em,ul,li{ margin:0; padding:0;}body{ color:#333; font-family:'微软雅黑'; font-size:12px;}em{ font-style:normal;}txet_up{ background:none !important; border:none !important}img { border:0 none;}ul,li { list-style-type:none;}a { cursor:pointer;  text-decoration:none;  color:#333;}.red{ color:#f94e00;}.clear:after { display: block; clear: both; height: 0px; content: '';}.height{ display:block; width:100%; height:20px; padding:0px !important;}.mail{ width:800px; margin:0 auto; border:1px solid #e6e6e6;}.mail .mail-t{ width:100%; height:50px; background:#f94e00;}.mail .mail-t .pic{ float:left; display:inline; margin:10px 0 0 15px;}.mail .mail-t .txet_up{ float:right;  color:#fff;     line-height: 50px;}.mail .mail-t .txet_up a{ font-size:14px; color:#fff; padding:0 20px;}.mail .mail-b{ padding:15px 20px;}.mail .mail-b p{ display:block; height:35px; line-height:35px; border-bottom:1px dotted #ddd; font-size:14px;}.mail .mail-b em{ color:#999; line-height:28px;}.mail .mail-m{ padding:15px 20px 0 20px; min-height:200px;}.mail .mail-m h2{ font-weight:normal; font-size:16px; margin-top:15px;}.mail .mail-m .mail-m1{ padding:20px 30px;}.mail .mail-m .mail-m2{ text-align:right;}.mail .mail-m p{ line-height:28px;  font-size:14px;}.mail .mail-f{ background:#f4f4f4; height:100px;}.mail .mail-f .list{ float:left; width:500px;}.mail .mail-f .list li{ float:left; width:230px;}.mail .mail-f .list li span{ float:left; display:inline; margin:10px 12px 0 20px;}.mail .mail-f .list li span img{ width:80px; height:80px;}.mail .mail-f .list li p{ font-size:16px; margin-top:10px; line-height:35px;}.mail .mail-f .list li em{ color:#999;}.mail .mail-f .txet_up{ line-height:100px; font-size:14px; float:right; display:inline; margin-right:20px;}</style>")
            .Append("<div class=\"mail\"><div class=\"mail-t\"><span class=\"pic\"><a href=\"http://www.bx58.com\"  target=\"_blank\"><img src=\"http://www.bx58.com/email-api/pic1.jpg\" /></a></span>")
            .AppendFormat(" <span class=\"txet_up\"><a href=\"http://www.bx58.com/\" target=\"_blank\">总站首页</a>|<a href=\"http://www.bx58.com/guestdemand.html\"  target=\"_blank\">顾客需求</a>|<a href=\"http://www.{0}.bx58.com\"  target=\"_blank\">会员首页</a>|<a href=\"http://www.bx58.com/usermanagesite/\"  target=\"_blank\">用户中心</a></span>", username)
            .Append(" </div>");
            return strText.ToString();
        }

        /// <summary>
        /// 公共的底部
        /// </summary>
        /// <returns></returns>
        protected static string getpublicfoot()
        {
            StringBuilder strText = new StringBuilder();
            strText.Append("<div class=\"mail-b\">")
             .Append(" <p>無極證道—無極證道科技（湖南）股份有限公司</p>")
             .Append(" <em>此为系统邮件请勿回复</em>")
             .Append(" </div>")
             .Append(" <div class=\"mail-f clear\">")
             .Append("<ul class=\"list\">")
             .Append(" <li><span><img src=\"http://www.bx58.com/email-api/pic2.jpg\" /></span><div><p>官方公众平台</p><em>关註微信<br />随时随地做芳华云</em></div></li>")
             .Append("<li><span><img src=\"http://www.bx58.com/email-api/pic3.jpg\" /></span><div><p>芳华云讯息订阅</p><em>关註微信<br />更多商机等着您</em></div></li>")
             .Append("</ul>")
             .Append(" <span class=\"txet_up\">Copyright©2012 無極證道版权所有</span></div></div></body>");
            return strText.ToString();
        }
        /// <summary>
        /// 名片确认邮件文本
        /// </summary>
        /// <param name="realname">设计名片人员姓名</param>
        /// <param name="username">设计名片人员帐号</param>
        /// <param name="pwd">密码</param>
        /// <param name="begintime">设计时间：2015年11月11日10:30</param>
        /// <param name="pagename">套餐</param>
        /// <returns></returns>
        public static string getsurecardinfobody(string realname, string username, string pwd, string begintime, string pagename)
        {
            StringBuilder strText = new StringBuilder();
            strText.Append(getpublichead(username, pwd))
                .AppendFormat(" <div class=\"mail-m\"><h2>尊敬的{0}：</h2><div class=\"mail-m1\">", realname)
                .AppendFormat("<p>您好，恭喜您于{0}成功申请了無極證道名片设计{1}，我们的工作人员将尽快与您取得联系并提供相应服务。</p>", begintime, pagename)
                .AppendFormat(" <div class=\"height\"></div>")

                .Append("<p>服务热线：0731-84122163&nbsp;&nbsp;&nbsp;&nbsp;客服QQ：800026038 </p></div></div>")
                .Append(getpublicfoot());
            return strText.ToString();
        }


        /// <summary>
        /// 芳华云发送验证码
        /// </summary>
        /// <returns></returns>
        public static string getVerificationCoe(string code, string username)
        {
            StringBuilder strText = new StringBuilder();
            strText.Append(getpublichead(username, code))
            .Append("<div class=\"mail-m\">")
            .AppendFormat("<h2>尊敬的{0}：</h2>", username)
            .Append("<div class=\"mail-m1\">")
            .AppendFormat("<p>提醒您，您正在进行邮箱验证，验证码为：<em class=\"red\">{0}</em></p>", code)
            .Append("<div class=\"height\"></div>")
            .Append("<p>服务热线：0731- 84122129&nbsp;&nbsp;&nbsp;&nbsp;客服QQ：800024819</p>")
            .Append("</div>")
            .Append("</div>")
            .Append(getpublicfoot());
            return strText.ToString();
        }

        public static string getErrorContrctNotice(string code, string username)
        {
            StringBuilder strText = new StringBuilder();
            strText.Append(getpublichead(username, code))
            .Append("<div class=\"mail-m\">")
            .AppendFormat("<h2>尊敬的{0}：</h2>", username)
            .Append("<div class=\"mail-m1\">")
            .AppendFormat("<p>提醒您，您提交的有奖纠错内容已审核通过，赠送你积分：<em class=\"red\">{0}</em></p>", 300)
            .Append("<div class=\"height\"></div>")
            .Append("<p>服务热线：0731- 84122129&nbsp;&nbsp;&nbsp;&nbsp;客服QQ：800024819</p>")
            .Append("</div>")
            .Append("</div>")
            .Append(getpublicfoot());
            return strText.ToString();
        }

        
    }
}
