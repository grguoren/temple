var MessageList = avalon.define('messageList', function (vm) {
    vm.array = [];

    vm.changeList = [];
    vm.changeAll = false;

    vm.AddTimeChange = "";
    vm.Search_Verify = 2;
    vm.Search_Type = 0;
    vm.Search_Keyword = "";

    vm.List_Page = 1;
    vm.ListCount = 5;
    vm.ListLoading = false;
    vm.ListNoData = true;
    vm.ListSearchCheck = false;

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
    //-------------------------跳转页面方法
    vm.HrefFun = function (url, param) {
        location.href = url + param;
    };
    vm.getList = function (page) {
        if (page === 1) {
            vm.List_Page = 1;
            //vm.ListSearchCheck = true;
        }
        vm.ListLoading = false;
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Sign/GetMessageList',
            data: { page: vm.List_Page, size: vm.pager.perPages, keyword: vm.Search_Keyword, isVerify: vm.Search_Verify, type: vm.Search_Type },
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
                    for (var i = 0; i < ajaxData.Data.length; i++) {
                        ajaxData.Data[i].AddTime = avalon.filters.date(ajaxData.Data[i].AddTime, "yyyy-MM-dd HH:mm");
                    }
                    vm.array = ajaxData.Data;
                    vm.ListLoading = true;
                    vm.ListNoData = true;
                }
            },
            dataType: 'json'
        });
    };

    vm.ExportHrefFun = function (url) {
        window.open(url , "_blank");
    }
    vm.Search_Clear = function () {
        vm.List_Page = 1;
        vm.Search_Type = 0;
        vm.Search_Verify = 2;
        vm.Search_Keyword = "";
        vm.getList();
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


    //-------------------------删除留言
    vm.SendModelMsg = function (id) {
        if (window.confirm('你确定要发送吗？')) {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_Sign/SendMsg',
                data: { id: $("#openid").val() },
                timeout: 200000,
                success: function (ajaxData) {
                    if (ajaxData === "True") {
                        alert("发送成功")
                    }
                },
                dataType: 'text'
            });
        } else {
            return false;
        }
    };
    vm.DeleteMessageFun = function (id) {
        if (window.confirm('你确定要删除吗？')) {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_Sign/DeleteMessage',
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
    //-------------------------批量删除留言
    vm.DeleteMessageAllFun = function () {
        if (vm.changeList.length > 0) {
            if (window.confirm('你确定要删除选定项吗？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }
                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_Sign/DeleteMessageAll',
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
            alert('请选择要删除的留言!');
        }
    };

    //-------------------------批量审核/取消审核
    vm.VerifyMessageAllFun = function (status) {
        if (vm.changeList.length > 0) {
            if (window.confirm('你确定要更改选定项的审核状态吗？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }
                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_Sign/VerifyAllMessage',
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
            alert('请选择要更改审核状态的留言!');
        }
    };

    //-------------------------单条审核/取消审核
    vm.VerifyMessageFun = function (id, status) {
        if (window.confirm('你确定要更改审核状态吗？')) {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_Sign/VerifyMessage',
                data: { id: id, verifyId: status },
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

    //-------------------------修改时间
    vm.UpdateAddTimeFun = function (id, addtime) {
        if (window.confirm('你确定要更改时间吗？')) {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_Sign/UpdateMessageAddTime',
                data: { id: id, addtime: addtime },
                timeout: 200000,
                success: function (ajaxData) {
                    if (ajaxData === "True") {
                        vm.getList();
                    } else {
                        alert("时间输入有误");
                    }
                },
                dataType: 'text'
            });
        } else {

            return false;
        }
    }
});

//初始绑定
avalon.scan();
MessageList.getList();


