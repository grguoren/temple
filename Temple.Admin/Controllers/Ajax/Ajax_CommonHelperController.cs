using Temple.Core.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Temple.Admin.Controllers.Ajax
{
    public class Ajax_CommonHelperController : Controller
    {
        //
        // GET: /Ajax_CommonHelper/
        int ImageMaxSize = 2000000;
        int TvmaxSize = 2000000000;
        int maxSize = 2000000000;
 

        //定义允许上传的文件扩展名
        Hashtable extTable = new Hashtable();
      
   

        [HttpPost]
        public ActionResult Photo_Save(string type)
        {
            JsonResult json = new JsonResult();
            json.ContentType = "text/html;charset=UTF-8";

            if (HttpContext.Request.Files.Count == 0)
            {
                json.Data = new { data = "0|无法获取文件,请确认已正确选择文件！" };
                return json;
            }
            if (string.IsNullOrEmpty(type)) {
                type = "photo";
            }
            HttpPostedFileBase file = HttpContext.Request.Files[0];

            UploadHelper upload = new UploadHelper();
            upload.PostUrl = System.Configuration.ConfigurationManager.AppSettings["UploadService"];
            upload.Dir = "zhihuyun";
            type = type.ToLower();//用小写
            string _sAdminUploadPath = "userfiles/"+ type;
            string DirectoryPath;
            String ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
            DirectoryPath = string.Format("{0}/{1}", _sAdminUploadPath, ymd);
            if (type != "product" && type != "course")//产品图片不加水印
            {
                //upload.WaterMark = "www.bx58.com";
            }
            if (type == "Product")
            {
                upload.CheckWidth = "400";


            }
            String fileExt = Path.GetExtension(file.FileName).ToLower();//缩略图后缀名
            string sFileName =  DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;  // 文件名称
            string FullPath = DirectoryPath + "/" + sFileName;        // 服务器端文件路径
            upload.SetImageSize(0,0,0,0);
          
            string url = upload.OssUpload(file, FullPath);

       
            if (url==null)
            {
                json.Data = new { data = "0|网络繁忙,请稍后在试！" };
                return json;
            }
           else
            {
                json.Data = new { data = "1|上传成功!|" + url };  //result[1]为返回图片的URL地址
                return json;
            }
        }

        [HttpPost]
        public string File_Save(HttpPostedFileBase fileUp, string type)
        {
            UploadHelper upload = new UploadHelper();
           // upload.PostUrl = System.Configuration.ConfigurationManager.AppSettings["UploadService"];
         
            string _sAdminUploadPath = "file";
            string DirectoryPath;
            String ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
            DirectoryPath = string.Format("{0}/{1}", _sAdminUploadPath, ymd);
         
            String fileExt = Path.GetExtension(fileUp.FileName).ToLower();//缩略图后缀名
            string sFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;  // 文件名称
            string FullPath = DirectoryPath + "/" + sFileName;        // 服务器端文件路径
            string url = upload.OssUpload(fileUp, FullPath);


            if (url == null)
            {
                return "0|网络繁忙,请稍后在试！";
            }
            else
            {
                return "1|上传成功!|" + url;  //result[1]为返回图片的URL地址
            }
        }

        [HttpPost]
        public JsonResult Photo_Save_KindImage(HttpPostedFileBase imgFile, string type)
        {
            UploadHelper upload = new UploadHelper();
         //   upload.PostUrl = System.Configuration.ConfigurationManager.AppSettings["UploadService"];
           // upload.Dir = type + "_AdminKindImage";
            string _sAdminUploadPath =type + "_adminkindimage";
            string DirectoryPath;
            String ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
            DirectoryPath = string.Format("{0}/{1}", _sAdminUploadPath, ymd);

            String fileExt = Path.GetExtension(imgFile.FileName).ToLower();//缩略图后缀名
            string sFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;  // 文件名称
            string FullPath = DirectoryPath + "/" + sFileName;        // 服务器端文件路径
            string url = upload.OssUpload(imgFile, FullPath);


            if (url == null)
            {
                var res = new { error = 1, message = "网络繁忙,请稍后在试！" };
                return Json(res);
            }
            else
            {
                //return "1|上传成功!|" + result[1];  //result[1]为返回图片的URL地址
                var res = new { error = 0, url = url };
                return Json(res);
            }
        }

        [HttpPost]
        public string Photo_SaveHaveSmall(HttpPostedFileBase file, string type, int smallWidth, int smallHeight)
        {
            UploadHelper upload = new UploadHelper();
          //  upload.PostUrl = System.Configuration.ConfigurationManager.AppSettings["UploadService"];
          //  upload.Dir = type + "_AdminImage";
            string _sAdminUploadPath =  type + "_adminimage";
            string DirectoryPath;
            String ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
            DirectoryPath = string.Format("{0}/{1}", _sAdminUploadPath, ymd);

            String fileExt = Path.GetExtension(file.FileName).ToLower();//缩略图后缀名
            string sFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;  // 文件名称
            string FullPath = DirectoryPath + "/" + sFileName;        // 服务器端文件路径
            string url = upload.OssUpload(file, FullPath);


            if (url == null)
            {
                return "0|网络繁忙,请稍后在试！";
            }
            else
            {
                return "1|上传成功!|" + url;  //result[1]为返回图片的URL地址
            }
        }

        /// <summary>
        /// 上传视频
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadVideo(int? type=0)
        {
            extTable.Add("flash", "swf,flv");
            extTable.Add("media", "flv,mp3,mp4,avi,rm,rmvb");

            JsonResult json = new JsonResult();
            json.ContentType = "text/html;charset=UTF-8";

            if (HttpContext.Request.Files.Count == 0)
            {
                json.Data = new { data = "0|无法获取文件,请确认已正确选择文件！" };
                return json;
            }

            HttpPostedFileBase file = HttpContext.Request.Files[0];

            String fileName = file.FileName;
            String fileExt = Path.GetExtension(fileName).ToLower();

            if (String.IsNullOrEmpty(fileExt)  || CheckExt(extTable, "media", fileExt))
            {
                if (file.InputStream == null || file.InputStream.Length > TvmaxSize)
                {
                    json.Data = new { data = "0|上传文件大小超过限制。" };
                    return json;
                }
            }
            else
            {
                json.Data = new { data = "0|上传文件扩展名是不允许的扩展名。\n只允许" + ((String)extTable["media"]) + "格式。" };
                return json;
            }

            UploadHelper upload = new UploadHelper();
            //upload.PostUrl = System.Configuration.ConfigurationManager.AppSettings["UploadService"];
            //upload.Dir = type + "_InterViewVideo";

            string _sAdminUploadPath = type + "_video";
            _sAdminUploadPath = _sAdminUploadPath.ToLower();
            string DirectoryPath;
            String ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
            DirectoryPath = string.Format("{0}/{1}", _sAdminUploadPath, ymd);

        
            string sFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;  // 文件名称
            string FullPath = DirectoryPath + "/" + sFileName;        // 服务器端文件路径
            string url = upload.OssUploadVideo(file, FullPath);


            if (url == null)
            {
                json.Data = new { data = "0|网络繁忙,请稍后在试" };
                return json;
            }
            else
            {
                json.Data = new { data = "1|上传成功!|" + url };  //result[1]为返回图片的URL地址
                return json;
            }
        }


        private bool CheckExt(Hashtable extTable, string extKey, string fileExt)
        {
            string[] exts = ((String)extTable[extKey]).Split(',');
            return Array.IndexOf(exts, fileExt.Substring(1).ToLower()) != -1 ? true : false;
        }
    }
}
