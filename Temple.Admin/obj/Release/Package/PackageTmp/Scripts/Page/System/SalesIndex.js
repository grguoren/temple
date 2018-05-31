
var UserList = avalon.define('userList', function (vm) {
    vm.type = "添加";
    vm.total = 0;
    vm.UserName = "";
    vm.NickName = "";
    vm.PWD = "";
    vm.ID = 0;
    vm.array = [];
    vm.array2 = [];
    vm.array3 = [];
    vm.Search_NickName = "";
    vm.Search_UserName = "";
    vm.List_Page = 1;
    vm.ListCount = 5;
    vm.ListLoading = false;
    vm.ListNoData = true;
    $("#date1").val(ReturnDateTimeNow());
    $("#date2").val(ReturnDateTimeNow());
    /*************************分页******************************/
    vm.pager = {
        currentPage: 1,
        showPages: 6,
        perPages: 18,
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
    vm.UpdateUserCacheFun = function () {
        $.ajax({
            type: 'POST',
            async: false,
            url: Config.WebUrl + 'Ajax_Sales/UpdateUserCache',
            data: {},
            timeout: 200000,
            error: function (XmlHttpRequest, textStatus, errorThrown) { },
            success: function (ajaxData) {
                alert("刷新成功!");
            },
            dataType: 'text'
        });
    }
    vm.add = function () {
        if (vm.type == "修改") {
            vm.UserName = "";
            vm.NickName = "";
            vm.PWD = "";
            vm.ID = 0;
        }
        vm.type = "添加";
    };
    vm.edit = function (item) {
        vm.UserName = item.sName;
        vm.NickName = item.sRealname;
        vm.PWD = "";
        vm.ID = item.sId;
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
        vm.Search_NickName = $("#Search_NickName").val();
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Sales/GetUserList',
            data: { page: 1, size: 18, nickname: vm.Search_NickName, date0: $("#date1").val(), date1: $("#date2").val()  },
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
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Sales/GetUserList',
            data: { page: 2, size: 18, nickname: vm.Search_NickName, date0: $("#date1").val(), date1: $("#date2").val() },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData.Count === 0) {
                    vm.ListCount = ajaxData.Count;

                    vm.array2 = ajaxData.Data;
                    vm.ListLoading = true;
                    vm.ListNoData = false;
                }
                else {
                    vm.ListCount = ajaxData.Count;
                    vm.array2 = ajaxData.Data;
                    vm.ListLoading = true;
                }
                //if (ajaxData.Status == true) {
                //    vm.array = ajaxData.Data;
                //    vm.ListCount = ajaxData.Count;
                //}
            },
            dataType: 'json'
        });
        //$.ajax({
        //    type: 'POST',
        //    url: Config.WebUrl + 'Ajax_Sales/GetUserList',
        //    data: { page: 3, size: 18, nickname: vm.Search_NickName, date0: $("#date1").val(), date1: $("#date2").val() },
        //    timeout: 200000,
        //    success: function (ajaxData) {
        //        if (ajaxData.Count === 0) {
        //            vm.ListCount = ajaxData.Count;

        //            vm.array3 = ajaxData.Data;
        //            vm.ListLoading = true;
        //            vm.ListNoData = false;
        //        }
        //        else {
        //            vm.ListCount = ajaxData.Count;
        //            vm.array3 = ajaxData.Data;
        //            vm.ListLoading = true;
        //        }
        //        //if (ajaxData.Status == true) {
        //        //    vm.array = ajaxData.Data;
        //        //    vm.ListCount = ajaxData.Count;
        //        //}
        //    },
        //    dataType: 'json'
        //});
    };
    vm.Search_Clear = function () {
        vm.Search_NickName = "";
        vm.Search_UserName = "";
        vm.getList();
    };
    vm.EditData = function (id, name) {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Sales/UpdateUser',
            data: { ID: id, NickName: name },
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
    vm.UpdateRemark = function () {
        var rname = $("#Search_NickName").val();
        if (rname == "")
        {
            alert("请输入要更新的备註者姓名!");
            $("#Search_NickName").foucs();
        }
        else
        {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_Sales/UpdateRemarkId',
                data: { rname: rname },
                timeout: 200000,
                success: function (ajaxData) {
                    if (ajaxData === "True") {
                        alert("更新成功！");
                    }
                    else {
                        alert("更新失败!");
                    }
                },
                dataType: 'text'
            });
        }
    }
    vm.removeUser = function (id) {
        if (window.confirm('你确定要删除吗？')) {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_Sales/DeleteUser',
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
});
UserList.getList();
avalon.scan();
function ReturnDateTimeNow() {
    var date = new Date();
    return date.getFullYear() + "/" + (1 + date.getMonth()) + "/" + date.getDate() + " ";
}
function updateItem(type) {
    if (type == "添加") {
        if (UserList.NickName !== "") {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_Sales/AddUser',
                data: {  NickName: UserList.NickName },
                timeout: 200000,
                success: function (ajaxData) {
                    if (ajaxData === "True") {
                        $('#addUser_Modal').modal('hide');
                        UserList.NickName = "";
                        UserList.getList();
                    }
                    else {
                        alert('备註姓名重复');
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
        if ( UserList.NickName !== "") {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_Sales/UpdateUser',
                data: { ID: UserList.ID, NickName: UserList.NickName },
                timeout: 200000,
                success: function (ajaxData) {
                    if (ajaxData === "True") {
                        $('#addUser_Modal').modal('hide');
                        UserList.NickName = "";
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

