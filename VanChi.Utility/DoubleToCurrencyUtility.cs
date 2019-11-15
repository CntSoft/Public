using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanChi.Utility
{
    public sealed class DoubleToCurrencyUtility
    {
        public static string ToCurrency(double number)
        {
            string result = string.Empty;
            //round number
            number = Math.Round(number);
            var currencyVND = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            //Convert to string
            result = String.Format(currencyVND, "{0:c}", number).ToString();
            //remove characters last of string
            result = result.Replace(result.Remove(0, result.Length - 5), "");
            return result;
        }
    }
}
