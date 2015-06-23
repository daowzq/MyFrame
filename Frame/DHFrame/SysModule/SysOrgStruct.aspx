<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysOrgStruct.aspx.cs" Inherits="HDFrame.SysModule.SysOrgStruct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .bodyDiv {
            background-color: #e7eaec;
        }

        .west-panel {
            border-Color: #a1a3a5;
            border-Width: 1px;
            border-Style: solid;
            border-Left-Width: 2px;
            border-Top-Width: 0px;
            border-top: none;
            border-Left-Color: rgb(173,210,237);
            border-right: none;
        }

        .center-panel {
            border-Color: #a1a3a5;
            border-Width: 1px;
            border-Style: solid;
            border-Left-Width: 0px;
            border-Top-Width: 0px;
            border-Left-Color: #eed485;
        }

        .tool-bar {
            margin-top: 1px;
            background-color: #fff;
            border-Color: #a1a3a5;
            border-Width: 1px;
            border-Style: solid;
            border-Left-Width: 0px;
            border-top-width: 0px;
            border-bottom-width: 1px;
            border-Left-Color: #eed485;
        }
            /*trigger clear icon*/
            .tool-bar .x-form-arrow-trigger-default {
                background-image: url("/ExtJs/resources/ext-theme-neptune/images/form/clear-trigger.png");
            }

        .red-text {
            color: red;
        }

        .grid-style {
            border-Color: #a1a3a5;
            border-Width: 0px;
            border-Style: solid;
            border-Top-Width: 0px;
            border-left-width: 0px;
        }
    </style>
    <script type="text/javascript">
        var pageGlobal = {
            nodeID: "",
            nodeExpand: false
        }
        Ext.onReady(function () {
            var value = document.getElementById("__PAGESTATE").value
            // var parentWin = Ext.decode(value)[0].Value.replace("Ext", "parent.Ext");
            // var moduleArr = Ext.decode(parentWin);
        })
        //加载后
        function afterInit() {
            App.treeTbar.add({
                id: "TriggerField1",
                fieldLabel: " ",
                labelSeparator: "",
                labelWidth: 0,
                labelAlign: "right",
                width: 180,
                value: '输入组织结构',
                xtype: "triggerfield",
                enableKeyEvents: true,
                listeners: {
                    specialkey: {
                    },
                    keyup: {
                        fn: function (tf, e) {
                            var tree = App.treePanel, text = tf.getRawValue();
                            tree.clearFilter();
                            if (Ext.isEmpty(text, false)) {
                                return;
                            }
                            if (e.getKey() === Ext.EventObject.ESC) {
                                this.setValue("");
                                tree.clearFilter(true);
                                // tree.getView().focus();

                            } else {
                                var re = new RegExp(".*" + text + ".*", "i");
                                tree.filterBy(function (node) {

                                    return re.test(node.data.text);
                                });
                            }
                        },
                        buffer: 200
                    },
                    focus: {
                        fn: function () {
                            //alert();
                            this.setValue("");
                        },
                        buffer: 200
                    },
                    blur: {
                        fn: function () {
                            if (!this.getValue()) {
                                this.setValue("输入组织结构");
                            }
                        }
                    },
                    triggerclick: {
                        fn: function () {
                            this.setValue("")
                            var tree = App.treePanel;
                            tree.clearFilter(true);
                            //tree.getView().focus();
                        },
                        buffer: 200
                    }
                }
            });
            App.treePanel.on("itemcontextmenu", function (view, record, item, index, e, eOpts) {
                e.preventDefault();
                e.stopEvent();
                App.treePanel.getSelectionModel().select(record);
                App.treeNodeMenu.showAt(e.getXY());
            })
        }


        //添加节点
        function AddNode() {

            var recd = App.treePanel.getSelectionModel().getLastSelected();
            //绑定排序号
            Ext.Ajax.request({
                url: '?action=getmaxnum',
                success: function (response) {
                    App.nodeFormPanel.getForm().reset();
                    var text = response.responseText;
                    App.txtSortIndex.setValue(text);
                    if (recd != null) {
                        App.txtParentID.setValue(recd.get("ID") || "");
                        App.txtPath.setValue(recd.getPath());
                    }
                    App.txtCreateTime.setValue(Ext.Date.format(new Date(), 'Y-m-d'));
                    App.treeNodeWin.setTitle("添加节点");
                    App.treeNodeWin.show();
                }
            });
        }

        //保存数据
        function saveData() {
            if (!App.nodeFormPanel.getForm().isValid()) {
                return;
            }
            //检查Code 是否重复
            App.direct.CheckCode(App.txtCode.getValue(), {
                success: function () {
                    pageGlobal.nodeID = "";
                    var record = App.nodeFormPanel.getForm().getValues();
                    App.direct.SaveData(Ext.encode(record), {
                        success: function (result) {
                            Ext.Msg.alert('提示', '保存成功');
                            App.nodeFormPanel.getForm().reset();
                            App.treeNodeWin.close();
                            App.TreeStore1.reload();
                            pageGlobal.nodeID = result;
                        }
                    })
                }
            });
        }

        //删除数据
        function deleteRecord() {
            if (!App.treePanel.getSelectionModel().getLastSelected()) {
                Ext.Msg.alert("提示", "请选择要删除的记录");
                return;
            }
            var record = App.treePanel.getSelectionModel().getLastSelected();
            if (record.get("ID") == "root") {
                Ext.Msg.alert("提示", "根节点不可删除");
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
                                            Ext.Msg.alert("提示", "删除成功");
                                            var nodeArr = record.getPath().split("/");
                                            if (Ext.isArray(nodeArr)) {
                                                pageGlobal.nodeID = nodeArr[nodeArr.length - 2];
                                            } else {
                                                pageGlobal.nodeID = "";
                                            }
                                            App.TreeStore1.reload();
                                        }
                                    }
                                });
                            }
                        })
                    } else {
                        Ext.Msg.alert("提示", "该节点下有子节点,不可删除");
                    }
                }
            })
        }
        //编辑
        function editRecord() {
            if (!App.treePanel.getSelectionModel().getLastSelected()) {
                Ext.Msg.alert("提示", "请选择要修改的记录");
                return;
            }
            App.treeNodeWin.setTitle("编辑节点");
            App.nodeFormPanel.getForm().reset();
            var record = App.treePanel.getSelectionModel().getLastSelected();
            App.nodeFormPanel.getForm().loadRecord(record);
            App.treeNodeWin.show();
        }

        //展开指定节点ID
        function expandNode(store, node, records, successful, eOpts) {
            var sltModel = App.treePanel.getSelectionModel();
            if (pageGlobal.nodeID) {
                var node = store.getNodeById(pageGlobal.nodeID);
                var path = node.getPath();
                App.treePanel.expandPath(path);
                // sltModel.select(node);
                pageGlobal.nodeID = "";
            }
            //else {
            //默认选中第一个节点
            //var node = store.getAt(0);
            // sltModel.select(node);
            // }
        }

        function treeRender(value, metaData, record) {
            if (record.get("ID") == "root") return "";
            return value == "1" ? "启用" : "停用";
        }

        //treepanel click
        function itemClick(record, item, index) {
            if (record.data.ParentID === "root") {
                App.UserStore.getProxy().extraParams.PID = "root";
                App.UserStore.load();
            } else {
                var txt = App.lblPath.getText();
                var arr = record.getPath().split('/');
                if (Ext.isArray(arr)) {

                    var store = App.TreeStore1;
                    var strBuilder = "";
                    Ext.each(arr, function (item) {
                        if (item && item != "root") {
                            var data = store.getById(item).data;
                            strBuilder += "/" + data.text;
                        }
                    })
                    App.lblPath.setText("当前节点:" + strBuilder.replace("/", ""));
                    App.txtTreeNodeID.setValue(record.data.ID);
                    App.UserStore.getProxy().extraParams.PID = record.data.ID;
                    App.UserStore.load();
                }
            }
        }

        //关联人员
        function refUserList() {
            var windSelSup = parent.Ext.create("SelectWin", {
                id: 'selectWin',
                width: 700,
                height: 480,
                modal: true,
                hideBbar: false,
                autoScroll: false,
                iframeScroll: false,
                gridOrTreeId: "UserSltGrid", //这里指定要关联的Grid
                srcF: "../select/UserSlt.aspx",
                title: "关联人员"
            });
            windSelSup.on("winclosed", function (recs) {
                var arr = [];
                Ext.each(recs, function (item) {
                    arr.push(item.data);
                });
                var nodeID = App.txtTreeNodeID.getValue();
                App.direct.RefUserToOrg(Ext.encode(arr), nodeID, {
                    success: function (rtn) {
                        if (rtn == "1") {
                            Ext.Msg.alert("提示", "添加成功");
                            App.UserStore.reload();
                        }
                        windSelSup.close();
                    }
                })
            });
            windSelSup.show();
        }

        //将人员关联到根节点
        function bindRootNode() {
            Ext.getBody().mask("操作中请稍后...");
            App.direct.BindRootNode({
                success: function (rtn) {
                    Ext.getBody().unmask();
                    if (rtn == "1") {
                        Ext.Msg.alert("提示", "操作成功");
                    }
                }
            })
        }

        //移除人员
        function removeUser() {
            var records = App.UserGrid.getSelectionModel().getSelection();
            if (records.length <= 0) {
                Ext.Msg.alert("提示", "请选择要删除的记录");
                return;
            }

            Ext.Msg.confirm("提醒", "确认要删除所选的数据吗", function (btn, text) {
                if (btn == "yes") {
                    var OrgID = App.txtTreeNodeID.getValue();
                    var arr = [];
                    Ext.each(records, function (item) {
                        arr.push(item.data.ID);
                    });

                    App.direct.RemoveUser(OrgID, Ext.encode(arr), {
                        success: function (rtn) {
                            Ext.Msg.alert("提示", "删除成功");
                            App.UserStore.reload();
                        }
                    });
                }
            })
        }

        //导出Excel
        function exportExcel() {
            Ext.getBody().mask("导出中请稍等");
            var OrgID = App.txtTreeNodeID.getValue();
            App.direct.ExportExcel(OrgID, {
                success: function (rtn) {
                    Ext.getBody().unmask();
                    Ext.DomHelper.append(Ext.getBody(), "<iframe style='display:none' src=" + rtn + "></iframe>");
                    // Ext.getBody().insertHtml("afterBegin", "<iframe style='display:none' src=" + rtn + "></iframe>");
                }
            })
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager runat="server" ID="ResourceM1">
        </ext:ResourceManager>
        <ext:Menu runat="server" ID="treeNodeMenu" BodyStyle=" background-color: rgb(231,234,236);">
            <Items>
                <ext:MenuItem runat="server" Text="添加">
                    <Listeners>
                        <Click Handler="AddNode();"></Click>
                    </Listeners>
                </ext:MenuItem>
                <ext:MenuItem runat="server" Text="编辑">
                    <Listeners>
                        <Click Handler="editRecord();"></Click>
                    </Listeners>
                </ext:MenuItem>
                <ext:MenuItem runat="server" Text="删除">
                    <Listeners>
                        <Click Handler="deleteRecord();"></Click>
                    </Listeners>
                </ext:MenuItem>
            </Items>
        </ext:Menu>
        <ext:Window
            runat="server"
            Width="450"
            Height="250"
            Hidden="true"
            ID="treeNodeWin">
            <Items>
                <ext:FormPanel
                    ID="nodeFormPanel"
                    Layout="FormLayout"
                    runat="server">
                    <Items>
                        <ext:Panel
                            Layout="BorderLayout"
                            Height="24"
                            BodyStyle="background-color:#fff"
                            runat="server">
                            <Items>
                                <ext:TextField ID="TextField2" Name="ID" Hidden="true" runat="server"></ext:TextField>
                                <ext:TextField Name="Path" Hidden="true" ID="txtPath" runat="server"></ext:TextField>
                                <ext:TextField Name="ParentID" ID="txtParentID" Hidden="true" runat="server"></ext:TextField>
                                <ext:TextField
                                    Name="Name"
                                    Width="400"
                                    LabelWidth="80"
                                    Region="West"
                                    IndicatorCls="red-text"
                                    IndicatorText="*"
                                    AllowBlank="false"
                                    runat="server"
                                    FieldLabel="组织名称">
                                </ext:TextField>
                            </Items>
                        </ext:Panel>
                        <ext:Panel ID="Panel3"
                            MarginSpec="10 0 0 0"
                            Layout="BorderLayout"
                            Height="24"
                            BodyStyle="background-color:#fff"
                            runat="server">
                            <Items>
                                <ext:TextField
                                    ID="txtSortIndex"
                                    Name="SortIndex"
                                    Width="210"
                                    LabelWidth="80"
                                    Region="West"
                                    MaskRe="/\d+/"
                                    AllowBlank="false"
                                    runat="server"
                                    FieldLabel="排序">
                                </ext:TextField>
                                <ext:Label runat="server" MarginSpec="5 0 0 10" Text="(用于显示顺序排列)"></ext:Label>
                            </Items>
                        </ext:Panel>
                        <ext:Panel ID="Panel1"
                            Layout="BorderLayout"
                            Height="24"
                            MarginSpec="10 0 0 0"
                            BodyStyle="background-color:#fff"
                            runat="server">
                            <Items>
                                <ext:ComboBox
                                    ID="comboOrgType"
                                    Name="OrgType"
                                    LabelWidth="80"
                                    Width="210"
                                    AllowBlank="false"
                                    Region="West"
                                    runat="server"
                                    FieldLabel="类型">
                                    <Items>
                                        <ext:ListItem Text="组织结构" Value="org"></ext:ListItem>
                                        <ext:ListItem Text="职务" Value="position"></ext:ListItem>
                                    </Items>
                                    <SelectedItems>
                                        <ext:ListItem Value="org"></ext:ListItem>
                                    </SelectedItems>
                                </ext:ComboBox>
                                <ext:TextField
                                    Width="170"
                                    MarginSpec="0 0 0 20"
                                    LabelAlign="Right"
                                    LabelWidth="50"
                                    ID="txtCode"
                                    Region="West"
                                    IndicatorCls="red-text"
                                    IndicatorText="*"
                                    AllowBlank="false"
                                    runat="server"
                                    Name="Code"
                                    FieldLabel="编号">
                                </ext:TextField>
                            </Items>
                        </ext:Panel>
                        <ext:Panel ID="Panel2"
                            Layout="BorderLayout"
                            Height="24"
                            MarginSpec="10 0 0 0"
                            BodyStyle="background-color:#fff"
                            runat="server">
                            <Items>
                                <ext:ComboBox
                                    ID="cboState"
                                    LabelWidth="80"
                                    Width="210"
                                    Region="West"
                                    Name="State"
                                    runat="server"
                                    FieldLabel="状态">
                                    <Items>
                                        <ext:ListItem Text="启用" Value="1"></ext:ListItem>
                                        <ext:ListItem Text="停用" Value="0"></ext:ListItem>
                                    </Items>
                                    <SelectedItems>
                                        <ext:ListItem Value="1"></ext:ListItem>
                                    </SelectedItems>
                                </ext:ComboBox>
                                <ext:DateField runat="server"
                                    Width="175"
                                    MarginSpec="0 0 0 10"
                                    LabelAlign="Right"
                                    LabelWidth="60"
                                    Editable="false"
                                    Name="CreateTime"
                                    ID="txtCreateTime"
                                    Region="West"
                                    FieldLabel="创建时间">
                                </ext:DateField>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:FormPanel>
            </Items>
            <DockedItems>
                <ext:Toolbar ID="Toolbar1" Height="38px" Dock="Bottom" Border="true" runat="server" Layout="BorderLayout">
                    <Items>
                        <ext:Button ID="Button3" Region="East" Icon="Disk" runat="server" Text="保存" Width="60px" Height="27" Y="0">
                            <Listeners>
                                <Click Fn="saveData">
                                </Click>
                            </Listeners>
                        </ext:Button>
                        <ext:Button ID="Button4" Region="East" Icon="PageDelete" Text="清空" runat="server" Width="60px" Height="27" Y="0">
                            <Listeners>
                                <Click Handler="App.nodeFormPanel.getForm().reset();"></Click>
                            </Listeners>
                        </ext:Button>
                        <ext:Button ID="Button5" Region="East" Icon="Cancel" Text="取消" runat="server" Width="60px" Height="27" Y="0">
                            <Listeners>
                                <Click Handler="App.treeNodeWin.close();"></Click>
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </DockedItems>
        </ext:Window>

        <%-- Main --%>
        <ext:Viewport runat="server" Layout="BorderLayout">
            <Items>
                <ext:Panel
                    Width="450px"
                    Region="West"
                    Border="false"
                    Cls="west-panel"
                    Layout="FitLayout"
                    runat="server">
                    <Items>
                        <ext:TreePanel
                            ID="treePanel"
                            runat="server"
                            Region="Center"
                            RootVisible="false"
                            AutoScroll="true">
                            <TopBar>
                                <ext:Toolbar ID="treeTbar"
                                    Cls="tool-bar"
                                    runat="server">
                                    <Items>
                                        <ext:Button ID="Button2" runat="server" Icon="SectionCollapsed" Text="展开/收缩">
                                            <Listeners>
                                                <Click Handler="if(pageGlobal.nodeExpand){
                                                        App.treePanel.collapseAll(); 
                                                         pageGlobal.nodeExpand=false;
                                                         this.setIcon('../icons/section_collapsed-png/ext.axd');
                                                    }else {
                                                        App.treePanel.expandAll(); 
                                                        pageGlobal.nodeExpand=true;
                                                        this.setIcon('../icons/section_expanded-png/ext.axd');
                                                    }
                                                    ">
                                                </Click>
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button ID="Button1" runat="server" Hidden="true" ToolTip="将人员绑定到根节点" Icon="DatabaseRefresh" MinWidth="80" Text="关联到根">
                                            <Listeners>
                                                <Click Handler="bindRootNode();">
                                                </Click>
                                            </Listeners>
                                        </ext:Button>
                                        <ext:ToolbarFill></ext:ToolbarFill>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
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
                                        <Load Fn="expandNode"></Load>
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
                                        Width="100"
                                        DataIndex="Code">
                                    </ext:Column>
                                    <ext:Column ID="Column1" runat="server" Text="状态"
                                        Width="80"
                                        DataIndex="State">
                                        <Renderer Fn="treeRender"></Renderer>
                                    </ext:Column>
                                    <ext:Column ID="Column7" runat="server" Text="ID" Width="80" Hidden="true" DataIndex="ID">
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
                            <Listeners>
                                <ItemDblClick Handler="itemClick(record,item,index)" Delay="200"></ItemDblClick>
                                <ItemExpand Handler="" Buffer="30" />
                                <ItemCollapse Handler="" Buffer="30" />
                                <%-- <ItemContextMenu Fn="treeNodeContexMeun" Buffer="200">
                                </ItemContextMenu>--%>
                            </Listeners>
                            <SelectionModel>
                                <ext:TreeSelectionModel Mode="Single" runat="server" SelectedIndex="0"></ext:TreeSelectionModel>
                            </SelectionModel>
                        </ext:TreePanel>
                    </Items>
                </ext:Panel>

                <%-- GridPanel --%>

                <ext:Panel
                    ID="panelUserMain"
                    Region="Center"
                    Layout="BorderLayout"
                    MarginSpec="0 0 0 1"
                    Cls="west-panel"
                    BodyStyle="background-color:#fff; "
                    runat="server">
                    <Items>
                        <ext:Panel runat="server"
                            Height="35"
                            Region="North"
                            BodyStyle="border-bottom:solid 1px rgb(193,193,193) !important;padding-top:6px; font-size:13px;font-weight:600 ">
                            <Items>
                                <ext:Label ID="lblPath" runat="server" MarginSpec="10 10 10 10" Text="aaa"></ext:Label>
                                <ext:TextField runat="server" Hidden="true" ID="txtTreeNodeID"></ext:TextField>
                            </Items>
                        </ext:Panel>
                        <ext:GridPanel
                            Region="Center"
                            runat="server"
                            Cls="grid-style"
                            ID="UserGrid"
                            Frame="false">
                            <TopBar>
                                <ext:Toolbar runat="server" Height="38">
                                    <Items>
                                        <ext:Button ID="Button8" runat="server" Icon="UserAdd" Text="添加人员">
                                            <Listeners>
                                                <Click Handler="refUserList()"></Click>
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button ID="Button6" runat="server" Icon="Delete" Text="移除人员">
                                            <Listeners>
                                                <Click Handler="removeUser()"></Click>
                                            </Listeners>
                                        </ext:Button>
                                        <ext:ToolbarSeparator></ext:ToolbarSeparator>
                                        <ext:Button ID="Button9" runat="server" Icon="PageExcel" Text="导出Excel">
                                            <Listeners>
                                                <Click Handler="exportExcel()"></Click>
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button ID="Button10" runat="server" Hidden="true" Icon="DatabaseAdd" Text="导入人员"></ext:Button>
                                        <ext:ToolbarFill></ext:ToolbarFill>
                                        <ext:TextField
                                            ID="TextField1"
                                            MaxWidth="150"
                                            Text="输入姓名简拼"
                                            Name="UserQuery"
                                            runat="server">
                                            <Listeners>
                                                <Focus Handler="this.setValue('')"></Focus>
                                                <Blur Handler="if(!this.getValue())this.setValue('输入姓名简拼')"></Blur>
                                                <SpecialKey Handler=" if (e.getKey() == Ext.EventObject.ENTER) {
                                                                      #{UserStore}.reload();   }">
                                                </SpecialKey>
                                            </Listeners>
                                        </ext:TextField>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Store>
                                <ext:Store
                                    ID="UserStore"
                                    runat="server"
                                    AutoLoad="true"
                                    OnReadData="RefreshData"
                                    PageSize="50">
                                    <Proxy>
                                        <ext:PageProxy />
                                    </Proxy>
                                    <Model>
                                        <ext:Model ID="Model1" runat="server" IDProperty="ID">
                                            <Fields>
                                                <ext:ModelField Name="WorkNo" />
                                                <ext:ModelField Name="ID" />
                                                <ext:ModelField Name="Name" />
                                                <ext:ModelField Name="EnglishName" />
                                                <ext:ModelField Name="LoginName" />
                                                <ext:ModelField Name="State" />
                                                <ext:ModelField Name="Email" />
                                                <ext:ModelField Name="Phone" />
                                                <ext:ModelField Name="City" />
                                                <ext:ModelField Name="TelNo" />
                                                <ext:ModelField Name="QQ" />
                                                <ext:ModelField Name="WeChat" />
                                                <ext:ModelField Name="WorkInDate" />
                                                <ext:ModelField Name="WorkOutDate" />
                                                <ext:ModelField Name="CreateTime" Type="Date" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>

                                    <ext:Column ID="Column3" runat="server" DataIndex="WorkNo" Text="工号" Width="120" />
                                    <ext:Column ID="Column4" runat="server" DataIndex="Name" Text="姓名" Width="100" />
                                    <ext:Column ID="DateColumn1" runat="server" DataIndex="Phone" Text="手机" Width="130" />
                                    <ext:Column ID="DateColumn2" runat="server" DataIndex="Email" Text="邮箱" Width="130" Flex="1" />
                                    <ext:Column ID="Column5" runat="server" DataIndex="State" Text="状态" Width="90">
                                        <Renderer Handler="return value=='1'?'启用':'<font color=red>冻结</font>';"></Renderer>
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:CheckboxSelectionModel runat="server" AllowDeselect="true"
                                    ID="CheckboxSelectionModel1"
                                    ShowHeaderCheckbox="true"
                                    Mode="Multi">
                                </ext:CheckboxSelectionModel>
                            </SelectionModel>

                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1"
                                    runat="server"
                                    Height="35"
                                    DisplayInfo="true"
                                    DisplayMsg="显示记录 {0} - {1} 共 {2}"
                                    EmptyMsg="无数据" />
                            </BottomBar>
                        </ext:GridPanel>
                    </Items>
                </ext:Panel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
