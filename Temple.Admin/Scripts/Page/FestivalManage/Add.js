var DataAddOrUpdate = avalon.define('DataAddOrUpdate', function (vm) {
    vm.buttonType = "添加";
    vm.NewModel = {
        Id: $("#Id_pageDom").val(),
        Name: "",
        Code: "",
        Location: "",
        Date: "",
        Info: "",
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
        Account: "請填寫法會代號",
        Name: "請填寫法會名稱",
        Location: "請填寫法會地點",
        OnBoardDate: "請填寫法會日期",
        Info: "請填寫法會內容",
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
            url: Config.WebUrl + 'Ajax_Festival/AddFestival',
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
            url: Config.WebUrl + 'Ajax_Festival/UpdateFestival',
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
        url: Config.WebUrl + 'Ajax_Festival/GetFestivalById',
        data: { id: DataAddOrUpdate.NewModel.Id },
        timeout: 200000,
        success: function (ajaxData) {
            DataAddOrUpdate.NewModel.Name = ajaxData.Name;
            DataAddOrUpdate.NewModel.Code = ajaxData.Code;
            DataAddOrUpdate.NewModel.Info = ajaxData.Info;
            DataAddOrUpdate.NewModel.Date = returntwDate(avalon.filters.date(ajaxData.Date, "yyyyMMdd"));
            DataAddOrUpdate.NewModel.Location = ajaxData.Location;
            DataAddOrUpdate.NewModel.Remark = ajaxData.Remark;
            
        }, error: function () {
            alert('對不起,沒有數據可以修改!');
            location.href = Config.WebUrl + "FestivalManage/List";
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
    if ($.trim(DataAddOrUpdate.NewModel.Code) === "") {
        alert(DataAddOrUpdate.errorMsg.Account);
        check = false;
    } else if ($.trim(DataAddOrUpdate.NewModel.Name) === "") {
        alert(DataAddOrUpdate.errorMsg.Name);
        check = false;
    } else if ($.trim(DataAddOrUpdate.NewModel.Date) === "") {
        alert(DataAddOrUpdate.errorMsg.OnBoardDate);
        check = false;
    } else if ($.trim(DataAddOrUpdate.NewModel.Location) === "") {
        alert(DataAddOrUpdate.errorMsg.Location);
        check = false;
    } else if ($.trim(DataAddOrUpdate.NewModel.Info) === "") {
        alert(DataAddOrUpdate.errorMsg.Info);
        check = false;
    }

    return check;
}

function CloseWindow() {
    window.opener.OpenWindowFunGetList();
    window.open('', '_parent', '');
    window.close();
}

