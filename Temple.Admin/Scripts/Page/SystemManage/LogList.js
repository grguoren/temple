
var SystemLogList = avalon.define('systemLogList', function (vm) {
    vm.array = [];
    vm.List_Page = 1;
    vm.ListCount = 5;
    vm.ListLoading = false;
    vm.Search_Title = "";
    vm.Search_Desp = "";
    vm.ListNoData = true;
    vm.getList = function (page) {
        if (page === 1) {
            vm.List_Page = 1;
        }
        vm.ListLoading = false;
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Log/GetLogList',
            data: { page: vm.List_Page, size: vm.pager.perPages, title: vm.Search_Title, desp: vm.Search_Desp },
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

    vm.updateIndex = function () {
      
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Log/updateIndex',
            data: {},
            timeout: 200000,
            error: function (XmlHttpRequest, textStatus, errorThrown) { alert(XmlHttpRequest.responseText); },
            success: function (ajaxData) {
                if (ajaxData.Count > 0) {
                    alert("已更新");

                }
                else {

                    alert(ajaxData.Name);
                }
            },
            dataType: 'json'
        });

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
});
avalon.scan();
SystemLogList.getList();

