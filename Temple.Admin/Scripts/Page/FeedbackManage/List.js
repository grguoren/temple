
var FeedbackList = avalon.define('feedbackList', function (vm) {
    vm.array = [];
    vm.changeList = [];
    vm.changeAll = false;
    vm.brandList = [];
    vm.gradesList = [];
    vm.provinceList = [];

    vm.Search_KeyWord = "";
    vm.Search_BrandId = 0;
    vm.Search_StatusId = -1;
    vm.Search_Key = 1;

    vm.Modal_Name = "";
    vm.Modal_FContent = "";
    vm.Modal_Content = "";
    vm.Modal_AddTime = "";
    vm.Modal_Pid = 0;

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
            url: Config.WebUrl + 'Ajax_Feedback/GetFeedbackListPage',
            data: { page: vm.List_Page, size: vm.pager.perPages, bid: vm.Search_BrandId, status: vm.Search_StatusId, key: vm.Search_Key, keyword: vm.Search_KeyWord },
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
        vm.Search_KeyWord = "";
        vm.Search_BrandId = 0;
        vm.Search_StatusId = -1;
        vm.Search_Key = 1;
        vm.getList(1);
    };
    //----------------------------------------------获取省份列表
    vm.getProvinceList = function () {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_City/GetCityList',
            data: { pid: 0 },
            timeout: 200000,
            success: function (ajaxData) {
                vm.provinceList = ajaxData;
            },
            dataType: 'json'
        });
    };
    //-------------------------删除反馈
    vm.DeleteFeedbackFun = function (id) {
        if (window.confirm('你确定要删除吗？')) {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_Feedback/DeleteFeedback',
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
    vm.DeleteFeedbackAllFun = function () {
        if (vm.changeList.length > 0) {
            if (window.confirm('你确定要删除选定项吗？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }
                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_Feedback/DeleteAllFeedback',
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
            alert('请选择要删除的反馈!');
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
    //-------------------------批量审核
    vm.VerifyFeedbackAllFun = function (status) {
        if (vm.changeList.length > 0) {
            if (window.confirm('你确定要更改选定项的审核状态吗？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }
                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_Feedback/VerifyAllFeedback',
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
            alert('请选择要更改审核状态的反馈!');
        }
    };
    vm.OpenFAnswerFun = function (obj) {
        vm.Modal_Name = obj.User != null ? obj.User.RealName : "";
        vm.Modal_FContent = obj.Content;
        vm.Modal_Pid = obj.Id;
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Feedback/GetFAnswerById',
            data: { pid: obj.Id },
            timeout: 5000,
            success: function (ajaxData) {
                if (ajaxData == null) {
                    vm.Modal_Content = "";
                    vm.Modal_AddTime = ReDateTime();
                }
                else {
                    vm.Modal_Content = ajaxData.Content;
                    vm.Modal_AddTime = avalon.filters.date(ajaxData.AddTime, "yyyy-MM-dd HH:mm");
                }
            }, error: function () {
                vm.Modal_Content = "";
                vm.Modal_AddTime = ReDateTime();
            },
            dataType: 'json'
        });
    };
    vm.SetDateTimeNow = function () {
        vm.Modal_AddTime = ReDateTime();
    };
    vm.AddFAnswer = function () {
        if (vm.Modal_Pid > 0) {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_Feedback/UpdateFAnswer',
                data: { pid: vm.Modal_Pid, content: vm.Modal_Content, addtime: vm.Modal_AddTime,fcontent:vm.Modal_FContent },
                timeout: 200000,
                success: function (ajaxData) {
                    if (ajaxData == "True") {
                        $('#FeedbackModal_FAnswer').modal('hide');
                        alert("回复成功");
                    }
                    else {
                        alert("回复失败,请稍后再试");
                    }
                },
                dataType: 'text'
            });
        }
        else {
            $('#FeedbackModal_FAnswer').modal('hide');
            alert("请勿非法操作");
        }
    };
});
avalon.scan();
FeedbackList.getList();
//FeedbackList.getProvinceList();


function ReStrProvinceName(pid) {
    var str = "";
    for (var i = 0; i < FeedbackList.provinceList.length; i++) {
        if (FeedbackList.provinceList[i].Id === pid) {
            str = FeedbackList.provinceList[i].Name;
            break;
        }
    }
    return str;
}

function ReDateTime() {
    var mydate = new Date();
    return mydate.getFullYear() + "/" + (mydate.getMonth() + 1) + "/" + mydate.getDate() + " " + mydate.getHours() + ":" + mydate.getMinutes();
}

