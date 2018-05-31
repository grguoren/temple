
var newsList = avalon.define('newsList', function (vm) {
    vm.array = [];
    vm.changeList = [];
    vm.changeAll = false;
    vm.NewsTypeList = [];
    vm.brandList = [];

    vm.Search_Title = "";
    vm.Search_BrandId = -1;
    vm.Search_TypeId =-1;
    vm.Search_StatusId = 0;
    vm.Search_SearchTypeId = 1;

    vm.UpdateTop_IsTop = 1;
    vm.UpdateTop_Begin = "";
    vm.UpdateTop_End = "";
    vm.UpdateTop_Id = 0;
    vm.Search_scId = 0;
    vm.ListLoading = false;
    vm.ListNoData = true;
    vm.List_Page = 1;
    vm.ListCount = 5;
    //-------------------监控全选按钮
    vm.$watch("changeAll", function (value, oldValue) {
        if (value) {
            for (var i = 0; i < vm.array.length; i++) {
                vm.changeList.push(vm.array[i].nId);
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
            url: Config.WebUrl + 'Ajax_Infomation/GetNewsListPage',
            data: { isuser: 8, page: vm.List_Page, size: vm.pager.perPages, bid: vm.Search_BrandId, typeid: vm.Search_TypeId, status: vm.Search_StatusId, keytype: vm.Search_SearchTypeId, keyword: vm.Search_Title, scid: vm.Search_scId },
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
    vm.UpdateIstopFun_Modal = function (id) {
        vm.UpdateTop_IsTop = 1;
        vm.UpdateTop_Id = id;
    };
    vm.ModalFun_ForumIsTop = function (type, item) {
        if (type == 1) {
            vm.UpdateTop_Id = 0;
            vm.UpdateTop_IsTop = 1;
            vm.UpdateTop_Begin = ReturnDateTimeNow();
            vm.UpdateTop_End = ReturnDateTimeNow();
        }
        else {

            vm.UpdateTop_Id = item.nId;
            vm.UpdateTop_IsTop = item.IsTop;
            vm.UpdateTop_Begin = item.nTopBeginTime != null ? avalon.filters.date(item.nTopBeginTime, "yyyy/MM/dd HH:mm") : ReturnDateTimeNow();
            vm.UpdateTop_End = item.nTopEndTime != null ? avalon.filters.date(item.nTopEndTime, "yyyy/MM/dd HH:mm") : ReturnDateTimeNow();
        }
    };
    //-------------------------批量置顶
    vm.TopQuestionAllFun = function (top) {
        vm.UpdateTop_IsTop = (top == 0 ? 0 : vm.UpdateTop_IsTop);
        if (vm.changeList.length > 0) {
            if (window.confirm('你确定要更改选定项的置顶状态吗？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }

                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_Infomation/IsTopAllInformation',
                    data: { list: str, isTop: vm.UpdateTop_IsTop, begin: vm.UpdateTop_Begin, end: vm.UpdateTop_End  },
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
                        $('#upQuestion_Modal').modal('hide');
                    },
                    dataType: 'json'
                });
                return true;
            } else {
                return false;
            }
        }
        else {
            alert('请选择要更改置顶状态的招聘!');
            $('#upQuestion_Modal').modal('hide');
        }
    };
    //-------------------------单条置顶
    vm.TopQuestionFun = function () {

        if (window.confirm('你确定要更改置顶状态吗？')) {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_Infomation/TopInformation',
                data: { id: vm.UpdateTop_Id, topId: vm.UpdateTop_IsTop, btime: vm.UpdateTop_Begin, etime: vm.UpdateTop_End },
                timeout: 200000,
                success: function (ajaxData) {
                    if (ajaxData === "True") {
                        vm.getList();
                        $('#upQuestion_Modal').modal('hide');
                    }
                },
                dataType: 'text'
            });
        } else {
            return false;
        }
    };
    vm.getTopStatus = function (istop, topBengTime, qTopEndTime) {

        var bengtime = avalon.filters.date(topBengTime, "yyyy/MM/dd");
        var endtime = avalon.filters.date(qTopEndTime, "yyyy/MM/dd");
        var nowtime = avalon.filters.date(new Date(), "yyyy/MM/dd");
        if (endtime > bengtime && endtime < nowtime) {
            return "已过期";
        }
        else {
            if (istop == "1") {
                return "已置顶";
            } else {
                return "未置顶";
            }
        }

    }
    vm.ModalFun_UpdateQuestionIsTop = function () {

        if (vm.UpdateTop_Id == 0) {
            vm.TopQuestionAllFun(1);
        } else {
            vm.TopQuestionFun();
        }
    };
    //----------------------------------------------获取栏目分类列表
    vm.GetNewsTypeList = function () {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Infomation/GetNewsTypeList',
            data: { isuser: 6, page: 1, size: 999, iscr: 2 },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData.Status == true) {
                    vm.NewsTypeList = ajaxData.Data;
                }
            },
            dataType: 'json'
        });
    };
    //----------------------------------------------获取品牌列表
    vm.getBrandList = function () {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Infomation/GetBrandList',
            data: {},
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData.Status == true) {
                    vm.brandList = ajaxData.Data;
                }
            },
            dataType: 'json'
        });
    };
    //-------------------------删除资讯分类
    vm.DeleteNewsFun = function (id) {
        if (window.confirm('你确定要删除吗？')) {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_Infomation/DeleteNews',
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
    vm.DeleteNewsAllFun = function () {
        if (vm.changeList.length > 0) {
            if (window.confirm('你确定要删除选定项吗？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }
                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_Infomation/DeleteAllnews',
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
            url: Config.WebUrl + 'Ajax_Infomation/UpdatenewsSort',
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
    vm.RecommendNewsAllFun = function (status) {
        if (vm.changeList.length > 0) {
            if (window.confirm('你确定要更改选定项的推荐状态吗？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }
                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_Infomation/RecommendAllnews',
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
            alert('请选择要更改推荐状态的关于我们!');
        }
    };
    //-------------------------批量审核
    vm.VerifyNewsAllFun = function (status) {
        if (vm.changeList.length > 0) {
            if (window.confirm('你确定要更改选定项的审核状态吗？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }
                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_Infomation/VerifyAllnews',
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
            alert('请选择要更改审核状态的关于我们!');
        }
    };
    //-------------------------修改分类
    vm.UpdateTypeFun = function (id, typeid) {
        //alert(id + "|" + typeid);
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Infomation/UpdatenewsStatus',
            data: { id: id, typeid: typeid },
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
        //    url: Config.WebUrl + 'Ajax_Infomation/UpdateNewsType',
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
    vm.TopNewsAllFun = function (status) {
        if (vm.changeList.length > 0) {
            if (window.confirm('你确定要更改选定项的置顶状态吗？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }
                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_Infomation/TopAllnews',
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
            alert('请选择要更改置顶状态的关于我们!');
        }
    };

    //-------------------------批量推送
    vm.PushNewsAllFun = function (status) {
        if (vm.changeList.length > 0) {
            if (window.confirm('你确定要更改选定项的推送目标吗？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }
                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_Infomation/PushAllnews',
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
            alert('请选择要更改推送目标的关于我们资讯!');
        }
    };
});
avalon.scan();
newsList.getList();
newsList.getBrandList();

function OpenWindowFunGetList() {
    newsList.getList();
}

function ReturnDateTimeNow() {
    var date = new Date();
    return date.getFullYear() + "/" + (1 + date.getMonth()) + "/" + date.getDate() + " " + date.getHours() + ":" + date.getMinutes();
}