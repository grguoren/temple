
var MyUserList = avalon.define('MyUserList', function (vm) {
    vm.array = [];
    vm.gradeList = [];
    vm.changeList = [];
    vm.changeAll = false;
    vm.Search_Title = "";
    vm.Search_gradeId = -1;
    vm.Search_BrandId = $("#pagedom_BrandId").val();
    vm.Search_TypeId = "-1";
    vm.Search_StatusId = 0;
    vm.Search_IsTop = -1;
    vm.UpdateTop_IsTop = 1;
    vm.UpdateTop_Begin = "";
    vm.UpdateTop_End = "";
    vm.UpdateTop_Id = 0;

    vm.Search_Remak = "-1";
    vm.Search_BrandLocationCount = 0;
    vm.UserTypeList = [{ Id: 0, Name: "" }, { Id: 1, Name: "赠送网站" }, { Id: 2, Name: "样版网站" }];
    vm.Search_SearchTypeId = 0;
    vm.UclickCount = "";
    vm.UpdateTypeModel = {
        Id: 0,
        TypeId: 0
    };//-----------------修改分类操作的model
    vm.DataModel = {
        RealName: "",
        Name: "",
        TelePhone: "",
        QQ: "",
        Email: "",
        IsClose: false
    };
    vm.List_Page = 1;
    vm.ListCount = 5;
    vm.ListLoading = false;
    vm.ListNoData = true;
    vm.ListSearchCheck = false;
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
        //alert(page);
        if (page === 1) {
            vm.List_Page = 1;
            //vm.ListSearchCheck = true;
        }
        $("#orderType").val("-1");
        vm.ListLoading = false;
        vm.ListNoData = true;

        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_MyUser/GetUserList',
            data: { page: vm.List_Page, size: vm.pager.perPages, state: $("#Search_StatusId").val(), typeid: vm.Search_TypeId, SearchTypeId: vm.Search_SearchTypeId, Title: vm.Search_Title, dateNo: 0, date0: $("#date1").val(), date1: $("#date2").val() },
            timeout: 200000,
            error: function (XmlHttpRequest, textStatus, errorThrown) { },
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
                }
            },
            dataType: 'json'
        });
    };
    
    vm.EditPopularity = function (id, click, name) {
        var p = /^\d{0,9}$/;
        if (!p.test(click)) {
            alert("请输入数字！");
            return;
        }
        $.ajax({
            type: 'POST',
            url: Config.WebUrl + 'Ajax_MyUser/EditTotalPopularity',
            data: { uid: id, Popularity: click, Name: name },
            timeout: 200000,
            success: function (ajaxData) {
                alert(ajaxData);
            },
            dataType: 'text'
        });
    }

    vm.EditRemark = function (uid, remark) {
        remark = $("#Remark_" + uid).val();
        $.ajax({
            type: 'POST',
            async: false,
            url: Config.WebUrl + 'Ajax_MyUser/EditRemark',
            data: { id: uid, remark: encodeURI(remark) },
            timeout: 200000,
            error: function (XmlHttpRequest, textStatus, errorThrown) { },
            success: function (ajaxData) {
                alert(ajaxData);
                //$("#Remark_" + uid).val("");
            },
            dataType: 'text'
        });
    }
    //查看历史备註
    vm.ShowRemark = function (uid) {
        var remark = "";
        $.ajax({
            type: 'POST',
            async: false,
            url: Config.WebUrl + 'Ajax_MyUser/ShowRemark',
            data: { id: uid, type: 2 },
            timeout: 200000,
            error: function (XmlHttpRequest, textStatus, errorThrown) { },
            success: function (ajaxData) {
                remark = ajaxData;
            },
            dataType: 'text'
        });
        $("#remarkhostList").html("");
        $("#remarkhostList").html(remark)
    }
    vm.HrefFun = function (url, uid) {
        location.href = url + uid;
    }
    //-------------------------批量审核
    vm.VerifyUserAllFun = function (status) {
        if (vm.changeList.length > 0) {
            if (window.confirm('你确定要更改选定项的审核状态吗？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }
                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_MyUser/VerifyAllUser',
                    data: { list: str, verifyId: status },
                    timeout: 200000,
                    success: function (ajaxData) {
                        if (!ajaxData.Status) {
                            var str = "";
                            console.log(ajaxData.Name);
                            //for (var i = 0; i < ajaxData.Data.length; i++) {
                            //    str += ajaxData.Data[i];
                            //}
                            alert(str);
                        }
                        else {
                            alert("修改审核状态成功!");
                        }

                        vm.changeList.clear();
                        vm.changeAll = false;
                        vm.getList();

                    },
                    dataType: 'json'
                });
                return true;
            } else {
                return false;
            }
        }
        else {
            alert('请选择要更改审核状态的企业会员!');
        }
    };
    //-------------------------批量推荐
    vm.RecomdUserAllFun = function (status) {
        if (vm.changeList.length > 0) {
            if (window.confirm('你确定要更改选定项的授权状态吗？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }
                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_MyUser/RecmdAllUser',
                    data: { list: str, verifyId: status },
                    timeout: 200000,
                    success: function (ajaxData) {
                        if (!ajaxData.Status) {
                            var str = "";
                            console.log(ajaxData.Name);
                            //for (var i = 0; i < ajaxData.Data.length; i++) {
                            //    str += ajaxData.Data[i];
                            //}
                            alert(str);
                        }
                        else {
                            alert("修改推荐状态成功!");
                        }

                        vm.changeList.clear();
                        vm.changeAll = false;
                        vm.getList();

                    },
                    dataType: 'json'
                });
                return true;
            } else {
                return false;
            }
        }
        else {
            alert('请选择要更改推荐状态的企业会员!');
        }
    };

    vm.DeleteMyUser = function (uid, realname) {

        if (confirm("确定要删除名为‘" + realname + "’的机构？")) {

            $.ajax({
                type: 'POST',
                async: false,
                url: Config.WebUrl + 'Ajax_MyUser/DeleteMyUser',
                data: { uid: uid },
                timeout: 200000,
                error: function (XmlHttpRequest, textStatus, errorThrown) { },
                success: function (ajaxData) {

                    vm.changeList.clear();
                    vm.changeAll = false;
                    vm.getList(vm.List_Page);
                    alert(ajaxData);
                },
                dataType: 'text'
            });
        }
    }

    //-------------------------批量删除
    vm.DeleteMyUserAllFun = function () {
        if (vm.changeList.length > 0) {
            if (window.confirm('你确定要删除选定项吗？')) {
                var str = "";
                for (var i = 0; i < vm.changeList.length; i++) {
                    str += vm.changeList[i] + ",";
                }
                $.ajax({
                    type: 'POST',
                    url: Config.WebUrl + 'Ajax_MyUser/DeleteAllCheckUser',
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
            alert('请选择要删除的商家用户信息!');
        }
    };

    vm.Search_Clear = function () {
        vm.List_Page = 1;
        vm.Search_Title = "";
        //vm.ListSearchCheck = false;
        vm.Search_BrandId = 0;
        vm.Search_TypeId = 0;
        vm.Search_StatusId = 0;
        vm.Search_SearchTypeId = 0;
        vm.getList();
    };

    vm.ToUserManage = function (name, pwd) {
        window.open(Config.SiteUrl + 'company/home/index?Name=' + name + '&Pwd=' + pwd + '&State=1', '_blank');
        //$.ajax({
        //    type: 'POST',
        //    async: false,
        //    url: Config.WebUrl + 'Ajax_MyUser/ToUserManage',
        //    data: { uid: uid, uname: uname },
        //    timeout: 200000,
        //    error: function (XmlHttpRequest, textStatus, errorThrown) {  },
        //    success: function (ajaxData) {

        //        if (ajaxData == 1) {
        //            window.open('http://www.weifaster.com/Member/UserManage/UserInfo', '_blank');
        //        } else {
        //            alert("商家不存在！");
        //        }

        //    },
        //    dataType: 'text'
        //});
    }
    /*************************分页******************************/
    vm.pager = {
        currentPage: 1,
        showPages: 6,
        perPages: 20,
        totalItems: 0,
        alwaysShowNext: true,
        alwaysShowPrev: true,
        showJumper: true,
        onJump: function (e, data) {
            //alert(data.currentPage +"|"+ $("#orderType").val());
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
MyUserList.getList();

function OpenWindowFunGetList() {
    MyUserList.getList();
}
function ReturnDateTimeNow() {
    var date = new Date();
    return date.getFullYear() + "/" + (1 + date.getMonth()) + "/" + date.getDate() + " " + date.getHours() + ":" + date.getMinutes();
}



