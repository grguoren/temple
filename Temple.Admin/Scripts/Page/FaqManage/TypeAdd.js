var AboutTypeAddOrUpdate = avalon.define('aboutTypeAddOrUpdate', function (vm) {
    vm.buttonType = "添加";
    vm.aboutTypeModel = {
        Id: $("#aboutTypeId_pageDom").val(),
        Remark: "",
        Name: "",
        Sort: 0
    };
    vm.CheckSub = false;//当该参数为true时,才会执行提交数据
    //----------------------------------------------添加资讯的方法
    vm.addAboutTypeFun = function () {
        if (vm.buttonType == "添加" && vm.aboutTypeModel.Id == 0) {
            AddAboutType_Ajax();
        }
        if (vm.buttonType == "修改" && vm.aboutTypeModel.Id != 0) {
            UpdateAboutType_Ajax();
        }
    };
    //----------------------------------------------错误信息对象
    vm.errorMsg = {
        Name: "请填写关于我们分类名称",
        Sort: "请填写正确的数字"
    };
});
avalon.scan();
if (AboutTypeAddOrUpdate.aboutTypeModel.Id != 0) {
    AboutTypeAddOrUpdate.buttonType = "修改";
    GetAboutTypeById_Ajax();
}

function AddAboutType_Ajax() {
    if (InitValidatorDataFun()) {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_About/AddAboutType',
            data: {
                name: AboutTypeAddOrUpdate.aboutTypeModel.Name,
                remark: AboutTypeAddOrUpdate.aboutTypeModel.Remark,
                sort: AboutTypeAddOrUpdate.aboutTypeModel.Sort
            },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData === "True") {
                    alert('添加成功');
                    location.href = Config.WebUrl + "FaqManage/TypeList";
                }
            },
            dataType: 'text'
        });
    }
}
function UpdateAboutType_Ajax() {
    if (InitValidatorDataFun()) {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_About/UpdateAboutType',
            data: {
                name: AboutTypeAddOrUpdate.aboutTypeModel.Name,
                remark: AboutTypeAddOrUpdate.aboutTypeModel.Remark,
                sort: AboutTypeAddOrUpdate.aboutTypeModel.Sort,
                id: AboutTypeAddOrUpdate.aboutTypeModel.Id
            },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData === "True") {
                    alert('修改成功');
                    location.href = Config.WebUrl + "FaqManage/TypeList";
                }
            },
            dataType: 'text'
        });
    }
}
function GetAboutTypeById_Ajax() {
    $.ajax({
        type: 'POST',
        url: Config.WebUrl + 'Ajax_About/GetAboutTypeById',
        data: { id: AboutTypeAddOrUpdate.aboutTypeModel.Id },
        timeout: 200000,
        success: function (ajaxData) {
            AboutTypeAddOrUpdate.aboutTypeModel.Name = ajaxData.Name;
            AboutTypeAddOrUpdate.aboutTypeModel.Remark = ajaxData.Remark;
            AboutTypeAddOrUpdate.aboutTypeModel.Sort = ajaxData.Sort;
        }, error: function () {
            alert('对不起,没有数据可以修改!');
            location.href = Config.WebUrl + "FaqManage/TypeList";
        },
        dataType: 'json'
    });
}

function InitValidatorDataFun() {
    var check = true;
    if ($.trim(AboutTypeAddOrUpdate.aboutTypeModel.Name) === "") {
        alert(AboutTypeAddOrUpdate.errorMsg.Name);
        check = false;
    }
    if ($.trim(AboutTypeAddOrUpdate.aboutTypeModel.Sort) == "" || ($.trim(AboutTypeAddOrUpdate.aboutTypeModel.Sort) != "" && isNaN(AboutTypeAddOrUpdate.aboutTypeModel.Sort))) {
        alert(AboutTypeAddOrUpdate.errorMsg.Sort);
        check = false;
    }
    return check;
}

