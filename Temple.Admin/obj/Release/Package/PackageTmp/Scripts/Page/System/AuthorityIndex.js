
var AuthorityList = avalon.define('authorityList', function (vm) {
    vm.updatetype = "添加";
    vm.Name = "";
    vm.Type = "";
    vm.LimitCity = 0;
    vm.ID = 0;
    vm.array = [];
    vm.add = function () {
        if (vm.updatetype == "修改") {
            vm.Name = "";
            vm.Type = "";
        }
        vm.ID = 0;
        vm.updatetype = "添加";
    };
    vm.edit = function (item) {
        vm.updatetype = "修改";
        vm.ID = item.ID;
        vm.Name = item.Name;
        vm.Type = item.Type
    };
    vm.update = function () {
        updateItem(vm.updatetype);
    };
    vm.getList = function () {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Authority/GetAuthorityList?' + Math.random(),
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
    vm.GetLimit = function () {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Authority/GetLimitCity?' + Math.random(),
            data: { pid: 0 },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData.Status == true) {
                    vm.LimitCity = ajaxData.Count;
                }
            },
            dataType: 'json'
        });
    };
    vm.updateLimit = function (id) {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Authority/UpdateLimitCity?' + Math.random(),
            data: { pid: id },
            //error: function (XmlHttpRequest, textStatus, errorThrown) { console.log(errorThrown);},
            timeout: 200000,
            success: function (ajaxData) {
                console.log(ajaxData);
                console.log(ajaxData.Name);
                if (ajaxData.Status == true) {
                    alert("修改成功");
                }
            },
            dataType: 'json'
        });
    };
    vm.removeMenu = function (id) {
        if (window.confirm('你确定要删除吗？')) {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_Authority/DeleteAuthority',
                data: { id: id },
                timeout: 200000,
                success: function (ajaxData) {
                    if (ajaxData === "True") {
                        vm.getList();
                        //location.href = location.href;
                    }
                },
                dataType: 'text'
            });
        } else {
            return false;
        }
    };
});
AuthorityList.getList();
AuthorityList.GetLimit();
avalon.scan();

function updateItem(updatetype) {
    if (updatetype == "添加") {
        if (AuthorityList.Name !== "") {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_Authority/AddAuthority',
                data: { name: AuthorityList.Name, type: AuthorityList.Type },
                timeout: 200000,
                success: function (ajaxData) {
                    if (ajaxData === "True") {
                        $('#updateAuthority_Modal').modal('hide');
                        AuthorityList.Name = "";
                        AuthorityList.Type = "";
                        AuthorityList.getList();
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
        if (AuthorityList.Name !== "") {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_Authority/UpdateAuthority',
                data: { id: AuthorityList.ID, name: AuthorityList.Name, type: AuthorityList.Type },
                timeout: 200000,
                success: function (ajaxData) {
                    if (ajaxData === "True") {
                        $('#updateAuthority_Modal').modal('hide');
                        AuthorityList.getList();
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

