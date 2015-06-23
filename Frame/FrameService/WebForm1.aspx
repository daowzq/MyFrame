<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="FrameService.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">
        $(function () {
            var dayStart = new Date('2015-06-12');
            var dayNow = new Date();
            //相差天数
            var daffDay = parseInt((dayNow.getTime() - dayStart.getTime()) / (1000 * 60 * 60 * 24));
            //弹框索引
            var showIndex = daffDay % 4;
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
