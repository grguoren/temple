
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
    //-------------------------跳转页面方法
    vm.HrefFun = function (url, param) {
        location.href = url + param;
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

function OpenWindowFunGetList() {
    UserList.getList();
}


