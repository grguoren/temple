
var MenuList = avalon.define('menuList', function (vm) {
    vm.updatetype = "添加";
    vm.Name = "";
    vm.PID = 0;
    vm.FID = 0;
    vm.ID = 0;
    vm.LinkUrl = "";
    vm.Code = "";
    vm.Status = 1;
    vm.ImportantLevel = 0;
    vm.array = [];
    vm.add = function (pid,fid) {
        if (vm.updatetype == "修改") {
            vm.Name = "";
            vm.LinkUrl = "";
        }
        vm.ID = 0;
        vm.Code = "";
        vm.Status = 1;
        vm.ImportantLevel = 0;
        vm.PID = pid;
        vm.FID = fid;
        vm.updatetype = "添加";
    };
    vm.edit = function (item) {
        vm.updatetype = "修改";
        vm.ID = item.Id;
        vm.Name = item.Name;
        vm.LinkUrl = item.LinkUrl;
        vm.PID = item.System_id;
        vm.Code = item.Code;
        vm.Status = item.Status;
        vm.ImportantLevel = item.ImportantLevel;
    };
    vm.update = function () {
        updateItem(vm.updatetype);
    };
    vm.getList = function () {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Menu/GetMenuList',
            data: { pid: 0 },
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
                url: Config.WebUrl + 'Ajax_Menu/DeleteMenu',
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
    vm.authorityDom = {
        menuID: 0,
        menuName: "",
        authorityList: [],
        selectList: []
    };
    vm.updateAuthorityMenu = function () {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Authority/AddAuthority_Menu',
            data: { authorityids: vm.authorityDom.selectList.toString(), menuid: vm.authorityDom.menuID },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData === "True") {
                    $('#setAuthority_Modal_MenuIndex').modal('hide');
                }
                else {
                    alert("设置权限失败,请重新保存,或者稍后再试...");
                }
            },
            dataType: 'text'
        });
    };
    vm.getAuthority = function (obj) {
        vm.authorityDom.menuID = obj.Id;
        vm.authorityDom.menuName = obj.Name;
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Authority/GetAuthorityList',
            data: { pid: 0 },
            timeout: 200000,
            success: function (ajaxData) {
                vm.authorityDom.authorityList = ajaxData.Data;
            },
            dataType: 'json'
        });
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Authority/GetAuthority_MenuList',
            data: { menuid: obj.Id },
            timeout: 200000,
            success: function (ajaxData) {
                vm.authorityDom.selectList = ajaxData.Data;
            },
            dataType: 'json'
        });
    };
    /**设置权限的各个操作对象---(avalonJS不能直接给对象添加新属性,但是可以给对象的属性添加子属性,另外添加属性在IE6-8会出现异常需要特殊处理,所以尽量不要采用添加属性的方式,详见官网API)**/
});
MenuList.getList();
avalon.scan();

function updateItem(updatetype) {
    if (updatetype == "添加") {
        if (MenuList.Name !== "") {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_Menu/AddMenu',
                data: { name: MenuList.Name, linkurl: MenuList.LinkUrl, pid: MenuList.PID, code: MenuList.Code, status: MenuList.Status},
                timeout: 200000,
                success: function (ajaxData) {
                    if (ajaxData === "True") {
                        $('#updateMenu_Modal').modal('hide');
                        MenuList.Name = "";
                        MenuList.LinkUrl = "";
                        MenuList.getList();
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
        if (MenuList.Name !== "") {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_Menu/UpdateMenu',
                data: { id: MenuList.ID, name: MenuList.Name, linkurl: MenuList.LinkUrl, code: MenuList.Code, status: MenuList.Status },
                timeout: 200000,
                success: function (ajaxData) {
                    if (ajaxData === "True") {
                        $('#updateMenu_Modal').modal('hide');
                        MenuList.getList();
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

