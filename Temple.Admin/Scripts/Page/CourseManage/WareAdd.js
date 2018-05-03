var CourseAddOrUpdate = avalon.define('courseAddOrUpdate', function (vm) {
    vm.buttonType = "添加";
    vm.typeList = [];
    vm.teacherList = [];
    vm.brandList = [];
    vm.CourseModel = {
        Id: $("#coursewareId_pageDom").val(),
        cTitle: "",
        cRemark: "",
        cFileUrl: "",
        cFileImage:"",
        cFileType: 0,
        CuId: $("#courseId_pageDom").val()
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
        Name: "请填写课节名称",
        Content: "请填写课节介绍",
        Sort: "请填写正确的数字",
        TName: "请选择主讲老师"
    };
    vm.uploadAjax = function () {
        UploadVideoFun(1);
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
});
avalon.scan();
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
                                CourseAddOrUpdate.CourseModel.cFileUrl = imgPath;
                            }
                            else {
                                CourseAddOrUpdate.CourseModel.cFileUrl = imgPath;
                            }
                        } else {
                            alert(args[1]);
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
            url: Config.WebUrl + 'Ajax_Course/AddCourseWare',
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
            url: Config.WebUrl + 'Ajax_Course/UpdateCourseWare',
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
            CourseAddOrUpdate.CourseModel.cTitle = ajaxData.cTitlew;
            CourseAddOrUpdate.CourseModel.cRemark = ajaxData.cRemarkw;
            CourseAddOrUpdate.CourseModel.cFileUrl = ajaxData.cFileUrlw;
            CourseAddOrUpdate.CourseModel.cFileType = ajaxData.cFileType;
            CourseAddOrUpdate.CourseModel.cFileImage = ajaxData.cFileImage == null ? "" : ajaxData.cFileImage;
            CourseAddOrUpdate.imgTip = CourseAddOrUpdate.CourseModel.cFileImage;
            if (CourseAddOrUpdate.CourseModel.cFileImage != "") {
                var img = new Image();
                img.style.width = "180px";
                img.style.height = "150px";
                img.src = CourseAddOrUpdate.CourseModel.cFileImage;
                document.getElementById("preview_img_page").appendChild(img);
            }
        }, error: function () {
            alert('对不起,没有数据可以修改!');
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
                    data: { type: "CourseWare" },
                    success: function (data, status)  //服务器成功响应处理函数
                    {
                        var args = data.data.split("|");
                        if (args[0] == "1") {
                            //$("#showimg").html(args[2] + "<br /><img src='" + args[2] + "'>");
                            var imgPath = args[2];
                            CourseAddOrUpdate.CourseModel.cFileImage = imgPath;
                            CourseAddOrUpdate.imgTip = CourseAddOrUpdate.CourseModel.cFileImage;
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
    if ($.trim(CourseAddOrUpdate.CourseModel.cTitle) === "") {
        alert(CourseAddOrUpdate.errorMsg.Name);
        check = false;
    }
    if ($.trim(CourseAddOrUpdate.CourseModel.cRemark) === "") {
        alert(CourseAddOrUpdate.errorMsg.Content);
        check = false;
    }
    return check;
}

