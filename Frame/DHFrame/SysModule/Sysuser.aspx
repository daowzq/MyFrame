<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sysuser.aspx.cs" Inherits="HDFrame.SysModule.Sysuser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .bg-white {
            background-color: #fff;
        }

        .west-panel {
            border-Color: #a1a3a5;
            border-Width: 1px;
            border-Style: solid;
            border-Left-Width: 3px;
            border-Top-Width: 0px;
            border-Left-Color: #eed485;
        }

        .panel-top-border {
            border-Color: #a1a3a5;
            border-Width: 1px;
            border-Style: solid;
            border-Top-Width: 1px;
            border-left: none;
            border-right: none;
            border-bottom: none;
        }
    </style>
    <script type="text/javascript">
        //页面初始化后
        function afterInit() {
            //批量注册事件
            var schItems = Ext.getCmp("panelSch").query("textfield(true)");
            Ext.each(schItems, function (item, index) {
                item.on("specialkey", function (field, e) {
                    if (e.getKey() == Ext.EventObject.ENTER) {
                        App.ListStore.reload();  //ListStore 重新加载
                    }
                })
            })
        }

        //添加数据
        function addRecord() {
            App.editorWin.setTitle("添加");
            App.editorWin.down("form(true)").getForm().reset();
            App.editorWin.show();
        }

        //编辑数据
        function editRecord() {
            var record = App.DataGridPanel.getSelectionModel().getLastSelected();
            if (!record) {
                Ext.Msg.alert("提示", "请选择要修改的记录");
                return;
            }
            App.editorWin.setTitle("编辑");
            var formPanel = App.editorWin.down("form(true)");
            formPanel.getForm().reset();
            formPanel.getForm().loadRecord(record);
            App.editorWin.show();
        }

        function deleteRecord() {
            var record = App.DataGridPanel.getSelectionModel().getLastSelected();
            if (!record) {
                Ext.Msg.alert("提示", "请选择要删除的记录");
                return;
            }

            Ext.Msg.confirm("提醒", "确认要删除所选的数据吗", function (btn, text) {
                if (btn == "yes") {
                    App.direct.DeleteRecord(record.get("ID"), {
                        success: function (rtn) {
                            App.editorWin.close();
                            Ext.Msg.alert("提示", "删除成功");
                            App.ListStore.reload();
                        }
                    });
                }
            })
        }

        //保存数据
        function saveData() {
            var formPanel = App.editorWin.down("form(true)");
            if (formPanel.getForm().isValid()) {
                var obj = formPanel.getForm().getValues();
                var json = Ext.encode(obj);
                App.direct.SaveData(json, {
                    success: function (rtn) {
                        if (rtn) {
                            App.editorWin.close();
                            Ext.Msg.alert("提示", "保存成功");
                            if (App.ListStore.hasListener("load")) {
                                App.ListStore.un("load")
                            }
                            App.ListStore.on({
                                load: {
                                    fn: function () {
                                        var record = App.ListStore.getById(rtn)
                                        if (record)
                                            App.DataGridPanel.getSelectionModel().select(record);
                                        App.ListStore.un("load");
                                    },
                                    scope: this,
                                    single: true
                                }
                            })
                            App.ListStore.reload();
                        }
                    }
                });
            }
        }

        //冻结账户
        function freezeUser() {
            var record = App.DataGridPanel.getSelectionModel().getLastSelected();
            if (!record) {
                Ext.Msg.alert("提示", "请选择要操作的记录");
                return;
            }
            App.direct.FreezeUser(record.get("ID"), {
                success: function (rtn) {
                    if (rtn == "1") {
                        Ext.Msg.alert("提示", "操作成功");
                        App.ListStore.reload();
                    }
                }
            });
        }

        //导出Excel
        function exportExcel() {
            Ext.getBody().mask("导出中请稍等");
            App.direct.ExportExcel({
                success: function (rtn) {
                    Ext.getBody().unmask();
                    Ext.DomHelper.append(Ext.getBody(), "<iframe style='display:none' src=" + rtn + "></iframe>");
                    // Ext.getBody().insertHtml("afterBegin", "<iframe style='display:none' src=" + rtn + "></iframe>");
                }
            })
        }

        //导入人员
        function importExcel() {
            App.importWin.show();
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager runat="server" ID="ResourceM1" />
        <ext:Window
            runat="server"
            ID="importWin"
            Title="导入人员"
            Width="500"
            Hidden="true"
            Layout="FormLayout"
            Height="300">
            <Items>
                <ext:Label runat="server" Text="导入说明:请选择下载导入模板"></ext:Label>

            </Items>
            <DockedItems>
                <ext:Toolbar ID="Toolbar1" runat="server" Dock="Bottom">
                    <Items>
                        <ext:ToolbarFill></ext:ToolbarFill>
                        <ext:Button ID="Button10" runat="server" Text="保存" Icon="PageSave">
                            <Listeners>
                                <Click Handler=""></Click>
                            </Listeners>
                        </ext:Button>
                        <ext:Button ID="Button11" runat="server" Text="取消" Icon="Cancel">
                            <Listeners>
                                <Click Handler="this.up('window').close()"></Click>
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </DockedItems>
        </ext:Window>

        <%-- EditWin --%>
        <ext:Window runat="server"
            ID="editorWin"
            Title="添加"
            Width="700"
            Hidden="true"
            Modal="true"
            Height="400"
            Layout="FitLayout"
            BodyStyle="background-color:#fff">
            <Items>
                <ext:FormPanel runat="server" Layout="FormLayout">
                    <Items>
                        <ext:TextField runat="server" ID="txtID" Name="ID" Hidden="true"></ext:TextField>
                        <ext:Panel runat="server"
                            Layout="BorderLayout"
                            MarginSpec="10 0 0 10"
                            Height="25"
                            BodyStyle="background-color:#fff">
                            <Items>
                                <ext:TextField
                                    runat="server"
                                    MaxHeight="25"
                                    LabelWidth="60"
                                    Region="West"
                                    AllowBlank="false"
                                    Name="Name"
                                    FieldLabel="<font color=red>*</font> 姓名">
                                </ext:TextField>
                                <ext:TextField ID="TextField4"
                                    LabelWidth="60"
                                    MarginSpec="0 0 0 20"
                                    MaxHeight="25"
                                    Region="West"
                                    AllowBlank="false"
                                    runat="server"
                                    Name="WorkNo"
                                    FieldLabel="<font color=red>*</font> 工号">
                                </ext:TextField>
                            </Items>
                        </ext:Panel>
                        <ext:Panel ID="Panel1"
                            runat="server"
                            Layout="BorderLayout"
                            MarginSpec="10 0 0 10"
                            Height="25"
                            BodyStyle="background-color:#fff">
                            <Items>
                                <ext:TextField ID="TextField6"
                                    LabelWidth="60"
                                    MaxHeight="25"
                                    Region="West"
                                    runat="server"
                                    Name="EnglishName"
                                    FieldLabel="英文名">
                                </ext:TextField>
                                <ext:TextField ID="TextField5"
                                    runat="server"
                                    MarginSpec="0 0 0 20"
                                    MaxHeight="25"
                                    LabelWidth="60"
                                    Region="West"
                                    Name="LoginName"
                                    FieldLabel="登陆名">
                                </ext:TextField>
                            </Items>
                        </ext:Panel>
                        <ext:FieldSet
                            Title="详细信息"
                            MarginSpec="10 0 0 10"
                            Layout="FormLayout"
                            runat="server">
                            <Items>
                                <ext:Panel ID="Panel2"
                                    runat="server"
                                    Layout="BorderLayout"
                                    Height="25"
                                    BodyStyle="background-color:#fff">
                                    <Items>
                                        <ext:TextField ID="TextField7"
                                            runat="server"
                                            MaxHeight="25"
                                            LabelWidth="60"
                                            Region="West"
                                            Width="300"
                                            Regex="/^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])/"
                                            RegexText="请输入正确的邮箱地址"
                                            Name="Email"
                                            FieldLabel="邮箱">
                                        </ext:TextField>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel ID="Panel3"
                                    runat="server"
                                    MarginSpec="3 0 0 0"
                                    Layout="BorderLayout"
                                    Height="25"
                                    BodyStyle="background-color:#fff">
                                    <Items>
                                        <ext:TextField ID="TextField8"
                                            runat="server"
                                            MaxHeight="25"
                                            Width="300"
                                            LabelWidth="60"
                                            MaskRe="/^\d+$/"
                                            Region="West"
                                            Regex="/^(1[0-9][0-9]{9})$/"
                                            RegexText="请输入正确的手机号码"
                                            Name="Phone"
                                            FieldLabel="手机">
                                        </ext:TextField>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel ID="Panel4"
                                    runat="server"
                                    MarginSpec="3 0 0 0"
                                    Layout="BorderLayout"
                                    Height="25"
                                    BodyStyle="background-color:#fff">
                                    <Items>
                                        <ext:TextField ID="TextField9"
                                            runat="server"
                                            MaxHeight="25"
                                            LabelWidth="60"
                                            MaskRe="/^\d+$/"
                                            Region="West"
                                            Width="300"
                                            Name="TelNo"
                                            FieldLabel="电话">
                                        </ext:TextField>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel ID="Panel5"
                                    runat="server"
                                    MarginSpec="3 0 0 0"
                                    Layout="BorderLayout"
                                    Height="25"
                                    BodyStyle="background-color:#fff">
                                    <Items>
                                        <ext:TextField ID="TextField10"
                                            runat="server"
                                            MaxHeight="25"
                                            LabelWidth="60"
                                            MaskRe="/^\d+$/"
                                            Region="West"
                                            Width="300"
                                            Name="QQ"
                                            FieldLabel="QQ">
                                        </ext:TextField>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel ID="Panel6"
                                    runat="server"
                                    Layout="BorderLayout"
                                    Height="25"
                                    MarginSpec="3 0 0 0"
                                    BodyStyle="background-color:#fff">
                                    <Items>
                                        <ext:TextField ID="TextField11"
                                            runat="server"
                                            MaxHeight="25"
                                            LabelWidth="60"
                                            MaskRe="/^\d+$/"
                                            Region="West"
                                            Width="300"
                                            Name="WeChat"
                                            FieldLabel="微信">
                                        </ext:TextField>
                                    </Items>
                                </ext:Panel>

                                <ext:Panel ID="Panel7"
                                    runat="server"
                                    Layout="BorderLayout"
                                    Height="25"
                                    MarginSpec="3 0 0 0"
                                    BodyStyle="background-color:#fff">
                                    <Items>
                                        <ext:DateField runat="server"
                                            MaxHeight="25"
                                            LabelWidth="60"
                                            Editable="false"
                                            Region="West"
                                            Width="300"
                                            Name="WorkInDate"
                                            FieldLabel="入职日期">
                                        </ext:DateField>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel ID="Panel8"
                                    runat="server"
                                    Layout="BorderLayout"
                                    Height="25"
                                    MarginSpec="3 0 0 0"
                                    BodyStyle="background-color:#fff">
                                    <Items>
                                        <ext:DateField ID="TextField13"
                                            runat="server"
                                            MaxHeight="25"
                                            LabelWidth="60"
                                            Editable="false"
                                            Region="West"
                                            Width="300"
                                            Name="WorkOutDate"
                                            FieldLabel="离职日期">
                                        </ext:DateField>
                                    </Items>
                                </ext:Panel>
                            </Items>
                        </ext:FieldSet>
                    </Items>
                </ext:FormPanel>
            </Items>
            <DockedItems>
                <ext:Toolbar runat="server" Dock="Bottom">
                    <Items>
                        <ext:ToolbarFill></ext:ToolbarFill>
                        <ext:Button runat="server" Text="保存" Icon="PageSave">
                            <Listeners>
                                <Click Handler="saveData()"></Click>
                            </Listeners>
                        </ext:Button>
                        <ext:Button runat="server" Text="取消" Icon="Cancel">
                            <Listeners>
                                <Click Handler="this.up('window').close()"></Click>
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </DockedItems>
        </ext:Window>

        <ext:Viewport runat="server" Layout="BorderLayout" Cls="west-panel">
            <Items>
                <%-- 隐藏状态域 --%>
                <ext:TextField runat="server" ID="txtSchType" Name="SchType" Hidden="true" Text="1"></ext:TextField>
                <%-- 工具栏 --%>
                <ext:Panel runat="server" Height="50" Region="North" Layout="BorderLayout" BodyStyle="background-color:#fff">
                    <DockedItems>
                        <ext:Toolbar runat="server" Dock="Bottom" Height="50">
                            <Items>
                                <ext:Button ID="Button1" runat="server" MaxHeight="25" Height="25" Region="West" Text="添加" Icon="ApplicationAdd">
                                    <Listeners>
                                        <Click Handler="addRecord()"></Click>
                                    </Listeners>
                                </ext:Button>
                                <ext:Button ID="Button2" runat="server" MaxHeight="25" Height="25" Region="West" Icon="ApplicationEdit" Text="编辑">
                                    <Listeners>
                                        <Click Handler="editRecord()"></Click>
                                    </Listeners>
                                </ext:Button>
                                <ext:Button ID="Button3" runat="server" MaxHeight="25" Height="25" Region="West" Text="删除" Icon="Delete">
                                    <Listeners>
                                        <Click Handler="deleteRecord();"></Click>
                                    </Listeners>
                                </ext:Button>
                                <ext:ToolbarSeparator></ext:ToolbarSeparator>
                                <ext:Button ID="Button7" runat="server" MaxHeight="25" Height="25" Region="West" Text="重置密码" Icon="UserAlert">
                                    <Listeners>
                                        <Click Handler=""></Click>
                                    </Listeners>
                                </ext:Button>
                                <ext:Button ID="Button6" runat="server" MaxHeight="25" Height="25" Region="West" Text="启用/冻结" Icon="UserCross">
                                    <Listeners>
                                        <Click Handler="freezeUser();"></Click>
                                    </Listeners>
                                </ext:Button>
                                <ext:Button ID="Button12" runat="server" MaxHeight="25" Height="25" Region="West" Text="导出Excel" Icon="PageExcel">
                                    <Listeners>
                                        <Click Handler="exportExcel()"></Click>
                                    </Listeners>
                                </ext:Button>
                                <ext:Button ID="Button9" runat="server" MaxHeight="25" Height="25" Region="West" Text="导入人员" Icon="DatabaseAdd">
                                    <Listeners>
                                        <Click Handler="importExcel()"></Click>
                                    </Listeners>
                                </ext:Button>
                                <ext:ToolbarFill></ext:ToolbarFill>
                                <ext:TextField runat="server" ID="SchVal" Name="SchVal" Text="输入工号/姓名/姓名简拼" Width="155">
                                    <Listeners>
                                        <Focus Handler="this.setValue('')"></Focus>
                                        <Blur Handler="if(!this.getValue())this.setValue('输入工号/姓名/姓名简拼')"></Blur>
                                        <SpecialKey Handler=" if (e.getKey() == Ext.EventObject.ENTER) {
                                                                      #{ListStore}.reload();   }">
                                        </SpecialKey>
                                    </Listeners>
                                </ext:TextField>
                                <ext:Button ID="Button4" runat="server" MaxHeight="25" Height="25" Region="East" Text="查询" Icon="Zoom">
                                    <Listeners>
                                        <Click Handler="#{ListStore}.reload()"></Click>
                                    </Listeners>
                                </ext:Button>
                                <ext:Button ID="Button5" runat="server" MaxHeight="25" Height="25" Region="East" Text="高级查询" Icon="Cog">
                                    <Listeners>
                                        <Click Handler="; 
                                            if(((parseInt(#{txtSchType}.getValue())+1)%2==0)){
                                                #{panelSch}.show();
                                                #{SchVal}.disable(true);
                                            }
                                             else {
                                                #{panelSch}.hide();
                                                #{SchVal}.enable();
                                            }
                                            #{txtSchType}.setValue(parseInt(#{txtSchType}.getValue())+1)
                                            ">
                                        </Click>
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </DockedItems>
                </ext:Panel>
                <ext:Panel
                    Hidden="true"
                    ID="panelSch"
                    runat="server"
                    Region="North"
                    Cls="panel-top-border"
                    Layout="AbsoluteLayout"
                    Height="50">
                    <Items>
                        <ext:TextField runat="server"
                            LabelWidth="60"
                            X="10"
                            Y="12"
                            Width="200"
                            Name="schName"
                            FieldLabel="姓名">
                        </ext:TextField>
                        <ext:TextField ID="TextField1" runat="server"
                            X="220"
                            Y="12"
                            LabelWidth="60"
                            Width="200"
                            Name="schWorkNo"
                            FieldLabel="工号">
                        </ext:TextField>
                        <ext:TextField ID="TextField2" runat="server"
                            X="430"
                            Y="12"
                            LabelWidth="60"
                            Width="200"
                            Name="schPhone"
                            FieldLabel="手机">
                        </ext:TextField>
                        <ext:ComboBox runat="server"
                            X="640"
                            Y="12"
                            LabelWidth="60"
                            Width="160"
                            ID="cboFreeze"
                            Name="schFreeze"
                            FieldLabel="状态">
                            <Items>
                                <ext:ListItem Text="" Value="请选择..."></ext:ListItem>
                                <ext:ListItem Text="启用" Value="1"></ext:ListItem>
                                <ext:ListItem Text="冻结" Value="0"></ext:ListItem>
                            </Items>
                            <SelectedItems>
                                <ext:ListItem Value="请选择..."></ext:ListItem>
                            </SelectedItems>
                        </ext:ComboBox>

                        <ext:Button ID="Button8" runat="server" X="850" MaxHeight="25" Y="12" Height="25" Text="查询" Icon="Zoom">
                            <Listeners>
                                <Click Handler="#{ListStore}.reload()"></Click>
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Panel>
                <%-- Line --%>
                <ext:Panel runat="server" Region="North" Height="3">
                    <Content>
                        <div style="height: 1px; border-bottom: solid 1px rgb(139,139,139);"></div>
                    </Content>
                </ext:Panel>
                <%-- Grid --%>
                <ext:Panel runat="server" Region="Center" Border="false" Layout="BorderLayout" BodyStyle="background-color:#fff">
                    <Items>
                        <ext:GridPanel
                            ID="DataGridPanel"
                            runat="server"
                            Border="false"
                            Region="Center"
                            MarginSpec="10 0 5 0"
                            EmptyText="<center>暂无信息</center>"
                            X="0" Y="45">
                            <Store>
                                <ext:Store
                                    ID="ListStore"
                                    runat="server"
                                    PageSize="20"
                                    AutoLoad="true"
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
                                    <ext:Column runat="server" ID="Col_Title" Text="姓名" DataIndex="Name" Align="left" Width="110px">
                                    </ext:Column>
                                    <ext:Column runat="server" ID="Col_LinkMan" Text="登陆名" DataIndex="LoginName" Align="left" Width="100px">
                                    </ext:Column>
                                    <ext:Column runat="server" ID="Col_LinkTel" Text="状态" DataIndex="State" Align="left" Width="80px">
                                        <Renderer Handler="return value=='1'?'启用':'<font color=red>冻结</font>';"></Renderer>
                                    </ext:Column>
                                    <ext:Column runat="server" ID="Col_StoreName" Text="英文名" DataIndex="EnglishName" Align="left" Width="110px">
                                    </ext:Column>
                                    <ext:Column runat="server" ID="Col_LinkMobile" Text="邮箱" DataIndex="Email" Align="left" Width="110px">
                                    </ext:Column>
                                    <ext:Column runat="server" ID="Col_Mails" Text="手机" DataIndex="Phone" Align="left" Width="110px">
                                    </ext:Column>
                                    <ext:Column runat="server" ID="Col_Fax" Text="电话" DataIndex="TelNo" Align="left" Width="110px"></ext:Column>
                                    <ext:Column runat="server" ID="Col_QQ" Text="QQ" DataIndex="QQ" Align="left" Width="110px">
                                    </ext:Column>
                                    <ext:Column runat="server" ID="Col_Address" Text="微信" DataIndex="WeChat" Align="left" Flex="1">
                                    </ext:Column>
                                    <ext:Column runat="server" ID="Col_Remark" Hidden="true" Text="入职日期" Width="120px" DataIndex="WorkInDate" Align="left">
                                    </ext:Column>
                                    <ext:Column runat="server" ID="Column1" Hidden="true" Text="离职日期" Width="120px" DataIndex="WorkOutDate" Align="left">
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:CheckboxSelectionModel runat="server" AllowDeselect="false"
                                    ID="rowSelect1"
                                    ShowHeaderCheckbox="false"
                                    Mode="Multi">
                                </ext:CheckboxSelectionModel>
                            </SelectionModel>

                            <%--pagetool start--%>
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
                        </ext:GridPanel>
                    </Items>
                </ext:Panel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
