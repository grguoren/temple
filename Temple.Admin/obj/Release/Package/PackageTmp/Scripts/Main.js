﻿
var Config = { WebUrl: "http://localhost:18100/", ImgUrl: "http://image.bx58.com/", SiteUrl: "http://manage.bxtest.com/" };
//var Config = { WebUrl: "http://192.168.0.30/", ImgUrl: "http://image.bx58.com/", SiteUrl: "http://www.bxtest.com/" };
//var Config = { WebUrl: "http://manage.zhihucn.com/", ImgUrl: "http://yun.zhihucn.com/", SiteUrl: "http://edu.zhihucn.com/" };
//var Config = { WebUrl: "http://192.168.0.30:8038/", ImgUrl: "http://image.bx58.com", SiteUrl: "http://qy.zxtcw.cn/" };
//var Config = { WebUrl: "http://manage.bxtest.com/", ImgUrl: "http://image.bx58.com/", SiteUrl: "http://manage.bxtest.com/" };
require.config({//第一块，配置
    baseUrl: '',
    paths: {
        jquery: Config.WebUrl + 'Scripts/Lib/jquery/jquery.min',
        avalon: Config.WebUrl + 'Scripts/Lib/avalon/avalon',
        text: Config.WebUrl + 'Scripts/Lib/avalon/text',
        domReady: Config.WebUrl + 'Scripts/Lib/avalon/domReady',
        bootstrap: Config.WebUrl + 'Content/Bootstrap_ACE/js/bootstrap.min',
        ace_min: Config.WebUrl + 'Content/Bootstrap_ACE/js/ace.min',
        ace_extra: Config.WebUrl + 'Content/Bootstrap_ACE/js/ace-extra.min',
        ace_elements: Config.WebUrl + 'Content/Bootstrap_ACE/js/ace-elements.min',
        bootbox: Config.WebUrl + 'Content/Bootstrap_ACE/js/bootbox.min',
        publicCommon: Config.WebUrl + 'Scripts/Public.js?' + Math.random(),
        css: Config.WebUrl + 'Scripts/Lib/avalon/css',
        echarts: Config.WebUrl + 'Scripts/Lib/echarts/dist'
    },
    priority: ['text', 'css'],
    shim: {
        avalon: {
            exports: "avalon"
        }
    }
});
require(['bootbox', 'publicCommon'], function () {
    require(['avalon', "domReady!"], function () {//第二块，添加根VM（处理共用部分）
        avalon.log("加载avalon完毕，开始构建根VM与加载其他模块");

        require([Config.WebUrl + 'Scripts/CommonHelper/PageHelper/avalon.pager.js?v2.0',
            Config.WebUrl + "Scripts/CommonHelper/DatepickerHelper/avalon.datepicker.js?v2.1",
            Config.WebUrl + "Scripts/CommonHelper/SliderHelper/avalon.slider.js?v1.0"], function () {
                avalon.log("将分页组件,滑块组件,时间组件在公共模块加载");

                //开始加载各个功能模块
                var urlStr = location.href;
                //avalon.log(urlStr);
                //商家管理模块--商家修改
                if (urlStr.indexOf("/MyUserManage/UserAdd") > -1) {
                    require([Config.WebUrl + 'Scripts/CommonHelper/KindeditorHelper/avalon.kindeditor.js?v2.0'], function () {
                        require([Config.WebUrl + 'Scripts/Page/MyUserManage/UserAdd.js?' + Math.random()], function () {
                            avalon.log("商家列表管理模块--商家新增修改加载成功...");
                        });
                    });
                }
                if (urlStr.indexOf("/MyUserManage/UserDetail") > -1) {
                    require([Config.WebUrl + 'Scripts/CommonHelper/KindeditorHelper/avalon.kindeditor.js?v2.0'], function () {
                        require([Config.WebUrl + 'Scripts/Page/MyUserManage/UserDetail.js?' + Math.random()], function () {
                            avalon.log("商家列表管理模块--商家修改加载成功...");
                        });
                    });
                }

                //用户管理模块
                if (urlStr.indexOf("/System/UserIndex") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/System/UserIndex.js?' + Math.random()], function () {
                        avalon.log("用户管理模块加载成功...");
                    });
                }
                else if (urlStr.indexOf("/System/UserAdd") > -1) {
                    require([Config.WebUrl + 'Scripts/CommonHelper/PreviewHelper/avalon.preview.js',
                    , Config.WebUrl + 'Scripts/CommonHelper/KindeditorHelper/avalon.kindeditor.js',
                    Config.WebUrl + 'Scripts/Lib/ajaxfileupload/ajaxfileupload.js'], function () {
                        require([Config.WebUrl + 'Scripts/Page//System/UserAdd.js?' + Math.random()]);
                        avalon.log("系統管理--用户管理模块編輯加载成功...");
                    });
                }
                    //省份城市管理--城市列表
                else if (urlStr.indexOf("/CityManage/List") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/CityManage/List.js?' + Math.random()], function () {
                        avalon.log("省份城市管理--城市列表加载成功...");

                    });
                }
               
                    //菜单管理模块
                else if (urlStr.indexOf("/System/MenuIndex") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/System/MenuIndex.js?' + Math.random()], function () {
                        avalon.log("菜单管理模块加载成功...");
                    });
                }

                    //角色管理模块
                else if (urlStr.indexOf("/System/Role") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/System/RoleIndex.js?' + Math.random()], function () {
                        avalon.log("角色管理模块加载成功...");
                    });
                }
                    //操作日志模块
                else if (urlStr.indexOf("/System/LogList") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/System/LogList.js?' + Math.random()], function () {
                        avalon.log("操作日志模块加载成功...");
                    });
                }
                    //邮件发送日志模块
                else if (urlStr.indexOf("/SystemManage/MailLogList") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/SystemManage/MailLogList.js?' + Math.random()], function () {
                        avalon.log("邮件发送日志模块加载成功...");
                    });
                }
                    //短信发送日志模块
                else if (urlStr.indexOf("/SystemManage/SmsLogList") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/SystemManage/SmSLogList.js?' + Math.random()], function () {
                        avalon.log("短信发送日志模块加载成功...");
                    });
                }
                else if (urlStr.indexOf("/AccountManage/AccountList") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/AccountManage/AccountList.js?' + Math.random()], function () {
                        avalon.log("入帳單位管理列表模塊加載成功...");
                    });
                }
                else if (urlStr.indexOf("/AccountManage/AccountAdd") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/AccountManage/AccountAdd.js?' + Math.random()], function () {
                        avalon.log("入帳單位管理編輯模塊加載成功...");
                    });
                }
                else if (urlStr.indexOf("/AccountManage/ServiceList") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/AccountManage/ServiceList.js?' + Math.random()], function () {
                        avalon.log("服務項目管理列表模塊加載成功...");
                    });
                }
                else if (urlStr.indexOf("/AccountManage/ServiceAdd") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/AccountManage/ServiceAdd.js?' + Math.random()], function () {
                        avalon.log("服務項目管理編輯模塊加載成功...");
                    });
                }
                else if (urlStr.indexOf("/MemberManage/Index") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/MemberManage/Index.js?' + Math.random()], function () {
                        avalon.log("彎友管理列表模塊加載成功...");
                    });
                }
                else if (urlStr.indexOf("/MemberManage/Add") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/MemberManage/Add.js?' + Math.random()], function () {
                        avalon.log("彎友管理編輯模塊加載成功...");
                    });
                }

                else if (urlStr.indexOf("/FestivalManage/List") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/FestivalManage/List.js?' + Math.random()], function () {
                        avalon.log("法會管理列表模塊加載成功...");
                    });
                }
                else if (urlStr.indexOf("/FestivalManage/Add") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/FestivalManage/Add.js?' + Math.random()], function () {
                        avalon.log("法會管理編輯模塊加載成功...");
                    });
                }


                else if (urlStr.indexOf("/AngelManage/List") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/AngelManage/List.js?' + Math.random()], function () {
                        avalon.log("聖示護法管理列表模塊加載成功...");
                    });
                }
                else if (urlStr.indexOf("/AngelManage/Add") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/AngelManage/Add.js?' + Math.random()], function () {
                        avalon.log("聖示護法管理編輯模塊加載成功...");
                    });
                }

                else if (urlStr.indexOf("/MakeManage/List") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/MakeManage/List.js?' + Math.random()], function () {
                        avalon.log("彎友叩問管理列表模塊加載成功...");
                    });
                }
                else if (urlStr.indexOf("/MakeManage/Add") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/MakeManage/Add.js?' + Math.random()], function () {
                        avalon.log("彎友叩問管理編輯模塊加載成功...");
                    });
                }

                else if (urlStr.indexOf("/MemberManage/PractitionerList") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/MemberManage/PractitionerList.js?' + Math.random()], function () {
                        avalon.log("被保舉人管理列表模塊加載成功...");
                    });
                }
                else if (urlStr.indexOf("/MemberManage/PractitionerAdd") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/MemberManage/PractitionerAdd.js?' + Math.random()], function () {
                        avalon.log("被保舉人管理編輯模塊加載成功...");
                    });
                }

                    //相片管理模块--相片列表
                else if (urlStr.indexOf("/ServiceManage/PictureList") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/ServiceManage/PictureList.js?' + Math.random()], function () {
                        avalon.log("祭拜圖片管理列表模塊加載成功...");
                        require([Config.WebUrl + 'Scripts/Lib/highslide/highslide-with-gallery.js'], function () {
                            hs.graphicsDir = Config.WebUrl + 'Scripts/Lib/highslide/graphics/';
                            hs.align = 'center';
                            hs.transitions = ['expand', 'crossfade'];
                            hs.outlineType = 'rounded-white';
                            hs.fadeInOut = true;
                            hs.showCredits = false;
                            hs.addSlideshow({
                                interval: 5000,
                                repeat: false,
                                useControls: true,
                                fixedControls: 'fit',
                                overlayOptions: {
                                    opacity: .75,
                                    position: 'bottom center',
                                    hideOnMouseOut: true
                                }
                            });
                        });
                    });
                }

                else if (urlStr.indexOf("/ServiceManage/PictureAdd") > -1) {
                    require([Config.WebUrl + 'Scripts/CommonHelper/PreviewHelper/avalon.preview.js',
                    , Config.WebUrl + 'Scripts/CommonHelper/KindeditorHelper/avalon.kindeditor.js',
                    Config.WebUrl + 'Scripts/Lib/ajaxfileupload/ajaxfileupload.js'], function () {
                        require([Config.WebUrl + 'Scripts/Page//ServiceManage/PictureAdd.js?' + Math.random()]);
                        avalon.log("祭拜圖片管理編輯加载成功...");
                    });
                }
                else if (urlStr.indexOf("/ServiceManage/List") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/ServiceManage/List.js?' + Math.random()], function () {
                        avalon.log("功德項目管理列表模塊加載成功...");
                    });
                }
                else if (urlStr.indexOf("/ServiceManage/Add") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/ServiceManage/Add.js?' + Math.random()], function () {
                        avalon.log("功德項目管理編輯模塊加載成功...");
                    });
                }
                else if (urlStr.indexOf("/BasicManage/Title") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/BasicManage/Title.js?' + Math.random()], function () {
                        avalon.log("稱謂管理列表模塊加載成功...");
                    });
                }
                else if (urlStr.indexOf("/BasicManage/AddTitle") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/BasicManage/AddTitle.js?' + Math.random()], function () {
                        avalon.log("稱謂管理編輯模塊加載成功...");
                    });
                }
                    //付款方式模塊
                else if (urlStr.indexOf("/BasicManage/Payment") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/BasicManage/Payment.js?' + Math.random()], function () {
                        avalon.log("付款方式管理列表模塊加載成功...");
                    });
                }
                else if (urlStr.indexOf("/BasicManage/Add") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/BasicManage/PaymentAdd.js?' + Math.random()], function () {
                        avalon.log("付款方式管理編輯模塊加載成功...");
                    });
                }
               
                else if (urlStr.indexOf("/EnumManage/Add") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/EnumManage/Add.js?' + Math.random()], function () {
                        avalon.log("参数管理修改模块加载成功...");
                    });
                }
                else if (urlStr.indexOf("/FeedbackManage/List") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/FeedbackManage/List.js?' + Math.random()], function () {
                        avalon.log("会员管理反馈列表模块加载成功...");
                    });
                } 
                else if (urlStr.indexOf("/ActiveManage/LiveTicket") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/ActiveManage/LiveTicket.js?' + Math.random()], function () {
                        avalon.log("活动管理模块--大会网络直播活动报名列表加载成功...");
                        require([Config.WebUrl + 'Scripts/Lib/highslide/highslide-with-gallery.js'], function () {
                            hs.graphicsDir = Config.WebUrl + 'Scripts/Lib/highslide/graphics/';
                            hs.align = 'center';
                            hs.transitions = ['expand', 'crossfade'];
                            hs.outlineType = 'rounded-white';
                            hs.fadeInOut = true;
                            hs.showCredits = false;
                            hs.addSlideshow({
                                interval: 5000,
                                repeat: false,
                                useControls: true,
                                fixedControls: 'fit',
                                overlayOptions: {
                                    opacity: .75,
                                    position: 'bottom center',
                                    hideOnMouseOut: true
                                }
                            });
                        });
                    });
                }
                    /*************************************************系统功能管理模块***************************************************************************/
                    //入驻管理模块--个人讲师列表
                else if (urlStr.indexOf("/EnterManage/Index") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/EnterManage/Index.js?' + Math.random()], function () {
                        avalon.log("入驻管理模块--入驻讲师列表加载成功...");
                        require([Config.WebUrl + 'Scripts/Lib/highslide/highslide-with-gallery.js'], function () {
                            hs.graphicsDir = Config.WebUrl + 'Scripts/Lib/highslide/graphics/';
                            hs.align = 'center';
                            hs.transitions = ['expand', 'crossfade'];
                            hs.outlineType = 'rounded-white';
                            hs.fadeInOut = true;
                            hs.showCredits = false;
                            hs.addSlideshow({
                                interval: 5000,
                                repeat: false,
                                useControls: true,
                                fixedControls: 'fit',
                                overlayOptions: {
                                    opacity: .75,
                                    position: 'bottom center',
                                    hideOnMouseOut: true
                                }
                            });
                        });
                    });
                }
                    //入驻管理模块--机构列表
                else if (urlStr.indexOf("/EnterManage/CompanyList") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/EnterManage/CompanyList.js?' + Math.random()], function () {
                        avalon.log("入驻管理模块--入驻机构列表加载成功...");
                        require([Config.WebUrl + 'Scripts/Lib/highslide/highslide-with-gallery.js'], function () {
                            hs.graphicsDir = Config.WebUrl + 'Scripts/Lib/highslide/graphics/';
                            hs.align = 'center';
                            hs.transitions = ['expand', 'crossfade'];
                            hs.outlineType = 'rounded-white';
                            hs.fadeInOut = true;
                            hs.showCredits = false;
                            hs.addSlideshow({
                                interval: 5000,
                                repeat: false,
                                useControls: true,
                                fixedControls: 'fit',
                                overlayOptions: {
                                    opacity: .75,
                                    position: 'bottom center',
                                    hideOnMouseOut: true
                                }
                            });
                        });
                    });
                }//讲师列表
                else if (urlStr.indexOf("/EnterManage/CTeacherList") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/EnterManage/CTeacherList.js?' + Math.random()], function () {
                        avalon.log("讲师管理模块--机构或平台讲师列表加载成功...");
                        require([Config.WebUrl + 'Scripts/Lib/highslide/highslide-with-gallery.js'], function () {
                            hs.graphicsDir = Config.WebUrl + 'Scripts/Lib/highslide/graphics/';
                            hs.align = 'center';
                            hs.transitions = ['expand', 'crossfade'];
                            hs.outlineType = 'rounded-white';
                            hs.fadeInOut = true;
                            hs.showCredits = false;
                            hs.addSlideshow({
                                interval: 5000,
                                repeat: false,
                                useControls: true,
                                fixedControls: 'fit',
                                overlayOptions: {
                                    opacity: .75,
                                    position: 'bottom center',
                                    hideOnMouseOut: true
                                }
                            });
                        });
                    });
                }
                    //讲师管理模块--添加
                else if (urlStr.indexOf("/EnterManage/TeacherAdd") > -1) {
                    require([Config.WebUrl + 'Scripts/CommonHelper/PreviewHelper/avalon.preview.js',
                    , Config.WebUrl + 'Scripts/CommonHelper/KindeditorHelper/avalon.kindeditor.js',
                    Config.WebUrl + 'Scripts/Lib/ajaxfileupload/ajaxfileupload.js'], function () {
                        require([Config.WebUrl + 'Scripts/Page/EnterManage/TeacherAdd.js?' + Math.random()]);
                        avalon.log("课程管理模块--添加与修改讲师加载成功...");
                    });
                }
                    //资讯管理模块--资讯列表
                else if (urlStr.indexOf("/InfomationManage/List") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/InfomationManage/List.js?' + Math.random()], function () {
                        avalon.log("资讯管理模块--资讯列表加载成功...");
                    });
                }
               
                else if (urlStr.indexOf("/Register/Agreement") > -1) {
                    require([Config.WebUrl + 'Scripts/CommonHelper/PreviewHelper/avalon.preview.js',
                    , Config.WebUrl + 'Scripts/CommonHelper/KindeditorHelper/avalon.kindeditor.js',
                    Config.WebUrl + 'Scripts/Lib/ajaxfileupload/ajaxfileupload.js'], function () {
                        require([Config.WebUrl + 'Scripts/Page/Register/Agreement.js?' + Math.random()]);
                        avalon.log("合同管理模块--註册协议加载成功...");
                    });
                }
                    //广告管理模块--添加或修改广告基本信息
                else if (urlStr.indexOf("/AdviceManage/AddAdvice") > -1) {
                    require([Config.WebUrl + 'Scripts/CommonHelper/PreviewHelper/avalon.preview.js',
                    , Config.WebUrl + 'Scripts/CommonHelper/KindeditorHelper/avalon.kindeditor.js',
                    Config.WebUrl + 'Scripts/Lib/ajaxfileupload/ajaxfileupload.js'], function () {
                        require([Config.WebUrl + 'Scripts/Page/AdviceManage/AddAdvice.js?' + Math.random()]);
                        avalon.log("广告管理模块--添加或修改广告基本信息加载成功...");
                    });
                }
                    //资讯管理模块--添加或修改资讯
                else if (urlStr.indexOf("/InfomationManage/Add") > -1) {
                    require([Config.WebUrl + 'Scripts/CommonHelper/PreviewHelper/avalon.preview.js',
                    , Config.WebUrl + 'Scripts/CommonHelper/KindeditorHelper/avalon.kindeditor.js',
                    Config.WebUrl + 'Scripts/Lib/ajaxfileupload/ajaxfileupload.js'], function () {
                        require([Config.WebUrl + 'Scripts/Page/InfomationManage/Add.js?' + Math.random()]);
                        avalon.log("资讯管理模块--添加或修改资讯加载成功...");
                    });
                }
                    //资讯管理模块--资讯分类列表
                else if (urlStr.indexOf("/InfomationManage/TypeList") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/InfomationManage/TypeList.js?' + Math.random()], function () {
                        avalon.log("资讯管理模块--资讯分类列表加载成功...");
                    });
                }
                    //资讯管理模块--资讯分类添加或修改
                else if (urlStr.indexOf("/InfomationManage/TypeAdd") > -1) {
                    require([Config.WebUrl + 'Scripts/CommonHelper/KindeditorHelper/avalon.kindeditor.js?v2.0'], function () {
                        require([Config.WebUrl + 'Scripts/Page/InfomationManage/TypeAdd.js?' + Math.random()], function () {
                            avalon.log("资讯管理模块--资讯分类添加或修改加载成功...");
                        });
                    });
                }

                else if (urlStr.indexOf("/SignManage/List") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/SignManage/List.js?' + Math.random()], function () {
                        avalon.log("大会签到模块加载成功...");
                    });
                } else if (urlStr.indexOf("/SignManage/Add") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/SignManage/Add.js?' + Math.random()], function () {
                        avalon.log("大会签到修改模块加载成功...");
                    });
                }
                  

                    //帮助中心管理模块--列表
                else if (urlStr.indexOf("/FaqManage/List") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/FaqManage/List.js?' + Math.random()], function () {
                        avalon.log("帮助中心管理模块--列表加载成功...");
                    });
                }
                    //课程管理模块--列表
                else if (urlStr.indexOf("/CourseManage/Index") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/CourseManage/Index.js?' + Math.random()], function () {
                        avalon.log("课程管理模块--列表加载成功...");
                    });
                }
                    //课程管理模块--添加
                else if (urlStr.indexOf("/CourseManage/WareAdd") > -1) {
                    require([Config.WebUrl + 'Scripts/CommonHelper/PreviewHelper/avalon.preview.js',
                    , Config.WebUrl + 'Scripts/CommonHelper/KindeditorHelper/avalon.kindeditor.js',
                    Config.WebUrl + 'Scripts/Lib/ajaxfileupload/ajaxfileupload.js'], function () {
                        require([Config.WebUrl + 'Scripts/Page/CourseManage/WareAdd.js?' + Math.random()]);
                        avalon.log("课程管理模块--新增修改课节加载成功...");
                    });
                }
                    //课程管理模块--添加
                else if (urlStr.indexOf("/CourseManage/CourseAdd") > -1) {
                    require([Config.WebUrl + 'Scripts/CommonHelper/PreviewHelper/avalon.preview.js',
                    , Config.WebUrl + 'Scripts/CommonHelper/KindeditorHelper/avalon.kindeditor.js',
                    Config.WebUrl + 'Scripts/Lib/ajaxfileupload/ajaxfileupload.js'], function () {
                        require([Config.WebUrl + 'Scripts/Page/CourseManage/CourseAdd.js?' + Math.random()]);
                        avalon.log("课程管理模块--新增修改课程加载成功...");
                    });
                }
                    //课程管理模块--列表
                else if (urlStr.indexOf("/CourseManage/AdviceList") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/CourseManage/AdviceList.js?' + Math.random()], function () {
                        avalon.log("课程管理模块--咨询列表加载成功...");
                    });
                }
                    //课程管理模块--列表
                else if (urlStr.indexOf("/CourseManage/TopicList") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/CourseManage/TopicList.js?' + Math.random()], function () {
                        avalon.log("课程管理模块--话题列表加载成功...");
                    });
                }
                   

                    //帮助中心管理模块--分类列表
                else if (urlStr.indexOf("/FaqManage/TypeList") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/FaqManage/TypeList.js?' + Math.random()], function () {
                        avalon.log("帮助中心管理模块--分类列表加载成功...");
                    });
                }
                    //帮助中心管理模块--添加
                else if (urlStr.indexOf("/FaqManage/Add") > -1) {
                    require([Config.WebUrl + 'Scripts/CommonHelper/KindeditorHelper/avalon.kindeditor.js?v2.0'], function () {
                        require([Config.WebUrl + 'Scripts/Page/FaqManage/Add.js?' + Math.random()], function () {
                            avalon.log("帮助中心管理模块--添加加载成功...");
                        });
                    });
                }
                    //帮助中心管理模块--分类添加
                else if (urlStr.indexOf("/FaqManage/TypeAdd") > -1) {
                    require([Config.WebUrl + 'Scripts/CommonHelper/KindeditorHelper/avalon.kindeditor.js?v2.0',
                        Config.WebUrl + 'Scripts/Page/FaqManage/TypeAdd.js?' + Math.random()], function () {
                            avalon.log("帮助中心管理模块--分类添加加载成功...");
                        });
                }
                    //支付管理模块--列表
                else if (urlStr.indexOf("/PayManage/List") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/PayManage/List.js?' + Math.random()], function () {
                        avalon.log("支付管理模块--列表加载成功...");
                    });
                }
                   
                    //反馈管理--反馈列表
                else if (urlStr.indexOf("/FeedbackManage/List") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/FeedbackManage/List.js?' + Math.random()], function () {
                        avalon.log("反馈管理--反馈列表加载成功...");

                    });
                }

                    //芳华云资质认证--认证列表
                else if (urlStr.indexOf("/QualifyCertifyManage/List") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/QualifyCertifyManage/List.js?' + Math.random()], function () {
                        avalon.log("芳华云资质认证--认证列表加载成功...");
                        require([Config.WebUrl + 'Scripts/Lib/highslide/highslide-with-gallery.js'], function () {
                            hs.graphicsDir = Config.WebUrl + 'Scripts/Lib/highslide/graphics/';
                            hs.align = 'center';
                            hs.transitions = ['expand', 'crossfade'];
                            hs.outlineType = 'rounded-white';
                            hs.fadeInOut = true;
                            hs.showCredits = false;
                            hs.addSlideshow({
                                interval: 5000,
                                repeat: false,
                                useControls: true,
                                fixedControls: 'fit',
                                overlayOptions: {
                                    opacity: .75,
                                    position: 'bottom center',
                                    hideOnMouseOut: true
                                }
                            });
                        });
                    });
                }
                    //芳华云资质认证--编辑认证信息
                else if (urlStr.indexOf("/QualifyCertifyManage/Add") > -1) {
                    require([Config.WebUrl + 'Scripts/Page/QualifyCertifyManage/Add.js?' + Math.random()], function () {
                        avalon.log("芳华云资质认证--编辑认证信息加载成功...");

                    });
                }
                 else if (urlStr.indexOf("/MyUserManage/MyTitle") > -1) {

                    require([Config.WebUrl + 'Scripts/Page/MyUserManage/MyTitle.js?' + Math.random()], function () {
                        avalon.log("商家标题模块--商家列表加载成功...");
                    });
                } else if (urlStr.indexOf("/MyUserManage/TitleAdd") > -1) {

                    require([Config.WebUrl + 'Scripts/Page/MyUserManage/TitleAdd.js?' + Math.random()], function () {
                        avalon.log("商家标题模块--添加加载成功...");
                    });
                }
                /*************************************************系统功能管理模块***************************************************************************/
            });

        //avalon.scan(document.getElementById('Doc_contentAll'));//註释掉DomReady模块之后需要手动扫描
    });
});