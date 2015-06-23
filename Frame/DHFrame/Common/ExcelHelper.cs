using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.IO;

namespace HDFrame.Common
{
    public class ExcelHelper
    {

        /// <summary>
        /// 导出映射 kye:DataTable Name, Value: Excel Cell header name
        /// </summary>
        private Dictionary<string, string> ExceNameMap;
        private readonly string OutPath = @"/Excel/output/";
        private DataTable OutDt;
        private string PageKey;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="ExlNameMap">Excel Header Name</param>
        /// <param name="PageKeyVal">标识值</param>
        public ExcelHelper(DataTable dt, Dictionary<string, string> ExlNameMap, string PageKeyVal)
        {
            OutDt = dt;
            ExceNameMap = ExlNameMap;
            PageKey = PageKeyVal;
        }

        /// <summary>
        /// 导入方法
        /// </summary>
        /// <returns>完整路径</returns>
        public string Start()
        {
            string OptPath = HttpContext.Current.Server.MapPath(OutPath);
            DirectoryInfo dir = new DirectoryInfo(OptPath);
            var filesInfo = dir.GetFileSystemInfos();
            foreach (var item in filesInfo)
            {
                if (item.Name.Contains(PageKey))
                {
                    try
                    {
                        lock (item) //add lock 
                        {
                            item.Delete();
                        }
                    }
                    catch { }
                }
            }
            string FileName = PageKey + DateTime.Now.ToString("yyyyMMddHH") + ".xls";
            string FullFilePath = OptPath + FileName;
            OutFileToDisk(OutDt, ExceNameMap, FullFilePath);
            return OutPath + FileName;
        }

        ///</summary>
        /// 导出数据到本地
        /// </summary>
        /// <param name="dt">要导出的数据</param>
        /// <param name="path">保存路径</param>
        private void OutFileToDisk(DataTable dt, Dictionary<string, string> dict, string path)
        {
            Workbook workbook = new Workbook(); //工作簿
            Worksheet sheet = workbook.Worksheets[0]; //工作表
            sheet.FreezePanes(1, 1, 1, dt.Columns.Count); //冻结首行
            Cells cells = sheet.Cells;//单元格
            //为标题设置样式 title
            Aspose.Cells.Style styleTitle = workbook.Styles[workbook.Styles.Add()];//新增样式
            styleTitle.HorizontalAlignment = TextAlignmentType.Center;//文字居中
            styleTitle.Font.Name = "宋体";//文字字体
            styleTitle.Font.Size = 18;//文字大小
            styleTitle.Font.IsBold = true;//粗体
            //样式2 columns
            Aspose.Cells.Style style2 = workbook.Styles[workbook.Styles.Add()];//新增样式
            style2.HorizontalAlignment = TextAlignmentType.Center;//文字居中
            style2.Font.Name = "宋体";//文字字体
            style2.Font.Size = 12;//文字大小
            style2.Font.IsBold = true;//粗体
            style2.IsTextWrapped = true;//单元格内容自动换行
            // style2.BackgroundColor = Color.CadetBlue; //Color.FromArgb(0, 176, 240);
            //style2.ForegroundColor = Color.FromArgb(0, 176, 240);
            style2.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
            style2.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
            style2.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
            style2.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
            //样式3
            Aspose.Cells.Style style3 = workbook.Styles[workbook.Styles.Add()];//新增样式
            style3.HorizontalAlignment = TextAlignmentType.Center;//文字居中
            style3.Font.Name = "宋体";//文字字体
            style3.Font.Size = 12;//文字大小
            style3.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
            style3.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
            style3.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
            style3.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;

            int Colnum = dt.Columns.Count;//表格列数
            int Rownum = dt.Rows.Count;//表格行数

            List<int> displayFieldIndex = new List<int>();
            cells.SetRowHeight(0, 28);
            //生成行2 列名行
            for (int i = 0; i < Colnum; i++)
            {
                string ClnNam = dt.Columns[i].ColumnName;
                if (dict.ContainsKey(ClnNam))
                {
                    displayFieldIndex.Add(i);
                    cells[0, i].PutValue(ExceNameMap[ClnNam]);
                    cells.SetColumnWidth(i, 20);
                    cells[0, i].SetStyle(style2);
                }
            }

            //生成数据行
            for (int i = 0; i < Rownum; i++)
            {
                foreach (var item in displayFieldIndex)
                {
                    cells[1 + i, item].PutValue(dt.Rows[i][item] + "");
                    cells[1 + i, item].SetStyle(style3);
                }
                cells.SetRowHeight(1 + i, 24); //设置行高
            }
            workbook.Save(path);
        }
    }
}