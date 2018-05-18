var DataAddOrUpdate = avalon.define('DataAddOrUpdate', function (vm) {
    vm.buttonType = "添加";
    vm.NewModel = {
        Id: $("#Id_pageDom").val(),
        Name: "",
        Status: 1,
        Code: "",
        Remark: ""
    };
    vm.CheckSub = false;//当该参数为true时,才会执行提交数据
    //----------------------------------------------添加资讯的方法
    vm.addDataFun = function () {
        if (vm.buttonType == "添加" && vm.NewModel.Id == 0) {
            AddData_Ajax();
        }
        if (vm.buttonType == "修改" && vm.NewModel.Id != 0) {
            UpdateData_Ajax();
        }
    };
    //----------------------------------------------错误信息对象
    vm.errorMsg = {
        Name: "請填寫稱謂名稱",
        Sort: "請填寫正確的數字"
    };
});
avalon.scan();
if (DataAddOrUpdate.NewModel.Id != 0) {
    DataAddOrUpdate.buttonType = "修改";
    GetDataById_Ajax();
}

function AddData_Ajax() {
    if (InitValidatorDataFun()) {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Title/AddTitle',
            data: {
                name: DataAddOrUpdate.NewModel.Name,
                code: DataAddOrUpdate.NewModel.Code,
                remark: DataAddOrUpdate.NewModel.Remark,
                status: DataAddOrUpdate.NewModel.Status
            },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData === "True") {
                    alert('添加成功');
                    location.href = Config.WebUrl + "BasicManage/Title";
                }
            },
            dataType: 'text'
        });
    }
}
function UpdateData_Ajax() {
    if (InitValidatorDataFun()) {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Title/UpdateTitle',
            data: {
                name: DataAddOrUpdate.NewModel.Name,
                code: DataAddOrUpdate.NewModel.Code,
                remark: DataAddOrUpdate.NewModel.Remark,
                status: DataAddOrUpdate.NewModel.Status,
                id: DataAddOrUpdate.NewModel.Id
            },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData === "True") {
                    alert('修改成功');
                    location.href = Config.WebUrl + "BasicManage/Title";
                }
            },
            dataType: 'text'
        });
    }
}
function GetDataById_Ajax() {
    $.ajax({
        type: 'POST',
        url: Config.WebUrl + 'Ajax_Title/GetTitleById',
        data: { id: DataAddOrUpdate.NewModel.Id },
        timeout: 200000,
        success: function (ajaxData) {
            DataAddOrUpdate.NewModel.Name = ajaxData.Name;
            DataAddOrUpdate.NewModel.Status = ajaxData.Status == true?1:0;
            DataAddOrUpdate.NewModel.Code = ajaxData.Code;
            DataAddOrUpdate.NewModel.Remark = ajaxData.Remark;
        }, error: function () {
            alert('對不起,沒有數據可以修改!');
            location.href = Config.WebUrl + "BasicManage/Title";
        },
        dataType: 'json'
    });
}

function InitValidatorDataFun() {
    var check = true;
    if ($.trim(DataAddOrUpdate.NewModel.Name) === "") {
        alert(DataAddOrUpdate.errorMsg.Name);
        check = false;
    }
    return check;
}

