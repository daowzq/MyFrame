<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UITest.aspx.cs" Inherits="WebApplication1.UITest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/mycss.css" rel="stylesheet" />
    <link href="css/gototop.css" rel="stylesheet" />
    <title></title>
    <script src="js/jquery-1.9.1.js"></script>
    <script src="js/jquery-migrate-1.2.1.js"></script>
    <script src="js/JqueryUI/js/jquery-ui-1.10.4.custom.js"></script>
    <link href="js/layer/skin/layer.css" rel="stylesheet" />
    <script src="js/layer/layer.min.js"></script>
    <script src="js/surveyTemplate.js"></script>
    <script src="js/common.js"></script>
    <script type="text/javascript" src="js/ckeditor.js"></script>
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


            //问题选型排序
            $(".unstyled").sortable({
                tolerance: 'pointer',
                placeholder: "ui-sortable-sub-placeholder",
                items: "li:not(.ui-state-disabled)", //排除选项
                delay: 100,
                opacity: 0.9,
                start: function (event, ui) {
                    //图片项
                    if (ui.helper.parent().hasClass("Imgli")) {
                        //  ui - sortable - sub - placeholder 
                        var itemWidth = ui.helper.width() + 1;
                        var itemHeight = ui.helper.height() + 1;
                        ui.placeholder.attr("class", "ui-img-placeholder").css({ "width": itemWidth + "px", "height": itemHeight })
                    }
                }
            });
            // $(".unstyled").disableSelection();//因为要选中，尽量设置文字不选中

            //补充说明项放置
            $(".moduled[name='append_txt']").draggable({
                helper: "clone",
                start: function (event, ui) {
                    var questiontype = ui.helper.attr("name");
                    ui.helper.html('').css({
                        'height': 'auto'
                    }).addclass("anbx-sub").append(questionmap[questiontype]);
                }
            });

            //题目设置
            //显示设置
            $('.dragwen .module').live("mouseover", function () {

                $(this).find('.setup-group a,.updown,.operationH a,.operationV a').show();

            }).live('mouseout', function () {
                $(this).find('.setup-group a,.updown,.operationH a,.operationV a').hide()
            });


            //上下移动
            $('.up-icon-active').live('click', function () {
                var $obj = $(this).parents('li');
                var index = $('.dragwen > li').index($obj);

                if (index === 0) {
                    layer.msg('已经第一道题', 1, 0);
                    return;
                }

                $(".dragwen").find('.module:eq(' + (index - 1) + ')').before($obj[0]);
                $("html,body").animate({
                    scrollTop: ($obj.offset().top - 100)
                }, 'slow');
            });

            $('.down-icon-active').live('click', function () {

                var $obj = $(this).parents('li');
                var sortIndex = $(".dragwen> li").index($obj);
                var length = $(".dragwen .module").length - 1;

                if (sortIndex === length) {
                    layer.msg('已经是最后一道题', 1, 0);
                    return;
                }

                $(".dragwen").find('.module:eq(' + (sortIndex + 1) + ')').after($obj[0]);

                if ($obj.offset().top !== 0) {
                    $("html,body").animate({
                        scrollTop: ($obj.offset().top - 100)
                    }, 'slow');
                }
            });



            //文字编辑

            function TextEdit() {
                this.obj = ''; //被编辑对象
                this.parentCon = {}; //编辑框
                this.addEdit = {}; //编辑框内容
                this.button = {}; //菜单按钮 
                this.fast_machine = {}; //快速操作按钮
                this.html = '';
                this.editor = ''; //FCK编辑器状态
                this.Tinfo = {};
                this.type = '';
                this.id = '';
                this.option_id = '';
                this.Cw = '';
            }

            TextEdit.prototype = {
                //标题类型编辑
                T_edit: function () {
                    var _this = this;

                    $('.T_edit').live('click', function () {

                    });
                },

                //li结构编辑
                T_edit_li: function () {


                },
                //td结构编辑
                T_edit_td: function () {


                },
                //保存编辑
                Save_title: function () {

                },
                //生成标准编辑框
                ConEdit: function (obj, menu_list) {


                },
                //生成小号编辑框
                ConEdit_min: function (obj, menu_list) {
                },
                //粘贴内容格式去除
                GetRidFormat: function (obj) {

                    EventUtil.addHandler(obj[0], "paste", function (event) {

                        setTimeout(function () {
                            var html = obj.html();
                            html = html.replace(/<\/?[^>(IMG)(img)][^>]*>/g, '');
                            obj.html(html);
                        }, 50);

                    });

                    function DgContents(htt) {

                        htt = htt.replace(/<\/?SPAN[^>]*>/gi, "");
                        htt = htt.replace(/<(\w[^>]*) class=([^ |>]*)([^>]*)/gi, "<$1$3");
                        htt = htt.replace(/<(\w[^>]*) style="([^"]*)"([^>]*)/gi, "<$1$3");
                        htt = htt.replace(/<(\w[^>]*) lang=([^ |>]*)([^>]*)/gi, "<$1$3");
                        htt = htt.replace(/<\\?\?xml[^>]*>/gi, "");
                        htt = htt.replace(/<\/?\w+:[^>]*>/gi, "");
                        htt = htt.replace(/&nbsp;/, " ");
                        var re = new RegExp("(<P)([^>]*>.*?)(<\/P>)", "gi"); // Different because of a IE 5.0 error
                        htt = htt.replace(re, "<div$2</div>");
                        return htt;
                    }

                },
                //插入图片_菜单
                addImg: function (data) {
                    if (!data.error_msg == "") {
                        loadMack({ off: 'on', Limg: 0, text: data.error_msg, set: 2500 });
                        return false;
                    }
                    var editImg = $('<img src="' + data.img_url + '">').appendTo(this.addEdit);
                    //this.button.click();
                    //设置图片大小
                    new ImgEditSize(editImg);
                    //imgEditSize.main(editImg);
                },
                //生成菜单
                menu: function (x, y, Obj) {
                },

                //删除选项
                Del_edit: function (only_Dom) {

                },
                //创建弹出框
                EditTcc: function (conw, conh) {

                },

                //li结构向上移动
                EdUp_li: function (conw, conh) {


                },
                //li结构向下移动
                EdDn_li: function (conw, conh) {



                },
                //td结构向上移动
                EdUp_td: function (conw, conh) {


                },
                //td结构向下移动
                EdDn_td: function (conw, conh) {

                },
                //td结构向左移动
                EdLeft_td: function (conw, conh) {

                },
                //td结构向右移动
                EdRight_td: function (conw, conh) {


                },
                Tcc_ajax: function () {

                },
                //创建上传图片弹出框
                UpdataImageTcc: function (conw, conh) {

                },
                //创建FCK高级编辑器
                createEditor: function (con, obj) {

                }

            }
            //js原生事件注册
            var EventUtil = {

                //增加事件处理函数
                addHandler: function (element, type, handler) {
                    if (element.addEventListener) {
                        element.addEventListener(type, handler, false);
                    } else if (element.attachEvent) {
                        element.attachEvent("on" + type, handler);
                    } else {
                        element["on" + type] = handler;
                    }
                },
                //移除事件处理函数    
                removeHandler: function (element, type, handler) {
                    if (element.removeEventListener) {
                        element.removeEventListener(type, handler, false);
                    } else if (element.detachEvent) {
                        element.detachEvent("on" + type, handler);
                    } else {
                        element["on" + type] = null;
                    }
                }
            }

            ////文字编辑
            //var textEdit = new TextEdit();
            //textEdit.T_edit();
            //textEdit.T_edit_li();
            //textEdit.T_edit_td();


            /*添加&批量添加选项*/
            function AddOrBatch() {
                return this.events();
            }
            AddOrBatch.prototype = {
                events: function () {
                    var _this = this;
                    //添加单条行
                    $('.operationH .add-icon-active').live('click', function () {
                        _this.module = $(this).parents('.module');

                        var items = _this.module.find("li[class!='ui-state-disabled']");//问题内容项
                        var questType = _this.module.attr('name').toUpperCase();
                        _this.addItems(questType, "H", items.length, items);
                    });
                    //添加多条行
                    $('.Batch_push').live('click', function () {
                        var oid = $(this).parents('.poplayer').attr('oid');
                        _this.module = $('.module[oid=' + oid + ']');
                        var issue = _this.module.attr('issue');
                        var cols_count = 0;
                        var disp_type = _this.module.attr('disp_type');
                        if (disp_type == 'column') { cols_count = _this.module.attr('cols_count') }

                        //如果是默认选项则取消提交
                        if ($('.poplayer[oid=' + oid + '] .bulkadd').is('.def_class')) {
                            $('.jsTip_close').click();
                            return;
                        }
                        _this.addItems(oid, issue, 2, cols_count);
                    });

                    //添加单条列
                    $('.operationV .add-icon-active').live('click', function () {
                        _this.module = $(this).parents('.module');
                        var oid = _this.module.attr('oid');
                        var issue = _this.module.attr('issue');
                        _this.addItems(oid, issue, 1);
                    });
                    //添加多条列
                    $('.Batch_push_v').live('click', function () {
                        var oid = $(this).parents('.poplayer').attr('oid');
                        _this.module = $('.module[oid=' + oid + ']');
                        var issue = _this.module.attr('issue');

                        //如果是默认选项则取消提交
                        if ($('.poplayer[oid=' + oid + '] .bulkadd').is('.def_class')) {
                            $('.jsTip_close').click();
                            return;
                        }

                        _this.addItems(oid, issue, 2);
                    });
                },
                /*添加行*/
                addItems: function (questType, layout, num, items) {

                    if (questType == "SINGLE") {
                        var html = '<li style=""><input name="radio" type="radio"><label  name="option" class="T_edit_min">选项' + (num + 1) + '</label></li>';
                        $(items[items.length - 1]).after(html);
                        $(items[items.length]).click(); //触发创建文本编辑框
                    }
                    if (questType == "MUTIPLE") {
                    }
                    if (questType == "IMGSINGLE") {
                    }
                    if (questType == "IMGMULTIPLE") {
                    }
                    if (questType == "ORDER") {
                    }
                    if (questType == "SCORE") {
                    }
                    if (questType == "MULTIPLE_BLANK") {
                    }
                    if (questType == "MATRIX_SINGLE") {
                    }
                    if (questType == "MATRIX_MULTIPLE") {
                    }
                    if (questType == "MATRIX_BLANK") {
                    }
                    if (questType == "MATRIX_SCORE") {
                    }
                    if (questType == "DESC") {
                    }
                    if (questType == "PAGE") {
                    }
                    if (questType == "APPEND_TXT") {

                    }
                    if (questType == "APPEND_TXTAREA") {
                    }
                }
            }
            //添加选项
            var addOrBatch = new AddOrBatch();
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
                                <li class="moduleD ui-draggable" name="APPEND_TXT">
                                    <a href="javascript:;">
                                        <i class=""></i>
                                        补充说明1
                                    </a>
                                </li>
                                <li class="moduleD ui-draggable" name="APPEND_TXTAREA">
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
                    <table class="table1 table-desc">
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
                        <li class="module" name="SINGLE">
                            <div class="topic_type">
                                <div class="topic_type_menu">
                                    <div class="setup-group">
                                        <h4>Q1</h4>
                                        <a style="display: none;" class="Bub" title="题目设置" href="javascript:;"><i class="setup-icon-active"></i></a><a style="display: none;" class="Bub" title="逻辑设置" href="javascript:;"><i class="link-icon-active"></i></a><a style="display: none;" class="Bub" title="题目复制" href="javascript:;"><i class="copy-icon-active"></i></a><a style="display: none;" class="Del" title="题目删除" href="javascript:;"><i class="del2-icon-active"></i></a>
                                    </div>
                                </div>
                                <div class="topic_type_con">
                                    <div class="Drag_area">
                                        <div class="th4 T_edit q_title">单选题</div>
                                    </div>
                                    <ul class="unstyled">
                                        <li style="">
                                            <input type="radio" /><label class="T_edit_min" for="">选项1</label></li>
                                        <li style="">
                                            <input type="radio" /><label class="T_edit_min" for="">选项2</label>
                                            <input type="text" style="margin-left: 2px; width: 200px; border: 0; border-bottom: 1px solid black; background: #fff;" />
                                        </li>
                                        <li style="margin-top: 5px;" class="ui-state-disabled">
                                            <span style="display: block; margin-top: 2px">其他建议：</span>
                                            <textarea class="txt-border" style="margin-top: 5px; width: 230px;" rows="3"></textarea>
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
                                                    <img src="./demo/545a2033f7405b328c3682c0_thumbnail.jpg" />
                                                </div>
                                                <input id="Radio3" name="radio" type="radio" />
                                                <label id="Label3" class="T_edit_min" for="">图片1</label>
                                            </div>
                                        </li>
                                        <li class="ui-state-disabled">
                                            <div class="questionImgBox abor">
                                                <div style="display: none;" class="AddQImgCon">
                                                    <div class="uploader">
                                                        <input title="Click to add Files" name="files[]" type="file" multiple="multiple" />
                                                    </div>
                                                </div>
                                                <div style="display: block;" class="AddQImgCon">
                                                    <div class="file-box">
                                                        <form id="logo_uploader_form" enctype="multipart/form-data" method="POST" action="">
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
                                        <li class="ui-state-disabled">
                                            <div class="questionImgBox abor">
                                                <div style="display: none;" class="AddQImgCon">
                                                    <div class="uploader">
                                                        <label>
                                                            <input title="Click to add Files" name="files[]" type="file" multiple="multiple" /></label>
                                                    </div>
                                                </div>
                                                <div style="display: block;" class="AddQImgCon_ie">
                                                    <div class="file-box">
                                                        <form id="Form1" enctype="multipart/form-data" method="POST" action="">
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
                                                <input class="txt-border" style="width: 300px; height: 24px;" value="" type="text" />
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
                                        <li>
                                            <div class="option_Fill">
                                                <textarea class="txt-border" cols="40" rows="5"></textarea>
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
                                    <div class="grade ">
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
                                        <li class="ui-state-disabled">
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
                                        <li class="ui-state-disabled">
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
