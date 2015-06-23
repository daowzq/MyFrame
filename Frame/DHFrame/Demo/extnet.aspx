<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="extnet.aspx.cs" Inherits="HDFrame.Demo.extnet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">
        Ext.onReady(function () {
            Ext.create("Ext.net.Viewport", {
                renderTo: Ext.get("form1"),
                items: [{
                    margin: "1 0 0 0",
                    xtype: "tabpanel",
                    items: [{
                        html: "<iframe width=\"100%\" height=\"100%\" src=\"../demo/response.htm?page=" + encodeURI("../sysmodule/Sysuser.aspx") + "\" name=\"frameContent\" frameborder=\"0\"></iframe>",
                        title: "列表前台"
                    }, {
                        id: "Panel1",
                        html: "<iframe width=\"100%\" height=\"100%\" src=\"../demo/response.htm?page=" + encodeURI("../sysmodule/Sysuser.aspx.cs") + "\" name=\"frameContent\" frameborder=\"0\"></iframe>",
                        title: "列表后台"
                    }
                    ],
                    activeTab: 0,
                    minTabWidth: 80
                }
                ],
                layout: "fit"
            });
        });
    </script>
</head>
<body>
    <form id="form2" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server"></ext:ResourceManager>
    </form>
</body>
</html>
