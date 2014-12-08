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
                    var questionType = ui.helper.find("a").text().trim();
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

            $(".dragwen").sortable({
                //containment:".dragwen",
                //axis:'y',
                snap: true,
                delay: 100,
                opacity: 0.9,
                scrollSensitivity: 160,
                tolerance: 'pointer',
                handle: '.Drag_area',
                start: function () {
                },
                sort: function (event, ui) {

                },
                receive: function (event, ui) {

                },
                stop: function (event, ui) {
                    var _this = $(".dragwen");
                    _this.find('.moduleL').remove();// 移除

                    // $(add_topic2(id, this_.t_wz, this_.paging_m)).prependto(_this);
                },
                revert: true
            });
        });

    </script>
</head>
<body>
    <div class="wjContent">
        <div class="container-fluid">
            <div class="row-fluid">
                <!--/.wentop-->
                <div class="rows1">
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
                                                    <img src="./demo/545a2033f7405b328c3682c0_thumbnail.jpg" orig_width="800" bbox="">
                                                </div>
                                                <input id="option_545a2033f7405b328c3682c0" name="radio" value="option_545a2033f7405b328c3682c0" type="radio"><label id="545a2033f7405b328c3682c0" class="T_edit_min" for="" name="option">图片1就会很会发个价格几乎U盾的Uuiyui快就hi就回家回家</label>
                                            </div>
                                        </li>
                                        <li>
                                            <div class="questionImgBox" name="545a2033f7405b328c3682c0">
                                                <div class="QImgCon">
                                                    <img src="./demo/545a2033f7405b328c3682c0_thumbnail.jpg" orig_width="800" bbox="">
                                                </div>
                                                <input id="Radio3" name="radio" value="option_545a2033f7405b328c3682c0" type="radio" />
                                                <label id="Label3" class="T_edit_min" for="" name="option">图片1就会很会发个价格几乎U盾的Uuiyui快就hi就回家回家</label>
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
                                                <input style="width: 300px; height: 30px;" value="" type="text">
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
                                                <textarea cols="40" rows="5" style="border: solid 1px rgb(219,219,219);" type="text"></textarea>
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
                                        <div class="th4 T_edit q_title" name="question">关于节假日安排你的意见</div>
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
