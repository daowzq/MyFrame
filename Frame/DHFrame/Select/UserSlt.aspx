<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserSlt.aspx.cs" Inherits="HDFrame.Select.UserSlt" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户选择</title>
    <script type="text/javascript">
        //返回选择
        function rtnRecord() {
            var sltWin = parent.Ext.getCmp("selectWin");
            var records = App.UserSltGrid.getSelectionModel().getSelection();
            sltWin.setSelectedVal(records);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager runat="server" ID="ResourceM1">
        </ext:ResourceManager>
        <ext:Viewport Layout="BorderLayout" runat="server">
            <Items>
                <ext:Panel Height="35" Region="North" runat="server" ID="TobBar">
                    <Items>
                    </Items>
                    <BottomBar>
                        <ext:Toolbar runat="server">
                            <Items>
                                <ext:TextField
                                    LabelAlign="Right"
                                    ID="TextField1"
                                    LabelWidth="60"
                                    runat="server"
                                    Name="WorkNo"
                                    MaxLength="15"
                                    FieldLabel="工号">
                                    <Listeners>
                                        <SpecialKey Handler=" if (e.getKey() == Ext.EventObject.ENTER) {
                                                                      #{DataStore}.reload();   }">
                                        </SpecialKey>
                                    </Listeners>
                                </ext:TextField>
                                <ext:TextField
                                    runat="server"
                                    LabelWidth="60"
                                    Name="Name"
                                    LabelAlign="Right"
                                    FieldLabel="姓名">
                                    <Listeners>
                                        <SpecialKey Handler=" if (e.getKey() == Ext.EventObject.ENTER) {
                                                                      #{DataStore}.reload();   }">
                                        </SpecialKey>
                                    </Listeners>
                                </ext:TextField>
                                <ext:Button runat="server" Text="查询" Icon="Zoom" MarginSpec="0 0 0 10">
                                    <Listeners>
                                        <Click Handler="#{DataStore}.reload();"></Click>
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </BottomBar>
                </ext:Panel>

                <ext:GridPanel
                    Region="Center"
                    runat="server"
                    Cls="grid-style"
                    ID="UserSltGrid"
                    Frame="false">
                    <Store>
                        <ext:Store
                            ID="DataStore"
                            runat="server"
                            RemoteSort="true"
                            OnReadData="RefreshDataList"
                            PageSize="30">
                            <Proxy>
                                <ext:PageProxy />
                            </Proxy>
                            <Model>
                                <ext:Model ID="Model1" runat="server" IDProperty="ID">
                                    <Fields>
                                        <ext:ModelField Name="WorkNo" />
                                        <ext:ModelField Name="Name" />
                                        <ext:ModelField Name="Email" />
                                        <ext:ModelField Name="Phone" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:Column ID="Column3" runat="server" DataIndex="WorkNo" Text="工号" Flex="1" />
                            <ext:Column ID="Column4" runat="server" DataIndex="Name" Text="姓名" Flex="1" />
                            <ext:Column ID="Column1" runat="server" DataIndex="Email" Text="手机" Flex="1" />
                            <ext:Column ID="ClnEmail" runat="server" DataIndex="Phone" Text="邮箱" Flex="1" />
                        </Columns>
                    </ColumnModel>
                    <SelectionModel>
                        <ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" Width="80" runat="server" Mode="Multi" />
                    </SelectionModel>
                    <BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar1"
                            runat="server"
                            Height="35"
                            DisplayInfo="true"
                            DisplayMsg="显示{0}-{1},共{2}"
                            EmptyMsg="无数据" />
                    </BottomBar>
                    <Listeners>
                        <RowDblClick Handler="rtnRecord();"></RowDblClick>
                    </Listeners>
                </ext:GridPanel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
