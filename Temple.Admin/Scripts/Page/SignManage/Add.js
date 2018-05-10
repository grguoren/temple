var CourseAddOrUpdate = avalon.define('courseAddOrUpdate', function (vm) {
    vm.buttonType = "添加";
    vm.typeList = [];
    vm.teacherList = [];
    vm.brandList = [];
    vm.CourseModel = {
        Id: $("#courseId_pageDom").val(),
        Phone: "",
        Name: "",
        Type: 3,
        Seat: "",
        Present: "",
        Hassign: 0,
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

    //----------------------------------------------错误信息对象
    vm.errorMsg = {
        Name: "请填写姓名",
        Phone: "请填写手机号码"
    };
});
avalon.scan();
if (CourseAddOrUpdate.CourseModel.Id != 0) {
    CourseAddOrUpdate.buttonType = "修改";
    GetCourseById_Ajax();
}

function AddCourse_Ajax() {
    if (InitValidatorDataFun()) {
        var subData = $.extend({}, CourseAddOrUpdate.CourseModel.$model);
        var saveData = JSON.stringify(subData);
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Sign/AddSign',
            data: { jsonModel: saveData },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData === "True") {
                    alert('添加成功');
                    location.href = Config.WebUrl + "SignManage/List";
                }
            },
            dataType: 'text'
        });
    }
}
function UpdateCourse_Ajax() {
    if (InitValidatorDataFun()) {
        var subData = $.extend({}, CourseAddOrUpdate.CourseModel.$model);
        var saveData = JSON.stringify(subData);
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Sign/UpdateSign',
            data: { jsonModel: saveData },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData === "True") {
                    alert('修改成功');
                    location.href = Config.WebUrl + "SignManage/List";
                }
            },
            dataType: 'text'
        });
    }
}
function GetCourseById_Ajax() {
    $.ajax({
        type: 'POST',
        url: Config.WebUrl + 'Ajax_Sign/GetSignById',
        data: { id: CourseAddOrUpdate.CourseModel.Id },
        timeout: 200000,
        success: function (ajaxData) {
            CourseAddOrUpdate.CourseModel.Name = ajaxData.Name;
            CourseAddOrUpdate.CourseModel.Phone = ajaxData.Phone;
            CourseAddOrUpdate.CourseModel.Seat = ajaxData.Seat;
            CourseAddOrUpdate.CourseModel.Present = ajaxData.Present;
            CourseAddOrUpdate.CourseModel.Type = ajaxData.Type;
            CourseAddOrUpdate.CourseModel.Hassign = ajaxData.Hassign
            
        }, error: function () {
            alert('對不起,沒有數據可以修改!');
            location.href = Config.WebUrl + "SignManage/List";
        },
        dataType: 'json'
    });
}

function InitValidatorDataFun() {
    var check = true;
    if ($.trim(CourseAddOrUpdate.CourseModel.Name) === "") {
        alert(CourseAddOrUpdate.errorMsg.Name);
        check = false;
    }
    if ($.trim(CourseAddOrUpdate.CourseModel.Phone) === "") {
        alert(CourseAddOrUpdate.errorMsg.Phone);
        check = false;
    }
    return check;
}

