using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanChi.Logs
{
    public class FileLogging
    {
        #region Properties

        /// <summary>
        /// Log engine
        /// </summary>
        public static ILog Logger = LogManager.GetLogger(typeof(FileLogging));

        #endregion

        #region Methods

        /// <summary>
        /// Ghi log debug
        /// </summary>
        /// <param name="message">Nội dung log</param>
        public static void LogDebug(string message)
        {
            Logger.Debug(message);
        }

        /// <summary>
        /// Ghi log debug
        /// </summary>
        /// <param name="message">Nội dung log</param>
        /// <param name="exception">Đối tượng Exception</param>
        public static void LogDebug(string message, Exception exception)
        {
            Logger.Debug(message, exception);
        }

        /// <summary>
        /// Ghi log lỗi
        /// </summary>
        /// <param name="message">Nội dung lỗi</param>
        public static void LogError(string message)
        {
            Logger.Error(message);
        }

        /// <summary>
        /// Ghi log lỗi
        /// </summary>
        /// <param name="message">Nội dung lỗi</param>
        /// <param name="exception">Đối tượng Exception</param>
        public static void LogError(string message, Exception exception)
        {
            Logger.Error(message, exception);
        }

        /// <summary>
        /// Ghi log lỗi
        /// </summary>
        /// <param name="message">Nội dung lỗi</param>
        public static void LogFatal(string message)
        {
            Logger.Fatal(message);
        }

        /// <summary>
        /// Ghi log lỗi
        /// </summary>
        /// <param name="message">Nội dung lỗi</param>
        /// <param name="exception">Đối tượng Exception</param>
        public static void LogFatal(string message, Exception exception)
        {
            Logger.Fatal(message, exception);
        }

        /// <summary>
        /// Ghi log thông tin
        /// </summary>
        /// <param name="message">Nội dung</param>
        public static void LogInfo(string message)
        {
            Logger.Info(message);
        }

        /// <summary>
        /// Ghi log thông tin
        /// </summary>
        /// <param name="message">Nội dung</param>
        /// <param name="exception">Đối tượng Exception</param>
        public static void LogInfo(string message, Exception exception)
        {
            Logger.Info(message, exception);
        }

        /// <summary>
        /// Ghi log cảnh báo
        /// </summary>
        /// <param name="message">Nội dung cảnh báo</param>
        public static void LogWarn(string message)
        {
            Logger.Warn(message);
        }

        /// <summary>
        /// Ghi log cảnh báo
        /// </summary>
        /// <param name="message">Nội dung cảnh báo</param>
        /// <param name="exception">Đối tượng Exception</param>
        public static void LogWarn(string message, Exception exception)
        {
            Logger.Warn(message, exception);
        }

        #endregion
    }
}
