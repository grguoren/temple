var DataAddOrUpdate = avalon.define('DataAddOrUpdate', function (vm) {
    vm.buttonType = "添加";
    vm.NewModel = {
        Id: $("#Id_pageDom").val(),
        Name: "",
        Status: 1,
        Account: "",
        Mobile: "",
        OnBoardDate: "",
        ResignationDate: "",
        FileName: "",
        Passwd:"",
        Remark: ""
    };

    vm.viewImgButton = true;
    vm.imgTip = "";
    vm.uploadAjaxInfomationImg = function () {
        UploadImgFun();
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
        Account: "請填寫使用者帳號",
        Name: "請填寫使用者名稱",
        Mobile: "請填寫行動電話",
        OnBoardDate: "請填寫到職日期",
        Passwd: "請填寫密碼",
        Sort: "請填寫正確的數字"
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
            url: Config.WebUrl + 'Ajax_User/AddUser',
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
            url: Config.WebUrl + 'Ajax_User/UpdateUser',
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
        url: Config.WebUrl + 'Ajax_User/GetUserById',
        data: { id: DataAddOrUpdate.NewModel.Id },
        timeout: 200000,
        success: function (ajaxData) {
            DataAddOrUpdate.NewModel.Name = ajaxData.Name;
            DataAddOrUpdate.NewModel.Status = ajaxData.Status == true ? 1 : 0;
            DataAddOrUpdate.NewModel.Account = ajaxData.Account;
            DataAddOrUpdate.NewModel.Mobile = ajaxData.Mobile;
            DataAddOrUpdate.NewModel.OnBoardDate = returntwDate(avalon.filters.date(ajaxData.OnBoardDate, "yyyyMMdd"));
            DataAddOrUpdate.NewModel.Passwd = ajaxData.Passwd;
            DataAddOrUpdate.NewModel.ResignationDate = returntwDate(ajaxData.ResignationDate != null ? avalon.filters.date(ajaxData.ResignationDate, "yyyyMMdd") : "");
            DataAddOrUpdate.NewModel.Remark = ajaxData.Remark;
            DataAddOrUpdate.NewModel.FileName = ajaxData.FileName;
            DataAddOrUpdate.imgTip = DataAddOrUpdate.NewModel.FileName;
            if (DataAddOrUpdate.NewModel.FileName != "") {
                var img = new Image();
                img.style.width = "180px";
                img.style.height = "150px";
                img.src = DataAddOrUpdate.NewModel.FileName;
                document.getElementById("preview_img_page").appendChild(img);
            }
        }, error: function () {
            alert('對不起,沒有數據可以修改!');
            location.href = Config.WebUrl + "System/UserIndex";
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
                    data: { type: "Invoice" },
                    success: function (data, status)  //服务器成功响应处理函数
                    {
                        var args = data.data.split("|");
                        if (args[0] == "1") {
                            var imgPath = args[2];
                            DataAddOrUpdate.NewModel.FileName = imgPath;
                            DataAddOrUpdate.imgTip = DataAddOrUpdate.NewModel.FileName
                            DataAddOrUpdate.viewImgButton = false;
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

function returntwDate(westdate)
{
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
    if ($.trim(DataAddOrUpdate.NewModel.Account) === "") {
        alert(DataAddOrUpdate.errorMsg.Account);
        check = false;
    } else if ($.trim(DataAddOrUpdate.NewModel.Name) === "") {
        alert(DataAddOrUpdate.errorMsg.Name);
        check = false;
    } else if ($.trim(DataAddOrUpdate.NewModel.Mobile) === "") {
        alert(DataAddOrUpdate.errorMsg.Mobile);
        check = false;
    } else if ($.trim(DataAddOrUpdate.NewModel.OnBoardDate) === "") {
        alert(DataAddOrUpdate.errorMsg.OnBoardDate);
        check = false;
    } else if ($.trim(DataAddOrUpdate.NewModel.Passwd) === "") {
        alert(DataAddOrUpdate.errorMsg.Passwd);
        check = false;
    }

    return check;
}

function CloseWindow() {
    window.opener.OpenWindowFunGetList();
    window.open('', '_parent', '');
    window.close();
}

