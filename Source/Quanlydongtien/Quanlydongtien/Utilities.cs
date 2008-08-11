using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop.Word;
using System.Windows.Forms;
namespace Quanlydongtien
{
    class Utilities
    {
        public static Boolean isInt(string number)
        {
            try
            {
                int.Parse(number);
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public static Boolean isInt64(string number)
        {
            try
            {
                Int64.Parse(number);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Boolean isDateTime(string date)
        {
            try
            {
                DateTime.Parse(date);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static DateTime minDate(DateTime date1, DateTime date2)
        {
            if (date1 < date2)
                return date1;
            else return date2;

        }

        public static DateTime maxDate(DateTime date1, DateTime date2)
        {
            if (date1 > date2)
                return date1;
            else return date2;
        }

        public static Boolean isFloat(string number)
        {
            try
            {
                float.Parse(number);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Boolean isDouble(string number)
        {
            try
            {
                double.Parse(number);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Boolean Replace_String_In_Word_File(ref Document doc, string sourceStr, string newStr)
        {           
            object replaceAll = WdReplace.wdReplaceAll;
            
            object missing = Type.Missing;
            try
            {                
                foreach(Range rng in doc.StoryRanges)
                {
                    rng.Find.Text = sourceStr;
                    rng.Find.Replacement.Text = newStr;
                    rng.Find.Wrap = WdFindWrap.wdFindContinue;
                    //object replaceAll = Word.WdReplace.wdReplaceAll;
                    rng.Find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                    //rng.Find.Execute(Replace = Word.WdReplace.wdReplaceAll);
                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static void Export_To_Excel(DataGridView dtGridView, string filename, string sheetName)
        {
            int i, j;
            object missing = Type.Missing;
            Microsoft.Office.Interop.Excel.ApplicationClass excellApp;
            excellApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
            excellApp.Application.Workbooks.Add(true);

            try
            {
                // Add columns name to excel file
                for (i = 0; i < dtGridView.Columns.Count; i++)
                {
                    excellApp.Cells[1, i + 1] = dtGridView.Columns[i].Name;
                }
                for (i = 0; i < dtGridView.Rows.Count; i++)
                {
                    for (j = 0; j < dtGridView.Columns.Count; j++)
                    {
                        excellApp.Cells[i + 2, j + 1] = dtGridView.Rows[i].Cells[j].Value;
                    }
                }
                //excellApp.Save(("Loinhuan.xls");
                Microsoft.Office.Interop.Excel._Worksheet worksheet = (Microsoft.Office.Interop.Excel._Worksheet)excellApp.ActiveSheet;
                worksheet.Activate();
                worksheet.Name = sheetName;
                worksheet.SaveAs(filename, missing, missing, missing, missing, missing, missing, missing, missing, missing);
                //excellApp.Workbooks[1].SaveCopyAs(@"D:\Project\SVN\Source\Quanlyloinhuan\Loinhuan.xls");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
