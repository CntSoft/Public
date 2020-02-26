using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace VanChi.Common
{
    public class AppSettings
    {
        private static string getAppSettings(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string ExtranetAccountXid = string.Empty;
        public static string ExtranetRole = string.Empty;
        public static string SystemDateFormat = getAppSettings("SystemDateFormat");
        public static string SystemCulture = getAppSettings("SystemCulture");
    }
}