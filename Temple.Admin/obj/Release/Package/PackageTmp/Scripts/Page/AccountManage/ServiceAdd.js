var DataAddOrUpdate = avalon.define('DataAddOrUpdate', function (vm) {
    vm.buttonType = "添加";
    vm.accountList = [];
    vm.NewModel = {
        Id: $("#Id_pageDom").val(),
        Name: "",
        Status: 1,
        Code: "",
        Remark: "",
        Type: 1,
        Accounting_unit_id:0
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
        Name: "請填寫服務項目名稱",
        Type: "請選擇入帳單位",
        Sort: "請填寫正確的數字"
    };

    vm.getAccountList = function () {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Account/GetAccountList',
            data: { page: 1, size: 999 },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData.Status == true) {
                    vm.accountList = ajaxData.Data;
                }
            },
            dataType: 'json'
        });
    };
});
DataAddOrUpdate.getAccountList();
avalon.scan();
if (DataAddOrUpdate.NewModel.Id != 0) {
    DataAddOrUpdate.buttonType = "修改";
    GetDataById_Ajax();
}

function AddData_Ajax() {
    if (InitValidatorDataFun()) {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Account/AddService',
            data: {
                name: DataAddOrUpdate.NewModel.Name,
                code: DataAddOrUpdate.NewModel.Code,
                remark: DataAddOrUpdate.NewModel.Remark,
                status: DataAddOrUpdate.NewModel.Status,
                type: DataAddOrUpdate.NewModel.Type,
                unitid: DataAddOrUpdate.NewModel.Accounting_unit_id
            },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData === "True") {
                    alert('添加成功');
                    location.href = Config.WebUrl + "AccountManage/ServiceList";
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
            url: Config.WebUrl + 'Ajax_Account/UpdateService',
            data: {
                name: DataAddOrUpdate.NewModel.Name,
                code: DataAddOrUpdate.NewModel.Code,
                remark: DataAddOrUpdate.NewModel.Remark,
                status: DataAddOrUpdate.NewModel.Status,
                unitid: DataAddOrUpdate.NewModel.Accounting_unit_id,
                type: DataAddOrUpdate.NewModel.Type,
                id: DataAddOrUpdate.NewModel.Id
            },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData === "True") {
                    alert('修改成功');
                    location.href = Config.WebUrl + "AccountManage/ServiceList";
                }
            },
            dataType: 'text'
        });
    }
}
function GetDataById_Ajax() {
    $.ajax({
        type: 'POST',
        url: Config.WebUrl + 'Ajax_Account/GetServiceById',
        data: { id: DataAddOrUpdate.NewModel.Id },
        timeout: 200000,
        success: function (ajaxData) {
            DataAddOrUpdate.NewModel.Name = ajaxData.Name;
            DataAddOrUpdate.NewModel.Status = ajaxData.Status == true ? 1 : 0;
            DataAddOrUpdate.NewModel.Code = ajaxData.Code;
            DataAddOrUpdate.NewModel.Remark = ajaxData.Remark;
            DataAddOrUpdate.NewModel.Accounting_unit_id = ajaxData.Accounting_unit_id;
            DataAddOrUpdate.NewModel.Type = ajaxData.Type;
        }, error: function () {
            alert('對不起,沒有數據可以修改!');
            location.href = Config.WebUrl + "AccountManage/ServiceList";
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

