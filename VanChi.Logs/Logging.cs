using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanChi.Logs
{
    public class Logging
    {
        #region Properties

        public static string LogType = ConfigurationManager.AppSettings[Logging.TypeOfLog].ToUpper() == Logging.TypeFile ? Logging.TypeFile : Logging.TypeWindow;

        #endregion

        #region Methods

        /// <summary>
        /// Ghi log debug
        /// </summary>
        /// <param name="message">Nội dung log</param>
        public static void LogDebug(string message)
        {
            if (LogType == "FILE")
            {
                FileLogging.LogDebug(message);
            }
            else
            {
                WindowsLogging.LogDebug(message);
            }
        }

        /// <summary>
        /// Ghi log debug
        /// </summary>
        /// <param name="message">Nội dung log</param>
        /// <param name="exception">Đối tượng Exception</param>
        public static void LogDebug(string message, Exception exception)
        {
            if (LogType == "FILE")
            {
                FileLogging.LogDebug(message, exception);
            }
            else
            {
                WindowsLogging.LogDebug(message, exception);
            }
        }

        /// <summary>
        /// Ghi log lỗi
        /// </summary>
        /// <param name="message">Nội dung lỗi</param>
        public static void LogError(string message)
        {
            if (LogType == "FILE")
            {
                FileLogging.LogError(message);
            }
            else
            {
                WindowsLogging.LogError(message);
            }
        }

        /// <summary>
        /// Ghi log lỗi
        /// </summary>
        /// <param name="message">Nội dung lỗi</param>
        /// <param name="exception">Đối tượng Exception</param>
        public static void LogError(string message, Exception exception)
        {
            if (LogType == "FILE")
            {
                FileLogging.LogError(message, exception);
            }
            else
            {
                WindowsLogging.LogError(message, exception);
            }
        }

        /// <summary>
        /// Ghi log lỗi
        /// </summary>
        /// <param name="message">Nội dung lỗi</param>
        public static void LogFatal(string message)
        {
            if (LogType == "FILE")
            {
                FileLogging.LogFatal(message);
            }
            else
            {
                WindowsLogging.LogFatal(message);
            }
        }

        /// <summary>
        /// Ghi log lỗi
        /// </summary>
        /// <param name="message">Nội dung lỗi</param>
        /// <param name="exception">Đối tượng Exception</param>
        public static void LogFatal(string message, Exception exception)
        {
            if (LogType == "FILE")
            {
                FileLogging.LogFatal(message, exception);
            }
            else
            {
                WindowsLogging.LogFatal(message, exception);
            }
        }

        /// <summary>
        /// Ghi log thông tin
        /// </summary>
        /// <param name="message">Nội dung</param>
        public static void LogInfo(string message)
        {
            if (LogType == "FILE")
            {
                FileLogging.LogInfo(message);
            }
            else
            {
                WindowsLogging.LogInfo(message);
            }
        }

        /// <summary>
        /// Ghi log thông tin
        /// </summary>
        /// <param name="message">Nội dung</param>
        /// <param name="exception">Đối tượng Exception</param>
        public static void LogInfo(string message, Exception exception)
        {
            if (LogType == "FILE")
            {
                FileLogging.LogInfo(message, exception);
            }
            else
            {
                WindowsLogging.LogInfo(message, exception);
            }
        }

        /// <summary>
        /// Ghi log cảnh báo
        /// </summary>
        /// <param name="message">Nội dung cảnh báo</param>
        public static void LogWarn(string message)
        {
            if (LogType == "FILE")
            {
                FileLogging.LogInfo(message);
            }
            else
            {
                WindowsLogging.LogInfo(message);
            }
        }

        /// <summary>
        /// Ghi log cảnh báo
        /// </summary>
        /// <param name="message">Nội dung cảnh báo</param>
        /// <param name="exception">Đối tượng Exception</param>
        public static void LogWarn(string message, Exception exception)
        {
            if (LogType == "FILE")
            {
                FileLogging.LogWarn(message, exception);
            }
            else
            {
                WindowsLogging.LogWarn(message, exception);
            }
        }

        #endregion

        #region Constants

        /// <summary>
        /// LogType
        /// </summary>
        private const string TypeOfLog = "LogType";

        /// <summary>
        /// FILE
        /// </summary>
        private const string TypeFile = "FILE";

        /// <summary>
        /// WINDOW
        /// </summary>
        private const string TypeWindow = "WINDOW";

        #endregion
    }
}
