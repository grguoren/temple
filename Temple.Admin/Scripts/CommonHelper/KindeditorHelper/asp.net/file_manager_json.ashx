<%@ webhandler Language="C#" class="FileManager" %>

/**
 * KindEditor ASP.NET
 *
 * 本ASP.NET程序是演示程序，建议不要直接在实际项目中使用。
 * 如果您确定直接使用本程序，使用之前请仔细确认相关安全设置。
 *
 */

using System;
using System.Collections;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;
using LitJson;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.IO.Compression;

public class FileManager : IHttpHandler
{
	public void ProcessRequest(HttpContext context)
	{
		String dirName = context.Request.QueryString["dir"];
		if (!String.IsNullOrEmpty(dirName)) {
			if (Array.IndexOf("image,flash,media,file".Split(','), dirName) == -1) {
				context.Response.Write("Invalid Directory name.");
				context.Response.End();
			}
		}

		//根据path参数，设置各路径和URL
		String path = context.Request.QueryString["path"];
		path = String.IsNullOrEmpty(path) ? "" : path;
		
		//排序形式，name or size or type
		String order = context.Request.QueryString["order"];
		order = String.IsNullOrEmpty(order) ? "" : order.ToLower();

        String ReqUrl = string.Format("http://image.bx58.com/filemanager?dir={0}&path={1}&order={2}", dirName, path, order);
        string result = ResponseToString(doGet(ReqUrl));

        context.Response.Write(result);
		context.Response.End();
	}

    /// <summary>
    /// 发送Get类型请求
    /// </summary>
    /// <param name="url">请求地址</param>
    /// <param name="postData">参数</param>
    /// <returns></returns>
    public WebResponse doGet(string url)
    {
        try
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "get";
            webRequest.Timeout = 5000;
            return webRequest.GetResponse();
        }
        catch (Exception ce)
        {
            return null;
            //throw ce;
        }
    }

    /// <summary>
    /// 根据相应返回字符串
    /// </summary>
    /// <param name="response"></param>
    /// <returns></returns>
    public string ResponseToString(WebResponse response)
    {
        try
        {
            Encoding encoding = Encoding.Default;
            string ContentType = response.ContentType.Trim();
            if (ContentType.IndexOf("utf-8") != -1)
                encoding = Encoding.UTF8;
            else if (ContentType.IndexOf("utf-7") != -1)
                encoding = Encoding.UTF7;
            else if (ContentType.IndexOf("unicode") != -1)
                encoding = Encoding.Unicode;

            StreamReader stream = new StreamReader(response.GetResponseStream(), encoding);
            string code = stream.ReadToEnd();
            stream.Close();
            response.Close();
            return code;
        }
        catch (Exception ce)
        {
            throw ce;
        }
    }

	public bool IsReusable
	{
		get
		{
			return true;
		}
	}
}
