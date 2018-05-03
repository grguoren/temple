var TeacherAddOrUpdate = avalon.define('teacherAddOrUpdate', function (vm) {
    vm.buttonType = "添加";
    vm.typeList = [];
    vm.brandList = [];
    vm.TeacherModel = {
        Id: $("#teacherId_pageDom").val(),
        tName: "",
        tRemark: "",
        Position: "",
        IsVerify: 0,
        HeadImages: ""
    };
    vm.viewImgButton = true;
    vm.imgTip = "";
    vm.CheckSub = false;//当该参数为true时,才会执行提交数据
    //----------------------------------------------添加关于我们的方法
    vm.addTeacherFun = function () {
        if (vm.buttonType == "添加" && vm.TeacherModel.Id == 0) {
            AddTeacher_Ajax();
        }
        if (vm.buttonType == "修改" && vm.TeacherModel.Id != 0) {
            UpdateTeacher_Ajax();
        }
    };
    vm.uploadAjaxInfomationImg = function () {
        UploadImgFun();
    };
    //----------------------------------------------错误信息对象
    vm.errorMsg = {
        Position: "请填写讲师头衔",
        tName: "请填写讲师姓名",
        tRemark: "请填写讲师简介"
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
if (TeacherAddOrUpdate.TeacherModel.Id != 0) {
    TeacherAddOrUpdate.buttonType = "修改";
    GetTeacherById_Ajax();
}

function AddTeacher_Ajax() {
    if (InitValidatorDataFun()) {
        var subData = $.extend({}, TeacherAddOrUpdate.TeacherModel.$model);
        subData.tRemark = escape(subData.tRemark);
        var saveData = JSON.stringify(subData);
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_MyUser/AddTeacher',
            data: { jsonModel: saveData },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData === "True") {
                    alert('添加成功');
                    location.href = Config.WebUrl + "EnterManage/CTeacherList";
                }
            },
            dataType: 'text'
        });
    }
}

function UpdateTeacher_Ajax() {
    if (InitValidatorDataFun()) {
        var subData = $.extend({}, TeacherAddOrUpdate.TeacherModel.$model);
        subData.tRemark = escape(subData.tRemark);
        var saveData = JSON.stringify(subData);
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_MyUser/UpdateTeacher',
            data: { jsonModel: saveData },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData === "True") {
                    alert('修改成功');
                    location.href = Config.WebUrl + "EnterManage/CTeacherList";
                }
            },
            dataType: 'text'
        });
    }
}

function GetTeacherById_Ajax() {
    $.ajax({
        type: 'POST',
        url: Config.WebUrl + 'Ajax_MyUser/GetMyTeacherUserById',
        data: { id: TeacherAddOrUpdate.TeacherModel.Id },
        timeout: 200000,
        success: function (ajaxData) {
            TeacherAddOrUpdate.TeacherModel.tName = ajaxData.tName;
            TeacherAddOrUpdate.TeacherModel.tRemark = ajaxData.tRemark;
            TeacherAddOrUpdate.TeacherModel.Position = ajaxData.Position;
            TeacherAddOrUpdate.TeacherModel.HeadImages = ajaxData.HeadImages == null ? "" : ajaxData.HeadImages;
            TeacherAddOrUpdate.imgTip = TeacherAddOrUpdate.TeacherModel.HeadImages;
            if (TeacherAddOrUpdate.TeacherModel.HeadImages != "") {
                var img = new Image();
                img.style.width = "180px";
                img.style.height = "150px";
                img.src = TeacherAddOrUpdate.TeacherModel.HeadImages;
                document.getElementById("preview_img_page").appendChild(img);
            }
        }, error: function () {
            alert('对不起,没有数据可以修改!');
            location.href = Config.WebUrl + "EnterManage/CTeacherList";
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
                    data: { type: "headimage_" },
                    success: function (data, status)  //服务器成功响应处理函数
                    {
                        var args = data.data.split("|");
                        if (args[0] == "1") {
                            //$("#showimg").html(args[2] + "<br /><img src='" + args[2] + "'>");
                            var imgPath = args[2];
                            TeacherAddOrUpdate.TeacherModel.HeadImages = imgPath;
                            TeacherAddOrUpdate.imgTip = TeacherAddOrUpdate.TeacherModel.HeadImages;
                            TeacherAddOrUpdate.viewImgButton = false;
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
    if (TeacherAddOrUpdate.TeacherModel.tName === "") {
        alert(TeacherAddOrUpdate.errorMsg.tName);
        check = false;
    }
    if ($.trim(TeacherAddOrUpdate.TeacherModel.Position) === "") {
        alert(TeacherAddOrUpdate.errorMsg.Position);
        check = false;
    }
    if ($.trim(TeacherAddOrUpdate.TeacherModel.tRemark) === "") {
        alert(TeacherAddOrUpdate.errorMsg.tRemark);
        check = false;
    }
    return check;
}

