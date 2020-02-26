using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;

namespace VanChi.Common
{
    public class Ultilities
    {
        public static string GetTemporaryDirectory()
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectory);
            return tempDirectory;
        }
        public static string GetDateTimeString(object dateTime)
        {
            return GetDateTimeString(dateTime, AppSettings.SystemDateFormat);
        }

        public static string GetDateTimeString(object dateTime, string format)
        {
            System.Globalization.CultureInfo dateCulture = System.Globalization.CultureInfo.CreateSpecificCulture(AppSettings.SystemCulture);
            if (dateTime is DateTime)
            {
                return ((DateTime)dateTime).ToString(format, dateCulture);
            }
            return string.Empty;
        }

        public static string GetNumerFormat<T>(T number, NumberFormat format)
        {
            try
            {
                decimal dmNumber = 0;
                bool bConvertToDecimal = false;
                if (number != null && !(number is double || number is decimal || number is string))
                {
                    try
                    {
                        dmNumber = Convert.ToDecimal(number);
                        bConvertToDecimal = true;
                    }
                    catch
                    {
                        return "0";
                    }
                }
                if (number is double || number is decimal || number is string || bConvertToDecimal)
                {
                    string sFormat = "";
                    System.Globalization.CultureInfo cul = System.Globalization.CultureInfo.CreateSpecificCulture(AppSettings.SystemCulture);
                    string decimalSep = cul.NumberFormat.CurrencyDecimalSeparator;
                    string groupSep = cul.NumberFormat.CurrencyGroupSeparator;
                    double dbNumber = number is double ? (double)(object)number : 0.0;
                    dmNumber = bConvertToDecimal ? dmNumber : number is decimal ? (decimal)(object)number : 0;
                    string strNumber = number is string ? (string)(object)number : "0";
                    if (format == NumberFormat.CurrencyIllusion)
                    {
                        sFormat = string.Format("#{0}##0", groupSep);
                    }
                    else if (format == NumberFormat.Currency)
                    {
                        sFormat = string.Format("#{0}##0{1}00", groupSep, decimalSep);
                    }
                    else if (format == NumberFormat.Number)
                    {
                        sFormat = string.Format("#{0}##0{1}#", groupSep, decimalSep);
                    }
                    else if (format == NumberFormat.CurrencyABS)
                    {
                        sFormat = string.Format("#{0}##0", groupSep);
                        if (number is double)
                        {
                            dbNumber = Math.Ceiling(dbNumber);
                        }
                        else if (number is decimal || bConvertToDecimal)
                        {
                            dmNumber = Math.Ceiling(dmNumber);
                        }
                        else
                        {
                            if (decimal.TryParse(strNumber, out dmNumber))
                            {
                                strNumber = Math.Ceiling(dmNumber).ToString();
                            }
                            else return "0";
                        }
                    }
                    if (number is double)
                    {
                        return dbNumber.ToString(sFormat);
                    }
                    else if (number is decimal || bConvertToDecimal)
                    {
                        return dmNumber.ToString(sFormat);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(strNumber)) return "0";
                        if (decimal.TryParse(strNumber, out dmNumber))
                        {
                            return dmNumber.ToString(sFormat);
                        }
                        else
                        {
                            return "0";
                        }
                    }
                }
            }
            catch
            {
                return number.ToString();
            }
            return string.Empty;
        }
        /// <summary>
        /// Generates a sequential guid
        /// Based on http://stackoverflow.com/questions/665417/sequential-guid-in-linq-to-sql
        /// </summary>
        /// <returns></returns>
        public static Guid GenerateComb()
        {
            // Fill the destination array with a guid - only the last 6 bytes of a guid are
            // evaluated for sorting on SQL Server, and this algorithm will later overwrite those with
            // 6 bytes that are related to time, and therefore the guids are in generation order as far
            // as SQL Server is concerned.
            // Putting an actual guid in the destination array first helps ensure uniqueness across
            // the remaining bytes. See http://msdn.microsoft.com/en-us/library/ms254976.aspx
            var destinationArray = Guid.NewGuid().ToByteArray();

            // Get clock ticks since 1900 and convert to byte array (we will use last 4 bytes later)
            var time = new DateTime(1900, 1, 1);
            var now = DateTime.UtcNow;
            var ticksSince1900 = new TimeSpan(now.Ticks - time.Ticks);
            var bytesFromClockTicks = BitConverter.GetBytes(ticksSince1900.Days);

            // Get milliseconds from time of day and convert to byte array (we will use last 2 bytes later)
            var timeOfDay = now.TimeOfDay;
            var bytesFromMilliseconds = BitConverter.GetBytes((long)(timeOfDay.TotalMilliseconds / 3.333333)); // Note that SQL Server is accurate to 3.33 millisecond so we divide by 3.333333,
            // makes us compatible with NEWSEQUENTIALID. Not sure that this is useful...

            // Reverse bytes for storage in SQL server
            Array.Reverse(bytesFromClockTicks);
            Array.Reverse(bytesFromMilliseconds);

            // Replace the last 6 bytes of our Guid. These are the ones SQL server will use when comparing guids
            Array.Copy(bytesFromClockTicks, bytesFromClockTicks.Length - 2, destinationArray, destinationArray.Length - 6, 2);
            Array.Copy(bytesFromMilliseconds, bytesFromMilliseconds.Length - 4, destinationArray, destinationArray.Length - 4, 4);

            return new Guid(destinationArray);
        }
        public static string getPathFileName(string path,string fileName)
        {
            if (fileName!=string.Empty)
            {
                return path.Replace("/", "\\") + fileName;
            }
            else
            {
                return string.Empty;
            }
        }
    }

}