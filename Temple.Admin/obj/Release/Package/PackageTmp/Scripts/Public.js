$.ajaxSetup({
    error: function (XMLHttpRequest, textStatus, errorThrown) {
        if (XMLHttpRequest.status == 403) {
            alert('您没有权限访问此资源或进行此操作');
            return false;
        }
    },
    //complete: function (XMLHttpRequest, textStatus) {
    //    var sessionstatus = XMLHttpRequest.getResponseHeader("sessionstatus"); //通过XMLHttpRequest取得响应头,sessionstatus， 
    //    if (sessionstatus == 'timeout') {
    //        //如果超时就处理 ，指定要跳转的页面  
    //        alert('登录超时, 请重新登录.');
    //        location.href = Config.WebUrl + "Login/Login";
    //    }
    //}
});


function ReturnImgPath(imgUrl)
{
    var url = imgUrl;
    if (imgUrl.indexOf("http://www.zhimg.com") == 0) {
        imgUrl = imgUrl.replace("http://www.zhimg.com", "");
    }
    if (imgUrl.indexOf("http://") < 0) {
        url = "http://www.bx58.com" + imgUrl;
    }
    if (imgUrl == null || imgUrl == "" || imgUrl == "http://www.bx58.com/") {
        url = "";
    }
    return url;
}

function ReturnBigImgPath(imgUrl) {
    var url = imgUrl;
    if (imgUrl.indexOf("http://www.zhimg.com") == 0) {
        imgUrl = imgUrl.replace("http://www.zhimg.com", "");
    }
    if (imgUrl.indexOf("http://") < 0) {
        url = "http://www.bx58.com" + imgUrl;
        url = url.replace("_c.jpg", ".jpg");
        url = url.replace("_c.jpeg", ".jpeg");
    }
    else {
        url = url.replace("_c.jpg", ".jpg");
        url = url.replace("_c.jpeg", ".jpeg");
    }
    if (imgUrl.indexOf("http://") < 0) {
        url = "http://www.bx58.com" + imgUrl;
        url = url.replace("_small.jpg", ".jpg");
        url = url.replace("_small.jpeg", ".jpeg");
    }
    else {
        if (imgUrl.indexOf(".jpg") > 0) {
            url = url.replace("_small.jpg", ".jpg");
            //url = url.replace("_small.jpeg", ".jpeg");
        }
        else {
            url = url.replace("_small.png", ".png");
            url = url.replace("_small.jpeg", ".jpeg");
        }
    }
    return url;
}

function ReturnNoPic() {
    var url = Config.ImgUrl + "userfiles/nopic.gif";
    return url;
}

function HrefSelf(url, param) {
    location.href = url + param;
}

function HrefOpen(url, param) {
    window.open(url + param, '_blank');
}

function RetUrlUserHomeById(name) {
    //var url = "http://www." + name + ".weifaster.com";
    //var url = "http://www." + name + ".zx58.cn";
    //var url = Config.SiteUrl + "user/" + name;
    var url = Config.SiteUrl.replace("www.", "www." + name + ".");
    return url;
}

function RetUrlBrandHome(name) {
    //var url = "http://" + name + ".weifaster.com";
    var url = Config.SiteUrl.replace("www.", name + ".");
    return url;
}