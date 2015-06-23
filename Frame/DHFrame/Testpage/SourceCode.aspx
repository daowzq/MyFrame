<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SourceCode.aspx.cs" Inherits="HDFrame.Testpage.SourceCode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../Js/jquery-1.7.2.min.js"></script>
    <title></title>
    <script type="text/javascript">
        $(function () {
            window.setTimeout(function () {
                $.get("?action=load", function (rtn) {

                    $("#content").text(rtn);
                })
            }, 1000);
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div runat="server" id="content"></div>
    </form>
</body>
</html>
