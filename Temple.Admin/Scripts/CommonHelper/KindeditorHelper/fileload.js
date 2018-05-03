function createHtml(obj) {
    var htmstr = [];
    htmstr.push("<form id='_fileForm' enctype='multipart/form-data'>");
    //htmstr.push("<table cellspacing=\"0\" cellpadding=\"3\" style=\"margin:0 auto; margin-top:20px;\">");
    htmstr.push("<table>");
    htmstr.push("<tr>");
    //htmstr.push("<td class=\"tdt tdl\">请选择文件：</td>");
    htmstr.push("<td class=\"tdt tdl\"><input class=\"center_tab\" style=\"width:300px\" id=\"loadcontrol\" type=\"file\" name=\"filepath\" id=\"filepath\" /></td>");
    htmstr.push("<td class=\"tdt tdl tdr\"><input type=\"button\" onclick=\"fileloadon()\" value=\"上传\"/></td>");
    htmstr.push("</tr>");
    //htmstr.push("<tr> <td class=\"tdt tdl tdr\" colspan='3'style='text-align:center;'><div id=\"msg\">&nbsp;</div></td> </tr>");
    //htmstr.push("<tr> <td class=\"tdt tdl tdr\" style=\" vertical-align:middle;\">图片预览：</td> <td class=\"tdt tdl tdr\" colspan=\"2\"><div style=\"text-align:center;\"><img src=\"project/Images/NoPhoto.jpg\"/></div></td> </tr>");
    htmstr.push("</table>")
    htmstr.push("</form>");
    obj.html(htmstr.join(""));
}

function Html(obj)
{
    var htmlstr = [];
    htmlstr.push("<form id='_fileForm' enctype='multipart/form-data'>");
    htmlstr.push("<ul>");
    htmlstr.push("<li  class=\"tdt tdl\"><input class=\"center_tab\" style=\"width:300px\" id=\"loadcontrol\" type=\"file\" name=\"filepath\" id=\"filepath\" /><input type=\"button\" onclick=\"fileloadon()\" value=\"上传\"/></li>");
    htmlstr.push("</ul>");
    htmlstr.push("</form>");
    obj.html(htmlstr.join(""));
}


function fileloadon() {
    $("#msg").html("");
    $("img").attr({ "src": "project/Images/processing.gif" });
    $("#_fileForm").submit(function () {
        $("#_fileForm").ajaxSubmit({
            type: "post",
            //url: "project/help.aspx",
            url: "../../../Scripts/kindeditor-4.1.10/FisForm1.aspx",
            success: function (data1) {
                //alert(data1);
                var remsg = data1.split("|");
                //alert(remsg);
                var name = remsg[1].split("\/");
                if (remsg[0] == "1") {
                    Fisimg = remsg[1];
                    alert(remsg[1]);
                    //var type = name[4].substring(name[4].indexOf("."), name[4].length);
                    //$("#msg").html("文件名：" + name[name.length - 1] + "   ---  " + remsg[2]);
                    //switch (type) {
                    //    case ".jpg":
                    //    case ".jpeg":
                    //    case ".gif":
                    //    case ".bmp":
                    //    case ".png":
                    //        //$("img").attr({ "src": remsg[1] });//图片预览
                    //        alert(remsg[1]);
                    //        $("#ss").attr({ "src": remsg[1] });
                    //        $("#_fileForm").hide();
                    //        break;
                    //    default:
                    //        $("img").attr({ "src": "project/Images/msg_ok.png" });
                    //        break;
                    //}
                } else {
                    alert("文件上传失败：" + remsg[2])
                    //$("#msg").html("文件上传失败：" + remsg[2]);
                    //$("img").attr({ "src": "project/Images/msg_error.png" });
                }
            },
            error: function (msg) {
                alert("文件上传失败");
            }
        });
        return false;
    });
    $("#_fileForm").submit();
}