<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sysmodule.aspx.cs" Inherits="HDFrame.SysModule.Sysmodule" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .red-text {
            color: red;
        }
    </style>
    <script type="text/javascript">

        var pageGlobal = {
            nodeID: ""
        }
        //添加子模块
        function addChild(treepanel) {

            var recd = App.SysModuleTree.getSelectionModel().getLastSelected();

            if (recd != null) {
                Ext.getCmp("txtParentID").setValue(recd.get("ID") || "");
                App.lblCurrNode.setText("当前父节点：" + recd.get("Name") || "");
            } else {
                App.lblCurrNode.setText("当前父节点：Null");
                App.cboType.select("应用");
            }
            if (recd != null && recd.get("Type") == "2") {
                Ext.Msg.alert("提示", "页面下不可再添加子节点");
                return;
            }

            //绑定排序号
            Ext.Ajax.request({
                url: '?action=getmaxnum',
                success: function (response) {
                    var text = response.responseText;
                    App.txtSortIndex.setValue(text);
                    App.txtPath.setValue(recd.getPath());
                    App.addSubModelWin.show();
                }
            });
        }
        //保存数据
        function saveData() {
            if (!App.NodeForm.getForm().isValid()) {
                return;
            }
            //检查Code 是否重复
            App.direct.CheckCode(App.txtNum.getValue(), {
                success: function () {
                    pageGlobal.nodeID = "";
                    var record = App.NodeForm.getForm().getValues();

                    var typeHash = {
                        "应用": 0,
                        "入口": 1,
                        "页面": 2
                    }
                    record.Type = typeHash[record.Type] == null ? record.Type : typeHash[record.Type];

                    App.direct.SaveData(Ext.encode(record), {
                        success: function (result) {
                            Ext.Msg.alert('提示', '修改成功');
                            App.NodeForm.getForm().reset();
                            App.addSubModelWin.close();
                            App.TreeStore1.reload();
                            pageGlobal.nodeID = result;
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
            App.lblCurrNode.setText("当前父节点：" + record.get("Name") || "");
            App.NodeForm.getForm().loadRecord(record);
            App.cboType.select(record.get("Type") == "0" ? "应用" : (record.get("Type") == "1" ? "入口" : "页面"));
            App.addSubModelWin.show();
        }
        //删除数据
        function deleteRecord() {
            if (!App.SysModuleTree.getSelectionModel().getLastSelected()) {
                Ext.Msg.alert("提示", "请选择要删除的记录");
                return;
            }

            var record = App.SysModuleTree.getSelectionModel().getLastSelected();
            if (record.get("Name") == "模块管理" || record.get("ModuleMgr")) {
                Ext.Msg.alert("提示", "模块管理不可删除");
                return;
            }
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

        //展开指定节点ID
        function expandNode() {
            if (pageGlobal.nodeID) {
                var node = App.TreeStore1.getNodeById(pageGlobal.nodeID);
                var path = node.getPath();
                App.SysModuleTree.expandPath(path);
                pageGlobal.nodeID = "";
            }
        }
        //combo选择控制
        function comboSelect(combox, record) {
            if (App.txtParentID.getValue() && record[0].data.field1 == "0") {
                combox.setValue("");
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager runat="server" ID="ResourceM1">
            <Listeners></Listeners>
        </ext:ResourceManager>
        <ext:Viewport runat="server">
            <Items>
                <ext:Window runat="server"
                    Title="添加子模块"
                    Width="520"
                    Hidden="true"
                    Height="360"
                    Draggable="false"
                    Resizable="false"
                    ID="addSubModelWin">
                    <Items>
                        <ext:FormPanel ID="NodeForm" runat="server">
                            <Items>
                                <ext:Label
                                    ID="lblCurrNode"
                                    MarginSpec="10 10 20 10"
                                    Text="当前节点："
                                    runat="server">
                                </ext:Label>
                                <ext:TextField ID="TextField6" runat="server" Name="ID" Hidden="true"></ext:TextField>
                                <ext:TextField ID="txtPath" runat="server" Name="Path" Hidden="true"></ext:TextField>
                                <ext:TextField ID="txtParentID" runat="server" Hidden="true" Name="ParentID"></ext:TextField>
                                <ext:TextField ID="TextField7" runat="server" Hidden="true" Name="IsLeaf">
                                </ext:TextField>
                                <ext:TextField runat="server" Name="Path" Hidden="true"></ext:TextField>
                                <ext:FieldSet ID="FieldSet1"
                                    Title="基本属性"
                                    MarginSpec="0 5"
                                    Layout="FormLayout"
                                    runat="server">
                                    <Items>
                                        <ext:Panel
                                            ID="pnlTableLayout"
                                            runat="server"
                                            Region="Center"
                                            Border="false"
                                            Layout="TableLayout">
                                            <LayoutConfig>
                                                <ext:TableLayoutConfig Columns="2" />
                                            </LayoutConfig>
                                            <Items>
                                                <ext:TextField ID="TextField1"
                                                    runat="server"
                                                    LabelWidth="80"
                                                    Name="Name"
                                                    Width="215"
                                                    IndicatorCls="red-text"
                                                    IndicatorText="*"
                                                    AllowBlank="false"
                                                    LabelAlign="Right"
                                                    FieldLabel="模块名">
                                                </ext:TextField>
                                                <ext:TextField
                                                    ID="txtNum"
                                                    LabelWidth="80"
                                                    Name="Code"
                                                    Width="215"
                                                    AllowBlank="false"
                                                    LabelAlign="Right"
                                                    IndicatorCls="red-text"
                                                    IndicatorText="*"
                                                    runat="server"
                                                    FieldLabel="编号">
                                                </ext:TextField>
                                                <ext:ComboBox runat="server"
                                                    LabelWidth="80"
                                                    ID="cboType"
                                                    LabelAlign="Right"
                                                    Editable="false"
                                                    AllowBlank="false"
                                                    Name="Type"
                                                    FieldLabel="模块类型"
                                                    Width="210">
                                                    <Items>
                                                        <ext:ListItem Text="应用" Value="0"></ext:ListItem>
                                                        <ext:ListItem Text="页面" Value="2"></ext:ListItem>
                                                        <ext:ListItem Text="入口" Value="1"></ext:ListItem>
                                                    </Items>
                                                    <SelectedItems>
                                                        <ext:ListItem Text="入口"></ext:ListItem>
                                                    </SelectedItems>
                                                    <Listeners>
                                                        <Select Handler="comboSelect(#{cboType},records)">
                                                        </Select>
                                                    </Listeners>
                                                </ext:ComboBox>
                                                <ext:TextField
                                                    ID="txtSortIndex"
                                                    LabelWidth="80"
                                                    Width="210"
                                                    Name="SortIndex"
                                                    LabelAlign="Right"
                                                    MaskRe="/\d+/"
                                                    runat="server"
                                                    FieldLabel="排序号">
                                                </ext:TextField>
                                                <ext:TextField
                                                    ID="TextField3"
                                                    runat="server"
                                                    Name="Url"
                                                    LabelAlign="Right"
                                                    Width="424"
                                                    LabelWidth="80"
                                                    Flex="1" ColSpan="2"
                                                    FieldLabel="URL">
                                                </ext:TextField>
                                                <ext:TextField
                                                    ID="TextField5"
                                                    runat="server"
                                                    LabelAlign="Right"
                                                    Name="Icon"
                                                    Width="424"
                                                    LabelWidth="80"
                                                    Flex="1"
                                                    ColSpan="2"
                                                    FieldLabel="图标">
                                                </ext:TextField>
                                                <ext:TextField runat="server"
                                                    LabelAlign="Right"
                                                    Width="424"
                                                    LabelWidth="80"
                                                    Flex="1"
                                                    Name="Description"
                                                    ColSpan="2"
                                                    FieldLabel="描述">
                                                </ext:TextField>
                                            </Items>
                                        </ext:Panel>
                                    </Items>
                                </ext:FieldSet>
                                <ext:FieldSet ID="FieldSet2"
                                    Title="配置属性"
                                    MarginSpec="0 5"
                                    Layout="FormLayout"
                                    Height="80"
                                    runat="server">
                                    <Items>
                                        <ext:Panel
                                            ID="Panel1"
                                            runat="server"
                                            Region="Center"
                                            Border="false"
                                            Height="50"
                                            Layout="AbsoluteLayout">
                                            <Items>
                                                <ext:Checkbox ID="Checkbox1"
                                                    runat="server"
                                                    Width="90"
                                                    Checked="true"
                                                    LabelWidth="70"
                                                    X="0"
                                                    Y="10"
                                                    InputValue="1"
                                                    Name="Status"
                                                    LabelAlign="Right"
                                                    FieldLabel="启用">
                                                </ext:Checkbox>
                                                <ext:Checkbox
                                                    runat="server"
                                                    Width="90"
                                                    LabelWidth="70"
                                                    X="140"
                                                    Y="10"
                                                    Name="IsQuickSearch"
                                                    LabelAlign="Right"
                                                    FieldLabel="快速搜索">
                                                </ext:Checkbox>
                                                <ext:Checkbox
                                                    Width="90"
                                                    LabelWidth="70"
                                                    runat="server"
                                                    X="270"
                                                    Y="10"
                                                    Name="IsRecyclable"
                                                    LabelAlign="Right"
                                                    FieldLabel="可回收">
                                                </ext:Checkbox>
                                            </Items>
                                        </ext:Panel>
                                    </Items>
                                </ext:FieldSet>
                            </Items>
                        </ext:FormPanel>
                    </Items>
                    <DockedItems>
                        <ext:Toolbar Height="38px" Dock="Bottom" Border="true" runat="server" Layout="BorderLayout">
                            <Items>
                                <ext:Button ID="Button2" Region="East" Icon="Disk" runat="server" Text="保存" Width="60px" Height="27" X="250" Y="0">
                                    <Listeners>
                                        <Click Fn="saveData">
                                        </Click>
                                    </Listeners>
                                </ext:Button>
                                <ext:Button ID="Button3" Region="East" Icon="PageDelete" Text="清空" runat="server" Width="60px" Height="27" X="320" Y="0">
                                    <Listeners>
                                        <Click Handler="App.NodeForm.getForm().reset();"></Click>
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

                <ext:Panel runat="server" Region="North" Heigh="90px">
                    <Items>
                        <ext:Toolbar runat="server">
                            <Items>
                                <ext:Button runat="server" Text="添加子模块" Icon="ApplicationAdd">
                                    <Listeners>
                                        <Click Handler="addChild()"></Click>
                                    </Listeners>
                                </ext:Button>
                                <ext:Button ID="Button1" runat="server" Icon="ApplicationEdit" Text="修改">
                                    <Listeners>
                                        <Click Handler="editRecord()"></Click>
                                    </Listeners>
                                </ext:Button>
                                <ext:Button runat="server" Text="删除" Icon="Delete">
                                    <Listeners>
                                        <Click Handler="deleteRecord()"></Click>
                                    </Listeners>
                                </ext:Button>
                                <ext:Button runat="server" Text="刷新模块" Icon="TableRefresh">
                                    <Listeners>
                                        <Click Handler="window.parent.location.reload();"></Click>
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </Items>
                </ext:Panel>

                <%-- treePanel --%>
                <ext:TreePanel ID="SysModuleTree"
                    Region="Center"
                    runat="server"
                    UseArrows="true"
                    RootVisible="false"
                    MinHeight="500"
                    SingleExpand="true"
                    FolderSort="true">
                    <Store>
                        <ext:TreeStore ID="TreeStore1" runat="server">
                            <Model>
                                <ext:Model ID="Model1" runat="server" IDProperty="ID">
                                    <Fields>
                                        <ext:ModelField Name="ID" Type="Auto" />
                                        <ext:ModelField Name="ParentID" Type="Auto" />
                                        <ext:ModelField Name="Code" Type="Auto" />
                                        <ext:ModelField Name="Name" Type="Auto" />
                                        <ext:ModelField Name="Type" Type="Auto" />
                                        <ext:ModelField Name="Url" Type="Auto" />
                                        <ext:ModelField Name="Description" Type="Auto" />
                                        <ext:ModelField Name="Status" Type="Auto" />
                                        <ext:ModelField Name="LastModifiedDate" Type="Date" />
                                        <ext:ModelField Name="CreateDate" Type="Date" />
                                        <ext:ModelField Name="SortIndex" Type="Auto" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                            <Root>
                                <ext:Node NodeID="root" Text="模块管理" Leaf="false" Expanded="true">
                                    <CustomAttributes>
                                        <ext:ConfigItem Name="ID" Value="root" Mode="Value" />
                                        <ext:ConfigItem Name="Name" Value="模块管理" />
                                    </CustomAttributes>
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
                                <Load Handler="expandNode()"></Load>
                            </Listeners>
                        </ext:TreeStore>
                    </Store>
                    <ColumnModel>
                        <Columns>
                            <ext:TreeColumn ID="TreeColumn1"
                                runat="server"
                                Text="应用/模块"
                                Width="240"
                                Sortable="true"
                                DataIndex="Name" />
                            <ext:Column runat="server"
                                Hidden="true" DataIndex="ID">
                            </ext:Column>
                            <ext:Column runat="server" Text="编号"
                                Width="120"
                                DataIndex="Code">
                            </ext:Column>
                            <ext:Column ID="Column1"
                                runat="server"
                                Text="类型"
                                Width="100"
                                Sortable="true"
                                DataIndex="Type">
                                <Renderer Handler="return value=='0'?'应用':(value=='1'?'入口':'页面');"></Renderer>
                            </ext:Column>
                            <ext:Column ID="Column3" runat="server"
                                DataIndex="Status"
                                Width="100"
                                Text="状态">
                                <Renderer Handler="return value=='1'?'启用':'<font color=red>停用</font>';"></Renderer>
                            </ext:Column>
                            <ext:Column ID="Column2" runat="server"
                                DataIndex="SortIndex"
                                Width="80"
                                Text="排序">
                            </ext:Column>
                            <ext:Column runat="server"
                                Flex="1"
                                DataIndex="Url"
                                Text="URL">
                            </ext:Column>
                            <ext:Column ID="Column4" runat="server"
                                Flex="1"
                                DataIndex="Description"
                                Text="描述">
                            </ext:Column>
                        </Columns>
                    </ColumnModel>
                </ext:TreePanel>
            </Items>
        </ext:Viewport>

    </form>
</body>
</html>
