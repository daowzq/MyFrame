<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JqueryTest.aspx.cs" Inherits="WebApplication1.JqueryTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="demo/jquery.js"></script>
    <script type="text/javascript">

        $(function () {
            $("p").slideToggle("show");
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 50px;">
            <p>这是一个段落标这是一个段落标这是一个段落标这是一个段落标这是一个段落标这是一个段落标这是一个段落标签</p>
        </div>
    </form>
</body>
</html>
