using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Office.Xls
{
    static public class XlsConvert
    {
        static public void ConvertCsvToXls(string sourcePath, string targetPath)
        {
            //加载CSV文件
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(sourcePath, ",");
            //获取第一个工作表
            Worksheet sheet = workbook.Worksheets[0];
            //访问工作表中使用的范围
            CellRange usedRange = sheet.AllocatedRange;
            //当将范围内的数字保存为文本时，忽略错误
            usedRange.IgnoreErrorOptions = IgnoreErrorType.NumberAsText;
            //自适应行高、列宽
            usedRange.AutoFitColumns();
            usedRange.AutoFitRows();
            //保存文档
            workbook.SaveToFile(targetPath, ExcelVersion.Version2013);
        }
    }
}
