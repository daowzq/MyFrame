<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BaseGrid.aspx.cs" Inherits="WebApplication1.BaseGrid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="Ext_4.2/resources/css/ext-all.css" rel="stylesheet" />
    <script src="Ext_4.2/ext-all-debug.js"></script>
    <script type="text/javascript">

        Ext.onReady(function () {
            var jsonData = {
                total: 20,
                'items': [
                    { 'name': 'Lisa', "email": "lisa@simpsons.com", "phone": "555-111-1224" },
                     { 'name': 'Bart', "email": "bart@simpsons.com", "phone": "555-222-1234" },
                    { 'name': 'Homer', "email": "home@simpsons.com", "phone": "555-222-1244" },
                    { 'name': 'Marge', "email": "marge@simpsons.com", "phone": "555-222-1254" }
                ]
            };

            var store = Ext.create('Ext.data.Store', {
                storeId: 'simpsonsStore',
                pageSize: 10,
                fields: ['name', 'email', 'phone'],
                data: jsonData,
                proxy: {
                    type: 'memory',
                    reader: {
                        type: 'json',
                        root: 'items',
                        totalProperty: 'total'
                    }
                }
            });
            //重新设置proxy
            var proxy = Ext.create("Ext.data.proxy.Ajax", {
                url: '?action=qry',
                reader: {
                    type: 'json',
                    root: 'items',
                    totalProperty: 'total'
                }
            });
            store.setProxy(proxy);

            var titleBar = Ext.create('Ext.toolbar.Toolbar', {
                width: 600,
                layout: {
                    overflowHandler: 'Menu'
                },
                items: [{
                    xtype: 'textfield',
                    id: 'searchMsg',
                    name: 'searchMsg',
                    fieldLabel: '姓名',
                    allowBlank: true
                }, '-', {
                    xtype: 'button',
                    text: '查询',
                    iconCls: 'icon-search-form',
                    handler: function () {
                        var txtSearch = Ext.String.trim(Ext.getCmp("searchMsg").getValue());
                        store.reload({ params: { start: 0, limit: store.pageSize, searchMsg: txtSearch } });
                    }
                }]
            });

            grid = Ext.create('Ext.grid.Panel', {
                title: 'Simpsons',
                store: store,
                columns: [
                    { text: 'Name', dataIndex: 'name' },
                    { text: 'Email', dataIndex: 'email', flex: 1 },
                    { text: 'Phone', dataIndex: 'phone' }
                ],
                tbar: titleBar,
                bbar: Ext.create('Ext.PagingToolbar', {
                    id: 'pagingBT',
                    store: store,
                    displayInfo: true,
                    displayMsg: '显示 {0} - {1} 条，共计 {2} 条记录',
                    emptyMsg: "没有一第记录显示"
                }),
                region: "center",
                renderTo: Ext.getBody()
            });
        })
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
