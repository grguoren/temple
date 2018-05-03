using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Core.Helper
{
    public static class PagingHelper
    {

        public static string GetPagingNew(string url, int index, int size, int count, int linkSize, string parms)
        {
            return GetMVCPagingNew(url, index, size, count, linkSize, parms, false, false, true, false, true);
        }

        public static string GetMVCPagingNew(string url, int index, int size, int count, int linkSize, string parms,
      bool showInfo, bool showFirstLast, bool showPrevNext, bool showSkip, bool showWite)
        {

            StringBuilder sb = new StringBuilder();
            int star = 0, end = 0;
            string infoStr = "", firstStr = "", lastStr = "", prevStr = "", nextStr = "", skipStr = "";

            int pageCount = (count % size) == 0 ? count / size : (count / size) + 1;
            int prev = index > 1 ? index - 1 : 1;
            int next = index < pageCount ? index + 1 : pageCount;
            int median = (linkSize / 2) + 1;
            median = linkSize % 2 == 0 ? median : median + 1;
            showInfo = false;
            if (showInfo)
            {
                infoStr = "<span>共" + count + "条数据　总计" + pageCount + "页</span>";

            }

      //<a href="#" class="a hover">1</a><a href="#" class="a">2</a>
            //showFirstLast = true;
            //showPrevNext = true;
            if (showFirstLast)
            {
                if (index != 1)
                    firstStr = "<span><a href=\"" + url + 1 + parms + "\">首页</a></span>";
                if (index != pageCount)
                    lastStr = "<span><a href=\"" + url + pageCount + parms + "\">尾页</a></span>";
            }
            if (showPrevNext)
            {
                if (index != 1)
                    prevStr = "<a href=\"" + url + prev + parms + "\" class=\"a\">《</a>";
                if (index != pageCount)
                    nextStr = "<a href=\"" + url + next + parms + "\" class=\"a\">》</a>";
            }
            if (showSkip)
            {
                string skipurl = "'" + url + "' + document.getElementById('skipPage').value + '" + parms + "'";
                skipStr = " <input type=\"text\"style=\"width:50px;height:23px;\" id=\"skipPage\" value=\"" + index + "\">";
                skipStr += "<a id=\"skipBtn\" href=\"javascript:skipPage(document.getElementById('skipPage').value ," + pageCount + ");\">Go</a>";
                skipStr += "<script type=\"text/javascript\">function skipPage(index,pageCount,url){";
                skipStr += "var number = /^\\+?[1-9][0-9]*$/;";
                skipStr += "if(!number.test(index)){alert('页码只能输入大于0的数字！');}";
                skipStr += "else if(index > pageCount){alert('页码不能大于总页数');}";
                skipStr += "else{window.location.href = " + skipurl + ";}";
                skipStr += "}</script>";
            }
            //sb.Append("<div class=\"pageslist2\">");
            sb.Append(infoStr);
            sb.Append(firstStr);
            sb.Append(prevStr);
            if (pageCount < linkSize)
            {
                star = 0; end = pageCount;
            }
            else
            {
                if (index < median)
                {
                    star = 0; end = linkSize;
                }
                else if ((pageCount - index) < median)
                {
                    star = (pageCount - linkSize); end = pageCount;
                }
                else
                {
                    star = median % 2 == 0 ? (index - (median)) + 1 : (index - (median));
                    end = (index + median - 1);
                }
            }
            star++; end++;
            //showWite = true;
            if (showWite)
            {
                if (star != 1)
                {
                    sb.Append("<a class=\"a\" href=\"" + url + (star - 2) + parms + "\">" + "......" + "</a>");
                }
                for (int i = star; i < end; i++)
                {
                    if (index == i)
                        sb.Append("<a class=\"a hover\">" + i + "</a>");
                    else
                        sb.Append("<a class=\"a\" href=\"" + url + i + parms + "\">" + i + "</a>");
                }
                if (end - 1 != pageCount)
                {
                    sb.Append("<a class=\"a\" href=\"" + url + (end + 2) + parms + "\">" + "......" + "</a>");
                }
            }
            else
            {
                for (int i = star; i < end; i++)
                {
                    if (index == i)
                        sb.Append("<a class=\"a hover\">" + i + "</a></span>");
                    else
                        sb.Append("<a class=\"a\" href=\"" + url + i + parms + "\">" + i + "</a>");
                }
            }
            sb.Append(nextStr);
            sb.Append(lastStr);
            sb.Append(skipStr);
            //sb.Append("</div>");
            return sb.ToString();
        }

    }
}
