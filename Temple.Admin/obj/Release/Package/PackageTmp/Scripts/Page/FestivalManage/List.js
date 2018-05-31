
var FestivalList = avalon.define('FestivalList', function (vm) {
    vm.array = [];
    vm.changeList = [];
    vm.changeAll = false;
    vm.List_Page = 1;
    vm.ListCount = 5;
    vm.ListLoading = false;
    vm.ListNoData = true;
    //-------------------监控全选按钮
    vm.$watch("changeAll", function (value, oldValue) {
        if (value) {
            for (var i = 0; i < vm.array.length; i++) {
                vm.changeList.push(vm.array[i].cId);
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
            url: Config.WebUrl + 'Ajax_Festival/GetFestivalList',
            data: { page: vm.List_Page, size: vm.pager.perPages },
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

    vm.getTWDate = function (edate) {
        return returntwDate(avalon.filters.date(edate, "yyyyMMdd"));
    }
    /*************************分页******************************/
    vm.pager = {
        currentPage: 1,
        showPages: 6,
        perPages: 20,
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
    //vm.EditSort = function (id, Sort) {
    //    var p = /^\d{0,9}$/;
    //    if (!p.test(Sort)) {
    //        alert("请输入数字！");
    //        return;
    //    }
    //    $.ajax({
    //        type: 'POST',
    //        url: Config.WebUrl + 'Ajax_Festival/UpdateNewsTypeSort',
    //        data: { id: id, Sort: Sort },
    //        timeout: 200000,
    //        success: function (ajaxData) {
    //            if (ajaxData === "True") {
    //                alert("排序修改成功");
    //            }
    //        },
    //        dataType: 'text'
    //    });
    //}
    //-------------------------删除法會
    vm.DeleteFestivalFun = function (id) {
        if (window.confirm('你確定要刪除嗎？')) {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_Festival/DeleteFestival',
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
    //-------------------------跳轉到頁面方法
    vm.HrefFun = function (url, param) {
        location.href = url + param;
    };
    //-------------------------批量刪除
    vm.DeleteNewsTypeAllFun = function () {
        if (vm.changeList.length > 0) {
            if (window.confirm('你確定要刪除選定項嗎？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }
                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_Festival/DeleteAllNewsType',
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
                        alert("批量刪除成功!");
                    },
                    dataType: 'json'
                });
                return true;
            } else {
                return false;
            }
        }
        else {
            alert('請選擇您要刪除的功德項目!');
        }
    };
});
avalon.scan();
FestivalList.getList();

function returntwDate(westdate) {
    if (westdate != "") {
        var year = westdate.substr(0, 4) - 1911; //获取完整的年份(4位,1970-????)
        var month = westdate.substr(4, 2); //获取当前月份(0-11,0代表1月)
        var day = westdate.substr(6, 2); //获取当前日(1-31)
        return year + "/" + month + "/" + day;
    }
    return "";

}