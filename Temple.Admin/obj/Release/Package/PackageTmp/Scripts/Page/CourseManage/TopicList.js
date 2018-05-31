var ForumList = avalon.define('forumList', function (vm) {
    vm.array = [];
    vm.brandList = [];
    vm.tempList = [];
    vm.changeList = [];
    vm.changeAll = false;

    vm.Search_BrandId = 0;
    vm.Search_Verify = -1;
    vm.Search_Top = 2;
    vm.Search_Temp = 0;
    vm.Search_Type = 0;
    vm.Search_Keyword = "";

    vm.ForumModel = {
        Id: 0,
        UserName: "",
        TypeId: 0,
        Bid: 0,
        Title: "",
        Content: "",
        IsTop: 0,
        IsVerify: 0,
        TouristQQ: "",
        TouristPhone: "",
        AddTime: "",
        IsRecommend: 0,
        TopEndTime: "",
        TopBeginTime: ""
    };

    vm.TopModal_Id = 0;
    vm.TopModal_IsTop = 0;
    vm.TopModal_BeginTime = "";
    vm.TopModal_EndTime = "";

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

    vm.getList = function (page) {
        if (page === 1) {
            vm.List_Page = 1;
            //vm.ListSearchCheck = true;
        }
        vm.ListLoading = false;
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Forum/GetForumList',
            data: { page: vm.List_Page, size: vm.pager.perPages, keyword: vm.Search_Keyword, brandid: vm.Search_BrandId, tempid: vm.Search_Temp, typeid: vm.Search_Type, isVerify: vm.Search_Verify, isTop: vm.Search_Top },
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


    //---------------------------编辑修改帖子对象信息绑定被修改的信息
    vm.edit = function (item) {
        vm.ForumModel.Id = item.Id;
        vm.ForumModel.UserName = item.User == null ? "游客" : item.User.RealName;
        vm.ForumModel.TypeId = item.TypeId;
        vm.ForumModel.Bid = item.Bid;
        vm.ForumModel.Title = item.Title;
        vm.ForumModel.Content = item.Content;
        vm.ForumModel.IsVerify = item.IsVerify;
        vm.ForumModel.IsRecommend = item.IsRecommend == null ? 0 : item.IsRecommend;
        vm.ForumModel.IsTop = item.IsTop;
        vm.ForumModel.TouristQQ = item.TouristQQ;
        vm.ForumModel.TouristPhone = item.TouristPhone;
        vm.ForumModel.AddTime = avalon.filters.date(item.AddTime, "yyyy-MM-dd HH:mm");
        vm.ForumModel.TopEndTime = item.TopEndTime != null ? avalon.filters.date(item.TopEndTime, "yyyy/MM/dd HH:mm") : ReturnDateTimeNow();
        vm.ForumModel.TopBeginTime = item.TopBeginTime != null ? avalon.filters.date(item.TopBeginTime, "yyyy-MM-dd HH:mm") : ReturnDateTimeNow();
    };

    vm.update = function () {
        UpdateItem();
    };

    vm.Search_Clear = function () {
        vm.List_Page = 1;
        vm.Search_BrandId = 0;
        vm.Search_Verify = 2;
        vm.Search_Top = 2;
        vm.Search_Temp = 0;
        vm.Search_Type = 0;
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
    vm.ModalFun_ForumIsTop = function (type, item) {
        if (type == 1) {
            vm.TopModal_Id = 0;
            vm.TopModal_IsTop = 1;
            vm.TopModal_BeginTime = ReturnDateTimeNow();
            vm.TopModal_EndTime = ReturnDateTimeNow();
        }
        else {
            vm.TopModal_Id = item.Id;
            vm.TopModal_IsTop = item.IsTop;
            vm.TopModal_BeginTime = item.TopBeginTime != null ? avalon.filters.date(item.TopBeginTime, "yyyy/MM/dd HH:mm") : ReturnDateTimeNow();
            vm.TopModal_EndTime = item.TopEndTime != null ? avalon.filters.date(item.TopEndTime, "yyyy/MM/dd HH:mm") : ReturnDateTimeNow();
        }
    };
    vm.ModalFun_UpdateForumIsTop = function () {
        if (vm.TopModal_Id == 0) {
            vm.TopForumgAllFun();
        } else {
            vm.TopForumFun();
        }
    };
    //-------------------------修改分类
    vm.UpdateTempFun = function (id, tempid) {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Forum/UpdateBBSTemp',
            data: { id: id, tempid: tempid },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData == "True") {
                    alert("模板分类修改成功");
                }
            },
            dataType: 'text'
        });
    };

    //-------------------------删除论坛帖子
    vm.DeleteForumFun = function (id) {
        if (window.confirm('你确定要删除吗？')) {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_Forum/DeleteForum',
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

    //-------------------------批量删除--------------------------------------------------------------------------------------
    vm.DeleteForumgAllFun = function () {
        if (vm.changeList.length > 0) {
            if (window.confirm('你确定要删除选定项吗？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }
                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_Forum/DeleteAllForum',
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
            alert('请选择要删除的论坛主题!');
        }
    };

    //-------------------------批量审核/取消审核
    vm.VerifyForumAllFun = function (status) {
        if (vm.changeList.length > 0) {
            if (window.confirm('你确定要更改选定项的审核状态吗？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }
                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_Forum/VerifyAllForum',
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
            alert('请选择要更改审核状态的帖子!');
        }
    };

    //-------------------------单条审核/取消审核
    vm.VerifyForumFun = function (id, status) {
        if (window.confirm('你确定要更改审核状态吗？')) {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_Forum/VerifyForum',
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

    //-------------------------单条置顶/取消置顶
    vm.TopForumFun = function () {
        if (window.confirm('你确定要更改置顶状态吗？')) {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_Forum/TopForum',
                data: { id: vm.TopModal_Id, topId: vm.TopModal_IsTop, btime: vm.TopModal_BeginTime, etime: vm.TopModal_EndTime },
                timeout: 200000,
                success: function (ajaxData) {
                    if (ajaxData === "True") {
                        vm.getList();
                        $('#ForumIsTop_Modal').modal('hide');
                    }
                },
                dataType: 'text'
            });
        } else {
            return false;
        }
    };
    vm.getTopStatus = function (istop, topBengTime, topEndTime) {

        var bengtime = avalon.filters.date(topBengTime, "yyyy/MM/dd");
        var endtime = avalon.filters.date(topEndTime, "yyyy/MM/dd");
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
    //-------------------------批量置顶/取消置顶
    vm.TopForumgAllFun = function () {
        if (vm.changeList.length > 0) {
            if (window.confirm('你确定要更改选定项的置顶状态吗？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }
                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_Forum/TopAllForum',
                    data: { list: str, topId: vm.TopModal_IsTop, btime: vm.TopModal_BeginTime, etime: vm.TopModal_EndTime },
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
                        $('#ForumIsTop_Modal').modal('hide');
                    },
                    dataType: 'json'
                });
                return true;
            } else {
                return false;
            }
        }
        else {
            alert('请选择要更改置顶状态的帖子!');
        }
    };
    //-------------------------单条推荐/取消推荐
    vm.RecommendForumFun = function (id, status) {
        if (window.confirm('你确定要更改推荐状态吗？')) {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_Forum/RecommendForum',
                data: { id: id, reId: status },
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

    //-------------------------批量推荐/取消推荐
    vm.RecommendForumgAllFun = function (status) {
        if (vm.changeList.length > 0) {
            if (window.confirm('你确定要更改选定项的推荐状态吗？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }
                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_Forum/RecommendAllForum',
                    data: { list: str, reId: status },
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
            alert('请选择要更改推荐状态的帖子!');
        }
    };
});

//初始绑定
avalon.scan();
ForumList.getList();


//更新帖子信息
function UpdateItem() {
    if (ForumList.ForumModel.Title == "") {
        alert("请输入帖子标题");
        return false;
    }
    if (ForumList.ForumModel.Content == "") {
        alert("请输入帖子内容");
        return false;
    }
    var forum = {
        Id: ForumList.ForumModel.Id,
        TypeId: ForumList.ForumModel.TypeId,
        Bid: ForumList.ForumModel.Bid,
        Title: ForumList.ForumModel.Title,
        Content: escape(ForumList.ForumModel.Content),
        IsTop: ForumList.ForumModel.IsTop,
        IsVerify: ForumList.ForumModel.IsVerify,
        TouristQQ: ForumList.ForumModel.TouristQQ,
        TouristPhone: ForumList.ForumModel.TouristPhone,
        IsRecommend: ForumList.ForumModel.IsRecommend,
        TopEndTime: ForumList.ForumModel.TopEndTime,
        TopBeginTime: ForumList.ForumModel.TopBeginTime
    };

    $.ajax({
        type: 'POST',
        url: Config.WebUrl + 'Ajax_Forum/UpdateForum',
        data: forum,
        timeout: 200000,
        success: function (ajaxData) {
            if (ajaxData === "True") {
                $('#updateForum_Modal').modal('hide');

                //ForumList.ForumModel.Id = 0;
                //ForumList.ForumModel.TypeId = 0;
                //ForumList.ForumModel.Bid = 0;
                //ForumList.ForumModel.Title = "";
                //ForumList.ForumModel.Content = "";
                //ForumList.ForumModel.IsTop = 0;
                //ForumList.ForumModel.IsVerify = 0;
                //ForumList.ForumModel.IsRecommend = 0;
                //ForumList.ForumModel.TouristQQ = "";
                //ForumList.ForumModel.TouristPhone = "";
                ForumList.getList();
            }
        },
        dataType: 'text'
    });


}

function ReturnDateTimeNow() {
    var date = new Date();
    return date.getFullYear() + "/" + (date.getMonth() + 1) + "/" + date.getDate() + " " + date.getHours() + ":" + date.getMinutes();
}
