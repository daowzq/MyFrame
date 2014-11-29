<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DraggableTest.aspx.cs" Inherits="WebApplication1.DraggableTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="css/test.css" rel="stylesheet" />
    <script src="js/JqueryUI/js/jquery-1.10.2.js"></script>
    <script src="js/JqueryUI/js/jquery-ui-1.10.4.custom.js"></script>
    <script type="text/javascript">
        $(function () {
            //题型设置
            $(".moduleL").draggable({
                helper: "clone",


                start: function (event, ui) {
                },
                revert: "invalid",
                scroll: true,
                cursor: "move"
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <div class="accordion-group">
            <h4 class="tc">
                <a href="javascript:;">常用题型
                                    <i class="icon_on"></i>
                </a>
            </h4>
            <ul class="ul-tool collapse">
                <li class="moduleL ui-draggable" name="2">
                    <a href="javascript:;">
                        <i class="basic-too11-icon-active"></i>
                        单选题
                    </a>
                </li>
                <li class="moduleL ui-draggable" name="3">
                    <a href="javascript:;">
                        <i class="basic-too12-icon-active"></i>
                        多选题
                    </a>
                </li>
                <li class="moduleL ui-draggable" name="2" disp_type="image_single">
                    <a href="javascript:;">
                        <i class="basic-too2013-icon-active"></i>
                        图片单选题
                    </a>
                </li>
                <li class="moduleL ui-draggable" name="3" disp_type="image_multiple">
                    <a href="javascript:;">
                        <i class="basic-too2014-icon-active"></i>
                        图片多选题
                    </a>
                </li>
                <li class="moduleL ui-draggable" name="6">
                    <a href="javascript:;">
                        <i class="basic-too13-icon-active"></i>
                        单行填空题
                    </a>
                </li>
                <li class="moduleL ui-draggable" name="6" disp_type="multi_line_blank">
                    <a href="javascript:;">
                        <i class="basic-too200-icon-active"></i>
                        多行填空题
                    </a>
                </li>
                <li class="moduleL ui-draggable" name="95">
                    <a href="javascript:;">
                        <i class="basic-too16-icon-active"></i>
                        多项填空题
                    </a>
                </li>
                <li class="moduleL ui-draggable" name="60">
                    <a href="javascript:;">
                        <i class="basic-too15-icon-active"></i>
                        排序题
                    </a>
                </li>
                <li class="moduleL ui-draggable" name="50">
                    <a href="javascript:;">
                        <i class="basic-too14-icon-active"></i>
                        打分题
                    </a>
                </li>
                <li class="moduleL ui-draggable" name="4">
                    <a href="javascript:;">
                        <i class="basic-too17-icon-active"></i>
                        矩阵单选题
                    </a>
                </li>
                <li class="moduleL ui-draggable" name="5">
                    <a href="javascript:;">
                        <i class="basic-too18-icon-active"></i>
                        矩阵多选题
                    </a>
                </li>
                <li class="moduleL ui-draggable" name="100">
                    <a href="javascript:;">
                        <i class="basic-too19-icon-active"></i>
                        矩阵填空题
                    </a>
                </li>
                <li class="moduleL ui-draggable" name="70">
                    <a href="javascript:;">
                        <i class="basic-too111-icon-active"></i>
                        段落说明
                    </a>
                </li>
                <li class="moduleL ui-draggable" name="page">
                    <a href="javascript:;">
                        <i class="basic-too112-icon-active"></i>
                        分页
                    </a>
                </li>
            </ul>
        </div>
        <div class="right-content">
        </div>
    </form>
</body>
</html>
