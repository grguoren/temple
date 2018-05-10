var CourseAddOrUpdate = avalon.define('courseAddOrUpdate', function (vm) {
    vm.buttonType = "添加";
    vm.typeList = [];
    vm.teacherList = [];
    vm.brandList = [];
    vm.CourseModel = {
        Id: $("#courseId_pageDom").val(),
        cType: 0,
        cTitle: "",
        Content: "",
        cPrice: 0,
        cImages: "",
        cImages2:"",
        cReward: 0,
        Userid: 0,
        TeacherId: 0,
        IsOne: 1,
        cTitlew: "",
        cRemarkw: "",
        cFileUrlw: "",
        cFileType: 0,
        CuId:0
    };
    vm.viewImgButton = true;
    vm.imgTip = "";
    vm.CheckSub = false;//当该参数为true时,才会执行提交数据
    //----------------------------------------------添加关于我们的方法
    vm.addCourseFun = function () {
        if (vm.buttonType == "添加" && vm.CourseModel.Id == 0) {
            AddCourse_Ajax();
        }
        if (vm.buttonType == "修改" && vm.CourseModel.Id != 0) {
            UpdateCourse_Ajax();
        }
    };
    vm.uploadAjaxInfomationImg = function () {
        UploadImgFun();
    };
    //----------------------------------------------错误信息对象
    vm.errorMsg = {
        level: "请选择课程分类",
        Name: "请填写课程名称",
        Content: "请填写课程大纲",
        Sort: "请填写正确的数字",
        TName: "请选择主讲老师"
    };
    vm.uploadAjax = function () {
        UploadVideoFun(1);
    };
    vm.uploadImgAjax = function () {
        UploadImg2Fun(0);
    };
    //----------------------------------------------获取栏目分类列表
    vm.getTypeList = function () {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Course/GetTypeList',
            data: { page: 1, size: 999 },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData.Status == true) {
                    vm.typeList = ajaxData.Data;
                }
            },
            dataType: 'json'
        });
    };
    vm.getTeacherList = function () {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Course/GetTeacherList',
            data: { page: 1, size: 999 },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData.Status == true) {
                    vm.teacherList = ajaxData.Data;
                }
            },
            dataType: 'json'
        });
    };
    vm.changeType = function () {
        var pid = vm.CourseModel.cType;
        console.log(pid);
        vm.ShowDiv(pid);
    }
    vm.ShowDiv = function (type)
    {
        if (type == 1000) {
            $("#warediv").show();
            $("#pricediv").hide();
        } else if (type == 1001) {
            $("#warediv").hide();
            $("#pricediv").show();
        } else if (type == 1002) {
            $("#warediv").hide();
            $("#pricediv").show();
        } else if (type == 1003) {
            $("#warediv").show();
            $("#pricediv").show();
        }
    }
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
});
avalon.scan();
CourseAddOrUpdate.getTypeList();
CourseAddOrUpdate.getTeacherList();
if (CourseAddOrUpdate.CourseModel.Id != 0) {
    CourseAddOrUpdate.buttonType = "修改";
    GetCourseById_Ajax();
}
function UploadVideoFun(type) {
    $.ajaxFileUpload
            (
                {
                    url: Config.WebUrl + 'Ajax_CommonHelper/UploadVideo', //用于文件上传的服务器端请求地址
                    secureuri: false, //一般设置为false
                    fileElementId: type == 0 ? 'file' : 'file1', //文件上传空间的id属性  <input type="file" id="file" name="file" />
                    dataType: 'json', //返回值类型 一般设置为json
                    data: { type: type },
                    success: function (data, status)  //服务器成功响应处理函数
                    {
                        var args = data.data.split("|");
                        if (args[0] == "1") {
                            //$("#showimg").html(args[1] + "<br /><img src='" + args[2] + "'>");
                            var imgPath = args[2];
                            if (type == 0) {
                                CourseAddOrUpdate.CourseModel.cFileUrlw = imgPath;
                            }
                            else {
                                CourseAddOrUpdate.CourseModel.cFileUrlw = imgPath;
                            }
                        } else {
                            alert("上传失败,请重新选择视频上传!");
                        }
                    },
                    error: function (data, status, e)//服务器响应失败处理函数
                    {
                        alert("错误:" + e);
                    }
                }
            )
    return false;
}
function UploadImg2Fun(type) {
    $.ajaxFileUpload
            (
                {
                    url: Config.WebUrl + 'Ajax_CommonHelper/Photo_Save', //用于文件上传的服务器端请求地址
                    secureuri: false, //一般设置为false
                    fileElementId: type == 0 ? 'file2' : 'file3', //文件上传空间的id属性  <input type="file" id="file" name="file" />
                    dataType: 'json', //返回值类型 一般设置为json
                    data: { type: "headimg" },
                    success: function (data, status)  //服务器成功响应处理函数
                    {
                        var args = data.data.split("|");
                        if (args[0] == "1") {
                            //$("#showimg").html(args[1] + "<br /><img src='" + args[2] + "'>");
                            var imgPath = args[2];
                            if (type == 0) {
                                CourseAddOrUpdate.CourseModel.cImages2 = imgPath;
                            }
                            else {
                                CourseAddOrUpdate.CourseModel.cImages2 = imgPath;
                            }
                        } else {
                            alert("上传失败,请重新选择图片上传!");
                        }
                    },
                    error: function (data, status, e)//服务器响应失败处理函数
                    {
                        alert("错误:" + e);
                    }
                }
            )
    return false;
}
function AddCourse_Ajax() {
    if (InitValidatorDataFun()) {
        var subData = $.extend({}, CourseAddOrUpdate.CourseModel.$model);
        //subData.Content = escape(subData.Content);
        var saveData = JSON.stringify(subData);
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Course/AddCourse',
            data: { jsonModel: saveData },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData === "True") {
                    alert('添加成功');
                    location.href = Config.WebUrl + "CourseManage/Index";
                }
            },
            dataType: 'text'
        });
    }
}
function UpdateCourse_Ajax() {
    if (InitValidatorDataFun()) {
        var subData = $.extend({}, CourseAddOrUpdate.CourseModel.$model);
        //subData.Content = escape(subData.Content);
        var saveData = JSON.stringify(subData);
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Course/UpdateCourse',
            data: { jsonModel: saveData },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData === "True") {
                    alert('修改成功');
                    location.href = Config.WebUrl + "CourseManage/Index";
                }
            },
            dataType: 'text'
        });
    }
}
function GetCourseById_Ajax() {
    $.ajax({
        type: 'POST',
        url: Config.WebUrl + 'Ajax_Course/GetCourseById',
        data: { id: CourseAddOrUpdate.CourseModel.Id },
        timeout: 200000,
        success: function (ajaxData) {
            CourseAddOrUpdate.CourseModel.cTitle = ajaxData.cTitle;
            CourseAddOrUpdate.CourseModel.cType = ajaxData.cType;
            CourseAddOrUpdate.CourseModel.Content = ajaxData.Content;
            CourseAddOrUpdate.CourseModel.TeacherId = ajaxData.TeacherId;
            CourseAddOrUpdate.CourseModel.cPrice = ajaxData.cPrice;
            CourseAddOrUpdate.CourseModel.cReward = ajaxData.cReward;
            CourseAddOrUpdate.CourseModel.Userid = ajaxData.Userid;
            CourseAddOrUpdate.CourseModel.IsOne = ajaxData.IsOne;
            CourseAddOrUpdate.CourseModel.cTitlew = ajaxData.cTitlew;
            CourseAddOrUpdate.CourseModel.cRemarkw = ajaxData.cRemarkw;
            CourseAddOrUpdate.CourseModel.cFileUrlw = ajaxData.cFileUrlw;
            CourseAddOrUpdate.CourseModel.cFileType = ajaxData.cFileType;
            CourseAddOrUpdate.CourseModel.cImages2 = ajaxData.cImages2 == null ? "" : ajaxData.cImages2;
            CourseAddOrUpdate.CourseModel.cImages = ajaxData.cImages == null ? "" : ajaxData.cImages;
            CourseAddOrUpdate.imgTip = CourseAddOrUpdate.CourseModel.cImages;
            CourseAddOrUpdate.ShowDiv(ajaxData.cType);
            if (CourseAddOrUpdate.CourseModel.cImages != "") {
                var img = new Image();
                img.style.width = "180px";
                img.style.height = "150px";
                img.src = CourseAddOrUpdate.CourseModel.cImages;
                document.getElementById("preview_img_page").appendChild(img);
            }
        }, error: function () {
            alert('對不起,沒有數據可以修改!');
            location.href = Config.WebUrl + "CourseManage/Index";
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
                    data: { type: "course" },
                    success: function (data, status)  //服务器成功响应处理函数
                    {
                        var args = data.data.split("|");
                        if (args[0] == "1") {
                            //$("#showimg").html(args[2] + "<br /><img src='" + args[2] + "'>");
                            var imgPath = args[2];
                            CourseAddOrUpdate.CourseModel.cImages = imgPath;
                            CourseAddOrUpdate.imgTip = CourseAddOrUpdate.CourseModel.cImages;
                            CourseAddOrUpdate.viewImgButton = false;
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
    if (CourseAddOrUpdate.CourseModel.cType === 0) {
        alert(CourseAddOrUpdate.errorMsg.level);
        check = false;
    }
    if ($.trim(CourseAddOrUpdate.CourseModel.cTitle) === "") {
        alert(CourseAddOrUpdate.errorMsg.Name);
        check = false;
    }
    if ($.trim(CourseAddOrUpdate.CourseModel.Content) === "") {
        alert(CourseAddOrUpdate.errorMsg.Content);
        check = false;
    }
    return check;
}

