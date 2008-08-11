using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop.Word;

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
    }
}
