var AboutAddOrUpdate = avalon.define('aboutAddOrUpdate', function (vm) {
    vm.buttonType = "添加";
    vm.abouttypeList = [];
    vm.brandList = [];
    vm.aboutModel = {
        Id: $("#aboutId_pageDom").val(),
        TypeId: 0,
        Title: "",
        SubTitle: "",
        Bid: 0,
        AddTime: "",
        IsVerify: 0,
        IsRecommend: 0,
        ImgPath: "",
        ClickCount: 0,
        IsTop: 0,
        Sort: 0,

        Content: "",
        Source:""
    };
    vm.viewImgButton = true;
    vm.imgTip = "";
    vm.CheckSub = false;//当该参数为true时,才会执行提交数据
    //----------------------------------------------添加关于我们的方法
    vm.addAboutFun = function () {
        if (vm.buttonType == "添加" && vm.aboutModel.Id == 0) {
            AddAbout_Ajax();
        }
        if (vm.buttonType == "修改" && vm.aboutModel.Id != 0) {
            UpdateAbout_Ajax();
        }
    };
    vm.uploadAjaxInfomationImg = function () {
        UploadImgFun();
    };
    //----------------------------------------------错误信息对象
    vm.errorMsg = {
        TypeId: "请选择广告的所属分类",
        Title: "請填寫广告标题",
        Sort: "請填寫正確的數字"
    };
    //----------------------------------------------获取栏目分类列表
    vm.getAboutTypeList = function () {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_About/GetAboutTypeList',
            data: { page: 1, size: 999 },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData.Status == true) {
                    vm.abouttypeList = ajaxData.Data;
                }
            },
            dataType: 'json'
        });
    };
    //----------------------------------------------获取品牌列表
    vm.getBrandList = function () {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_MyUser/GetBrandList',
            data: {},
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData.Status == true) {
                    vm.brandList = ajaxData.Data;
                }
            },
            dataType: 'json'
        });
    };
    //----------------------------------------------缩略图控件
    vm.preview = {
        fileInput: document.getElementById("file"),
        fileCount: 1,
        onInit: function (vmodel, options, vmodels) {
            avalon.bind(options.fileInput, "change", function () {
                try {
                    //parent && parent.setHeight && parent.setHeight()
                    vm.imgTip = "请先点击确认上传按钮将图片上传";
                } catch (e) { }
            })
        }
    };
    vm.$skipArray = ["preview"];
    //----------------------------------------------时间控件
    vm.datepicker = {
        onSelectTime: function (vmodel) {

        }
    };
});
avalon.scan();
AboutAddOrUpdate.getAboutTypeList();
if (AboutAddOrUpdate.aboutModel.Id != 0) {
    AboutAddOrUpdate.buttonType = "修改";
    GetAboutById_Ajax();
}

function AddAbout_Ajax() {
    if (InitValidatorDataFun()) {
        var subData = $.extend({}, AboutAddOrUpdate.aboutModel.$model);
	subData.Content = escape(subData.Content);
        var saveData = JSON.stringify(subData);
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_About/AddAbout',
            data: { jsonModel: saveData },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData === "True") {
                    alert('添加成功');
                    location.href = location.href;
                }
            },
            dataType: 'text'
        });
    }
}
function UpdateAbout_Ajax() {
    if (InitValidatorDataFun()) {
        var subData = $.extend({}, AboutAddOrUpdate.aboutModel.$model);
	subData.Content = escape(subData.Content);
        var saveData = JSON.stringify(subData);
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_About/UpdateAbout',
            data: { jsonModel: saveData },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData === "True") {
                    alert('修改成功');
                    CloseWindow();
                }
            },
            dataType: 'text'
        });
    }
}
function GetAboutById_Ajax() {
    $.ajax({
        type: 'POST',
        url: Config.WebUrl + 'Ajax_About/GetAdviceById',
        data: { id: AboutAddOrUpdate.aboutModel.Id },
        timeout: 200000,
        success: function (ajaxData) {
            AboutAddOrUpdate.aboutModel.TypeId = ajaxData.TypeId;
            AboutAddOrUpdate.aboutModel.Title = ajaxData.Title;
            AboutAddOrUpdate.aboutModel.SubTitle = ajaxData.SubTitle;
            AboutAddOrUpdate.aboutModel.Source = ajaxData.Source;
            AboutAddOrUpdate.aboutModel.ClickCount = ajaxData.ClickCount;
            AboutAddOrUpdate.aboutModel.IsVerify = ajaxData.IsVerify;
            AboutAddOrUpdate.aboutModel.IsRecommend = ajaxData.IsRecommend;
            AboutAddOrUpdate.aboutModel.IsTop = ajaxData.IsTop;
            AboutAddOrUpdate.aboutModel.ImgPath = ajaxData.ImgPath == null ? "" : ajaxData.ImgPath;
            AboutAddOrUpdate.imgTip = AboutAddOrUpdate.aboutModel.ImgPath;
            AboutAddOrUpdate.aboutModel.Sort = ajaxData.Sort;
            AboutAddOrUpdate.aboutModel.AddTime = avalon.filters.date(ajaxData.AddTime, "yyyy-MM-dd HH:mm");
            AboutAddOrUpdate.aboutModel.Content = ajaxData.Content;
            if (AboutAddOrUpdate.aboutModel.ImgPath != "") {
                var img = new Image();
                img.style.width = "180px";
                img.style.height = "150px";
                img.src = AboutAddOrUpdate.aboutModel.ImgPath;
                document.getElementById("preview_img_page").appendChild(img);
            }
        }, error: function () {
            alert('對不起,沒有數據可以修改!');
            location.href = Config.WebUrl + "FaqManage/List";
        },
        dataType: 'json'
    });
}

function UploadImgFun() {
    $.ajaxFileUpload
            (
                {
                    url: Config.WebUrl + 'Ajax_CommonHelper/Photo_Save', //用于文件上传的服务器端请求地址
                    secureuri: false, //一般设置为false
                    fileElementId: 'file', //文件上传空间的id属性  <input type="file" id="file" name="file" />
                    dataType: 'json', //返回值类型 一般设置为json
                    data: { type: "About" },
                    success: function (data, status)  //服务器成功响应处理函数
                    {
                        var args = data.data.split("|");
                        if (args[0] == "1") {
                            //$("#showimg").html(args[2] + "<br /><img src='" + args[2] + "'>");
                            var imgPath = args[2];
                            AboutAddOrUpdate.aboutModel.ImgPath = imgPath;
                            AboutAddOrUpdate.imgTip = AboutAddOrUpdate.aboutModel.ImgPath
                            AboutAddOrUpdate.viewImgButton = false;
                        } else {
                            alert("上传失败,请重新选择图片上传!");
                        }
                    },
                    error: function (data, status, e)//服务器响应失败处理函数
                    {
                        alert(e);
                    }
                }
            )
    return false;
}

function InitValidatorDataFun() {
    var check = true;
    if (AboutAddOrUpdate.aboutModel.TypeId === 0) {
        alert(AboutAddOrUpdate.errorMsg.TypeId);
        check = false;
    }
    if ($.trim(AboutAddOrUpdate.aboutModel.Title) === "") {
        alert(AboutAddOrUpdate.errorMsg.Title);
        check = false;
    }
    if ($.trim(AboutAddOrUpdate.aboutModel.Sort) == "" || ($.trim(AboutAddOrUpdate.aboutModel.Sort) != "" && isNaN(AboutAddOrUpdate.aboutModel.Sort))) {
        alert(AboutAddOrUpdate.errorMsg.Sort);
        check = false;
    }
    return check;
}
function CloseWindow() {
    window.opener.OpenWindowFunGetList();
    window.open('', '_parent', '');
    window.close();
}

