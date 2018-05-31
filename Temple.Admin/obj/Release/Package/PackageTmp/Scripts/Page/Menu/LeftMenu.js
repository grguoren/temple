define(["avalon", "text!./LeftMenu.html?" + Math.random()], function (avalon, leftmenu) {
    avalon.templateCache.leftmenu = leftmenu;
    avalon.vmodels.Index.LeftMenu = "leftmenu";
    var $list = avalon.define("leftmenu_common", function (vm) {
        vm.text = [];
    });//初始化模块ul

    //请求数据后修改模块内的数据
    $.ajax({
        type: 'POST',
        url: Config.WebUrl + 'Menu/GetLeftMenu',
        data: '',
        success: function (ajaxData) {
            $list.text = ajaxData;
        },
        dataType: 'json'
    });
})