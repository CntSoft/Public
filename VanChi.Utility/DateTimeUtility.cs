using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanChi.Utility
{
    public class DateTimeUtility
    {
        public static string GetSqlDateTime(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd");
        }
        public static string GetFullSqlDateTime(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public static string GetSqlDateTime(string date)
        {
            string[] item = date.Split(new char[] { '/' });
            if (item.Length < 3)
            {
                return GetSqlDateTime(DateTime.Now);
            }
            return string.Join("-", new string[] { item[2], item[1], item[0] });
        }
    }
}
