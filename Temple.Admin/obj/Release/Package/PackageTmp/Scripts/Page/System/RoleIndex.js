﻿
var RoleList = avalon.define('roleList', function (vm) {
    vm.updatetype = "添加";
    vm.Name = "";
    vm.Remark = "";
    vm.Code = "";
    vm.Status = 1;
    vm.SystemId = 1;
    vm.ID = 0;
    vm.array = [];
    vm.sysList = [];
    vm.add = function () {
        if (vm.updatetype == "修改") {
            vm.Name = "";
            vm.Remark = "";
            vm.Code = "";
            vm.Status = 1;
        }
        vm.ID = 0;
        vm.updatetype = "添加";
    };
    vm.edit = function (item) {
        vm.updatetype = "修改";
        vm.ID = item.Id;
        vm.Name = item.Name;
        vm.Code = item.Code;
        vm.Remark = item.Remark;
        vm.Status = item.Status == true ? 1 : 0;
    };
    vm.update = function () {
        updateItem(vm.updatetype);
    };
    vm.getList = function () {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Role/GetRoleList',
            data: { pid:2},
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData.Status == true) {
                    vm.array = ajaxData.Data;
                }
            },
            dataType: 'json'
        });
    };
    vm.removeMenu = function (id) {
        if (window.confirm('你确定要删除吗？')) {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_Role/DeleteRole',
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

    vm.getSystemList = function () {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Menu/GetTopMenuList',
            data: {},
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData.Status == true) {
                    vm.sysList = ajaxData.Data;
                }
            },
            dataType: 'json'
        });
    };

    vm.formatStr = function (str) {
        str = str.length >= 10 ? str.substring(0, 10) + "..." : str;
        return str;
    };
    /**设置权限的各个操作对象---(avalonJS不能直接给对象添加新属性,但是可以给对象的属性添加子属性,另外添加属性在IE6-8会出现异常需要特殊处理,所以尽量不要采用添加属性的方式,详见官网API)**/
    vm.authorityDom = {
        roleID: 0,
        roleName: "",
        authorityList: [],
        selectList: []
    };
    vm.changeSystem = function () {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Role/GetProgramList',
            data: { pid: vm.SystemId },
            timeout: 200000,
            success: function (ajaxData) {
                vm.authorityDom.authorityList = ajaxData.Data;
            },
            dataType: 'json'
        });
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Role/GetProgram_RoleList',
            data: { roleid: vm.authorityDom.roleID },
            timeout: 200000,
            success: function (ajaxData) {
                vm.authorityDom.selectList = ajaxData.Data;
            },
            dataType: 'json'
        });
    };
    vm.updateAuthorityRole = function () {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Role/AddProgramList_Role',
            data: { authorityids: vm.authorityDom.selectList.toString(), roleid: vm.authorityDom.roleID },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData === "True") {
                    $('#setAuthority_Modal_RoleIndex').modal('hide');
                }
                else {
                    alert("設置程式失敗,請重新保存,或者稍后再試...");
                }
            },
            dataType: 'text'
        });
    };
    vm.getAuthority = function (obj) {
        vm.authorityDom.roleID = obj.Id;
        vm.authorityDom.roleName = obj.Name;
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Role/GetProgramList',
            data: { pid: vm.SystemId },
            timeout: 200000,
            success: function (ajaxData) {
                vm.authorityDom.authorityList = ajaxData.Data;
            },
            dataType: 'json'
        });
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Role/GetProgram_RoleList',
            data: { roleid: obj.Id },
            timeout: 200000,
            success: function (ajaxData) {
                vm.authorityDom.selectList = ajaxData.Data;
            },
            dataType: 'json'
        });
    };
    /**设置权限的各个操作对象---(avalonJS不能直接给对象添加新属性,但是可以给对象的属性添加子属性,另外添加属性在IE6-8会出现异常需要特殊处理,所以尽量不要采用添加属性的方式,详见官网API)**/
});
avalon.scan();
RoleList.getList();
RoleList.getSystemList();

function updateItem(updatetype) {
    if (updatetype == "添加") {
        if (RoleList.Name !== "") {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_Role/AddRole',
                data: { name: RoleList.Name, Remark: RoleList.Remark,code :RoleList.Code,status : RoleList.Status},
                timeout: 200000,
                success: function (ajaxData) {
                    if (ajaxData === "True") {
                        $('#updateRole_Modal').modal('hide');
                        RoleList.Name = "";
                        RoleList.Remark = "";
                        RoleList.Code = "";
                        RoleList.getList();
                    }
                },
                dataType: 'text'
            });
        }
        else {
            alert("请输入正确的信息");
        }
    }
    if (updatetype == "修改") {
        if (RoleList.Name !== "") {
            console.log(RoleList);
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_Role/UpdateRole',
                data: { id: RoleList.ID, name: RoleList.Name, Remark: RoleList.Remark, code: RoleList.Code, status: RoleList.Status },
                timeout: 200000,
                success: function (ajaxData) {
                    if (ajaxData === "True") {
                        $('#updateRole_Modal').modal('hide');
                        RoleList.getList();
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

