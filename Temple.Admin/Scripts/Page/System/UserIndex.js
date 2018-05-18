﻿
var UserList = avalon.define('userList', function (vm) {
    vm.type = "添加";
    vm.total = 0;
    vm.UserName = "";
    vm.NickName = "";
    vm.DepartName = "";
    vm.PWD = "";
    vm.ID = 0;
    vm.array = [];
    vm.Search_NickName = "";
    vm.Search_UserName = "";
    vm.List_Page = 1;
    vm.ListCount = 5;
    vm.ListLoading = false;
    vm.ListNoData = true;
    vm.viewImgButton = true;
    vm.imgTip = "";
    vm.uploadAjaxInfomationImg = function () {
        UploadImgFun();
    };
    /*************************分页******************************/
    vm.pager = {
        currentPage: 1,
        showPages: 6,
        perPages: 20,
        totalItems: 9,
        alwaysShowNext: true,
        alwaysShowPrev: true,
        onJump: function (e, data) {
            //avalon.log(data.currentPage);
            vm.List_Page = data.currentPage;
            vm.getList();
        }
    };
    vm.$watch("ListCount", function (a) {
        var widget = avalon.vmodels.pp
        if (widget) {
            widget.totalItems = a
        }
    });
    vm.$skipArray = ["pager"];
    /*************************分页******************************/
    vm.add = function () {
        if (vm.type == "修改") {
            vm.UserName = "";
            vm.NickName = "";
            vm.DepartName = "";
            vm.PWD = "";
            vm.ID = 0;
        }
        vm.type = "添加";
    };
    vm.edit = function (item) {
        vm.UserName = item.UserName;
        vm.NickName = item.NickName;
        vm.DepartName = item.DepartName;
        vm.PWD = item.Pwd;
        vm.ID = item.ID;
        vm.type = "修改";
    };
    vm.update = function () {
        updateItem(vm.type);
    };
    vm.getList = function (page) {
        if (page === 1) {
            vm.List_Page = 1;
        }

        vm.ListLoading = false;
        vm.ListNoData = true;
        vm.Search_UserName = $("#Search_UserName").val();
        vm.Search_NickName = $("#Search_NickName").val();
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_User/GetUserList',
            data: { page: vm.List_Page, size: vm.pager.perPages, username: vm.Search_UserName, nickname: vm.Search_NickName },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData.Count === 0) {
                    vm.ListCount = ajaxData.Count;

                    vm.array = ajaxData.Data;
                    vm.ListLoading = true;
                    vm.ListNoData = false;
                }
                else {
                    vm.ListCount = ajaxData.Count;
                    vm.array = ajaxData.Data;
                    vm.ListLoading = true;
                }
                //if (ajaxData.Status == true) {
                //    vm.array = ajaxData.Data;
                //    vm.ListCount = ajaxData.Count;
                //}
            },
            dataType: 'json'
        });
    };
    vm.Search_Clear = function () {
        vm.Search_NickName = "";
        vm.Search_UserName = "";
        vm.getList();
    };
    vm.EditData = function (id, name,dname, uname, pwd) {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_User/UpdateUser',
            data: { ID: id, NickName: name, DepartName: dname, UserName: uname, PWD: pwd },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData === "True") {
                    alert("修改成功！");
                }
                else {
                    alert("修改失败!");
                }
            },
            dataType: 'text'
        });
    }
    vm.removeUser = function (id) {
        if (window.confirm('你确定要删除吗？')) {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_User/DeleteUser',
                data: { id: id },
                timeout: 200000,
                success: function (ajaxData) {
                    if (ajaxData === "True") {
                        vm.getList();
                    }
                },
                dataType: 'text'
            });
        } else {
            return false;
        }
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
    /**设置权限的各个操作对象---(avalonJS不能直接给对象添加新属性,但是可以给对象的属性添加子属性,另外添加属性在IE6-8会出现异常需要特殊处理,所以尽量不要采用添加属性的方式,详见官网API)**/
    vm.RoleDom = {
        userID: 0,
        userName: "",
        roleList: [],
        selectList: []
    };
    vm.updateRoleUser = function () {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Role/AddRole_User',
            data: { roleids: vm.RoleDom.selectList.toString(), userid: vm.RoleDom.userID },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData === "True") {
                    $('#setRole_Modal_UserIndex').modal('hide');
                }
                else {
                    alert("设置权限失败,请重新保存,或者稍后再试...");
                }
            },
            dataType: 'text'
        });
    };
    vm.getRoleList = function (obj) {
        vm.RoleDom.userID = obj.Id;
        vm.RoleDom.userName = obj.UserName;
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Role/GetRoleList',
            data: {pid :1 },
            timeout: 200000,
            success: function (ajaxData) {
                vm.RoleDom.roleList = ajaxData.Data;
            },
            dataType: 'json'
        });
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Role/GetRole_UserList',
            data: { userid: obj.Id },
            timeout: 200000,
            success: function (ajaxData) {
                vm.RoleDom.selectList = ajaxData.Data;
            },
            dataType: 'json'
        });
    };
    /**设置权限的各个操作对象---(avalonJS不能直接给对象添加新属性,但是可以给对象的属性添加子属性,另外添加属性在IE6-8会出现异常需要特殊处理,所以尽量不要采用添加属性的方式,详见官网API)**/
});
UserList.getList();
avalon.scan();

function updateItem(type) {
    if (type == "添加") {
        if (UserList.UserName !== "" && UserList.NickName !== "" && UserList.PWD !== "") {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_User/AddUser',
                data: { UserName: UserList.UserName, NickName: UserList.NickName,DepartName:UserList.DepartName, PWD: UserList.PWD },
                timeout: 200000,
                success: function (ajaxData) {
                    if (ajaxData === "True") {
                        $('#addUser_Modal').modal('hide');
                        UserList.UserName = "";
                        UserList.NickName = "";
                        UserList.DepartName = "";
                        UserList.PWD = "";
                        UserList.getList();
                    }
                    else {
                        alert('用户名重复');
                    }
                },
                dataType: 'text'
            });
        }
        else {
            alert("请输入正确的信息");
        }
    }
    if (type == "修改") {
        if (UserList.UserName !== "" && UserList.NickName !== "" && UserList.PWD !== "") {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_User/UpdateUser',
                data: { ID: UserList.ID, UserName: UserList.UserName, NickName: UserList.NickName, DepartName: UserList.DepartName, PWD: UserList.PWD },
                timeout: 200000,
                success: function (ajaxData) {
                    if (ajaxData === "True") {
                        $('#addUser_Modal').modal('hide');
                        UserList.UserName = "";
                        UserList.NickName = "";
                        UserList.DepartName = "";
                        UserList.PWD = "";
                        UserList.ID = 0;
                        UserList.getList();
                    }
                },
                dataType: 'text'
            });
        }
        else {
            alert("请输入正确的信息");
        }
    }
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
                            //$("#showimg").html(args[2] + "<br /><img src='" + args[2] + "'>");
                            var imgPath = args[2];
                            //InvoiceList.EmailDom.ImgUrl = imgPath;
                            //InvoiceList.imgTip = InvoiceList.EmailDom.ImgUrl
                            UserList.viewImgButton = false;
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


