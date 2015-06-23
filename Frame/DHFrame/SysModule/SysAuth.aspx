<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysAuth.aspx.cs" Inherits="HDFrame.SysModule.SysAuth" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">
        var globalVal = {};
        globalVal.setItemValue = function (tabIndex, itemVal) {
            this.tabIndex = tabIndex;
            this.itemVal = itemVal;
        }
        globalVal.clearItemVal = function () {
            this.tabIndex = "";
            this.itemVal = "";
        }

        //tabChange事件
        function tabChange(tabPanel, newCard, oldCard, e) {
            //
            globalVal.clearItemVal();

            if (newCard.id == "rolePanel") {
                App.rolePanel.add(App.SysModuleTree);
                App.modelStore.getProxy().extraParams.TabIndex = "1";
                App.modelStore.load();
            } else if (newCard.id == "orgPanel") {
                App.orgPanel.add(App.SysModuleTree);
                App.modelStore.getProxy().extraParams.TabIndex = "2";
                App.modelStore.load();
            } else if (newCard.id == "userPanel") {
                App.userPanel.add(App.SysModuleTree);
                App.modelStore.getProxy().extraParams.TabIndex = "3";
                App.modelStore.load();
                if (App.ListStore.getCount()) {

                } else {
                    App.ListStore.reload();
                }
            }
        }

        //组织结构
        function itemClick(record, item, index) {
            globalVal.setItemValue("0", record.data.ID);
            App.modelStore.getProxy().extraParams.TreeNodeID = record.data.ID;
            App.modelStore.getProxy().extraParams.TabIndex = "0";
            App.modelStore.load();
        }
        function orgSave() {
            var nodes = App.SysModuleTree.getChecked();
            //if (nodes.length <= 0) {
            //    Ext.Msg.alert("提示", "请选择模块节点");
            //    return;
            //}
            var nodeArr = [];
            Ext.each(nodes, function (item) {
                nodeArr.push(item.id);
            });
            var refID = globalVal.itemVal;
            if (!refID) {
                Ext.Msg.alert("提示", "请选择左侧组织结构节点");
                return;
            }
            App.direct.SaveSelectNode(Ext.encode(nodeArr), refID, globalVal.tabIndex, {
                success: function (rtn) {
                    if (rtn == "1") {
                        Ext.Msg.alert("提示", "保存成功!");
                        // App.modelStore.load();
                    }
                }
            })
        }
        //角色
        function roleItemClick(record, item, index) {
            globalVal.setItemValue("1", record.data.ID);
            App.modelStore.getProxy().extraParams.TreeNodeID = record.data.ID;
            App.modelStore.getProxy().extraParams.TabIndex = "1";
            App.modelStore.load();
        }
        function roleSave() {
            var nodes = App.SysModuleTree.getChecked();
            //if (nodes.length <= 0) {
            //    Ext.Msg.alert("提示", "请选择模块节点");
            //    return;
            //}
            var nodeArr = [];
            Ext.each(nodes, function (item) {
                nodeArr.push(item.id);
            });
            var refID = globalVal.itemVal;
            if (!refID) {
                Ext.Msg.alert("提示", "请选择左侧节点");
                return;
            }
            App.direct.SaveSelectNode(Ext.encode(nodeArr), refID, globalVal.tabIndex, {
                success: function (rtn) {
                    if (rtn == "1") {
                        Ext.Msg.alert("提示", "保存成功!");
                        //App.modelStore.load();
                    }
                }
            })
        }
        //人员
        function userItemClick(record, item, index) {
            globalVal.setItemValue("2", record.data.ID);
            App.modelStore.getProxy().extraParams.TreeNodeID = record.data.ID;
            App.modelStore.getProxy().extraParams.TabIndex = "2";
            App.modelStore.load();
        }
        function userSave() {
            var nodes = App.SysModuleTree.getChecked();
            //if (nodes.length <= 0) {
            //    Ext.Msg.alert("提示", "请选择模块节点");
            //    return;
            //}
            var nodeArr = [];
            Ext.each(nodes, function (item) {
                nodeArr.push(item.id);
            });
            var refID = globalVal.itemVal;
            if (!refID) {
                Ext.Msg.alert("提示", "请选择左侧人员");
                return;
            }
            App.direct.SaveSelectNode(Ext.encode(nodeArr), refID, globalVal.tabIndex, {
                success: function (rtn) {
                    if (rtn == "1") {
                        Ext.Msg.alert("提示", "保存成功!");
                        //  App.modelStore.load();
                    }
                }
            })
        }
        //递归选中子节点
        function checkNode(node, checked) {
            if (Ext.isArray(node)) {
                for (var i = node.length - 1; i >= 0; i--) {
                    checkNode(node[i], checked);
                }
            } else {
                if (node.data.checked != null) {
                    node.set("checked", checked);
                }
                if (node.childNodes.length > 0) {
                    checkNode(node.childNodes, checked);
                }
            }
        }

        //生成权限控制列表
        function createAuthList() {
            //Ext.Msg.alert("提示", "请选择左侧人员");
            Ext.Msg.confirm("提示", "确认要刷新权限列表吗?", function (btn) {
                if (btn == "yes") {
                    App.direct.CreateAuthList({
                        success: function (rtn) {
                            if (rtn == "1") {
                                Ext.Msg.alert("提示", "操作成功!");
                            }
                        }
                    })
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager runat="server" ValidateRequestMode="Disabled" DisableViewState="true">
        </ext:ResourceManager>
        <ext:Viewport runat="server"
            Layout="BorderLayout">
            <Items>
                <ext:TabPanel runat="server"
                    MarginSpec="1 0 0 0"
                    MinTabWidth="80"
                    BodyStyle="background-color:#fff"
                    Region="Center">
                    <Items>

                        <ext:Panel
                            runat="server"
                            Title="组织结构"
                            ID="orgPanel"
                            BodyStyle="background-color:#fff"
                            Layout="BorderLayout">
                            <TopBar>
                                <ext:Toolbar runat="server">
                                    <Items>
                                        <ext:Button ID="Button6" runat="server" Text="<font color='red'>刷新权限列表</font>" Icon="ApplicationOsxLink">
                                            <Listeners>
                                                <Click Handler="createAuthList();"></Click>
                                            </Listeners>
                                        </ext:Button>
                                        <ext:ToolbarSeparator></ext:ToolbarSeparator>
                                        <ext:Button ID="Button3" runat="server" Text="收起应用/模块" Icon="ApplicationGet">
                                            <Listeners>
                                                <Click Handler="Ext.getCmp('SysModuleTree').collapseAll();"></Click>
                                            </Listeners>
                                        </ext:Button>
                                        <ext:ToolbarSeparator></ext:ToolbarSeparator>
                                        <ext:Button ID="Button9" runat="server" Text="保存" Icon="Disk">
                                            <Listeners>
                                                <Click Handler="orgSave();"></Click>
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Items>
                                <%-- 组织结构 --%>
                                <ext:TreePanel
                                    ID="treePanel"
                                    runat="server"
                                    Region="West"
                                    Width="400"
                                    RootVisible="false"
                                    AutoScroll="false">
                                    <Store>
                                        <ext:TreeStore ID="TreeStore1" runat="server">
                                            <Proxy>
                                                <ext:AjaxProxy Url="?action=reader">
                                                    <Reader>
                                                        <ext:JsonReader />
                                                    </Reader>
                                                </ext:AjaxProxy>
                                            </Proxy>
                                            <Root>
                                                <ext:Node NodeID="root" Text="远道软件有限公司" Expanded="true">
                                                    <CustomAttributes>
                                                        <ext:ConfigItem Name="ID" Value="root" Mode="Value" />
                                                        <ext:ConfigItem Name="Name" Value="远道软件有限公司" />
                                                    </CustomAttributes>
                                                </ext:Node>
                                            </Root>
                                            <Fields>
                                                <ext:ModelField Name="ID" Type="Auto" />
                                                <ext:ModelField Name="Code" />
                                                <ext:ModelField Name="Name" />
                                                <ext:ModelField Name="ParentID" Type="Auto" />
                                                <ext:ModelField Name="OrgType" Type="Auto" />
                                                <ext:ModelField Name="State" Type="Auto" />
                                                <ext:ModelField Name="CreateTime" Type="Date" />
                                            </Fields>
                                            <Listeners>
                                            </Listeners>
                                        </ext:TreeStore>
                                    </Store>
                                    <ColumnModel
                                        Sortable="false">
                                        <Columns>
                                            <ext:TreeColumn ID="TreeColumn1"
                                                runat="server"
                                                Flex="1"
                                                Filterable="false"
                                                MenuDisabled="true"
                                                Text="组织结构"
                                                Sortable="true"
                                                DataIndex="Name" />
                                            <ext:Column ID="Column2" runat="server" Text="编号"
                                                Width="120"
                                                DataIndex="Code">
                                            </ext:Column>
                                            <ext:Column ID="Column7" runat="server" Text="ID" Width="80" Hidden="true" DataIndex="ID">
                                            </ext:Column>
                                        </Columns>
                                    </ColumnModel>
                                    <Listeners>
                                        <ItemDblClick Handler="itemClick(record,item,index)" Delay="200"></ItemDblClick>
                                        <ItemExpand Handler="" Buffer="30" />
                                        <ItemCollapse Handler="" Buffer="30" />
                                    </Listeners>
                                    <SelectionModel>
                                        <ext:TreeSelectionModel ID="TreeSelectionModel1" Mode="Single" runat="server" SelectedIndex="0"></ext:TreeSelectionModel>
                                    </SelectionModel>
                                </ext:TreePanel>

                                <%-- 系统模块 --%>
                                <ext:TreePanel
                                    ID="SysModuleTree"
                                    Region="Center"
                                    runat="server"
                                    RootVisible="false"
                                    MarginSpec="0 0 0 1"
                                    BodyStyle="border-left :solid 1px #c1c1c1 !important; ">
                                    <Store>
                                        <ext:TreeStore ID="modelStore" runat="server">
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
                                                <ext:AjaxProxy Url="?action=readOrg">
                                                    <Reader>
                                                        <ext:JsonReader />
                                                    </Reader>
                                                </ext:AjaxProxy>
                                            </Proxy>
                                            <Listeners>
                                                <Load Handler="Ext.getCmp('SysModuleTree').expandAll();"></Load>
                                            </Listeners>
                                        </ext:TreeStore>
                                    </Store>
                                    <ColumnModel>
                                        <Columns>
                                            <ext:TreeColumn ID="TreeColumn2"
                                                runat="server"
                                                Text="应用/模块"
                                                Width="240"
                                                Sortable="true"
                                                DataIndex="Name" />
                                            <ext:Column ID="Column1" runat="server"
                                                Hidden="true" DataIndex="ID">
                                            </ext:Column>
                                            <ext:Column ID="Column3" runat="server" Text="编号"
                                                Width="120"
                                                DataIndex="Code">
                                            </ext:Column>
                                            <ext:Column ID="Column4"
                                                runat="server"
                                                Text="类型"
                                                Width="100"
                                                Sortable="true"
                                                DataIndex="Type">
                                                <Renderer Handler="return value=='0'?'应用':(value=='1'?'入口':'页面');"></Renderer>
                                            </ext:Column>
                                        </Columns>
                                    </ColumnModel>
                                    <Listeners>
                                        <CheckChange Delay="50" Fn="checkNode"></CheckChange>
                                    </Listeners>
                                </ext:TreePanel>
                            </Items>
                        </ext:Panel>

                        <%-- 角色与组 --%>
                        <ext:Panel
                            ID="rolePanel"
                            runat="server"
                            Title="角色与组"
                            BodyStyle="background-color:#fff"
                            Layout="BorderLayout">
                            <TopBar>
                                <ext:Toolbar ID="Toolbar1" runat="server">
                                    <Items>
                                        <ext:Button ID="Button7" runat="server" Text="<font color='red'>刷新权限列表</font>" Icon="ApplicationOsxLink">
                                            <Listeners>
                                                <Click Handler="createAuthList();"></Click>
                                            </Listeners>
                                        </ext:Button>
                                        <ext:ToolbarSeparator></ext:ToolbarSeparator>
                                        <ext:Button ID="Button4" runat="server" Text="收起应用/模块" Icon="ApplicationGet">
                                            <Listeners>
                                                <Click Handler="Ext.getCmp('SysModuleTree').collapseAll();"></Click>
                                            </Listeners>
                                        </ext:Button>
                                        <ext:ToolbarSeparator></ext:ToolbarSeparator>
                                        <ext:Button ID="Button1" runat="server" Text="保存" Icon="Disk">
                                            <Listeners>
                                                <Click Handler="roleSave();"></Click>
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Items>
                                <ext:TreePanel
                                    ID="treePanel1"
                                    runat="server"
                                    Region="West"
                                    Width="400"
                                    RootVisible="false"
                                    AutoScroll="true">
                                    <Store>
                                        <ext:TreeStore ID="TreeStore3" runat="server">
                                            <Proxy>
                                                <ext:AjaxProxy Url="?action=readrole">
                                                    <Reader>
                                                        <ext:JsonReader />
                                                    </Reader>
                                                </ext:AjaxProxy>
                                            </Proxy>
                                            <Root>
                                                <ext:Node NodeID="root" Text="根角色" Expanded="true">
                                                    <CustomAttributes>
                                                        <ext:ConfigItem Name="ID" Value="root" Mode="Value" />
                                                        <ext:ConfigItem Name="Name" Value="根角色" />
                                                    </CustomAttributes>
                                                </ext:Node>
                                            </Root>
                                            <Fields>
                                                <ext:ModelField Name="ID" Type="Auto" />
                                                <ext:ModelField Name="GroupCode" />
                                                <ext:ModelField Name="Name" />
                                                <ext:ModelField Name="ParentID" Type="Auto" />
                                                <ext:ModelField Name="Remark" Type="Auto" />
                                                <ext:ModelField Name="Type" Type="Auto" />
                                                <ext:ModelField Name="State" Type="Auto" />
                                                <ext:ModelField Name="CreateTime" Type="Date" />
                                            </Fields>
                                        </ext:TreeStore>
                                    </Store>
                                    <ColumnModel
                                        Sortable="false">
                                        <Columns>
                                            <ext:TreeColumn ID="TreeColumn3"
                                                runat="server"
                                                Flex="1"
                                                Filterable="false"
                                                MenuDisabled="true"
                                                Text="角色/组名称"
                                                Sortable="true"
                                                DataIndex="text" />
                                            <ext:Column ID="Column5" runat="server" Text="编号"
                                                Width="80"
                                                DataIndex="GroupCode">
                                            </ext:Column>
                                            <ext:Column ID="Column8" runat="server" Text="ID" Width="80" Hidden="true" DataIndex="ID">
                                            </ext:Column>
                                        </Columns>
                                    </ColumnModel>
                                    <Listeners>
                                        <ItemDblClick Handler="roleItemClick(record,item,index)" Delay="200"></ItemDblClick>
                                        <ItemExpand Handler="" Buffer="30" />
                                        <ItemCollapse Handler="" Buffer="30" />
                                    </Listeners>
                                </ext:TreePanel>
                            </Items>
                        </ext:Panel>

                        <%-- 人员 --%>
                        <ext:Panel
                            ID="userPanel"
                            runat="server"
                            Title="人员"
                            BodyStyle="background-color:#fff"
                            Layout="BorderLayout">
                            <TopBar>
                                <ext:Toolbar ID="Toolbar2" runat="server">
                                    <Items>
                                        <ext:TextField runat="server" LabelWidth="50" Width="180" LabelAlign="Right" FieldLabel="工号" Name="schWorkNo">
                                            <Listeners>
                                                <SpecialKey Handler=" if (e.getKey() == Ext.EventObject.ENTER) {
                                                                      #{ListStore}.reload();   }">
                                                </SpecialKey>
                                            </Listeners>
                                        </ext:TextField>
                                        <ext:TextField ID="TextField1" LabelWidth="50" Width="180" runat="server" LabelAlign="Right" FieldLabel="姓名" Name="schName">
                                            <Listeners>
                                                <SpecialKey Handler=" if (e.getKey() == Ext.EventObject.ENTER) {
                                                                      #{ListStore}.reload();   }">
                                                </SpecialKey>
                                            </Listeners>
                                        </ext:TextField>
                                        <ext:Button runat="server" Icon="Zoom" Text="查询">
                                            <Listeners>
                                                <Click Handler=" #{ListStore}.reload();"></Click>
                                            </Listeners>
                                        </ext:Button>
                                        <ext:ToolbarSeparator></ext:ToolbarSeparator>
                                        <ext:Button ID="Button8" runat="server" Text="<font color='red'>刷新权限列表</font>" Icon="ApplicationOsxLink">
                                            <Listeners>
                                                <Click Handler="createAuthList();"></Click>
                                            </Listeners>
                                        </ext:Button>
                                        <ext:ToolbarSeparator></ext:ToolbarSeparator>
                                        <ext:Button ID="Button5" runat="server" Text="收起应用/模块" Icon="ApplicationGet">
                                            <Listeners>
                                                <Click Handler="Ext.getCmp('SysModuleTree').collapseAll();"></Click>
                                            </Listeners>
                                        </ext:Button>
                                        <ext:ToolbarSeparator></ext:ToolbarSeparator>
                                        <ext:Button ID="Button2" runat="server" Text="保存" Icon="Disk">
                                            <Listeners>
                                                <Click Handler="userSave();"></Click>
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Items>
                                <ext:GridPanel
                                    ID="DataGridPanel"
                                    runat="server"
                                    Border="false"
                                    Region="West"
                                    Width="500"
                                    EmptyText="<center>暂无信息</center>">
                                    <Store>
                                        <ext:Store
                                            ID="ListStore"
                                            runat="server"
                                            PageSize="30"
                                            AutoLoad="false"
                                            RemotePaging="true"
                                            OnReadData="ListStore_RefershData">
                                            <Proxy>
                                                <ext:PageProxy></ext:PageProxy>
                                            </Proxy>
                                            <Model>
                                                <ext:Model ID="ListModel" runat="server" IDProperty="ID">
                                                    <Fields>
                                                        <ext:ModelField Name="ID" Type="Auto" />
                                                        <ext:ModelField Name="WorkNo" Type="Auto" />
                                                        <ext:ModelField Name="Name" Type="Auto" />
                                                        <ext:ModelField Name="EnglishName" Type="Auto" />
                                                        <ext:ModelField Name="LoginName" Type="Auto" />
                                                        <ext:ModelField Name="State" Type="Auto" />
                                                        <ext:ModelField Name="Email" Type="Auto" />
                                                        <ext:ModelField Name="Phone" Type="Auto" />
                                                        <ext:ModelField Name="TelNo" Type="Auto" />
                                                        <ext:ModelField Name="QQ" Type="Auto" />
                                                        <ext:ModelField Name="WeChat" Type="Auto" />
                                                        <ext:ModelField Name="WorkInDate" Type="Auto" />
                                                        <ext:ModelField Name="WorkOutDate" Type="Auto" />
                                                    </Fields>
                                                </ext:Model>
                                            </Model>
                                        </ext:Store>
                                    </Store>
                                    <View>
                                        <ext:GridView LoadingText="加载中"></ext:GridView>
                                    </View>
                                    <ColumnModel ID="ColumnModel1" runat="server">
                                        <Columns>
                                            <ext:Column ID="Col_ID" runat="server" DataIndex="ID" Text="编号" Align="Center" Width="5px" Hidden="true"></ext:Column>
                                            <ext:Column runat="server" ID="Cln_No" Text="工号" DataIndex="WorkNo" Align="Left" Width="120px">
                                            </ext:Column>
                                            <ext:Column runat="server" ID="Col_Title" Text="姓名" DataIndex="Name" Align="left" Width="120px" Flex="1">
                                            </ext:Column>
                                            <ext:Column runat="server" ID="Col_StoreName" Text="英文名" DataIndex="EnglishName" Align="left" Flex="1">
                                            </ext:Column>
                                        </Columns>
                                    </ColumnModel>
                                    <SelectionModel>
                                        <ext:CheckboxSelectionModel runat="server" AllowDeselect="false"
                                            ID="rowSelect1"
                                            ShowHeaderCheckbox="false"
                                            Mode="Single">
                                        </ext:CheckboxSelectionModel>
                                    </SelectionModel>
                                    <BottomBar>
                                        <ext:PagingToolbar
                                            ID="PageToolBar"
                                            StoreID="ListStore"
                                            runat="server"
                                            DisplayInfo="true"
                                            DisplayMsg="显示记录 {0} - {1} 共 {2}"
                                            EmptyMsg="无数据">
                                        </ext:PagingToolbar>
                                    </BottomBar>
                                    <Listeners>
                                        <ItemDblClick Handler="userItemClick(record, item, index)"></ItemDblClick>
                                    </Listeners>
                                </ext:GridPanel>
                            </Items>
                        </ext:Panel>
                    </Items>
                    <Listeners>
                        <TabChange Fn="tabChange"></TabChange>
                    </Listeners>
                </ext:TabPanel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
