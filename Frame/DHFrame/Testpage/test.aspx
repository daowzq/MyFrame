<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="HDFrame.Testpage.test" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/ExtJs/resources/css/ext-all-neptune.css" rel="stylesheet" />
    <link href="../Css/common.css" rel="stylesheet" />
    <link href="../Css/extextend.css" rel="stylesheet" />
    <script type="text/javascript" src="/ExtJs/ext-all.js"></script>
    <script src="/ExtJs/ext-theme-neptune.js" type="text/javascript"></script>
    <script src="../Js/extextend.js"></script>
    <style type="text/css">
        .x-form-trigger-default.x-form-trigger-over {
            background-position: 0px center !important;
        }

        .custom-trigger {
            background: url('/icons/magnifier-png/ext.axd') no-repeat scroll 0px center #FFF;
            width: 22px;
        }
    </style>
    <script type="text/javascript">
        Ext.onReady(function () {
            Ext.create("Ext.panel.Panel", {
                id: "panel",
                margin: 20,
                renderTo: Ext.getBody(),
                width: 600,
                height: 300,
                items: [
                    {
                        xtype: 'button',
                        text: "获取值",
                        listeners: {
                            "click": function () {
                                var val = Ext.getCmp("TagField1").getValue();
                                alert(val);
                            }
                        }
                    },
                    {
                        id: "TagField1",
                        width: 400,
                        xtype: "tagfield",
                        emptyText: "请输入名称查询",
                        editable: true,
                        queryDelay: 50,
                        minChars: 1,
                        forceSelection: true,
                        queryMode: "remote",
                        store: new Ext.data.JsonStore({
                            // store configs
                            proxy: {
                                type: 'ajax',
                                url: '?',
                                reader: {
                                    type: 'json',
                                    root: 'items',
                                    totalProperty: 'total',
                                    idProperty: 'Code'
                                }
                            },
                            fields: [{ name: 'Code' }, { name: 'Name' }]
                        }),
                        triggerAction: 'all',
                        valueField: 'Code',
                        displayField: 'Name',
                        multiSelect: false,
                        inputMoving: true,
                        hideSelected: false
                    }
                ],
                title: "Title"
            });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    </form>
</body>
</html>
