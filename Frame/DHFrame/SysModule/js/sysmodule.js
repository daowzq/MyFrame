
var win = parent.Ext.create('Ext.window.Window', {
    id: "modelWin",
    height: 400,
    hidden: true,
    width: 480,
    resizable: false,
    items: [{
        xtype: "form",
        items: [{
            margin: "10 10 20 10",
            xtype: "netlabel",
            text: "当前节点："
        }, {
            id: "TextField6",
            hidden: true,
            xtype: "textfield",
            name: "ID"
        }, {
            hidden: true,
            xtype: "textfield",
            name: "ParentID"
        }, {
            id: "TextField7",
            hidden: true,
            xtype: "textfield",
            name: "IsLeaf"
        }, {
            hidden: true,
            xtype: "textfield",
            name: "Path"
        }, {
            id: "FieldSet1",
            margin: "0 5",
            xtype: "fieldset",
            items: [{
                id: "pnlTableLayout",
                border: false,
                region: "center",
                items: [{
                    id: "TextField1",
                    width: 210,
                    xtype: "textfield",
                    fieldLabel: "模块名",
                    labelAlign: "right",
                    labelWidth: 80,
                    name: "Name"
                }, {
                    id: "TextField2",
                    width: 210,
                    xtype: "textfield",
                    fieldLabel: "编号",
                    labelAlign: "right",
                    labelWidth: 80,
                    name: "Code"
                }, {
                    width: 210,
                    xtype: "combobox",
                    fieldLabel: "模块类型",
                    labelAlign: "right",
                    labelWidth: 80,
                    name: "Type",
                    editable: false,
                    queryMode: "local",
                    store: [["0", "应用"], ["1", "页面"], ["2", "入口"]]
                }, {
                    id: "TextField4",
                    width: 210,
                    xtype: "textfield",
                    fieldLabel: "排序号",
                    labelAlign: "right",
                    labelWidth: 80,
                    name: "SortIndex",
                    maskRe: /\d+/
                }, {
                    id: "TextField3",
                    width: 420,
                    xtype: "textfield",
                    flex: 1,
                    colspan: 2,
                    fieldLabel: "URL",
                    labelAlign: "right",
                    labelWidth: 80,
                    name: "Url"
                }, {
                    id: "TextField5",
                    width: 420,
                    xtype: "textfield",
                    flex: 1,
                    colspan: 2,
                    fieldLabel: "图标",
                    labelAlign: "right",
                    labelWidth: 80,
                    name: "Icon"
                }, {
                    width: 420,
                    xtype: "textfield",
                    flex: 1,
                    colspan: 2,
                    fieldLabel: "描述",
                    labelAlign: "right",
                    labelWidth: 80,
                    name: "Description"
                }
                ],
                layout: {
                    type: "table",
                    columns: 2
                }
            }
            ],
            layout: "form",
            title: "基本属性"
        }, {
            id: "FieldSet2",
            height: 120,
            margin: "0 5",
            xtype: "fieldset",
            items: [{
                id: "Panel1",
                border: false,
                height: 50,
                region: "center",
                items: [{
                    xtype: "checkboxfield",
                    x: 0,
                    y: 10,
                    fieldLabel: "快速搜索",
                    labelAlign: "right",
                    name: "IsQuickSearch",
                    inputValue: "App.ctl24"
                }, {
                    xtype: "checkboxfield",
                    x: 120,
                    y: 10,
                    fieldLabel: "可回收",
                    labelAlign: "right",
                    name: "IsRecyclable",
                    inputValue: "App.ctl26"
                }
                ],
                layout: "absolute"
            }
            ],
            layout: "form",
            title: "配置属性"
        }
        ],
        url: unescape("%2fsysmodule%2fsysmodule.aspx"),
        waitMsgTarget: ""
    }
    ],
    dockedItems: [{
        border: true,
        dock: "bottom",
        height: 30,
        xtype: "toolbar",
        items: [{
            id: "Button2",
            height: 27,
            width: 60,
            x: 250,
            y: 0,
            iconCls: "#Disk",
            text: "保存"
        }, {
            id: "Button3",
            height: 27,
            width: 60,
            x: 320,
            y: 0,
            iconCls: "#PageDelete",
            text: "清空"
        }, {
            id: "Button4",
            height: 27,
            width: 60,
            x: 390,
            y: 0,
            iconCls: "#Cancel",
            text: "取消",
            listeners: {
                click: {
                    fn: function (item, e) {
                        App.addSubModelWin.close();
                    }
                }
            }
        }
        ],
        layout: "absolute"
    }
    ],
    title: "添加子模块",
    hidden: true
})