using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BUS
{
    public class Bus
    {
        public static void Export(DataTable dt, string sheetName)
        {
            int i = dt.Columns.Count;
            //Tạo các đối tượng Excel 
            Microsoft.Office.Interop.Excel.Application oExcel = new
            Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook  
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = sheetName;

            // Tạo tiêu đề cột  

            for (int z = 0; z < dt.Columns.Count; z++)
            {
                Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range(((char)(z + 65)) + "1", ((char)(z + 65)) + "1");
                cl1.NumberFormat = "@";
                cl1.Value2 = dt.Columns[z].ColumnName;
                cl1.ColumnWidth = 15;
            }

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A1", ((char)(dt.Columns.Count + 65 - 1)) + "1");
            rowHead.Font.Bold = true;
            // Kẻ viền 
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            // Thiết lập màu nền 
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            // Tạo mảng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable, 
            object[,] arr = new object[dt.Rows.Count, dt.Columns.Count];
            //Chuyển dữ liệu từ DataTable vào mảng đối tượng 
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                DataRow dr = dt.Rows[r];
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    arr[r, c] = dr[c];
                }
            }
            //Thiết lập vùng điền dữ liệu 
            int rowStart = 2;
            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = dt.Columns.Count;
            if (rowEnd > rowStart && columnEnd > columnStart)
            {
                // Ô bắt đầu điền dữ liệu 
                Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
                // Ô kết thúc điền dữ liệu 
                Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
                // Lấy về vùng điền dữ liệu 
                Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);
                //Điền dữ liệu vào vùng đã thiết lập 
                range.NumberFormat = "@";
                range.Value2 = arr;
                // Kẻ viền 
                range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
                // Canh giữa cột STT 
                Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];
                Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);
                oSheet.get_Range(c3, c4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            }
        }

        public static string convertitle(string str)
        {
            return System.Threading.Thread.CurrentThread.CurrentUICulture.TextInfo.ToTitleCase(str.ToLower());
        }
        
    }
}
