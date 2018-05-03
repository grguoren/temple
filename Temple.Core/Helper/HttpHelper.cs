using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Core.Helper
{
    public class HttpHelper
    {
        public static string SendHttpGet(string Url, string postDataStr, out string exinfo)
        {
            Stream myResponseStream = null;
            StreamReader myStreamReader = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                myResponseStream = response.GetResponseStream();
                myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                exinfo = "";
                return retString;
            }
            catch (Exception ex)
            {
                exinfo = ex.Message;
                myStreamReader.Close();
                myResponseStream.Close();
                return null;
            }
        }
    }
}
