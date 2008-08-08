using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
