/*
* @Default页,处理系统模块 
* @Author: WGM
* @Date:   2015-3-28
*/

//---------添加系统模块,返回TreePanel数组------------------//
function addAppTree(moduleArr) {
    var treePanelArr = [];
    for (var i = 0; i < moduleArr.length; i++) {
        var record = moduleArr[i];
        //应用
        if (record.ParentID == "root" || record.ParentID == "") {
            var SeekId = record.ID;

            //添加子项
            var store = Ext.create('Ext.data.TreeStore', {
                root: {
                    expanded: true,
                    children: getChild(moduleArr, SeekId)
                }
            });

            var tree = Ext.create('Ext.tree.Panel', {
                title: record.Name || "",           //应用名称
                store: store,
                border: false,
                rootVisible: false,
                listeners: {
                    itemclick: function (view, rcd, item, idx, event, eOpts) {
                        var nodeName = rcd.get('text'); //节点名称
                        var nodeid = rcd.get('id');

                        var url = rcd.raw.url;          //自定义数据
                        var tabItem = Ext.getCmp(nodeid);
                        var tabCmp = Ext.ComponentQuery.query('tabpanel')[0];
                        if (url) {
                            Ext.History.add(nodeid + ':' + url); //添加到历史管理
                        }

                        if (tabItem == null) {
                            if (url == null || url == "") return; //不添加tab 
                            //添加tab
                            tabCmp.add(new Ext.Panel({
                                id: nodeid,
                                closable: true,
                                title: nodeName,
                                tabTip: nodeName,
                                html: '<iframe width="100%" height="100%" id="defaultPgFrame" src="' + url + '" name="frameContent" frameborder="0"></iframe>'
                            }));
                            tabCmp.setActiveTab(nodeid);
                        } else {
                            //重复点击
                            tabCmp.setActiveTab(tabItem)
                        }
                    }

                }
            });
            treePanelArr.push(tree);
        }
    }
    return treePanelArr;
}

//添加入口或页面
function getChild(arrs, parentId) {
    var resultArr = [];
    for (var i = 0; i < arrs.length; i++) {
        var object = arrs[i];
        if (object.ParentID == parentId) {
            var obj = {
                text: object.Name || "",
                id: object.ID || "",
                leaf: checkIsLeaf(arrs, object.ID),
                url: object.Url || "",
                children: getChild(arrs, object.ID)
            }
            resultArr.push(obj);
        }
    }
    return resultArr.length > 0 ? resultArr : null;
}
//leaf 属性 
function checkIsLeaf(arrs, Id) {
    for (var i = 0; i < arrs.length; i++) {
        if (arrs[i].ParentID == Id) {
            return false;
            break;
        }
    }
    return true;
}

//系统设置模块,特殊配置默认不启用
function sysModule() {
    var store = Ext.create('Ext.data.TreeStore', {
        root: {
            expanded: true,
            children: [
                { text: "系统模块", id: 'tb0_model', leaf: true, url: "sysmodule/sysmodule.aspx" }
            ]
        }
    });

    var tree = Ext.create('Ext.tree.Panel', {
        title: "特殊配置",
        store: store,
        border: false,
        rootVisible: false
    });

    tree.on("itemclick", function (view, rcd, item, idx, event, eOpts) {
        var nodeName = rcd.get('text'); //节点名称
        var nodeid = rcd.get('id');

        var url = rcd.raw.url;          //自定义数据
        var tabItem = Ext.getCmp(nodeid);
        var tabCmp = Ext.ComponentQuery.query('tabpanel')[0];
        if (tabItem == null) {
            //添加tab
            tabCmp.add(new Ext.Panel({
                id: nodeid,
                closable: true,
                title: nodeName,
                tabTip: nodeName,
                html: '<iframe width="100%" height="100%" id="defaultPgFrame" src="' + url + '" name="frameContent" frameborder="0"></iframe>'
            }));
            tabCmp.setActiveTab(nodeid);
        } else {
            //重复点击
            tabCmp.setActiveTab(tabItem)
        }
    });
    return tree;
}
//---------------End---------------------------------

//---------History 操作,when TabChange Add History---
function onTabChange(tabPanel, tab) {
    var tabs = [],
        ownerCt = tabPanel.ownerCt,
        oldToken, newToken;
    tabs.push(tab.id);
    tabs.push(tabPanel.id);
    newToken = tabs.reverse().join(":"); //分割
    oldToken = Ext.History.getToken();
    if (oldToken === null || oldToken.search(newToken) === -1) {
        Ext.History.add(newToken);
    }
}

//Handle this change event in order to restore the UI to the appropriate history state
//when page location href have changed fire History Event
function onAfterRender() {
    Ext.History.on('change', function (token) {
        var parts, tabPanel, length, i;
        if (token) {
            parts = token.split(":");
            Ext.getCmp('tabpanel').setActiveTab(Ext.getCmp(parts[0]));
            length = parts.length;
            // setActiveTab in all nested tabs
            //for (i = 0; i < length - 1; i++) {
            //    Ext.getCmp(parts[i]).setActiveTab(Ext.getCmp(parts[i + 1]));
            //}
        }
    });

    //打开上一次操作Tab(此方法耦合性较强,大量直接应用Default页面的变量)
    var token = Ext.History.getToken();
    if (token != null) {
        window.setTimeout(function () {
            var value = document.getElementById("__PAGESTATE").value
            var moduleObj = Ext.decode(value);
            var moduleArr = Ext.decode(moduleObj[0].Value);
            var tab = Ext.getCmp(token.split(":")[0]); //key:Value split

            if (moduleArr != null && tab == null && Ext.isArray(moduleArr)) {
                var tabCmp = Ext.getCmp('tabpanel');
                for (var i = 0; i < moduleArr.length; i++) {
                    var item = moduleArr[i], url = item.Url;
                    if (item.ID == token.split(":")[0]) {
                        //添加tab
                        tabCmp.add(new Ext.Panel({
                            id: item.ID,
                            closable: true,
                            title: item.Name,
                            tabTip: item.Name,
                            html: '<iframe width="100%" height="100%" id="defaultPgFrame" src="' + url + '" name="frameContent" frameborder="0"></iframe>'
                        }));
                        tabCmp.setActiveTab(item.ID);
                        break;
                    }
                }
            }
        }, 200);
    } else {
        // This is the initial default state.  Necessary if you navigate starting from the
        // page without any existing history token params and go back to the start state.
        var activeTab1 = Ext.getCmp('tabpanel').getActiveTab();
        onTabChange(Ext.getCmp('tabpanel'), activeTab1);
    }
}
//----------------------End---------------------------------------------