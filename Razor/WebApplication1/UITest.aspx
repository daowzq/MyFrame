<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UITest.aspx.cs" Inherits="WebApplication1.UITest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/mycss.css" rel="stylesheet" />
    <link href="css/gototop.css" rel="stylesheet" />
    <title></title>
    <script src="js/jquery-1.6.1.js"></script>
    <script src="SurveyUI/jquery-migrate-1.2.1.js"></script>
    <script src="js/JqueryUI/js/jquery-ui-1.10.4.custom.js"></script>
    <link href="js/layer/skin/layer.css" rel="stylesheet" />
    <script src="js/layer/layer.min.js"></script>
    <script src="js/surveyTemplate.js"></script>
    <script src="js/common.js"></script>
    <style type="text/css">
        .uploader input[type='file'] {
            display: none;
        }
        .topmenue {
            width: 990px;
            position: fixed;
            display: block;
            top: 0px;
            z-index: 9999;
            height: 65px;
            border: solid 1px red;
            background-color:#1c658b;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            //菜单切换
            $(".accordion-group h4").click(function () {
                $(this).find('i').toggleClass("icon_on");
                $(this).siblings("h4").find('i').removeClass("icon_on");
                $(this).next("ul").slideToggle("slow").siblings("ul:visible").slideUp("slow");
            });
            //回到顶部
            $(".gotoTop a").first().css({ "visibility": "hidden" });
            $(window).scroll(function () {
                if ($(window).scrollTop() > 100) {
                    $(".gotoTop a").first().css({ "visibility": "visible" });
                } else {
                    $(".gotoTop a").first().css({ "visibility": "hidden" });
                }
            });
            $('.gotoTop a:first').live('click', function () {
                $('html,body').animate({
                    scrollTop: 0
                }, 'slow')
            });

            //题型设置
            $(".moduleL").draggable({
                helper: "clone",
                appendTo: '.rows2',
                connectToSortable: ".dragwen",
                start: function (event, ui) {
                    var questionType = ui.helper.attr("name");
                    ui.helper.html('').css({
                        'height': 'auto'
                    }).addClass('anbx').append(QUESTIONMAP[questionType]);
                },
                stop: function (event, ui) {
                    //这里先执行
                },
                opacity: 0,
                revert: "invalid",
                scroll: true
            });

            //题型排序
            var sotIndex = 0;   //当前题项所在位置
            $(".dragwen").sortable({
                //containment:".dragwen",
                snap: true,
                delay: 100,
                opacity: 0.9,
                scrollSensitivity: 160,
                tolerance: 'pointer',
                handle: '.Drag_area',
                placeholder: "ui-sortable-placeholder",//拖拽时的样式
                start: function (event, ui) {

                },
                sort: function (event, ui) {
                    sotIndex = $(this).children().index(ui.placeholder)
                },
                receive: function (event, ui) {

                },
                stop: function (event, ui) {
                    var _this = $(".dragwen");
                    var questMenue = _this.find('.moduleL');
                    var length = _this.find('.module').length;//32

                    //是拖拽菜单
                    if (questMenue.length >= 1) {
                        var questType = questMenue.attr("name");  //问题类型
                        questMenue.remove();                      // 移除自身
                        $(QUESTIONMAP[questType]).prependTo(_this); //添加题型
                        // alert(sotIndex)
                    }
                },
                revert: true
            });
        });
    </script>
</head>
<body>
    <div class="wjContent">
        <div id="topmenue" class="topmenue">
        </div>
        <div class="container-fluid">

            <div class="row-fluid">
                <!--/.wentop-->
                <div class="rows1">
                    <div class="well sidebar-nav affix-top" id="accordion1">
                        <div class="accordion-group">
                            <h4 class="tc">
                                <a href="javascript:;">题型设置
                                    <i class="icon_on"></i>
                                </a>
                            </h4>
                            <ul class="ul-tool collapse">
                                <li class="moduleL ui-draggable" name="SINGLE">
                                    <a href="javascript:;">
                                        <i class="basic-too11-icon-active"></i>
                                        单选题
                                    </a>
                                </li>
                                <li class="moduleL ui-draggable" name="MUTIPLE">
                                    <a href="javascript:;">
                                        <i class="basic-too12-icon-active"></i>
                                        多选题
                                    </a>
                                </li>
                                <li class="moduleL ui-draggable" name="IMGSINGLE">
                                    <a href="javascript:;">
                                        <i class="basic-too2013-icon-active"></i>
                                        图片单选题
                                    </a>
                                </li>
                                <li class="moduleL ui-draggable" name="IMGMULTIPLE">
                                    <a href="javascript:;">
                                        <i class="basic-too2014-icon-active"></i>
                                        图片多选题
                                    </a>
                                </li>
                                <li class="moduleL ui-draggable" name="BLANK">
                                    <a href="javascript:;">
                                        <i class="basic-too13-icon-active"></i>
                                        单行填空题
                                    </a>
                                </li>
                                <li class="moduleL ui-draggable" name="MULTIPLE_BLANK">
                                    <a href="javascript:;">
                                        <i class="basic-too200-icon-active"></i>
                                        多行填空题
                                    </a>
                                </li>
                                <li class="moduleL ui-draggable" name="Multi_Line_blank">
                                    <a href="javascript:;">
                                        <i class="basic-too16-icon-active"></i>
                                        多项填空题
                                    </a>
                                </li>
                                <li class="moduleL ui-draggable" name="ORDER">
                                    <a href="javascript:;">
                                        <i class="basic-too15-icon-active"></i>
                                        排序题
                                    </a>
                                </li>
                                <li class="moduleL ui-draggable" name="SCORE">
                                    <a href="javascript:;">
                                        <i class="basic-too14-icon-active"></i>
                                        打分题
                                    </a>
                                </li>
                                <li class="moduleL ui-draggable" name="MATRIX_SINGLE">
                                    <a href="javascript:;">
                                        <i class="basic-too17-icon-active"></i>
                                        矩阵单选题
                                    </a>
                                </li>
                                <li class="moduleL ui-draggable" name="MATRIX_MULTIPLE">
                                    <a href="javascript:;">
                                        <i class="basic-too18-icon-active"></i>
                                        矩阵多选题
                                    </a>
                                </li>
                                <li class="moduleL ui-draggable" name="MATRIX_BLANK">
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
                                <a href="javascript:;">我的题型
                                   
                                    <i class=""></i>
                                </a>
                            </h4>
                            <ul id="common" class="ul-tool collapse" style="display: none;">
                                <li class="moduleL ui-draggable" name="APPEND_TXT">
                                    <a href="javascript:;">
                                        <i class=""></i>
                                        补充说明1
                                    </a>
                                </li>
                                <li class="moduleL ui-draggable" name="APPEND_TXTAREA">
                                    <a href="javascript:;">
                                        <i class=""></i>
                                        补充说明2
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <!--/.rows1-->
                <div class="rows2 well2 Tj">
                    <div class="gotoTop" style="">
                        <a href="javascript:;" title="回到顶部" style="background: url(images/top_hj.png) no-repeat scroll 0px 0px transparent;"></a>
                        <a href="javascript:;" title="微信关注" style="background: url(images/wxpic.jpg) no-repeat scroll 0px 0px transparent;"></a>
                    </div>
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
                                        <div class="th4 T_edit q_title">单选题</div>
                                    </div>
                                    <ul class="unstyled ">
                                        <li style="">
                                            <input type="radio" /><label class="T_edit_min" for="">选项1</label></li>
                                        <li style="">
                                            <input type="radio" /><label class="T_edit_min" for="">选项2</label>
                                            <input type="text" style="margin-left: 2px; border: 0; border-bottom: 1px solid black; background: #fff;" />
                                        </li>
                                        <li style="margin-top: 5px;">
                                            <span style="display: block; margin-top: 2px">其他建议：</span>
                                            <textarea style="margin-top: 5px; width: 230px;" rows="3"></textarea>
                                        </li>
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
                                            <input type="checkbox" /><label class="T_edit_min" for="" id="Label1">选项1</label></li>
                                        <li style="">
                                            <input type="checkbox" /><label class="T_edit_min" for="" id="Label2">选项2</label></li>
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
                                            <div class="questionImgBox">
                                                <div class="QImgCon">
                                                    <img src="./demo/545a2033f7405b328c3682c0_thumbnail.jpg" />
                                                </div>
                                                <input name="radio" type="radio" /><label class="T_edit_min" for="">图片1</label>
                                            </div>
                                        </li>
                                        <li>
                                            <div class="questionImgBox">
                                                <div class="QImgCon">
                                                    <img src="./demo/545a2033f7405b328c3682c0_thumbnail.jpg">
                                                </div>
                                                <input id="Radio3" name="radio" type="radio" />
                                                <label id="Label3" class="T_edit_min" for="">图片1</label>
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
                                                <div style="display: block;" class="AddQImgCon">
                                                    <div class="file-box">
                                                        <form id="logo_uploader_form" enctype="multipart/form-data" method="POST" action="">
                                                            <iframe style="left: 0px; top: 0px; width: 100%; height: 100%; filter: alpha(opacity = 0); position: absolute; opacity: 0; -moz-opacity: 0; -khtml-opacity: 0;" id="imgUpload" class="uploadfile" src="./demo/saved_resource.htm"></iframe>
                                                            <div class="WJButton wj_blue">上传</div>
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
                                            <div class="questionImgBox">
                                                <div class="QImgCon">
                                                    <img src="./demo/545a2056f7405b328c3682c7_thumbnail.jpg" />
                                                </div>
                                                <input type="checkbox" /><label id="Label4" class="T_edit_min" for="" name="option">图片1</label>
                                            </div>
                                        </li>
                                        <li>
                                            <div class="questionImgBox">
                                                <div class="QImgCon">
                                                    <img src="./demo/545a2056f7405b328c3682c7_thumbnail.jpg" />
                                                </div>
                                                <input name="checkbox" type="checkbox" /><label id="Label5" class="T_edit_min" for="" name="option">图片2</label>
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
                                                            <div class="WJButton wj_blue ">上传</div>
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
                                        <h4>Q5</h4>
                                        <a style="display: none;" class="Bub" title="题目设置" href="javascript:;"><i class="setup-icon-active"></i></a><a style="display: none;" class="Bub" title="逻辑设置" href="javascript:;"><i class="link-icon-active"></i></a><a style="display: none;" class="Bub" title="题目复制" href="javascript:;"><i class="copy-icon-active"></i></a><a style="display: none;" class="Del" title="题目删除" href="javascript:;"><i class="del2-icon-active"></i></a>
                                    </div>
                                </div>
                                <div class="topic_type_con">
                                    <div class="Drag_area">
                                        <div class="th4 T_edit q_title">你最喜欢什么问题呢</div>
                                    </div>
                                    <ul class="unstyled">
                                        <li style="overflow: inherit;">
                                            <div class="option_Fill">
                                                <div style="display: none;" class="min_an"><i></i></div>
                                                <input style="width: 300px; height: 30px;" value="" type="text" />
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
                                            <div class="option_Fill">
                                                <div style="display: none;" class="min_an"><i></i></div>
                                                <textarea cols="40" rows="5" style="border: solid 1px #dbdbdb;" type="text"></textarea>
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
                                        <h4>Q7</h4>
                                        <a style="display: none;" class="Bub" title="题目设置" href="javascript:;"><i class="setup-icon-active"></i></a><a style="display: none;" class="Bub" title="逻辑设置" href="javascript:;"><i class="link-icon-active"></i></a><a style="display: none;" class="Bub" title="题目复制" href="javascript:;"><i class="copy-icon-active"></i></a><a style="display: none;" class="Del" title="题目删除" href="javascript:;"><i class="del2-icon-active"></i></a>
                                    </div>
                                </div>
                                <div class="topic_type_con">
                                    <div class="Drag_area">
                                        <div class="th4 T_edit q_title">你喜欢什么运动?</div>
                                    </div>
                                    <div class="pxul">
                                        <ul class="unstyled Sorting">
                                            <li>
                                                <label class="T_edit_min" name="option">足球</label></li>
                                            <li>
                                                <label class="T_edit_min" name="option">篮球</label></li>
                                            <li>
                                                <label class="T_edit_min" name="option">水球</label></li>
                                            <li>
                                                <label class="T_edit_min" name="option">气球</label></li>
                                        </ul>
                                        <div class="sort-right">
                                            <table class="table2">
                                                <tbody>
                                                    <tr>
                                                        <th>1</th>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <th>2</th>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <th>3</th>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <th>4</th>
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

                        <li class="module">
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
                                                    <td class="T_edit_td" align="right" name="option">很高效</td>
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
                                                    <td class="T_edit_td" align="right" name="option">很不好了</td>
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
                                                    <td class="T_edit_td" align="right" name="option">这是什么玩意</td>
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

                        <li class="module">
                            <div class="topic_type">
                                <div class="topic_type_menu">
                                    <div class="setup-group">
                                        <h4>Q9</h4>
                                        <a style="display: none;" class="Bub" title="题目设置" href="javascript:;"><i class="setup-icon-active"></i></a><a style="display: none;" class="Bub" title="逻辑设置" href="javascript:;"><i class="link-icon-active"></i></a><a style="display: none;" class="Bub" title="题目复制" href="javascript:;"><i class="copy-icon-active"></i></a><a style="display: none;" class="Del" title="题目删除" href="javascript:;"><i class="del2-icon-active"></i></a>
                                    </div>
                                </div>
                                <div class="topic_type_con">
                                    <div class="Drag_area">
                                        <div class="th4 T_edit q_title" name="question">关于节假日安排你的意见</div>
                                    </div>
                                    <ul class="unstyled">
                                        <li>
                                            <div class="matrix">
                                                <table style="width: 682px;" class="table table-bordered td-Tc" cellspacing="0" cellpadding="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 165px;">&nbsp;</td>
                                                            <td style="width: 206px;" class="T_edit_td">一般般</td>
                                                            <td style="width: 308px;" class="T_edit_td">贪污腐败</td>
                                                        </tr>
                                                        <tr class="Ed_tr">
                                                            <td style="width: 165px; text-align: left;" class="T_edit_td" name="row" menutype="row">矩阵行1</td>
                                                            <td style="width: 206px;">
                                                                <div style="width: 206px;" class="div">
                                                                    <div style="width: 206px;" class="div">
                                                                        <input type="radio" />
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td style="width: 308px;">
                                                                <div style="width: 308px;" class="div">
                                                                    <div style="width: 308px;" class="div">
                                                                        <input type="radio" />
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr class="Ed_tr">
                                                            <td style="width: 165px; text-align: left;" class="T_edit_td" name="row" menutype="row">矩阵行2</td>
                                                            <td style="width: 206px;">
                                                                <div style="width: 206px;" class="div">
                                                                    <div style="width: 206px;" class="div">
                                                                        <input type="radio" />
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td style="width: 308px;">
                                                                <div style="width: 308px;" class="div">
                                                                    <div style="width: 308px;" class="div">
                                                                        <input type="radio" />
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr class="Ed_tr">
                                                            <td style="width: 165px; text-align: left;" class="T_edit_td" name="row" menutype="row">执政理念</td>
                                                            <td style="width: 206px;">
                                                                <div style="width: 206px;" class="div">
                                                                    <div style="width: 206px;" class="div">
                                                                        <input type="radio" />
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td style="width: 308px;">
                                                                <div style="width: 308px;" class="div">
                                                                    <div style="width: 308px;" class="div">
                                                                        <input type="radio" />
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

                        <li class="module">
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
                                                            <td class="T_edit_td" width="114" name="option" menutype="col">请填空1</td>
                                                            <td class="T_edit_td" width="114" name="option" menutype="col">请填空2</td>
                                                        </tr>
                                                        <tr class="Ed_tr">
                                                            <td style="text-align: left;" class="T_edit_td" name="row" menutype="row">矩阵行1</td>
                                                            <td>
                                                                <textarea cols="20" rows="1"></textarea></td>
                                                            <td>
                                                                <textarea cols="20" rows="1"></textarea></td>
                                                        </tr>
                                                        <tr class="Ed_tr">
                                                            <td style="text-align: left;" class="T_edit_td" name="row" menutype="row">矩阵行2</td>
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
