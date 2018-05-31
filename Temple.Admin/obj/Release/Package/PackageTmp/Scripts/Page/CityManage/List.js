
var AboutTypeList = avalon.define('cityList', function (vm) {
    vm.array = [];
    vm.changeList = [];
    vm.provinceList = [];
    vm.cityList = [];
    vm.changeAll = false;
    vm.List_Page = 1;
    vm.ListCount = 5;
    vm.ListLoading = false;
    vm.ListNoData = true;

    vm.SearchPid = $("#pagedom_Pid").val();

    vm.Province_Id = 0;
    vm.Province_Name = "";
    vm.Province_AliasEng = "";
    vm.Province_FirstEng = "";

    vm.City_Id = 0;
    vm.City_Name = "";
    vm.City_AliasEng = "";
    vm.City_FirstEng = "";
    vm.City_Pid = 0;

    vm.County_Id = 0;
    vm.County_Name = "";
    vm.County_AliasEng = "";
    vm.County_FirstEng = "";
    vm.County_Pid = 0;
    vm.County_Cid = 0;

    //-------------------监控全选按钮
    vm.$watch("changeAll", function (value, oldValue) {
        if (value) {
            for (var i = 0; i < vm.array.length; i++) {
                vm.changeList.push(vm.array[i].Id);
            }
        }
        else {
            vm.changeList.clear();
        }
    });
    vm.getList = function (page) {
        if (page === 1) {
            vm.List_Page = 1;
            //vm.ListSearchCheck = true;
        }
        vm.ListLoading = false;
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_City/GetCityListPageByPid',
            data: { page: vm.List_Page, size: vm.pager.perPages, pid: vm.SearchPid },
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
                    vm.ListNoData = true;
                }
            },
            dataType: 'json'
        });
    };
    /*************************分页******************************/
    vm.pager = {
        currentPage: 1,
        showPages: 6,
        perPages: 40,
        totalItems: 0,
        alwaysShowNext: true,
        alwaysShowPrev: true,
        onJump: function (e, data) {
            vm.List_Page = data.currentPage;
            vm.getList();
        }
    };
    vm.$watch("ListCount", function (a) {
        var widget = avalon.vmodels.pp
        if (widget) {
            widget.totalItems = a;
        }
    });
    vm.$watch("List_Page", function (a) {
        var widget = avalon.vmodels.pp
        if (widget) {
            widget.currentPage = a;
        }
    });
    vm.$skipArray = ["pager"];
    /*************************分页******************************/
    //-------------------------删除关于我们
    vm.DeleteAboutTypeFun = function (id) {
        if (window.confirm('你确定要删除吗？')) {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_City/DeleteCity',
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
    //-------------------------批量删除
    vm.DeleteAboutTypeAllFun = function () {
        if (vm.changeList.length > 0) {
            if (window.confirm('你确定要删除选定项吗？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }
                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_City/DeleteAllCity',
                    data: { list: str },
                    timeout: 200000,
                    success: function (ajaxData) {
                        if (!ajaxData.Status) {
                            var str = "";
                            for (var i = 0; i < ajaxData.Data.length; i++) {
                                str += ajaxData.Data[i];
                            }
                            alert(str);
                        }
                        vm.changeList.clear();
                        vm.changeAll = false;
                        vm.getList();
                        alert("批量删除成功!");
                    },
                    dataType: 'json'
                });
                return true;
            } else {
                return false;
            }
        }
        else {
            alert('请选择要删除的城市!');
        }
    };
    //--------------------------编辑添加城市
    vm.EditProvince = function (obj) {
        vm.Province_Id = obj.Id;
        vm.Province_Name = obj.Name;
        vm.Province_AliasEng = obj.AliasEng;
        vm.Province_FirstEng = obj.FirstEng;
    };

    vm.EditCity = function (obj) {
        if (obj == null) {
            vm.City_Id = 0;
            vm.City_Pid = 0;
            vm.City_Name = "";
            vm.City_AliasEng = "";
            vm.City_FirstEng = "";
        }
        else {
            vm.City_Id = obj.Id;
            vm.City_Pid = obj.Pid;
            vm.City_Name = obj.Name;
            vm.City_AliasEng = obj.AliasEng;
            vm.City_FirstEng = obj.FirstEng;
        }

        if (vm.provinceList.length <= 0) {
            vm.GetProvinceList();
        }
    };

    vm.EditCounty = function (obj) {
        if (obj == null) {
            vm.County_Id = 0;
            vm.County_Name = "";
            vm.County_AliasEng = "";
            vm.County_FirstEng = "";
            vm.County_Pid = 0;
            vm.County_Cid = 0;
        }
        else {
            vm.County_Id = obj.Id;
            vm.County_Name = obj.Name;
            vm.County_AliasEng = obj.AliasEng;
            vm.County_FirstEng = obj.FirstEng;
            vm.County_Pid = obj.Pid;
            vm.County_Cid = obj.Cid;
        }

        if (vm.provinceList.length <= 0) {
            vm.GetProvinceList();
        }
        if (vm.County_Pid > 0) {
            vm.ChangeGetCityList(vm.County_Pid);
        }
    };

    vm.GetProvinceList = function () {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_City/GetCityListPageByPid',
            data: { page: 1, size: 99, pid: 0 },
            timeout: 200000,
            success: function (ajaxData) {
                vm.provinceList = ajaxData.Data;
            },
            dataType: 'json'
        });
    };

    vm.UpdateProvince = function () {
        if (vm.Province_Name == "" || vm.Province_FirstEng == "" || vm.Province_AliasEng == "") {
            alert("請填寫完整的数据");
            return false;
        }

        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_City/UpdateCity',
            data: { id: vm.Province_Id, name: vm.Province_Name, feng: vm.Province_FirstEng, aeng: vm.Province_AliasEng },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData === "True") {
                    $('#addProvince_Modal').modal('hide');
                    vm.getList(1);
                }
                else {
                    alert("添加省份失败");
                }
            },
            dataType: 'text'
        });
    };

    vm.UpdateCity = function () {
        if (vm.City_Pid <= 0 || vm.City_Name == "" || vm.City_FirstEng == "" || vm.City_AliasEng == "") {
            alert("請填寫完整的数据");
            return false;
        }

        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_City/UpdateCity',
            data: { id: vm.City_Id, name: vm.City_Name, feng: vm.City_FirstEng, aeng: vm.City_AliasEng, pid: vm.City_Pid },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData === "True") {
                    HrefSelf(Config.WebUrl + "CityManage/List?pid=" + vm.City_Pid, "");
                }
                else {
                    alert("添加城市失败");
                }
            },
            dataType: 'text'
        });
    };

    vm.UpdateCounty = function () {
        if (vm.County_Cid <= 0 || vm.County_Pid <= 0 || vm.County_Name == "") {
            alert("請填寫完整的数据");
            return false;
        }

        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_City/UpdateCity',
            data: { id: vm.County_Id, name: vm.County_Name, feng: vm.County_FirstEng, aeng: vm.County_AliasEng, pid: vm.County_Pid, cid: vm.County_Cid },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData === "True") {
                    HrefSelf(Config.WebUrl + "CityManage/List?pid=" + vm.County_Cid, "");
                }
                else {
                    alert("添加区县失败");
                }
            },
            dataType: 'text'
        });
    };

    vm.ChangeGetCityList = function (id) {
        if (id > 0) {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_City/GetCityListPageByPid',
                data: { page: 1, size: 99, pid: id },
                timeout: 200000,
                success: function (ajaxData) {
                    vm.cityList = ajaxData.Data;
                },
                dataType: 'json'
            });
        }
        else {
            vm.cityList = [];
            vm.County_Cid = 0;
        }
    };
    vm.RefUpPage = function () {
        var pid = 0;
        if (vm.array[0].Pid > 0 && vm.array[0].Cid == 0) {
            pid = 0;
        }
        if (vm.array[0].Pid > 0 && vm.array[0].Cid > 0) {
            pid = vm.array[0].Pid;
        }
        //alert(pid);
        HrefSelf(Config.WebUrl + 'CityManage/List?pid=' + pid, '');
    };
});
avalon.scan();
AboutTypeList.getList();

