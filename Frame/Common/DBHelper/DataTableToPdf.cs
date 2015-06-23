using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Razor.Data
{
    public class DataTable2Pdf
    {
        /// <summary>
        /// DataTable导出到PDF
        /// </summary>
        /// <param name="datatable">DataTable</param>
        /// <param name="PDFFilePath">导出的PDF存储路径</param>
        /// <param name="PdfSaveTitle">导出的文件名</param>
        /// <param name="FontPath">字体路径</param>
        /// <param name="FontSize">字体大小</param>
        /// <param name="widthmz">每一列宽度</param>
        /// <returns>布尔值</returns>
        public static string ConvertDataTableToPDF(DataTable datatable, string PDFFilePath, string PdfSaveTitle, string FontPath, float FontSize, float[] widthmz)
        {
            string strReturnSaveFileName = "";//用于返回的文件名
            if (widthmz == null || widthmz.Length == 0)//如果每一列宽度未指定
            {
                widthmz = new float[datatable.Columns.Count];
                for (int i = 0; i < datatable.Columns.Count; i++)
                {
                    widthmz[i] = 11f;
                }
            }
            //初始化一个目标文档类
            Document document = new Document();
            //调用PDF的写入方法流

            //注意FileMode-Create表示如果目标文件不存在，则创建，如果已存在，则覆盖。
            PdfWriter writer = PdfWriter.getInstance(document, new FileStream(PDFFilePath + "\\" + PdfSaveTitle + ".pdf", FileMode.Create));
            strReturnSaveFileName = PDFFilePath + "\\" + PdfSaveTitle + ".pdf";
            try
            {
                //打开目标文档对象
                document.Open();

                // 添加页眉
                HeaderFooter header = new HeaderFooter(new Phrase(PdfSaveTitle), false);
                document.Header = header;
                // 添加页脚
                HeaderFooter footer = new HeaderFooter(new Phrase(PdfSaveTitle), true);
                footer.Border = Rectangle.NO_BORDER;
                document.Footer = footer;

                //创建PDF文档中的字体
                BaseFont baseFont = BaseFont.createFont(FontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                //根据字体路径和字体大小属性创建字体
                Font font = new Font(baseFont, FontSize);

                Paragraph pTitle = new Paragraph(new Chunk(PdfSaveTitle, FontFactory.getFont(FontFactory.HELVETICA, 12)));
                document.Add(pTitle);

                //根据数据表内容创建一个PDF格式的表
                PdfPTable table = null;
                table = new PdfPTable(widthmz);


                //打印列名
                for (int j = 0; j < datatable.Columns.Count; j++)
                {
                    table.addCell(new Phrase(datatable.Columns[j].ColumnName.ToString(), font));
                }


                //遍历原table的内容
                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    for (int j = 0; j < datatable.Columns.Count; j++)
                    {
                        table.addCell(new Phrase(datatable.Rows[i][j].ToString(), font));
                    }
                }
                //在目标文档中添加转化后的表数据
                document.Add(table);
            }
            catch (Exception ec)
            {
                strReturnSaveFileName = "";
            }
            finally
            {
                //关闭目标文件
                document.Close();
                //关闭写入流
                writer.Close();
            }
            return strReturnSaveFileName;
        }
    }
}
