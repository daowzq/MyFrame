<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysRegedit.aspx.cs" Inherits="HDFrame.SysModule.SysRegedit" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .bg-white {
            background-color: #fff;
        }

        .west-panel {
            background-color: #fff;
            border-Color: #a1a3a5;
            border-Width: 1px;
            border-Style: solid;
            border-Left-Width: 3px;
            border-Top-Width: 0px;
            border-Left-Color: #eed485;
        }
    </style>
    <script type="text/javascript">

        //添加子模块
        function addChild(treepanel) {
            var recd = App.SysModuleTree.getSelectionModel().getLastSelected();
            if (recd != null) {
                App.txtParentID.setValue(recd.get("ID") || "");
                App.txtPath.setValue(recd.getPath());
            } else {
                App.txtPath.setValue("/root");
            }
            App.addSubModelWin.show();
        }

        //保存数据
        function saveData() {
            if (!App.NodeForm.getForm().isValid()) {
                return;
            }
            //检查Code 是否重复
            App.direct.CheckCode(App.txtNum.getValue(), {
                success: function () {
                    var record = App.NodeForm.getForm().getValues();

                    App.direct.SaveData(Ext.encode(record), {
                        success: function (result) {
                            Ext.Msg.alert('提示', '修改成功');
                            App.NodeForm.getForm().reset();
                            App.addSubModelWin.close();
                            App.TreeStore1.on({
                                "load": function () {
                                    var node = App.TreeStore1.getNodeById(result);
                                    App.SysModuleTree.expandPath(node.getPath());
                                },
                                single: true
                            })
                            App.TreeStore1.reload();
                        }
                    })
                }
            });
        }
        //编辑数据
        function editRecord() {
            if (!App.SysModuleTree.getSelectionModel().getLastSelected()) {
                Ext.Msg.alert("提示", "请选择要修改的记录");
                return;
            }

            var record = App.SysModuleTree.getSelectionModel().getLastSelected();
            App.NodeForm.getForm().loadRecord(record);
            App.addSubModelWin.show();
        }
        //删除数据
        function deleteRecord() {
            if (App.SysModuleTree.getSelectionModel().getLastSelected()) {
                if (App.SysModuleTree.getSelectionModel().getLastSelected().get("ParentID") == "root") {
                    Ext.Msg.alert("提示", "根节点不可删除!");
                    return;
                }
            }
            if (!App.SysModuleTree.getSelectionModel().getLastSelected()) {
                Ext.Msg.alert("提示", "请选择要删除的记录");
                return;
            }

            var record = App.SysModuleTree.getSelectionModel().getLastSelected();
            App.direct.DeleteCheck(record.get("ID"), {
                success: function (result) {
                    if (result == "1") {
                        Ext.Msg.confirm("提示", "确认要删除数据吗?", function (rtn) {
                            if (rtn == "yes") {
                                App.direct.DeleteData(record.get("ID"), {
                                    success: function (result) {
                                        if (result == "1") {
                                            Ext.Msg.alert("提示", "删除成功")
                                            App.TreeStore1.reload();
                                        }
                                    }
                                });
                            }
                        })
                    } else {
                        Ext.Msg.alert("提示", "该节点下有子节点");
                    }
                }
            })
        }
        //键值查询
        function treeKeySearch() {

            var name = App.txtName.getValue();
            var key = App.txtCode.getValue();
            Ext.Ajax.request({
                url: '?action=nodesch',
                params: {
                    Name: name,
                    Code: key
                },
                success: function (response) {
                    var arr = Ext.decode(response.responseText);
                    if (Ext.isArray(arr)) {
                        Ext.each(arr, function (item) {
                            App.SysModuleTree.expandPath(item.Path);
                        })
                    }
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" DisableViewState="true" runat="server"></ext:ResourceManager>
        <ext:Window runat="server"
            Title="添加子节点"
            Width="400"
            Hidden="true"
            Height="250"
            Resizable="false"
            ID="addSubModelWin">
            <Items>
                <ext:FormPanel ID="NodeForm" runat="server" MarginSpec="10 0 0 0">
                    <Items>
                        <ext:TextField ID="TextField1" LabelWidth="60" Width="260" runat="server" Name="ID" Hidden="true" />
                        <ext:TextField ID="txtPath" runat="server" Hidden="true" Name="Path" />
                        <ext:TextField ID="txtParentID" runat="server" Hidden="true" Name="ParentID" />

                        <ext:TextField ID="TextField2"
                            runat="server"
                            Name="Name"
                            LabelWidth="60"
                            Width="260"
                            AllowBlank="false"
                            LabelAlign="Right"
                            FieldLabel="名称">
                        </ext:TextField>

                        <ext:TextField ID="txtNum"
                            Name="RegisterKey"
                            Width="260"
                            AllowBlank="false"
                            LabelAlign="Right"
                            LabelWidth="60"
                            runat="server"
                            FieldLabel="Code">
                        </ext:TextField>

                        <ext:TextField ID="TextField3" runat="server"
                            Name="RegisterValue"
                            Width="260"
                            LabelWidth="60"
                            LabelAlign="Right"
                            FieldLabel="Value">
                        </ext:TextField>

                        <ext:TextArea ID="TextArea1" runat="server"
                            LabelWidth="60"
                            Width="320"
                            LabelAlign="Right"
                            Name="Remark"
                            FieldLabel="描述">
                        </ext:TextArea>
                    </Items>
                </ext:FormPanel>
            </Items>
            <DockedItems>
                <ext:Toolbar ID="Toolbar1" Height="38px" Dock="Bottom" Border="true" runat="server" Layout="BorderLayout">
                    <Items>
                        <ext:Button ID="Button2" Region="East" Icon="Disk" runat="server" Text="保存" Width="60px" Height="27" X="250" Y="0">
                            <Listeners>
                                <Click Fn="saveData">
                                </Click>
                            </Listeners>
                        </ext:Button>
                        <ext:Button ID="Button4" Region="East" Icon="Cancel" Text="取消" runat="server" Width="60px" Height="27" X="390" Y="0">
                            <Listeners>
                                <Click Handler="App.addSubModelWin.close();"></Click>
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </DockedItems>
        </ext:Window>
        <%-- Main --%>
        <ext:Viewport ID="Viewport1" runat="server" Cls="west-panel" Layout="BorderLayout">
            <Items>
                <ext:Panel ID="Panel2" runat="server" Region="North" Heigh="85px">
                    <Items>
                        <ext:Toolbar ID="Toolbar2" runat="server">
                            <Items>
                                <ext:Button ID="Button1" runat="server" Text="添加" Icon="ApplicationAdd">
                                    <Listeners>
                                        <Click Handler="addChild()"></Click>
                                    </Listeners>
                                </ext:Button>
                                <ext:Button ID="Button5" runat="server" Icon="ApplicationEdit" Text="修改">
                                    <Listeners>
                                        <Click Handler="editRecord()"></Click>
                                    </Listeners>
                                </ext:Button>
                                <ext:Button ID="Button6" runat="server" Text="删除" Icon="Delete">
                                    <Listeners>
                                        <Click Handler="deleteRecord()"></Click>
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </Items>
                </ext:Panel>
                <ext:Panel ID="Panel1" runat="server" Border="false" Region="North" MarginSpec="3 0 0 0">
                    <Content>
                        <div style="height: 1px; border-top: solid 1px rgb(21,127,204)"></div>
                    </Content>
                </ext:Panel>
                <ext:Panel ID="Panel3" runat="server" Region="North" Layout="ColumnLayout" MarginSpec="8 0 0 0">
                    <Items>
                        <ext:TextField
                            ColumnWidth="0.25"
                            LabelWidth="60"
                            ID="txtName"
                            Width="180"
                            FieldLabel="&nbsp;名称"
                            LabelAlign="left"
                            runat="server">
                            <Listeners>
                                <SpecialKey Handler=" if (e.getKey() == Ext.EventObject.ENTER) {
                                                                      treeKeySearch();   }">
                                </SpecialKey>
                            </Listeners>
                        </ext:TextField>
                        <ext:TextField ID="txtCode"
                            LabelWidth="80"
                            Width="180"
                            ColumnWidth="0.25"
                            LabelAlign="Right"
                            FieldLabel="KEY"
                            runat="server">
                            <Listeners>
                                <SpecialKey Handler=" if (e.getKey() == Ext.EventObject.ENTER) {
                                                                      treeKeySearch();   }">
                                </SpecialKey>
                            </Listeners>
                        </ext:TextField>

                        <ext:Panel ID="Panel4" runat="server" ColumnWidth="0.2">
                            <Items>
                                <ext:Button runat="server"
                                    ID="btnSub"
                                    Width="80"
                                    MarginSpec="0 0 0 10"
                                    Text="查询" Icon="Zoom">
                                    <Listeners>
                                        <Click Handler="treeKeySearch()">
                                        </Click>
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Panel>

                <%-- treePanel --%>
                <ext:TreePanel ID="SysModuleTree"
                    Region="Center"
                    runat="server"
                    RootVisible="false"
                    MinHeight="500"
                    FolderSort="true">
                    <Store>
                        <ext:TreeStore ID="TreeStore1" runat="server">
                            <Model>
                                <ext:Model ID="Model1" runat="server" IDProperty="ID">
                                    <Fields>
                                        <ext:ModelField Name="ID" Type="Auto" />
                                        <ext:ModelField Name="ParentID" Type="Auto" />
                                        <ext:ModelField Name="RegisterKey" Type="Auto" />
                                        <ext:ModelField Name="Name" Type="Auto" />
                                        <ext:ModelField Name="RegisterValue" Type="Auto" />
                                        <ext:ModelField Name="Path" Type="Auto" />
                                        <ext:ModelField Name="Remark" Type="Auto" />
                                        <ext:ModelField Name="CreateTime" Type="Date" />
                                        <ext:ModelField Name="SortIndex" Type="Auto" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                            <Root>
                                <ext:Node NodeID="root" Text="系统枚举" Leaf="false" Expanded="true">
                                </ext:Node>
                            </Root>
                            <Proxy>
                                <ext:AjaxProxy Url="?action=reader">
                                    <Reader>
                                        <ext:JsonReader />
                                    </Reader>
                                </ext:AjaxProxy>
                            </Proxy>
                            <Listeners>
                            </Listeners>
                        </ext:TreeStore>
                    </Store>
                    <ColumnModel>
                        <Columns>
                            <ext:Column ID="Column1" runat="server" Text="ID" DataIndex="ID" Hidden="true"></ext:Column>
                            <ext:TreeColumn ID="TreeColumn1"
                                runat="server"
                                Text="名称"
                                Width="240"
                                Sortable="true"
                                DataIndex="Name" />
                            <ext:Column ID="Column5" runat="server"
                                DataIndex="SortIndex"
                                Width="80"
                                Hidden="true"
                                Text="排序">
                            </ext:Column>
                            <ext:Column ID="Column2" runat="server" Text="KEY"
                                Width="120"
                                DataIndex="RegisterKey">
                            </ext:Column>
                            <ext:Column ID="Column3"
                                runat="server"
                                Text="VALUE"
                                Width="180"
                                Sortable="true"
                                DataIndex="RegisterValue">
                            </ext:Column>
                            <ext:Column ID="Column4" runat="server"
                                DataIndex="Remark"
                                Width="100"
                                Flex="1"
                                Text="备注">
                            </ext:Column>
                        </Columns>
                    </ColumnModel>
                </ext:TreePanel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
