using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ThoughtWorks;
using ThoughtWorks.QRCode;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;

namespace Temple.Admin.Controllers
{
    public class MakeQRCodeController : Controller
    {
        public ActionResult Index(string data)
        {
            try
            {
                if (!string.IsNullOrEmpty(Request["data"]))
                {
                    string str = Request.QueryString["data"];
                    if (str.Contains("||"))
                    {
                        str = str.Replace("||", "&");
                    }
                    //初始化二维码生成工具
                    QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                    qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                    qrCodeEncoder.QRCodeVersion = 0;
                    qrCodeEncoder.QRCodeScale = 4;

                    //将字符串生成二维码图片
                    Bitmap image = qrCodeEncoder.Encode(str, Encoding.Default);

                    //保存为PNG到内存流  
                    MemoryStream ms = new MemoryStream();
                    image.Save(ms, ImageFormat.Png);

                    //输出二维码图片
                    Response.BinaryWrite(ms.GetBuffer());
                    Response.End();
                }
            }
            catch (Exception ex)
            {
     
            }
            return View();
        }


    }
}
