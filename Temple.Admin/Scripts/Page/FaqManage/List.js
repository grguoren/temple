
var AboutList = avalon.define('aboutList', function (vm) {
    vm.array = [];
    vm.changeList = [];
    vm.changeAll = false;
    vm.abouttypeList = [];
    vm.brandList = [];

    vm.Search_Title = "";
    vm.Search_BrandId = 0;
    vm.Search_TypeId = document.getElementById("aboutTypeId_pageDom").value;
    vm.Search_StatusId = 0;
    vm.Search_SearchTypeId = 1;

    vm.ListLoading = false;
    vm.ListNoData = true;
    vm.List_Page = 1;
    vm.ListCount = 5;
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
        }
        vm.ListLoading = false;
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_About/GetAboutListPage',
            data: { page: vm.List_Page, size: vm.pager.perPages, bid: vm.Search_BrandId, typeid: vm.Search_TypeId, status: vm.Search_StatusId, keytype: vm.Search_SearchTypeId, keyword: vm.Search_Title },
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
    vm.Search_Clear = function () {
        vm.List_Page = 1;
        vm.Search_Title = "";
        vm.Search_BrandId = 0;
        vm.Search_TypeId = 0;
        vm.Search_StatusId = 0;
        vm.Search_SearchTypeId = 1;
        vm.getList(1);
    };
    //----------------------------------------------获取栏目分类列表
    vm.getAboutTypeList = function () {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_About/GetAboutTypeList',
            data: { page: 1, size: 999 },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData.Status == true) {
                    vm.abouttypeList = ajaxData.Data;
                }
            },
            dataType: 'json'
        });
    };

    //-------------------------删除资讯分类
    vm.DeleteAboutFun = function (id) {
        if (window.confirm('你确定要删除吗？')) {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_About/DeleteAbout',
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
    //-------------------------跳转页面方法
    vm.HrefFun = function (url, param) {
        location.href = url + param;
    };
    //-------------------------批量删除
    vm.DeleteAboutAllFun = function () {
        if (vm.changeList.length > 0) {
            if (window.confirm('你确定要删除选定项吗？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }
                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_About/DeleteAllAbout',
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
            alert('请选择要删除的广告!');
        }
    };
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
    vm.EditSort = function (id, Sort) {
        var p = /^\d{0,9}$/;
        if (!p.test(Sort)) {
            alert("请输入数字！");
            return;
        }
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_About/UpdateAboutSort',
            data: { id: id, sort: Sort },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData === "True") {
                    alert("排序修改成功");
                }
            },
            dataType: 'text'
        });
    }
    //-------------------------批量推荐
    vm.RecommendAboutAllFun = function (status) {
        if (vm.changeList.length > 0) {
            if (window.confirm('你确定要更改选定项的推荐状态吗？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }
                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_About/RecommendAllAbout',
                    data: { list: str, recommendId: status },
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
                        alert("修改推荐状态成功!");
                    },
                    dataType: 'json'
                });
                return true;
            } else {
                return false;
            }
        }
        else {
            alert('请选择要更改推荐状态的帮助中心!');
        }
    };
    //-------------------------批量审核
    vm.VerifyAboutAllFun = function (status) {
        if (vm.changeList.length > 0) {
            if (window.confirm('你确定要更改选定项的审核状态吗？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }
                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_About/VerifyAllAbout',
                    data: { list: str, verifyId: status },
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
                        alert("修改审核状态成功!");
                    },
                    dataType: 'json'
                });
                return true;
            } else {
                return false;
            }
        }
        else {
            alert('请选择要更改审核状态的帮助中心!');
        }
    };
    //-------------------------修改分类
    vm.UpdateTypeFun = function (id, typeid) {
        //alert(id + "|" + typeid);
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_About/UpdateAboutStatus',
            data: {id:id,typeid:typeid},
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData === "True") {
                    alert("分类修改成功");
                }
            },
            dataType: 'text'
        });

        //$.ajax({
        //    type: 'POST',
        //    url: Config.WebUrl + 'Ajax_About/UpdateAboutType',
        //    data: { },
        //    timeout: 200000,
        //    success: function (ajaxData) {
        //        if (ajaxData == "True") {
        //            alert("分类修改成功");
        //        }
        //    },
        //    dataType: 'text'
        //});
    };
    //-------------------------批量置顶
    vm.TopAboutAllFun = function (status) {
        if (vm.changeList.length > 0) {
            if (window.confirm('你确定要更改选定项的置顶状态吗？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }
                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_About/TopAllAbout',
                    data: { list: str, topId: status },
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
                        alert("修改置顶状态成功!");
                    },
                    dataType: 'json'
                });
                return true;
            } else {
                return false;
            }
        }
        else {
            alert('请选择要更改置顶状态的帮助中心!');
        }
    };

    //-------------------------批量推送
    vm.PushAboutAllFun = function (status) {
        if (vm.changeList.length > 0) {
            if (window.confirm('你确定要更改选定项的推送目标吗？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }
                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_About/PushAllAbout',
                    data: { list: str, sendId: status },
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
                        alert("修改推送目标成功!");
                    },
                    dataType: 'json'
                });
                return true;
            } else {
                return false;
            }
        }
        else {
            alert('请选择要更改推送目标的帮助中心资讯!');
        }
    };
});
avalon.scan();
AboutList.getList();
AboutList.getAboutTypeList();


function OpenWindowFunGetList() {
    AboutList.getList();
}

