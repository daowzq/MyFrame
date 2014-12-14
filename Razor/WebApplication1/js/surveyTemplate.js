//问卷模板
var TPL_MAP = {};
TPL_MAP.PAGE = '<li class="module paging" name="page"><div class="topic_type"><div class="topic_type_menu"><div class="setup-group"><a class="DelPaging" title="删除分页" href="javascript:;" style="display: none;"> <i class="del2-icon-active"></i></a></div></div><div class="topic_type_con"><div class="Drag_area" style="margin:0px;"><div class="icon_paging"></div><div class="fr con_paging">页码：<span></span></div></div></div></div><div class="updown" style="display: none;"><a href="javascript:;"> <i class="up-icon-active"></i></a><a href="javascript:;"><i class="down-icon-active"></i></a></div></li>';
//单项选择
TPL_MAP.SINGLE = "<li class='module'>\
	<div class='topic_type'>\
		<div class='topic_type_menu'>\
			<div class='setup-group'>\
				<h4>Q1</h4>\
				<a class='Bub' href='javascript:;' title='题目设置' style='display: block;'><i class='setup-icon-active'></i></a><a class='Bub' href='javascript:;' title='逻辑设置' style='display: block;'><i class='link-icon-active'></i></a><a class='Bub' href='javascript:;' title='题目复制' style='display: block;'><i class='copy-icon-active'></i></a><a class='Del' href='javascript:;' title='题目删除' style='display: block;'><i class='del2-icon-active'></i></a>\
			</div>\
		</div>\
		<div class='topic_type_con'>\
			<div class='Drag_area'>\
				<div class='th4 T_edit q_title'>单选题</div>\
			</div>\
			<ul class='unstyled '>\
				<li style=''>\
					<input type='radio' /><label class='T_edit_min' for=''>选项1</label></li>\
				<li style=''>\
					<input type='radio' /><label class='T_edit_min' for=''>选项2</label></li>\
			</ul>\
			<div class='operationH'><a href='javascript:;' style='display: block;'><i title='添加选项' class='add-icon-active'></i></a><a class='Bub' href='javascript:;' title='批量添加' style='display: block;'><i class='clone-icon-active'></i></a></div>\
		</div>\
	</div>\
	<div class='updown' style='display: none;'><a href='javascript:;'><i title='上移本题' class='up-icon-active'></i></a><a href='javascript:;'><i title='下移本题' class='down-icon-active'></i></a></div>\
</li>";

//多项选择
TPL_MAP.MUTIPLE = TPL_MAP.SINGLE;

//图片单选题
TPL_MAP.IMGSINGLE = "<li class='module'>\
	<div class='topic_type'>\
		<div class='topic_type_menu'>\
			<div class='setup-group'>\
				<h4>Q3</h4>\
				<a style='display: none;' class='Bub' title='题目设置' href='javascript:;'><i class='setup-icon-active'></i></a><a style='display: none;' class='Bub' title='逻辑设置' href='javascript:;'><i class='link-icon-active'></i></a><a style='display: none;' class='Bub' title='题目复制' href='javascript:;'><i class='copy-icon-active'></i></a><a style='display: none;' class='Del' title='题目删除' href='javascript:;'><i class='del2-icon-active'></i></a>\
			</div>\
		</div>\
		<div class='topic_type_con'>\
			<div class='Drag_area'>\
				<div class='th4 T_edit q_title' name='question'>图片单选题</div>\
			</div>\
			<ul class='unstyled Imgli'>\
				<li>\
					<div class='questionImgBox'>\
						<div class='QImgCon'>\
							<img src='./demo/545a2033f7405b328c3682c0_thumbnail.jpg' />\
						</div>\
						<input name='radio' type='radio' /><label class='T_edit_min' for=''>图片1</label>\
					</div>\
				</li>\
				<li>\
					<div class='questionImgBox'>\
						<div class='QImgCon'>\
							<img src='./demo/545a2033f7405b328c3682c0_thumbnail.jpg'>\
						</div>\
						<input id='Radio3' name='radio' type='radio' />\
						<label id='Label3' class='T_edit_min' for=''>图片1</label>\
					</div>\
				</li>\
				<li class='dragZone'>\
					<div class='questionImgBox abor'>\
						<div style='display: none;' class='AddQImgCon'>\
							<div class='uploader'>\
								<label><input title='Click to add Files' name='files[]' type='file' multiple='multiple' /></label>\
							</div>\
						</div>\
						<div style='display: block;' class='AddQImgCon'>\
							<div class='file-box'>\
								<form id='logo_uploader_form' enctype='multipart/form-data' method='POST' action=''>\
									<iframe style='left: 0px; top: 0px; width: 100%; height: 100%; filter: alpha(opacity = 0); position: absolute; opacity: 0; -moz-opacity: 0; -khtml-opacity: 0;' id='imgUpload' class='uploadfile' src='./demo/saved_resource.htm'></iframe>\
									<div class='WJButton wj_blue'>上传</div>\
								</form>\
							</div>\
						</div>\
					</div>\
				</li>\
			</ul>\
		</div>\
	</div>\
	<div style='display: none;' class='updown'><a href='javascript:;'><i class='up-icon-active' title='上移本题'></i></a><a href='javascript:;'><i class='down-icon-active' title='下移本题'></i></a></div>\
</li>";

//图片多选
TPL_MAP.IMGMULTIPLE = TPL_MAP.IMGSINGLE

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
TPL_MAP.BLANK = "<li class='module'>\
	<div class='topic_type'>\
		<div class='topic_type_menu'>\
			<div class='setup-group'>\
				<h4>Q5</h4>\
				<a style='display: none;' class='Bub' title='题目设置' href='javascript:;'><i class='setup-icon-active'></i></a><a style='display: none;' class='Bub' title='逻辑设置' href='javascript:;'><i class='link-icon-active'></i></a><a style='display: none;' class='Bub' title='题目复制' href='javascript:;'><i class='copy-icon-active'></i></a><a style='display: none;' class='Del' title='题目删除' href='javascript:;'><i class='del2-icon-active'></i></a>\
			</div>\
		</div>\
		<div class='topic_type_con'>\
			<div class='Drag_area'>\
				<div class='th4 T_edit q_title' >你最喜欢什么问题呢</div>\
			</div>\
			<ul class='unstyled'>\
				<li style='overflow: inherit;'>\
					<div class='option_Fill'>\
						<div style='display: none;' class='min_an'><i></i></div>\
						<input style='width: 300px; height: 30px;' value='' type='text' />\
					</div>\
				</li>\
			</ul>\
		</div>\
	</div>\
	<div style='display: none;' class='updown'><a href='javascript:;'><i class='up-icon-active' title='上移本题'></i></a><a href='javascript:;'><i class='down-icon-active' title='下移本题'></i></a></div>\
</li>";

//多项填空题
TPL_MAP.MULTIPLE_BLANK = "<li class='module'>\
	<div class='topic_type'>\
		<div class='topic_type_menu'>\
			<div class='setup-group'>\
				<h4>Q6</h4>\
				<a style='display: none;' class='Bub' title='题目设置' href='javascript:;'><i class='setup-icon-active'></i></a><a style='display: none;' class='Bub' title='逻辑设置' href='javascript:;'><i class='link-icon-active'></i></a><a style='display: none;' class='Bub' title='题目复制' href='javascript:;'><i class='copy-icon-active'></i></a><a style='display: none;' class='Del' title='题目删除' href='javascript:;'><i class='del2-icon-active'></i></a>\
			</div>\
		</div>\
		<div class='topic_type_con'>\
			<div class='Drag_area'>\
				<div class='th4 T_edit q_title' name='question'>你对过年有什么看法吗?</div>\
			</div>\
			<ul class='unstyled'>\
				<li style='overflow: inherit;'>\
					<div class='option_Fill'>\
						<div style='display: none;' class='min_an'><i></i></div>\
						<textarea cols='40' rows='5' style='border: solid 1px #dbdbdb;' type='text'></textarea>\
					</div>\
				</li>\
			</ul>\
		</div>\
	</div>\
	<div style='display: none;' class='updown'><a href='javascript:;'><i class='up-icon-active' title='上移本题'></i></a><a href='javascript:;'><i class='down-icon-active' title='下移本题'></i></a></div>\
</li>";

//排序题
TPL_MAP.ORDER = "<li class='module'>\
	<div class='topic_type'>\
		<div class='topic_type_menu'>\
			<div class='setup-group'>\
				<h4>Q7</h4>\
				<a style='display: none;' class='Bub' title='题目设置' href='javascript:;'><i class='setup-icon-active'></i></a><a style='display: none;' class='Bub' title='逻辑设置' href='javascript:;'><i class='link-icon-active'></i></a><a style='display: none;' class='Bub' title='题目复制' href='javascript:;'><i class='copy-icon-active'></i></a><a style='display: none;' class='Del' title='题目删除' href='javascript:;'><i class='del2-icon-active'></i></a>\
			</div>\
		</div>\
		<div class='topic_type_con'>\
			<div class='Drag_area'>\
				<div class='th4 T_edit q_title'>你喜欢什么运动?</div>\
			</div>\
			<div class='pxul'>\
				<ul class='unstyled Sorting'>\
					<li><label class='T_edit_min' name='option'>足球</label></li>\
					<li><label class='T_edit_min' name='option'>篮球</label></li>\
					<li><label class='T_edit_min' name='option'>水球</label></li>\
					<li><label class='T_edit_min' name='option'>气球</label></li>\
				</ul>\
				<div class='sort-right'>\
					<table class='table2'>\
						<tbody>\
							<tr>\
								<th class='w28'>1</th>\
								<td>&nbsp;</td>\
							</tr>\
							<tr>\
								<th class='w28'>2</th>\
								<td>&nbsp;</td>\
							</tr>\
							<tr>\
								<th class='w28'>3</th>\
								<td>&nbsp;</td>\
							</tr>\
							<tr>\
								<th class='w28'>4</th>\
								<td>&nbsp;</td>\
							</tr>\
						</tbody>\
					</table>\
				</div>\
			</div>\
			<div class='operationH'><a style='display: none;' href='javascript:;'><i class='add-icon-active' title='添加选项'></i></a><a style='display: none;' class='Bub' title='批量添加' href='javascript:;'><i class='clone-icon-active'></i></a></div>\
			<p class='mt10'>请将左面的项拖放到右面的框完成排序</p>\
		</div>\
	</div>\
	<div style='display: none;' class='updown'><a href='javascript:;'><i class='up-icon-active' title='上移本题'></i></a><a href='javascript:;'><i class='down-icon-active' title='下移本题'></i></a></div>\
</li>";

//矩阵单选题
TPL_MAP.MATRIX_SINGLE = "<li class='module'>\
	<div class='topic_type'>\
		<div class='topic_type_menu'>\
			<div class='setup-group'>\
				<h4>Q9</h4>\
				<a style='display: none;' class='Bub' title='题目设置' href='javascript:;'><i class='setup-icon-active'></i></a><a style='display: none;' class='Bub' title='逻辑设置' href='javascript:;'><i class='link-icon-active'></i></a><a style='display: none;' class='Bub' title='题目复制' href='javascript:;'><i class='copy-icon-active'></i></a><a style='display: none;' class='Del' title='题目删除' href='javascript:;'><i class='del2-icon-active'></i></a>\
			</div>\
		</div>\
		<div class='topic_type_con'>\
			<div class='Drag_area'>\
				<div class='th4 T_edit q_title' name='question'>关于节假日安排你的意见</div>\
			</div>\
			<ul class='unstyled'>\
				<li>\
					<div class='matrix'>\
						<table style='width: 682px;' class='table table-bordered td-Tc' cellspacing='0' cellpadding='0'>\
							<tbody>\
								<tr>\
									<td style='width: 165px;' width='136'>&nbsp;</td>\
									<td style='width: 206px;' class='T_edit_td' width='109' name='option' menutype='col'>标题1</td>\
									<td style='width: 308px;' class='T_edit_td' width='109' name='option' menutype='col'>标题1</td>\
								</tr>\
								<tr class='Ed_tr'>\
									<td style='width: 165px; text-align: left;' class='T_edit_td' name='row' menutype='row'>矩阵行1</td>\
									<td style='width: 206px;'>\
										<div style='width: 206px;' class='div'>\
											<div style='width: 206px;' class='div'>\
												<input type='radio' />\
											</div>\
										</div>\
									</td>\
									<td style='width: 308px;'>\
										<div style='width: 308px;' class='div'>\
											<div style='width: 308px;' class='div'>\
												<input type='radio' />\
											</div>\
										</div>\
									</td>\
								</tr>\
							</tbody>\
						</table>\
					</div>\
					<div class='operationV'><a style='display: none;' href='javascript:;'><i class='add-icon-active' title='添加选项'></i></a><a style='display: none;' class='Bub' title='批量添加' href='javascript:;'><i class='clone-icon-active'></i></a></div>\
				</li>\
				<li>\
					<div class='operationH'>\
						<div class='GetWidthMatrix'><a style='display: none;' href='javascript:;'>调整列宽</a></div>\
						<a style='display: none;' href='javascript:;'><i class='add-icon-active' title='添加选项'></i></a><a style='display: none;' class='Bub' title='批量添加' href='javascript:;'><i class='clone-icon-active'></i></a>\
					</div>\
				</li>\
			</ul>\
		</div>\
	</div>\
	<div style='display: none;' class='updown'><a href='javascript:;'><i class='up-icon-active' title='上移本题'></i></a><a href='javascript:;'><i class='down-icon-active' title='下移本题'></i></a></div>\
</li>";

//矩阵多选题
TPL_MAP.MATRIX_MULTIPLE = TPL_MAP.MATRIX_SINGLE;

//矩阵填空题
TPL_MAP.MATRIX_BLANK = "<li class='module' >\
	<div class='topic_type'>\
		<div class='topic_type_menu'>\
			<div class='setup-group'>\
				<h4>Q11</h4>\
				<a style='display: none;' class='Bub' title='题目设置' href='javascript:;'><i class='setup-icon-active'></i></a><a style='display: none;' class='Bub' title='逻辑设置' href='javascript:;'><i class='link-icon-active'></i></a><a style='display: none;' class='Bub' title='题目复制' href='javascript:;'><i class='copy-icon-active'></i></a><a style='display: none;' class='Del' title='题目删除' href='javascript:;'><i class='del2-icon-active'></i></a>\
			</div>\
		</div>\
		<div class='topic_type_con'>\
			<div class='Drag_area'>\
				<div class='th4 T_edit q_title' name='question'>矩阵填空题</div>\
			</div>\
			<ul class='unstyled'>\
				<li>\
					<div class='matrix'>\
						<table class='table table-bordered td-Tc' cellspacing='0' cellpadding='0'>\
							<tbody>\
								<tr>\
									<td width='142'>&nbsp;</td>\
									<td  class='T_edit_td' width='114' name='option' menutype='col'>请填空1</td>\
									<td  class='T_edit_td' width='114' name='option' menutype='col'>请填空2</td>\
								</tr>\
								<tr class='Ed_tr'>\
									<td style='text-align: left;'  class='T_edit_td' name='row' menutype='row'>矩阵行1</td>\
									<td><textarea cols='20' rows='1'></textarea></td>\
									<td><textarea cols='20' rows='1'></textarea></td>\
								</tr>\
								<tr class='Ed_tr'>\
									<td style='text-align: left;' class='T_edit_td' name='row' menutype='row'>矩阵行2</td>\
									<td><textarea cols='20' rows='1'></textarea></td>\
									<td><textarea cols='20' rows='1'></textarea></td>\
								</tr>\
							</tbody>\
						</table>\
					</div>\
					<div class='operationV'><a style='display: none;' href='javascript:;'><i class='add-icon-active' title='添加选项'></i></a><a style='display: none;' class='Bub' title='批量添加' href='javascript:;'><i class='clone-icon-active'></i></a></div>\
				</li>\
				<li>\
					<div class='operationH'>\
						<div class='GetWidthMatrix'><a style='display: none;' href='javascript:;'>调整列宽</a></div>\
						<a style='display: none;' href='javascript:;'><i class='add-icon-active' title='添加选项'></i></a><a style='display: none;' class='Bub' title='批量添加' href='javascript:;'><i class='clone-icon-active'></i></a>\
					</div>\
				</li>\
			</ul>\
		</div>\
	</div>\
	<div style='display: none;' class='updown'><a href='javascript:;'><i class='up-icon-active' title='上移本题'></i></a><a href='javascript:;'><i class='down-icon-active' title='下移本题'></i></a></div>\
</li> ";

//矩阵打分题
TPL_MAP.MATRIX_SCORE = "<li class='module'>\
	<div class='topic_type'>\
		<div class='topic_type_menu'>\
			<div class='setup-group'>\
				<h4>Q8</h4>\
				<a style='display: none;' class='Bub' title='题目设置' href='javascript:;'><i class='setup-icon-active'></i></a><a style='display: none;' class='Bub' title='逻辑设置' href='javascript:;'><i class='link-icon-active'></i></a><a style='display: none;' class='Bub' title='题目复制' href='javascript:;'><i class='copy-icon-active'></i></a><a style='display: none;' class='Del' title='题目删除' href='javascript:;'><i class='del2-icon-active'></i></a>\
			</div>\
		</div>\
		<div class='topic_type_con'>\
			<div class='Drag_area'>\
				<div class='th4 T_edit q_title' name='question'>程序员的工作效率</div>\
			</div>\
			<div class='grade'>\
				<table cellspacing='0' cellpadding='0'>\
					<thead>\
						<tr>\
							<td>&nbsp;</td>\
							<td>\
								<table style='width: 400px; margin-left: 20px;'>\
									<tbody>\
										<tr>\
											<td style='width: 116px;'>&nbsp;</td>\
											<td style='width: 116px;' align='center'>&nbsp;</td>\
											<td style='width: 116px;' align='center'>&nbsp;</td>\
											<td style='width: 116px;' align='right'>&nbsp;</td>\
											<td width='50'></td>\
										</tr>\
									</tbody>\
								</table>\
							</td>\
						</tr>\
					</thead>\
					<tbody>\
						<tr class='Ed_tr'>\
							<td class='T_edit_td' align='right' name='option'>很高效</td>\
							<td>\
								<table style='width: 400px;'>\
									<tbody>\
										<tr>\
											<td>\
												<div class='grade_text'>\
													<table class='topic_ul' border='0' cellspacing='0' cellpadding='1'>\
														<tbody>\
															<tr>\
																<td class='div_float'>1</td>\
																<td class='div_float'>2</td>\
																<td class='div_float'>3</td>\
																<td class='div_float'>4</td>\
																<td class='div_float'>5</td>\
															</tr>\
														</tbody>\
													</table>\
												</div>\
											</td>\
											<td width='30' align='right'>分</td>\
										</tr>\
									</tbody>\
								</table>\
							</td>\
						</tr>\
					</tbody>\
				</table>\
			</div>\
			<div class='operationH'><a style='display: none;' href='javascript:;'><i class='add-icon-active' title='添加选项'></i></a><a style='display: none;' class='Bub' title='批量添加' href='javascript:;'><i class='clone-icon-active'></i></a></div>\
		</div>\
	</div>\
	<div style='display: none;' class='updown'><a href='javascript:;'><i class='up-icon-active' title='上移本题'></i></a><a href='javascript:;'><i class='down-icon-active' title='下移本题'></i></a></div>\
</li>";

//段落说明
TPL_MAP.DESC = "<li class='module paging' name='page'>\
	<div class='topic_type'>\
		<div class='topic_type_menu'>\
			<div class='setup-group'><a style='display: none;' class='DelPaging' title='删除分页' href='javascript:;'><i class='del2-icon-active'></i></a></div>\
		</div>\
		<div class='topic_type_con'>\
			<div style='margin: 0px;' class='Drag_area'>\
				<div class='icon_paging'></div>\
				<div class='fr con_paging'>页码：<span>1/3</span></div>\
			</div>\
		</div>\
	</div>\
	<div style='display: none;' class='updown'><a href='javascript:;'><i class='up-icon-active'></i></a><a href='javascript:;'><i class='down-icon-active'></i></a></div>\
</li>";

//题型映射
var QUESTIONMAP = {
    "SINGLE": TPL_MAP.SINGLE,
    "MUTIPLE": TPL_MAP.MUTIPLE,
    "IMGSINGLE": TPL_MAP.IMGSINGLE,
    "IMGMULTIPLE": TPL_MAP.IMGMULTIPLE,
    "ORDER": TPL_MAP.ORDER,
    "SCORE": TPL_MAP.SCORE,

    "BLANK": TPL_MAP.BLANK,
    "MULTIPLE_BLANK": TPL_MAP.MULTIPLE_BLANK,
    "MATRIX_SINGLE": TPL_MAP.MATRIX_SINGLE,
    "MATRIX_MULTIPLE": TPL_MAP.MATRIX_MULTIPLE,
    "MATRIX_BLANK": TPL_MAP.MATRIX_BLANK,
    "MATRIX_SCORE": TPL_MAP.MATRIX_SCORE,
    "DESC": TPL_MAP.DESC,
    "PAGE": TPL_MAP.PAGE
};