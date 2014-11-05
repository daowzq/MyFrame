<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UITest.aspx.cs" Inherits="WebApplication1.UITest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        body, input, textarea, select {
            font-family: "微软雅黑";
            font-size: 14px;
            color: #666666;
            background-color: #fff;
        }

        h1, h2, h3, h4, p, ul, ol, dl, dd, form {
            margin: 0px;
            padding: 0px;
        }

        h1, h2, h3, h4, h5, h6 {
            font-weight: normal;
        }

        h4 {
            font-size: 16px;
        }

            h4 a {
                color: #717171;
            }

        a {
            text-decoration: none;
            display: block;
            outline-width: medium;
            outline-style: none;
            outline-color: invert;
        }

        .wjContent {
            width: 990px;
            min-width: 990px;
            margin-left: auto;
            margin-right: auto;
            background-color: white;
        }

        ul li {
            list-style: none;
            padding-left: 0px;
        }

        .rows1 {
            margin-left: 12px;
            width: 140px;
            float: left;
            display: inline;
            border: 1px solid;
            border-color: #e3e3e3;
            background-color: rgb(245,245,245);
            border-radius: 4px;
        }

        .well {
            padding: 8px 8px;
        }


        .ul-tool {
            margin-top: 5px;
        }

            .ul-tool li {
                height: 24px;
                line-height: 24px;
                margin-bottom: 4px;
                border-width: 1px 2px 2px 1px;
                border-color: #dbdbdb;
                border-style: solid;
                background-color: rgb(255,255,255);
            }

                .ul-tool li a {
                    padding: 0px 8px;
                    display: block;
                    color: #717171;
                    text-decoration: none;
                }

                .ul-tool li i {
                    margin-top: -3px;
                    margin-right: 5px;
                }

        [class^='-icon'], [class*='-icon'] {
            margin-right: 0px;
            vertical-align: middle;
            display: inline-block;
            background-image: url("/images/wjsj_toolico_off.png");
            background-repeat: no-repeat;
        }

        .fr li a:hover [class*='-icon'], .fr li a:focus [class*='-icon'], [class^='-icon-active'], [class*='-icon-active'] {
            background-image: url("/images/wjsj_toolico.png");
        }

        .basic-too11-icon-active {
            width: 20px;
            height: 20px;
            background-position-x: 0px;
            background-position-y: -119px;
        }

        .basic-too12-icon-active {
            width: 20px;
            height: 20px;
            background-position-x: 0px;
            background-position-y: -140px;
        }

        .basic-too2013-icon-active {
            width: 20px;
            height: 20px;
            background-position-x: 0px;
            background-position-y: -650px;
        }

        .basic-too2014-icon-active {
            width: 20px;
            height: 20px;
            background-position-x: 0px;
            background-position-y: -650px;
        }

        .basic-too13-icon-active {
            width: 20px;
            height: 20px;
            background-position-x: 0px;
            background-position-y: -159px;
        }

        .basic-too200-icon-active {
            width: 20px;
            height: 20px;
            background-position-x: 0px;
            background-position-y: -377px;
        }

        .basic-too16-icon-active {
            width: 20px;
            height: 20px;
            background-position-x: 0px;
            background-position-y: -220px;
        }

        .basic-too15-icon-active {
            width: 20px;
            height: 20px;
            background-position-x: 0px;
            background-position-y: -200px;
        }

        .basic-too14-icon-active {
            width: 20px;
            height: 20px;
            background-position-x: 0px;
            background-position-y: -180px;
        }

        .basic-too17-icon-active {
            width: 20px;
            height: 20px;
            background-position-x: 0px;
            background-position-y: -240px;
        }

        .basic-too18-icon-active {
            width: 20px;
            height: 20px;
            background-position-x: 0px;
            background-position-y: -260px;
        }

        .basic-too19-icon-active {
            width: 20px;
            height: 20px;
            background-position-x: 0px;
            background-position-y: -280px;
        }

        .basic-too111-icon-active {
            width: 20px;
            height: 20px;
            background-position-x: 0px;
            background-position-y: -320px;
        }

        .basic-too112-icon-active {
            width: 20px;
            height: 20px;
            background-position-x: 0px;
            background-position-y: -340px;
        }

        .tc {
            text-align: center;
            text-decoration-style: none;
        }

        #accordion1 h4 i {
            width: 12px;
            height: 15px;
            margin: 1px 0px 0px 5px;
            vertical-align: middle;
            display: inline-block;
            background-image: url("/images/xjwn_index_button.png");
            background-attachment: scroll;
            background-repeat: no-repeat;
            background-position-x: -364px;
            background-position-y: -24px;
            background-size: auto;
            background-origin: padding-box;
            background-color: transparent;
        }

        /*右边题干部分*/
        .rows2 {
            width: 805px;
            float: right;
            background-color: rgb(245,245,245);
        }

        .well2 {
            padding: 0px 7px 10px 7px;
            border: solid 1px #dbdbdb;
        }

        .h4-bg {
            width: 100%;
            text-align: center;
            padding: 4px 0px 0px 0px;
            font-size: 18px;
            margin: 0px;
            border-color: #fafafa;
            border-width: 1px;
            border-style: solid;
            background-attachment: scroll;
            background-size: auto;
            background-origin: padding-box;
            background-clip: border-box;
            background-color: rgb(250,250,250);
        }
        /*公共部分*/
        table {
            width: 100%;
            border-collapse: collapse;
            border-spacing: 0;
            background-color: transparent;
        }

        .table1 {
            width: 100%;
            border-color: #dbdbdb;
            border-width: 1px;
            border-style: solid;
        }

        .bg-m.table1 {
            margin-top: 10px;
            background-image: none;
            background-attachment: scroll;
            background-repeat: repeat;
            background-size: auto;
            background-origin: padding-box;
            background-clip: border-box;
            background-color: #fff;
        }

        .table1 td {
            padding: 8px;
            vertical-align: top;
        }

        .table1 .rb {
            width: 34px;
            border-right-color: #dbdbdb;
            border-right-width: 1px;
            border-right-style: solid;
        }

        .th4 {
            width: 600px;
            padding: 6px 0px 0px 0px;
            font-size: 16px;
            min-height: 30px;
        }

        .dragwen {
            padding: 0px;
            margin: 0px;
            list-style-type: none;
            list-style-position: outside;
            list-style-image: none;
            position: relative;
            min-height: 250px;
        }

            .dragwen > li {
                width: 100%;
                height: auto;
                position: relative;
                background-image: none;
                background-attachment: scroll;
                background-repeat: repeat;
                background-size: auto;
                background-origin: padding-box;
                background-clip: border-box;
                background-color: #fff;
            }

        .topic_type {
            border-color: #dbdbdb;
            border-width: 1px;
            border-style: solid;
            position: relative;
        }

        .topic_type_menu {
            left: 0px;
            top: 0px;
            width: 50px;
            padding: 8px 3px;
            position: absolute;
        }

        .topic_type_con {
            padding: 8px;
            margin-left: 50px;
            border-left-color: #dbdbdb;
            border-left-width: 1px;
            border-left-style: solid;
            min-height: 150px;
        }

        .setup-group h4 {
            text-align: center;
        }

        .ui-sortable {
            margin-top: 20px;
        }

        input {
            border: solid 1px #d2d2d2;
        }

        .unstyled li {
            margin-top: 5px;
            overflow: hidden;
        }

        .unstyled input[type='radio'], .unstyled input[type='checkbox'] {
            margin: 0px 5px 0px 0px;
            vertical-align: middle !important;
        }

        .module {
            margin-bottom: 20px;
        }
    </style>
</head>
<body>
    <div class="wjContent">
        <div class="container-fluid">
            <div class="row-fluid">
                <!--/.wentop-->
                <div class="rows1" style="">
                    <div class="well sidebar-nav affix-top" id="accordion1">
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
                            <h4 class="tc">
                                <a href="javascript:;">更多题型
                                   
                                    <i class=""></i>
                                </a>
                            </h4>
                            <ul id="common" class="ul-tool collapse" style="display: none;">
                                <li class="moduleL ui-draggable" name="7">
                                    <a href="javascript:;">
                                        <i class="basic-too110-icon-active"></i>
                                        矩阵打分题
                                    </a>
                                </li>
                                <li class="moduleL ui-draggable" name="sex">
                                    <a href="javascript:;">
                                        <i class="basic-too207-icon-active"></i>
                                        性别
                                    </a>
                                </li>
                                <li class="moduleL ui-draggable" name="mobile">
                                    <a href="javascript:;">
                                        <i class="basic-too202-icon-active"></i>
                                        手机
                                    </a>
                                </li>
                                <li class="moduleL ui-draggable" name="email">
                                    <a href="javascript:;">
                                        <i class="basic-too203-icon-active"></i>
                                        Email
                                    </a>
                                </li>
                                <li class="moduleL ui-draggable" name="age">
                                    <a href="javascript:;">
                                        <i class="basic-too2020-icon-active"></i>
                                        生日
                                    </a>
                                </li>
                                <li class="moduleL ui-draggable" name="city">
                                    <a href="javascript:;">
                                        <i class="basic-too2019-icon-active"></i>
                                        城市
                                    </a>
                                </li>
                                <li class="moduleL ui-draggable" name="address">
                                    <a href="javascript:;">
                                        <i class="basic-too204-icon-active"></i>
                                        地址
                                    </a>
                                </li>
                                <li class="moduleL ui-draggable" name="name">
                                    <a href="javascript:;">
                                        <i class="basic-too201-icon-active"></i>
                                        姓名
                                    </a>
                                </li>
                                <li class="moduleL ui-draggable" name="work_ex">
                                    <a href="javascript:;">
                                        <i class="basic-too208-icon-active"></i>
                                        工作年限
                                    </a>
                                </li>
                                <li class="moduleL ui-draggable" name="education">
                                    <a href="javascript:;">
                                        <i class="basic-too209-icon-active"></i>
                                        教育程度
                                    </a>
                                </li>
                                <li class="moduleL ui-draggable" name="income">
                                    <a href="javascript:;">
                                        <i class="basic-too2010-icon-active"></i>
                                        个人收入
                                    </a>
                                </li>
                                <li class="moduleL ui-draggable" name="company">
                                    <a href="javascript:;">
                                        <i class="basic-too2011-icon-active"></i>
                                        工作单位
                                    </a>
                                </li>
                                <li class="moduleL ui-draggable" name="marriage">
                                    <a href="javascript:;">
                                        <i class="basic-too2012-icon-active"></i>
                                        婚姻状况
                                    </a>
                                </li>
                                <li class="moduleL ui-draggable" name="70" disp_type="split_line">
                                    <a href="javascript:;">
                                        <i class="basic-too2017-icon-active"></i>
                                        分割线
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <!--/.rows1-->
                <div class="rows2 well2 Tj">
                    <h4 name="project" class="h4-bg T_edit p_title">你的上班有什么看法</h4>
                    <table class="table1 bg-m">
                        <tbody>
                            <tr>
                                <td class="rb">&nbsp;</td>
                                <td>
                                    <div class="th4 T_edit p_begin_desc" name="begin_desc">欢迎参加本次答题</div>
                                </td>
                            </tr>
                        </tbody>
                    </table>

                    <ul class="dragwen ui-sortable" id="question_box">
                        <li class="module">
                            <div class="topic_type">
                                <div class="topic_type_menu">
                                    <div class="setup-group">
                                        <h4>Q1</h4>
                                        <a class="Bub" href="javascript:;" title="题目设置" style="display: block;"><i class="setup-icon-active"></i></a><a class="Bub" href="javascript:;" title="逻辑设置" style="display: block;"><i class="link-icon-active"></i></a><a class="Bub" href="javascript:;" title="题目复制" style="display: block;"><i class="copy-icon-active"></i></a><a class="Del" href="javascript:;" title="题目删除" style="display: block;"><i class="del2-icon-active"></i></a>
                                    </div>
                                </div>
                                <div class="topic_type_con">
                                    <div class="Drag_area">
                                        <div class="th4 T_edit q_title" name="question">单选题</div>
                                    </div>
                                    <ul class="unstyled ">
                                        <li style="">
                                            <input type="radio" name="radio" id="option_543a2ef6f7405b41b6f77ca7" value="option_543a2ef6f7405b41b6f77ca7" /><label class="T_edit_min" for="" name="option" id="543a2ef6f7405b41b6f77ca7">选项1</label></li>
                                        <li style="">
                                            <input type="radio" name="radio" id="option_543a2ef6f7405b41b6f77ca8" value="option_543a2ef6f7405b41b6f77ca8" /><label class="T_edit_min" for="" name="option" id="543a2ef6f7405b41b6f77ca8">选项2</label></li>
                                    </ul>
                                    <div class="operationH"><a href="javascript:;" style="display: block;"><i title="添加选项" class="add-icon-active"></i></a><a class="Bub" href="javascript:;" title="批量添加" style="display: block;"><i class="clone-icon-active"></i></a></div>
                                </div>
                            </div>
                            <div class="updown" style="display: none;"><a href="javascript:;"><i title="上移本题" class="up-icon-active"></i></a><a href="javascript:;"><i title="下移本题" class="down-icon-active"></i></a></div>
                        </li>
                        <li class="module">
                            <div class="topic_type">
                                <div class="topic_type_menu">
                                    <div class="setup-group">
                                        <h4>Q2</h4>
                                        <a class="Bub" href="javascript:;" title="题目设置" style="display: block;"><i class="setup-icon-active"></i></a><a class="Bub" href="javascript:;" title="逻辑设置" style="display: block;"><i class="link-icon-active"></i></a><a class="Bub" href="javascript:;" title="题目复制" style="display: block;"><i class="copy-icon-active"></i></a><a class="Del" href="javascript:;" title="题目删除" style="display: block;"><i class="del2-icon-active"></i></a>
                                    </div>
                                </div>
                                <div class="topic_type_con">
                                    <div class="Drag_area">
                                        <div class="th4 T_edit q_title" name="question">多选题</div>
                                    </div>
                                    <ul class="unstyled ">
                                        <li style="">
                                            <input type="checkbox" name="radio" id="Radio1" value="option_543a2ef6f7405b41b6f77ca7" /><label class="T_edit_min" for="" name="option" id="Label1">选项1</label></li>
                                        <li style="">
                                            <input type="checkbox" name="radio" id="Radio2" value="option_543a2ef6f7405b41b6f77ca8" /><label class="T_edit_min" for="" name="option" id="Label2">选项2</label></li>
                                    </ul>
                                    <div class="operationH"><a href="javascript:;" style="display: block;"><i title="添加选项" class="add-icon-active"></i></a><a class="Bub" href="javascript:;" title="批量添加" style="display: block;"><i class="clone-icon-active"></i></a></div>
                                </div>
                            </div>
                            <div class="updown" style="display: none;"><a href="javascript:;"><i title="上移本题" class="up-icon-active"></i></a><a href="javascript:;"><i title="下移本题" class="down-icon-active"></i></a></div>
                        </li>

                        <li class="module">
                            <div class="topic_type">
                                <div class="topic_type_menu">
                                    <div class="setup-group">
                                        <h4>Q3</h4>
                                        <a style="display: none;" class="Bub" title="题目设置" href="javascript:;"><i class="setup-icon-active"></i></a><a style="display: none;" class="Bub" title="逻辑设置" href="javascript:;"><i class="link-icon-active"></i></a><a style="display: none;" class="Bub" title="题目复制" href="javascript:;"><i class="copy-icon-active"></i></a><a style="display: none;" class="Del" title="题目删除" href="javascript:;"><i class="del2-icon-active"></i></a>
                                    </div>
                                </div>
                                <div class="topic_type_con">
                                    <div class="Drag_area">
                                        <div class="th4 T_edit q_title" name="question">图片单选题</div>
                                    </div>
                                    <ul class="unstyled Imgli">
                                        <li>
                                            <div class="questionImgBox" name="545a2033f7405b328c3682c0">
                                                <div class="QImgCon">
                                                    <img src="./demo/545a2033f7405b328c3682c0_thumbnail.jpg" orig_width="800" bbox="" maxsrc="/static/img/survey/upload/543a2e85f7405b41c21c51f0/545a2033f7405b328c3682c0.jpg?v=7531ab97bd050c4232192732f9327d09">
                                                </div>
                                                <input id="option_545a2033f7405b328c3682c0" name="radio" value="option_545a2033f7405b328c3682c0" type="radio"><label id="545a2033f7405b328c3682c0" class="T_edit_min" for="" name="option">图片1就会很会发个价格几乎U盾的Uuiyui快就hi就回家回家</label>
                                            </div>
                                        </li>
                                        <li>
                                            <div class="questionImgBox" name="545a2033f7405b328c3682c0">
                                                <div class="QImgCon">
                                                    <img src="./demo/545a2033f7405b328c3682c0_thumbnail.jpg" orig_width="800" bbox="" maxsrc="/static/img/survey/upload/543a2e85f7405b41c21c51f0/545a2033f7405b328c3682c0.jpg?v=7531ab97bd050c4232192732f9327d09">
                                                </div>
                                                <input id="Radio3" name="radio" value="option_545a2033f7405b328c3682c0" type="radio"><label id="Label3" class="T_edit_min" for="" name="option">图片1就会很会发个价格几乎U盾的Uuiyui快就hi就回家回家</label>
                                            </div>
                                        </li>
                                        <li class="dragZone">
                                            <div class="questionImgBox abor">
                                                <div style="display: none;" class="AddQImgCon">
                                                    <div class="uploader">
                                                        <label>
                                                            <input title="Click to add Files" name="files[]" type="file" multiple="multiple" /></label>
                                                    </div>
                                                </div>
                                                <div style="display: block;" class="AddQImgCon_ie">
                                                    <div class="file-box">
                                                        <form id="logo_uploader_form" enctype="multipart/form-data" method="POST" action="">
                                                            <iframe style="left: 0px; top: 0px; width: 100%; height: 100%; filter: alpha(opacity = 0); position: absolute; opacity: 0; -moz-opacity: 0; -khtml-opacity: 0;" id="imgUpload" class="uploadfile" src="./demo/saved_resource.htm"></iframe>
                                                            <div class="WJButton wj_blue smallerfontsize">上传</div>
                                                        </form>
                                                    </div>
                                                </div>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div style="display: none;" class="updown"><a href="javascript:;"><i class="up-icon-active" title="上移本题"></i></a><a href="javascript:;"><i class="down-icon-active" title="下移本题"></i></a></div>
                        </li>

                        <li class="module">
                            <div class="topic_type">
                                <div class="topic_type_menu">
                                    <div class="setup-group">
                                        <h4>Q4</h4>
                                        <a style="display: none;" class="Bub" title="题目设置" href="javascript:;"><i class="setup-icon-active"></i></a><a style="display: none;" class="Bub" title="逻辑设置" href="javascript:;"><i class="link-icon-active"></i></a><a style="display: none;" class="Bub" title="题目复制" href="javascript:;"><i class="copy-icon-active"></i></a><a style="display: none;" class="Del" title="题目删除" href="javascript:;"><i class="del2-icon-active"></i></a>
                                    </div>
                                </div>
                                <div class="topic_type_con">
                                    <div class="Drag_area">
                                        <div class="th4 T_edit q_title" name="question">图片多选题</div>
                                    </div>
                                    <ul class="unstyled Imgli">
                                        <li>
                                            <div id="545a2044f7405b31353e2056" class="questionImgBox">
                                                <div class="QImgCon">
                                                    <img src="./demo/545a2044f7405b31353e2056_thumbnail.jpg" orig_width="800" bbox="" maxsrc="/static/img/survey/upload/543a2e85f7405b41c21c51f0/545a2044f7405b31353e2056.jpg?v=78a3d129ef9c9954c35282a2f1a20db4">
                                                </div>
                                                <input id="option_545a2044f7405b31353e2056" name="checkbox" value="option_545a2044f7405b31353e2056" type="checkbox"><label id="Label4" class="T_edit_min" for="" name="option">图片1</label>
                                            </div>
                                        </li>
                                        <li>
                                            <div id="545a2056f7405b328c3682c7" class="questionImgBox">
                                                <div class="QImgCon">
                                                    <img src="./demo/545a2056f7405b328c3682c7_thumbnail.jpg" orig_width="800" bbox="" maxsrc="/static/img/survey/upload/543a2e85f7405b41c21c51f0/545a2056f7405b328c3682c7.jpg?v=8ac7d059635bc8874e37b90a4b115c99">
                                                </div>
                                                <input id="option_545a2056f7405b328c3682c7" name="checkbox" value="option_545a2056f7405b328c3682c7" type="checkbox"><label id="Label5" class="T_edit_min" for="" name="option">图片2</label>
                                            </div>
                                        </li>
                                        <li class="dragZone">
                                            <div class="questionImgBox abor">
                                                <div style="display: none;" class="AddQImgCon">
                                                    <div class="uploader">
                                                        <label>
                                                            <input title="Click to add Files" name="files[]" type="file" multiple="multiple"></label>
                                                    </div>
                                                </div>
                                                <div style="display: block;" class="AddQImgCon_ie">
                                                    <div class="file-box">
                                                        <form id="Form1" enctype="multipart/form-data" method="POST" action="">
                                                            <iframe style="left: 0px; top: 0px; width: 100%; height: 100%; filter: alpha(opacity = 0); position: absolute; opacity: 0; -moz-opacity: 0; -khtml-opacity: 0;" id="Iframe1" class="uploadfile" src="./demo/saved_resource(1).htm"></iframe>
                                                            <div class="WJButton wj_blue smallerfontsize">上传</div>
                                                        </form>
                                                    </div>
                                                </div>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div style="display: none;" class="updown"><a href="javascript:;"><i class="up-icon-active" title="上移本题"></i></a><a href="javascript:;"><i class="down-icon-active" title="下移本题"></i></a></div>
                        </li>
                        <li class="module" issue="6" oid="545a205cf7405b328c3682c8">
                            <div class="topic_type">
                                <div class="topic_type_menu">
                                    <div class="setup-group">
                                        <h4>Q5</h4>
                                        <a style="display: none;" class="Bub" title="题目设置" href="javascript:;"><i class="setup-icon-active"></i></a><a style="display: none;" class="Bub" title="逻辑设置" href="javascript:;"><i class="link-icon-active"></i></a><a style="display: none;" class="Bub" title="题目复制" href="javascript:;"><i class="copy-icon-active"></i></a><a style="display: none;" class="Del" title="题目删除" href="javascript:;"><i class="del2-icon-active"></i></a>
                                    </div>
                                </div>
                                <div class="topic_type_con">
                                    <div class="Drag_area">
                                        <div class="th4 T_edit q_title" name="question">你最喜欢什么问题呢</div>
                                    </div>
                                    <ul class="unstyled">
                                        <li style="overflow: inherit;">
                                            <div id="545a205cf7405b328c3682c9" class="option_Fill">
                                                <div style="display: none;" class="min_an"><i></i></div>
                                                <input style="width: 300px;" value="" type="text">
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div style="display: none;" class="updown"><a href="javascript:;"><i class="up-icon-active" title="上移本题"></i></a><a href="javascript:;"><i class="down-icon-active" title="下移本题"></i></a></div>
                        </li>

                        <li class="module" issue="6" oid="545a206cf7405b328c3682cb">
                            <div class="topic_type">
                                <div class="topic_type_menu">
                                    <div class="setup-group">
                                        <h4>Q6</h4>
                                        <a style="display: none;" class="Bub" title="题目设置" href="javascript:;"><i class="setup-icon-active"></i></a><a style="display: none;" class="Bub" title="逻辑设置" href="javascript:;"><i class="link-icon-active"></i></a><a style="display: none;" class="Bub" title="题目复制" href="javascript:;"><i class="copy-icon-active"></i></a><a style="display: none;" class="Del" title="题目删除" href="javascript:;"><i class="del2-icon-active"></i></a>
                                    </div>
                                </div>
                                <div class="topic_type_con">
                                    <div class="Drag_area">
                                        <div class="th4 T_edit q_title" name="question">你对过年有什么看法吗?</div>
                                    </div>
                                    <ul class="unstyled">
                                        <li style="overflow: inherit;">
                                            <div id="545a206cf7405b328c3682cc" class="option_Fill">
                                                <div style="display: none;" class="min_an"><i></i></div>
                                                <textarea cols="40" rows="5" type="text"></textarea>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div style="display: none;" class="updown"><a href="javascript:;"><i class="up-icon-active" title="上移本题"></i></a><a href="javascript:;"><i class="down-icon-active" title="下移本题"></i></a></div>
                        </li>
                        <li class="module" issue="60" oid="545a207ff7405b31353e2068">
                            <div class="topic_type">
                                <div class="topic_type_menu">
                                    <div class="setup-group">
                                        <h4>Q7</h4>
                                        <a style="display: none;" class="Bub" title="题目设置" href="javascript:;"><i class="setup-icon-active"></i></a><a style="display: none;" class="Bub" title="逻辑设置" href="javascript:;"><i class="link-icon-active"></i></a><a style="display: none;" class="Bub" title="题目复制" href="javascript:;"><i class="copy-icon-active"></i></a><a style="display: none;" class="Del" title="题目删除" href="javascript:;"><i class="del2-icon-active"></i></a>
                                    </div>
                                </div>
                                <div class="topic_type_con">
                                    <div class="Drag_area">
                                        <div class="th4 T_edit q_title" name="question">你喜欢什么运动?</div>
                                    </div>
                                    <div class="pxul">
                                        <ul class="unstyled Sorting">
                                            <li>
                                                <label id="545a207ff7405b31353e2069" class="T_edit_min" name="option">足球</label></li>
                                            <li>
                                                <label id="545a207ff7405b31353e206a" class="T_edit_min" name="option">篮球</label></li>
                                            <li>
                                                <label id="545a20a6f7405b31ef32a19a" class="T_edit_min" name="option">水球</label></li>
                                            <li>
                                                <label id="545a20adf7405b31624dedbe" class="T_edit_min" name="option">气球</label></li>
                                        </ul>
                                        <div class="sort-right">
                                            <table class="table2">
                                                <tbody>
                                                    <tr>
                                                        <th class="w28">1</th>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <th class="w28">2</th>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <th class="w28">3</th>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <th class="w28">4</th>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="operationH"><a style="display: none;" href="javascript:;"><i class="add-icon-active" title="添加选项"></i></a><a style="display: none;" class="Bub" title="批量添加" href="javascript:;"><i class="clone-icon-active"></i></a></div>
                                    <p class="mt10">请将左面的项拖放到右面的框完成排序</p>
                                </div>
                            </div>
                            <div style="display: none;" class="updown"><a href="javascript:;"><i class="up-icon-active" title="上移本题"></i></a><a href="javascript:;"><i class="down-icon-active" title="下移本题"></i></a></div>
                        </li>
                        <li class="module" issue="50" oid="545a20b5f7405b30bd1df6fc" maxnum="5" minnum="1">
                            <div class="topic_type">
                                <div class="topic_type_menu">
                                    <div class="setup-group">
                                        <h4>Q8</h4>
                                        <a style="display: none;" class="Bub" title="题目设置" href="javascript:;"><i class="setup-icon-active"></i></a><a style="display: none;" class="Bub" title="逻辑设置" href="javascript:;"><i class="link-icon-active"></i></a><a style="display: none;" class="Bub" title="题目复制" href="javascript:;"><i class="copy-icon-active"></i></a><a style="display: none;" class="Del" title="题目删除" href="javascript:;"><i class="del2-icon-active"></i></a>
                                    </div>
                                </div>
                                <div class="topic_type_con">
                                    <div class="Drag_area">
                                        <div class="th4 T_edit q_title" name="question">程序员的工作效率</div>
                                    </div>
                                    <div class="grade">
                                        <table cellspacing="0" cellpadding="0">
                                            <thead>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <table style="width: 400px; margin-left: 20px;">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 116px;">&nbsp;</td>
                                                                    <td style="width: 116px;" align="center">&nbsp;</td>
                                                                    <td style="width: 116px;" align="right">&nbsp;</td>
                                                                    <td width="50"></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr class="Ed_tr">
                                                    <td id="545a20b5f7405b30bd1df6fd" class="T_edit_td" align="right" name="option">很高效</td>
                                                    <td>
                                                        <table style="width: 400px;">
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <div class="grade_text">
                                                                            <table class="topic_ul" border="0" cellspacing="0" cellpadding="1">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td class="div_float">1</td>
                                                                                        <td class="div_float">2</td>
                                                                                        <td class="div_float">3</td>
                                                                                        <td class="div_float">4</td>
                                                                                        <td class="div_float">5</td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </div>
                                                                    </td>
                                                                    <td width="30" align="right">分</td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr class="Ed_tr">
                                                    <td id="545a20b5f7405b30bd1df6fe" class="T_edit_td" align="right" name="option">很不好了</td>
                                                    <td>
                                                        <table style="width: 400px;">
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <div class="grade_text">
                                                                            <table class="topic_ul" border="0" cellspacing="0" cellpadding="1">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td class="div_float">1</td>
                                                                                        <td class="div_float">2</td>
                                                                                        <td class="div_float">3</td>
                                                                                        <td class="div_float">4</td>
                                                                                        <td class="div_float">5</td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </div>
                                                                    </td>
                                                                    <td width="30" align="right">分</td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr class="Ed_tr">
                                                    <td id="545a20fff7405b30e48d0a41" class="T_edit_td" align="right" name="option">这是什么玩意</td>
                                                    <td>
                                                        <table style="width: 400px;">
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <div class="grade_text">
                                                                            <table class="topic_ul" border="0" cellspacing="0" cellpadding="1">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td class="div_float">1</td>
                                                                                        <td class="div_float">2</td>
                                                                                        <td class="div_float">3</td>
                                                                                        <td class="div_float">4</td>
                                                                                        <td class="div_float">5</td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </div>
                                                                    </td>
                                                                    <td width="30" align="right">分</td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="operationH"><a style="display: none;" href="javascript:;"><i class="add-icon-active" title="添加选项"></i></a><a style="display: none;" class="Bub" title="批量添加" href="javascript:;"><i class="clone-icon-active"></i></a></div>
                                </div>
                            </div>
                            <div style="display: none;" class="updown"><a href="javascript:;"><i class="up-icon-active" title="上移本题"></i></a><a href="javascript:;"><i class="down-icon-active" title="下移本题"></i></a></div>
                        </li>
                        <li class="module" issue="4" oid="545a210ff7405b31ef32a1ac">
                            <div class="topic_type">
                                <div class="topic_type_menu">
                                    <div class="setup-group">
                                        <h4>Q9</h4>
                                        <a style="display: none;" class="Bub" title="题目设置" href="javascript:;"><i class="setup-icon-active"></i></a><a style="display: none;" class="Bub" title="逻辑设置" href="javascript:;"><i class="link-icon-active"></i></a><a style="display: none;" class="Bub" title="题目复制" href="javascript:;"><i class="copy-icon-active"></i></a><a style="display: none;" class="Del" title="题目删除" href="javascript:;"><i class="del2-icon-active"></i></a>
                                    </div>
                                </div>
                                <div class="topic_type_con">
                                    <div class="Drag_area">
                                        <div class="th4 T_edit q_title" name="question">中国共产党的性质</div>
                                    </div>
                                    <ul class="unstyled">
                                        <li>
                                            <div class="matrix">
                                                <table style="width: 682px;" class="table table-bordered td-Tc" cellspacing="0" cellpadding="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 165px;" width="136">&nbsp;</td>
                                                            <td style="width: 206px;" id="545a210ff7405b31ef32a1ad" class="T_edit_td" width="109" name="option" menutype="col">一般般</td>
                                                            <td style="width: 308px;" id="545a210ff7405b31ef32a1ae" class="T_edit_td" width="109" name="option" menutype="col">贪污腐败</td>
                                                        </tr>
                                                        <tr class="Ed_tr">
                                                            <td style="width: 165px; text-align: left;" id="545a210ff7405b31ef32a1af" class="T_edit_td" name="row" menutype="row">矩阵行1</td>
                                                            <td style="width: 206px;">
                                                                <div style="width: 206px;" class="div">
                                                                    <div style="width: 206px;" class="div">
                                                                        <input type="radio">
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td style="width: 308px;">
                                                                <div style="width: 308px;" class="div">
                                                                    <div style="width: 308px;" class="div">
                                                                        <input type="radio">
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr class="Ed_tr">
                                                            <td style="width: 165px; text-align: left;" id="545a210ff7405b31ef32a1b0" class="T_edit_td" name="row" menutype="row">矩阵行2</td>
                                                            <td style="width: 206px;">
                                                                <div style="width: 206px;" class="div">
                                                                    <div style="width: 206px;" class="div">
                                                                        <input type="radio">
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td style="width: 308px;">
                                                                <div style="width: 308px;" class="div">
                                                                    <div style="width: 308px;" class="div">
                                                                        <input type="radio">
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr class="Ed_tr">
                                                            <td style="width: 165px; text-align: left;" id="545a2123f7405b319eff0ce3" class="T_edit_td" name="row" menutype="row">执政理念</td>
                                                            <td style="width: 206px;">
                                                                <div style="width: 206px;" class="div">
                                                                    <div style="width: 206px;" class="div">
                                                                        <input type="radio">
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td style="width: 308px;">
                                                                <div style="width: 308px;" class="div">
                                                                    <div style="width: 308px;" class="div">
                                                                        <input type="radio">
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                            <div class="operationV"><a style="display: none;" href="javascript:;"><i class="add-icon-active" title="添加选项"></i></a><a style="display: none;" class="Bub" title="批量添加" href="javascript:;"><i class="clone-icon-active"></i></a></div>
                                        </li>
                                        <li>
                                            <div class="operationH">
                                                <div class="GetWidthMatrix"><a style="display: none;" href="javascript:;">调整列宽</a></div>
                                                <a style="display: none;" href="javascript:;"><i class="add-icon-active" title="添加选项"></i></a><a style="display: none;" class="Bub" title="批量添加" href="javascript:;"><i class="clone-icon-active"></i></a>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div style="display: none;" class="updown"><a href="javascript:;"><i class="up-icon-active" title="上移本题"></i></a><a href="javascript:;"><i class="down-icon-active" title="下移本题"></i></a></div>
                        </li>

                        <li class="module" issue="100" oid="545a2164f7405b31624deddf">
                            <div class="topic_type">
                                <div class="topic_type_menu">
                                    <div class="setup-group">
                                        <h4>Q11</h4>
                                        <a style="display: none;" class="Bub" title="题目设置" href="javascript:;"><i class="setup-icon-active"></i></a><a style="display: none;" class="Bub" title="逻辑设置" href="javascript:;"><i class="link-icon-active"></i></a><a style="display: none;" class="Bub" title="题目复制" href="javascript:;"><i class="copy-icon-active"></i></a><a style="display: none;" class="Del" title="题目删除" href="javascript:;"><i class="del2-icon-active"></i></a>
                                    </div>
                                </div>
                                <div class="topic_type_con">
                                    <div class="Drag_area">
                                        <div class="th4 T_edit q_title" name="question">矩阵填空题</div>
                                    </div>
                                    <ul class="unstyled">
                                        <li>
                                            <div class="matrix">
                                                <table class="table table-bordered td-Tc" cellspacing="0" cellpadding="0">
                                                    <tbody>
                                                        <tr>
                                                            <td width="142">&nbsp;</td>
                                                            <td id="545a2164f7405b31624dede0" class="T_edit_td" width="114" name="option" menutype="col">请填空1</td>
                                                            <td id="545a2164f7405b31624dede1" class="T_edit_td" width="114" name="option" menutype="col">请填空2</td>
                                                        </tr>
                                                        <tr class="Ed_tr">
                                                            <td style="text-align: left;" id="545a2164f7405b31624dede2" class="T_edit_td" name="row" menutype="row">矩阵行1</td>
                                                            <td>
                                                                <textarea cols="20" rows="1"></textarea></td>
                                                            <td>
                                                                <textarea cols="20" rows="1"></textarea></td>
                                                        </tr>
                                                        <tr class="Ed_tr">
                                                            <td style="text-align: left;" id="545a2164f7405b31624dede3" class="T_edit_td" name="row" menutype="row">矩阵行2</td>
                                                            <td>
                                                                <textarea cols="20" rows="1"></textarea></td>
                                                            <td>
                                                                <textarea cols="20" rows="1"></textarea></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                            <div class="operationV"><a style="display: none;" href="javascript:;"><i class="add-icon-active" title="添加选项"></i></a><a style="display: none;" class="Bub" title="批量添加" href="javascript:;"><i class="clone-icon-active"></i></a></div>
                                        </li>
                                        <li>
                                            <div class="operationH">
                                                <div class="GetWidthMatrix"><a style="display: none;" href="javascript:;">调整列宽</a></div>
                                                <a style="display: none;" href="javascript:;"><i class="add-icon-active" title="添加选项"></i></a><a style="display: none;" class="Bub" title="批量添加" href="javascript:;"><i class="clone-icon-active"></i></a>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div style="display: none;" class="updown"><a href="javascript:;"><i class="up-icon-active" title="上移本题"></i></a><a href="javascript:;"><i class="down-icon-active" title="下移本题"></i></a></div>
                        </li>
                        <li class="module paging" name="page">
                            <div class="topic_type">
                                <div class="topic_type_menu">
                                    <div class="setup-group"><a style="display: none;" class="DelPaging" title="删除分页" href="javascript:;"><i class="del2-icon-active"></i></a></div>
                                </div>
                                <div class="topic_type_con">
                                    <div style="margin: 0px;" class="Drag_area">
                                        <div class="icon_paging"></div>
                                        <div class="fr con_paging">页码：<span>1/3</span></div>
                                    </div>
                                </div>
                            </div>
                            <div style="display: none;" class="updown"><a href="javascript:;"><i class="up-icon-active"></i></a><a href="javascript:;"><i class="down-icon-active"></i></a></div>
                        </li>
                    </ul>
                </div>
            </div>
            <!--/.row-fluid-->
        </div>
    </div>
</body>
</html>
