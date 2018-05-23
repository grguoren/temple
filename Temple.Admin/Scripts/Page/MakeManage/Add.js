var DataAddOrUpdate = avalon.define('DataAddOrUpdate', function (vm) {
    vm.buttonType = "添加";
    vm.NewModel = {
        Id: $("#Id_pageDom").val(),
        Member_Id: 0,
        Ask_Date: "",
        Ask_Info: "",
        Instructions: "",
        Confirmation_date:"",
        Reply_YN: "Y",
        Publish_YN: "Y",
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
        Ask_Date: "請填寫法會代號",
        Ask_Info: "請填寫法會名稱",
        Instructions: "請填寫法會地點",
        Confirmation_date: "請填寫法會日期",
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
        var subData = $.extend({}, DataAddOrUpdate.NewModel.$model);
        var saveData = JSON.stringify(subData);
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Make/AddMake',
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
function UpdateData_Ajax() {
    if (InitValidatorDataFun()) {
        var subData = $.extend({}, DataAddOrUpdate.NewModel.$model);
        var saveData = JSON.stringify(subData);
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Make/UpdateMake',
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
function GetDataById_Ajax() {
    $.ajax({
        type: 'POST',
        url: Config.WebUrl + 'Ajax_Make/GetMakeById',
        data: { id: DataAddOrUpdate.NewModel.Id },
        timeout: 200000,
        success: function (ajaxData) {
            DataAddOrUpdate.NewModel.Ask_Date = returntwDate(avalon.filters.date(ajaxData.Ask_Date, "yyyyMMdd"));
            DataAddOrUpdate.NewModel.Ask_Info = ajaxData.Ask_Info;
            DataAddOrUpdate.NewModel.Instructions = ajaxData.Instructions;
            DataAddOrUpdate.NewModel.Confirmation_date = returntwDate(avalon.filters.date(ajaxData.Confirmation_date, "yyyyMMdd"));
            DataAddOrUpdate.NewModel.Reply_YN = ajaxData.Reply_YN;
            DataAddOrUpdate.NewModel.Publish_YN = ajaxData.Publish_YN;
            DataAddOrUpdate.NewModel.Remark = ajaxData.Remark;

        }, error: function () {
            alert('對不起,沒有數據可以修改!');
            location.href = Config.WebUrl + "MakeManage/List";
        },
        dataType: 'json'
    });
}

function returntwDate(westdate) {
    if (westdate != "") {
        var year = westdate.substr(0, 4) - 1911; //获取完整的年份(4位,1970-????)
        var month = westdate.substr(4, 2); //获取当前月份(0-11,0代表1月)
        var day = westdate.substr(6, 2); //获取当前日(1-31)
        return year + "/" + month + "/" + day;
    }
    return "";

}
function InitValidatorDataFun() {
    var check = true;
    if ($.trim(DataAddOrUpdate.NewModel.Ask_Date) === "") {
        alert(DataAddOrUpdate.errorMsg.Ask_Date);
        check = false;
    } else if ($.trim(DataAddOrUpdate.NewModel.Ask_Info) === "") {
        alert(DataAddOrUpdate.errorMsg.Ask_Info);
        check = false;
    } else if ($.trim(DataAddOrUpdate.NewModel.Instructions) === "") {
        alert(DataAddOrUpdate.errorMsg.Instructions);
        check = false;
    } else if ($.trim(DataAddOrUpdate.NewModel.Confirmation_date) === "") {
        alert(DataAddOrUpdate.errorMsg.Confirmation_date);
        check = false;
    } 

    return check;
}

function CloseWindow() {
    window.opener.OpenWindowFunGetList();
    window.open('', '_parent', '');
    window.close();
}

