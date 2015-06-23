<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HDFrame.Default" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智能学习管理系统</title>
    <link href="ExtJs/resources/css/ext-all-neptune.css" rel="stylesheet" />
    <script type="text/javascript" src="ExtJs/ext-all.js"></script>
    <script src="ExtJs/ext-theme-neptune.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
    <script src="Js/default.js" type="text/javascript"></script>
    <script src="Js/extextend.js" type="text/javascript"></script>
    <script src="ExtJs/ux/TabCloseMenu.js" type="text/javascript"></script>
    <style type="text/css">
        .view-port {
            background-color: #e7eaec;
        }
        /*top样式*/
        #topdiv-innerCt {
            display: block !important;
        }

        #topdiv .logo {
            width: 260px;
            height: 98%;
            border: solid 1px rgb(30,150,200);
            background-repeat: no-repeat;
            background-image: url("Images/logo.png");
            background-position-x: 10px;
            background-position-y: 6px;
        }

            #topdiv .logo > h1 {
                margin-top: 20px;
                margin-left: 70px;
                color: #fff;
                font-size: 1.3em;
                font-family: 'Microsoft YaHei', 微软雅黑;
            }
        /*底部版权样式*/
        .bottomCls {
            background-color: #4B9CD7 !important;
        }

        #corpDiv {
            width: 300px;
            margin-top: 5px;
            margin-left: auto;
            margin-right: auto;
        }
    </style>
    <script type="text/javascript">
        function topArrowClick(obj) {
            if ($(obj).find("img").attr("src").indexOf("bar4") > -1) {
                $(obj).css({ "top": 1 });
                var imgPath = $(obj).find("img").attr("src");
                $(obj).find("img").attr("src", imgPath.replace("bar4", "bar3"));
                Ext.getCmp("topdiv").setHeight(10);
                $(".logo").hide();
            } else {
                var imgPath = $(obj).find("img").attr("src");
                $(obj).find("img").attr("src", imgPath.replace("bar3", "bar4"));
                $(obj).css({ "top": 58 });
                Ext.getCmp("topdiv").setHeight(66);
                $(".logo").show();
            }
        }

        Ext.onReady(function () {
            Ext.History.init();//添加历史记录
            //---------treeArr------------------
            var value = document.getElementById("__PAGESTATE").value
            var moduleObj = Ext.decode(value);
            var moduleArr = Ext.decode(moduleObj[0].Value);
            var treeArr = addAppTree(moduleArr);
            //treeArr.push(sysModule()); //模块特殊配置
            //-------布局-------------------------
            Ext.create('Ext.container.Viewport', {
                layout: 'border',
                cls: "view-port",
                items: [{
                    id: "topdiv",
                    region: 'north',
                    height: 66,
                    collapseMode: 'mini',
                    layout: 'auto',
                    html: "<div style='height:66px; background-color: #1e96c8;'>"
                        + "<div class='logo'>"
                           + "<h1>目未智能学习管理中心</h1>"
                        + "</div>"
                        + "<div id='top-div' onclick='topArrowClick(this)' style='width:50px; z-index:999; position:absolute;top:58px;left:49%; cursor:pointer;'>"
                            + "<img src='Images/bar4.png' />"
                        + "</div>"
                        + "</div>",
                    border: false
                }, {
                    id: 'westDiv',
                    region: 'west',
                    layout: {
                        // layout-specific configs go here
                        type: 'accordion',
                        animate: true
                    },
                    split: true,
                    margin: '10 0 10 0',
                    collapsible: true,
                    title: '功能列表',
                    width: 180,
                    items: treeArr,
                    dockedItems: [{
                        xtype: 'toolbar',
                        dock: 'bottom',
                        bodyStyle: "padding-left:0px !important",
                        items: [{
                            width: 170,
                            hidden: true,
                            xtype: "textfield",
                            emptyText: "Search here..."
                        }]
                    }]
                }, {
                    id: 'tabpanel',
                    margin: '10 15 10 10',
                    region: 'center',
                    plain: true,
                    xtype: 'tabpanel',
                    activeTab: 0,
                    minTabWidth: 100,
                    items: [{
                        title: '首页',
                        id: 'tb0',
                        html: '<iframe width="100%" height="100%" id="defaultPgFrame" src="./defaulttab.aspx" name="frameContent" frameborder="0"></iframe>'
                    }
                    ],
                    plugins: Ext.create('Ext.ux.TabCloseMenu', {
                        closeTabText: '关闭当前页',
                        closeOthersTabsText: '关闭其他页',
                        closeAllTabsText: '关闭所有页'
                    }),
                    //Tab事件
                    listeners: {
                        // tabchange: onTabChange,
                        afterrender: onAfterRender
                    }
                }, {
                    margin: '1 0 0 0',
                    height: 26,
                    region: 'south',
                    cls: 'bottomCls',
                    //hidden: true,
                    html: '<div class="bottomDiv"><div id="corpDiv">Copyright © 2014 目未视觉软件有限公司</div></div>'
                }]
            });
        });
    </script>
</head>
<body>
    <form runat="server"></form>
</body>
</html>
