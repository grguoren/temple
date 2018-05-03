using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Temple.Core.Tools
{
    public class CommonHelper
    {
        public static string ImgUrlReplace(string url)
        {
            Regex reg = new Regex(@"(?is)(<img[^>]*?src=|\bbackground(?:=|:url\())(?!['""]?http://)((['""])(?<img>[^'"">)]+)\3|(?<img>[^'""\s)>]+))");
            string result = reg.Replace(url, "$1$3http://img.zx58.cn${img}$3");
            return result;
        }
    }
}
