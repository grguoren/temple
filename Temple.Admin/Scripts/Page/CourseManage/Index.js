
var CourseList = avalon.define('courseList', function (vm) {
    vm.array = [];
    vm.changeList = [];
    vm.changeAll = false;
    vm.CoursetypeList = [];
    vm.brandList = [];

    vm.Search_Title = "";
    vm.Search_BrandId = 0;
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
            url: Config.WebUrl + 'Ajax_Course/GetExamCourseListPage',
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
    vm.Search_Clear = function () {
        vm.List_Page = 1;
        vm.Search_Title = "";
        vm.Search_BrandId = 0;
        vm.Search_StatusId = 0;
        vm.Search_SearchTypeId = 1;
        vm.getList(1);
    };
    //----------------------------------------------获取等级列表
    vm.getTypeList = function () {
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_Course/GetTypeList',
            data: { page: 1, size: 999 },
            timeout: 200000,
            success: function (ajaxData) {
                if (ajaxData.Status == true) {
                    vm.CoursetypeList = ajaxData.Data;
                }
            },
            dataType: 'json'
        });
    };

    //-------------------------批量删除
    vm.DeleteCourseAllFun = function () {
        if (vm.changeList.length > 0) {
            if (window.confirm('你确定要删除选定项吗？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }
                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_Course/DeleteAllCourse',
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
            alert('请选择要删除的课程!');
        }
    };
    //-------------------------批量审核
    vm.VerifyCourseAllFun = function (status) {
        if (vm.changeList.length > 0) {
            if (window.confirm('你确定要更改选定项的审核状态吗？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }
                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_Course/VerifyAllCourse',
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
            alert('请选择要更改审核状态的课程!');
        }
    };
    //-------------------------批量推荐
    vm.DisplayCourseAllFun = function (status) {
        if (vm.changeList.length > 0) {
            if (window.confirm('你确定要更改选定项的推荐状态吗？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }
                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_Course/DisplayAllCourse',
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
                        alert("修改显示状态成功!");
                    },
                    dataType: 'json'
                });
                return true;
            } else {
                return false;
            }
        }
        else {
            alert('请选择要更改推荐状态的课程!');
        }
    };
    //-------------------------批量热门
    vm.HotCourseAllFun = function (status) {
        if (vm.changeList.length > 0) {
            if (window.confirm('你确定要更改选定项的热门状态吗？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }
                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_Course/HotCourseAllFun',
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
                        alert("修改热门状态成功!");
                    },
                    dataType: 'json'
                });
                return true;
            } else {
                return false;
            }
        }
        else {
            alert('请选择要更改热门状态的课程!');
        }
    };
    //-------------------------删除课程
    vm.DeleteCourseFun = function (id) {
        if (window.confirm('你确定要删除吗？')) {
            $.ajax({
                type: 'POST',
                url: Config.WebUrl + 'Ajax_Course/DeleteCourse',
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
    vm.DeleteCourseAllFun = function () {
        if (vm.changeList.length > 0) {
            if (window.confirm('你确定要删除选定项吗？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }
                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_Course/DeleteAllCourse',
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
            alert('请选择要删除的课程!');
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
});
avalon.scan();
CourseList.getList();
CourseList.getTypeList();

