﻿//问卷模板
var TPL_MAP = {};
TPL_MAP.PAGE = '<li class="module paging" name="page"><div class="topic_type"><div class="topic_type_menu"><div class="setup-group"><a class="DelPaging" title="删除分页" href="javascript:;" style="display: none;"> <i class="del2-icon-active"></i></a></div></div><div class="topic_type_con"><div class="Drag_area" style="margin:0px;"><div class="icon_paging"></div><div class="fr con_paging">页码：<span></span></div></div></div></div><div class="updown" style="display: none;"><a href="javascript:;"> <i class="up-icon-active"></i></a><a href="javascript:;"><i class="down-icon-active"></i></a></div></li>';
TPL_MAP.SINGLE = '<li class="module"><div class="topic_type"><div class="topic_type_menu"><div class="setup-group"><h4></h4></div></div><div class="topic_type_con"><div class="th4">单选题</div><ul class="unstyled"><li><input type="radio" name="radio" id="1" value="1"><label class="" for="">选项1</label></li><li><input type="radio" name="radio" id="2" value="1"><label class="" for="">选项2</label></li></ul></div></div></li>';
TPL_MAP.MUTIPLE = '<li class="module"><div class="topic_type"><div class="topic_type_menu"><div class="setup-group"><h4></h4></div></div><div class="topic_type_con"><h4 class="th4 T_edit">多选题</h4><ul class="unstyled"><li><input type="checkbox" name="radio" id="" value="1" /><label class="">选项1</label></li><li><input type="checkbox" name="radio" id="" value="2" /><label class="">选项2</label></li></ul></div></div></li>';
TPL_MAP.IMGSINGLE = '<li class="module"><div class="topic_type"></div><div class="topic_type_con"><div class="Drag_area"><div name="question" class="th4 T_edit q_title">图片单选题</div></div><ul class="unstyled Imgli"><li class="dragZone"><div class="questionImgBox abor"> <div class="AddQImgCon"><div class="uploader"><label><input type="file" name="files[]" multiple="multiple" title="Click to add Files"/></label></div></div></div></li></ul></div></li>';
TPL_MAP.IMGMULTIPLE = '<li class="module"><div class="topic_type"></div><div class="topic_type_con"><div class="Drag_area"><div name="question" class="th4 T_edit q_title">图片单选题</div></div><ul class="unstyled Imgli"><li class="dragZone"><div class="questionImgBox abor"> <div class="AddQImgCon"><div class="uploader"><label><input type="file" name="files[]" multiple="multiple" title="Click to add Files"/></label></div></div></div></li></ul></div></li>';

//打分题
TPL_MAP.SCORE = '<li class="module" ><div class="topic_type"><div class="topic_type_con"><div class="Drag_area"><div class="th4 T_edit q_title" name="question">打分题</div>'
                + '</div><div class="grade"><table cellspacing="0" cellpadding="0"><thead><tr><td>&nbsp;</td><td><table style="width: 400px; margin-left: 20px;">'
                + '<tbody><tr><td style="width: 116px;">&nbsp;</td><td style="width: 116px;" align="center">&nbsp;</td><td style="width: 116px;" align="right">&nbsp;</td>'
                + '<td width="50"></td></tr></tbody></table></td></tr></thead><tbody><tr class="Ed_tr"><td  class="T_edit_td" align="right" name="option">选型1</td>'
                + '<td><table style="width: 400px;"><tbody><tr><td><div class="grade_text"><table class="topic_ul" border="0" cellspacing="0" cellpadding="1"><tbody>'
                + '<tr><td class="div_float">1</td><td class="div_float">2</td><td class="div_float">3</td><td class="div_float">4</td><td class="div_float">5</td>'
                + '</tr></tbody></table></div></td><td width="30" align="right">分</td></tr></tbody></table></td></tr><tr class="Ed_tr"><td  class="T_edit_td" align="right" name="option">选型1</td>'
                + '<td><table style="width: 400px;"><tbody><tr><td><div class="grade_text"><table class="topic_ul" border="0" cellspacing="0" cellpadding="1">'
                + '<tbody><tr><td class="div_float">1</td><td class="div_float">2</td><td class="div_float">3</td><td class="div_float">4</td><td class="div_float">5</td>'
                + '</tr></tbody></table></div></td><td width="30" align="right">分</td></tr></tbody></table></td></tr></tbody></table></div></div></div></li>';
//单行填空题
TPL_MAP.BLANK = '<li class="module"><div class="topic_type"><div class="topic_type_menu"><div class="setup-group"><h4></h4></div></div><div class="topic_type_con"><h4 class="th4 T_edit">单行填空</h4><ul class="unstyled"><li><textarea name="" id="" cols="40" rows="1"></textarea></li></ul></div></div></li>';
//排序题
TPL_MAP.ORDER = '<li class="module"><div class="topic_type"><div class="topic_type_menu"><div class="setup-group"><h4></h4></div></div><div class="topic_type_con"><h4 class="th4 T_edit">排序题</h4><div class="pxul"><ul class="unstyled Sorting"><li class=""><label class="T_edit_min" name="option">选项1</label></li><li class=""><label class="T_edit_min" name="option">选项2</label></li></ul><div class="sort-right"><table class="table2"><tr><th class="w28">1</th><td>&nbsp;</td></tr><tr><th class="w28">2</th><td>&nbsp;</td></tr></table></div></div><div class="operationH"></div><p class="mt10">请将左面的项拖放到右面的框完成排序</p></div></div></li>';
//多项填空题
TPL_MAP.MULTIPLE_BLANK = '<li class="module"><div class="topic_type"><div class="topic_type_menu"><div class="setup-group"><h4></h4></div></div><div class="topic_type_con"><h4 class="th4 T_edit">多项填空题</h4><div class="grade"><table width="290"><tr><td align="center" width="55"><div class="" >选项1</div></td><td align="left"><textarea name="" id="" cols="30" rows="1"></textarea></td></tr><tr><td align="center" width="55"><div class="" >选项2</div></td><td align="left"><textarea name="" id="" cols="30" rows="1" style="margin-top:5px;"></textarea></td></tr></table></div></div></div></li>';
//矩阵单选题
TPL_MAP.MATRIX_SINGLE = '<li class="module"><div class="topic_type"><div class="topic_type_menu"><div class="setup-group"><h4></h4></div></div><div class="topic_type_con"><h4 class="th4 T_edit">矩阵单选题</h4><ul class="unstyled"><li><div class="matrix"><table class="table table-bordered td-Tc"><tr><td>&nbsp;</td><td class="">选项1</td><td class="">选项2</td></tr><tr><td class="">矩阵行1</td><td><input type="radio" name="radio" id="radio" value="radio" /></td><td><input type="radio" name="radio3" id="radio3" value="radio3" /></td></tr><tr><td class="">矩阵行2</td><td><input type="radio" name="radio2" id="radio2" value="radio2" /></td><td><input type="radio" name="radio4" id="radio4" value="radio4" /></td></tr></table></div></li></ul></div></div></li>';
//矩阵多选题
TPL_MAP.MATRIX_MULTIPLE = '<li class="module"><div class="topic_type"><div class="topic_type_menu"><div class="setup-group"><h4></h4></div></div><div class="topic_type_con"><h4 class="th4 T_edit">矩阵多选题</h4><ul class="unstyled"><li><div class="matrix"><table class="table table-bordered td-Tc"><tr><td>&nbsp;</td><td class="">选项1</td><td class="">选项2</td></tr><tr><td class="">矩阵行1</td><td><input type="checkbox" name="checkbox"/></td><td><input type="checkbox" name="checkbox"/></td></tr><tr><td class="">矩阵行2</td><td><input type="checkbox" name="checkbox"/></td><td><input type="checkbox" name="checkbox"/></td></tr></table></div><div class="operationV"></div></li><li><div class="operationH"></div></li></ul></div></div></li>';
//矩阵填空题
TPL_MAP.MATRIX_BLANK = '<li class="module"><div class="topic_type"><div class="topic_type_menu"><div class="setup-group"><h4></h4></div></div><div class="topic_type_con"><div class="Drag_area"><div class="th4 T_edit">矩阵填空题</div></div><ul class="unstyled"><li><div class="matrix"><table class="table table-bordered td-Tc"><tbody><tr><td>&nbsp;</td><td class="">请填空1</td><td class="">请填空2</td></tr><tr><td class="">矩阵行1</td><td><textarea name="" id="" cols="20" rows="1"></textarea></td><td><textarea name="" id="" cols="20" rows="1"></textarea></td></tr><tr><td class="">矩阵行2</td><td><textarea name="" id="" cols="20" rows="1"></textarea></td><td><textarea name="" id="" cols="20" rows="1"></textarea></td></tr></tbody></table></div></li><li></li></ul></div></div></li>';
//矩阵打分题
TPL_MAP.MATRIX_SCORE = '<li class="module"><div class="topic_type"><div class="topic_type_menu"><div class="setup-group"><h4></h4></div></div><div class="topic_type_con"><div class="Drag_area"><div class="th4 T_edit">矩阵打分题</div></div><ul class="unstyled"><li><div class="matrix"><table class="table table-bordered  td-Tc"><tbody><tr><td>&nbsp;</td><td class="">请打分1</td><td class="">请打分2</td></tr><tr><td class="">矩阵行1</td><td><div class="dfW"><a href="javascript:;"> <i class="basic-too14-icon-active"></i></a><a href="javascript:;"> <i class="basic-too14-icon-active"></i></a><a href="javascript:;"><i class="basic-too14-icon-active"></i></a><a href="javascript:;"><i class="basic-too14-icon-active"></i></a><a href="javascript:;"><i class="basic-too14-icon-active"></i></a></div></td><td><div class="dfW"><a href="javascript:;"><i class="basic-too14-icon-active"></i></a><a href="javascript:;"><i class="basic-too14-icon-active"></i></a><a href="javascript:;"><i class="basic-too14-icon-active"></i></a><a href="javascript:;"><i class="basic-too14-icon-active"></i></a><a href="javascript:;"><i class="basic-too14-icon-active"></i></a></div></td></tr><tr><td class="">矩阵行2</td><td><div class="dfW"><a href="javascript:;"><i class="basic-too14-icon-active"></i></a><a href="javascript:;"><i class="basic-too14-icon-active"></i></a><a href="javascript:;"><i class="basic-too14-icon-active"></i></a><a href="javascript:;"><i class="basic-too14-icon-active"></i></a><a href="javascript:;"><i class="basic-too14-icon-active"></i></a></div></td><td><div class="dfW"><a href="javascript:;"><i class="basic-too14-icon-active"></i></a><a href="javascript:;"><i class="basic-too14-icon-active"></i></a><a href="javascript:;"><i class="basic-too14-icon-active"></i></a><a href="javascript:;"><i class="basic-too14-icon-active"></i></a><a href="javascript:;"><i class="basic-too14-icon-active"></i></a></div></td></tr></tbody></table></div></li><li></li></ul></div></div></li>';
//多行填空题
TPL_MAP.Multi_Line_blank = '<li class="module"><div class="topic_type"><div class="topic_type_menu"><div class="setup-group"><h4></h4></div></div><div class="topic_type_con"><h4 class="th4 T_edit">多行填空</h4><ul class="unstyled"><li><textarea name="" id="" cols="40" rows="5"></textarea></li></ul></div></div></li>';
//段落说明
TPL_MAP.DESC = '<li class="module"><div class="topic_type"><div class="topic_type_menu"><div class="setup-group"><h4></h4></div></div><div class="topic_type_con"><div class="Drag_area"><div class="th4 T_edit">段落说明</div></div></div></div></li>'