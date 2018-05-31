<%@ webhandler Language="C#" class="ImgServerUpload" %>
using System;
using System.Collections;
using System.Web;
using System.IO;
using System.Globalization;
using Temple.Core.Tools;
using LitJson;

public class ImgServerUpload : IHttpHandler
{
    /// <summary>
    /// 上传路径
    /// </summary>
    private static string imgUrl = "http://image.bx58.com/upload/";
    /// <summary>
    /// 水印文字
    /// </summary>
    private static string HostMechine = "bx58.com";

    private HttpContext context;

    public void ProcessRequest(HttpContext context)
    {
        String aspxUrl = context.Request.Path.Substring(0, context.Request.Path.LastIndexOf("/") + 1);

        //最大文件大小
        int ImageMaxSize = 2000000;
        int TvmaxSize = 20000000;
        int maxSize = 20000000;
        this.context = context;

        //定义允许上传的文件扩展名
        Hashtable extTable = new Hashtable();
        extTable.Add("image", "gif,jpg,jpeg,png,bmp");
        extTable.Add("flash", "swf,flv");
        extTable.Add("media", "swf,flv,mp3,wav,wma,wmv,mid,avi,mpg,asf,rm,rmvb");
        extTable.Add("file", "doc,docx,xls,xlsx,ppt,htm,html,txt,zip,rar,gz,bz2");

        HttpPostedFileBase imgFile = new HttpPostedFileWrapper(context.Request.Files["imgFile"]);
        if (imgFile == null)
        {
            showError("请选择文件。");
        }

        String dirName = context.Request.QueryString["dir"];
        if (String.IsNullOrEmpty(dirName))
        {
            dirName = "UserMgrFile";
        }

        String fileName = imgFile.FileName;
        String fileExt = Path.GetExtension(fileName).ToLower();

        ///图片
        if (String.IsNullOrEmpty(fileExt) || CheckExt(extTable, "image", fileExt))
        {
            if (imgFile.InputStream == null || imgFile.InputStream.Length > ImageMaxSize)
            {
                showError("上传文件大小超过限制。");
            }
        }
        ///视频
        else if (String.IsNullOrEmpty(fileExt) || CheckExt(extTable, "flash", fileExt) || CheckExt(extTable, "media", fileExt) || CheckExt(extTable, "file", fileExt))
        {
            if (imgFile.InputStream == null || imgFile.InputStream.Length > TvmaxSize)
            {
                showError("上传文件大小超过限制。");
            }
        }
        else
        {
            showError("上传文件扩展名是不允许的扩展名。\n只允许" + ((String)extTable[dirName]) + "格式。");
        }
        String savePath = "attached/";
        var dirPath = savePath + dirName + "/";
       string mystr = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo);
        String newFileName = mystr + fileExt;
        String filePath = dirPath + newFileName;

        UploadHelper upload = new UploadHelper();


        string url= upload.OssUpload(imgFile, filePath);
        //string url = "";
        //if (String.IsNullOrEmpty(fileExt) || CheckExt(extTable, "image", fileExt))
        //{
        //    url = upload.UploadImage((HttpPostedFileBase)imgFile);
        //}
        //else if (String.IsNullOrEmpty(fileExt) || CheckExt(extTable, "flash", fileExt) || CheckExt(extTable, "media", fileExt) || CheckExt(extTable, "file", fileExt))
        //{
        //    url = upload.UploadVideo((HttpPostedFileBase)imgFile);
        //}


        Hashtable hash = new Hashtable();
        hash["error"] = 0;
        hash["url"] =url;
        context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
        context.Response.Write(JsonMapper.ToJson(hash));
        context.Response.End();

    }

    private bool CheckExt(Hashtable extTable, string extKey, string fileExt)
    {
        string[] exts = ((String)extTable[extKey]).Split(',');
        return Array.IndexOf(exts, fileExt.Substring(1).ToLower()) != -1 ? true : false;
    }

    private void showError(string message)
    {
        Hashtable hash = new Hashtable();
        hash["error"] = 1;
        hash["message"] = message;
        context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
        context.Response.Write(JsonMapper.ToJson(hash));
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return true;
        }
    }
}
