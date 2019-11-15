using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanChi.Logs
{
    public class WindowsLogging
    {
        #region Properties

        /// <summary>
        /// Log category
        /// </summary>
        public const string LOG_CATEGORY = "LV.EDO";

        /// <summary>
        /// Log source
        /// </summary>
        public const string LOG_SOURCE = "Application";

        #endregion

        #region Methods

        /// <summary>
        /// Ghi log debug
        /// </summary>
        /// <param name="message">Nội dung log</param>
        public static void LogDebug(string message)
        {
            if (!EventLog.SourceExists(LOG_CATEGORY))
            {
                EventLog.CreateEventSource(LOG_CATEGORY, LOG_SOURCE);
            }
            string strLogEvent = BuildLogEvent(message, null);
            EventLog.WriteEntry(LOG_SOURCE, strLogEvent, EventLogEntryType.Information);
        }

        /// <summary>
        /// Ghi log debug
        /// </summary>
        /// <param name="message">Nội dung log</param>
        /// <param name="exception">Đối tượng Exception</param>
        public static void LogDebug(string message, Exception exception)
        {
            if (!EventLog.SourceExists(LOG_CATEGORY))
            {
                EventLog.CreateEventSource(LOG_CATEGORY, LOG_SOURCE);
            }
            string strLogEvent = BuildLogEvent(message, exception);
            EventLog.WriteEntry(LOG_SOURCE, strLogEvent, EventLogEntryType.Information);
        }

        /// <summary>
        /// Ghi log lỗi
        /// </summary>
        /// <param name="message">Nội dung lỗi</param>
        public static void LogError(string message)
        {
            if (!EventLog.SourceExists(LOG_CATEGORY))
            {
                EventLog.CreateEventSource(LOG_CATEGORY, LOG_SOURCE);
            }
            string strLogEvent = BuildLogEvent(message, null);
            EventLog.WriteEntry(LOG_SOURCE, strLogEvent, EventLogEntryType.Error);
        }

        /// <summary>
        /// Ghi log lỗi
        /// </summary>
        /// <param name="message">Nội dung lỗi</param>
        /// <param name="exception">Đối tượng Exception</param>
        public static void LogError(string message, Exception exception)
        {
            if (!EventLog.SourceExists(LOG_CATEGORY))
            {
                EventLog.CreateEventSource(LOG_CATEGORY, LOG_SOURCE);
            }
            string strLogEvent = BuildLogEvent(message, exception);
            EventLog.WriteEntry(LOG_SOURCE, strLogEvent, EventLogEntryType.Error);
        }

        /// <summary>
        /// Ghi log lỗi
        /// </summary>
        /// <param name="message">Nội dung lỗi</param>
        public static void LogFatal(string message)
        {
            if (!EventLog.SourceExists(LOG_CATEGORY))
            {
                EventLog.CreateEventSource(LOG_CATEGORY, LOG_SOURCE);
            }
            string strLogEvent = BuildLogEvent(message, null);
            EventLog.WriteEntry(LOG_SOURCE, strLogEvent, EventLogEntryType.Error);
        }

        /// <summary>
        /// Ghi log lỗi
        /// </summary>
        /// <param name="message">Nội dung lỗi</param>
        /// <param name="exception">Đối tượng Exception</param>
        public static void LogFatal(string message, Exception exception)
        {
            if (!EventLog.SourceExists(LOG_CATEGORY))
            {
                EventLog.CreateEventSource(LOG_CATEGORY, LOG_SOURCE);
            }
            string strLogEvent = BuildLogEvent(message, exception);
            EventLog.WriteEntry(LOG_SOURCE, strLogEvent, EventLogEntryType.Error);
        }

        /// <summary>
        /// Ghi log thông tin
        /// </summary>
        /// <param name="message">Nội dung</param>
        public static void LogInfo(string message)
        {
            if (!EventLog.SourceExists(LOG_CATEGORY))
            {
                EventLog.CreateEventSource(LOG_CATEGORY, LOG_SOURCE);
            }
            string strLogEvent = BuildLogEvent(message, null);
            EventLog.WriteEntry(LOG_SOURCE, strLogEvent, EventLogEntryType.Information);
        }

        /// <summary>
        /// Ghi log thông tin
        /// </summary>
        /// <param name="message">Nội dung</param>
        /// <param name="exception">Đối tượng Exception</param>
        public static void LogInfo(string message, Exception exception)
        {
            if (!EventLog.SourceExists(LOG_CATEGORY))
            {
                EventLog.CreateEventSource(LOG_CATEGORY, LOG_SOURCE);
            }
            string strLogEvent = BuildLogEvent(message, exception);
            EventLog.WriteEntry(LOG_SOURCE, strLogEvent, EventLogEntryType.Information);
        }

        /// <summary>
        /// Ghi log cảnh báo
        /// </summary>
        /// <param name="message">Nội dung cảnh báo</param>
        public static void LogWarn(string message)
        {
            if (!EventLog.SourceExists(LOG_CATEGORY))
            {
                EventLog.CreateEventSource(LOG_CATEGORY, LOG_SOURCE);
            }
            string strLogEvent = BuildLogEvent(message, null);
            EventLog.WriteEntry(LOG_SOURCE, strLogEvent, EventLogEntryType.Warning);
        }

        /// <summary>
        /// Ghi log cảnh báo
        /// </summary>
        /// <param name="message">Nội dung cảnh báo</param>
        /// <param name="exception">Đối tượng Exception</param>
        public static void LogWarn(string message, Exception exception)
        {
            if (!EventLog.SourceExists(LOG_CATEGORY))
            {
                EventLog.CreateEventSource(LOG_CATEGORY, LOG_SOURCE);
            }
            string strLogEvent = BuildLogEvent(message, exception);
            EventLog.WriteEntry(LOG_SOURCE, strLogEvent, EventLogEntryType.Warning);
        }

        /// <summary>
        /// Build log event string
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="exception">Exception</param>
        /// <returns>Log event string</returns>
        private static string BuildLogEvent(string message, Exception exception)
        {
            string strLogEvent = string.Empty;
            if (exception != null)
            {
                strLogEvent = "Source: " + message + ".\n";
                strLogEvent += "Message: " + exception.Message + ".\n";
                strLogEvent += "HResult: " + exception.HResult + ".\n";
                strLogEvent += "StackTrace: " + exception.StackTrace + ".\n";
                if (exception.InnerException != null)
                {
                    strLogEvent += "InnerException: " + exception.InnerException.Message + ".\n";
                }
            }
            else
            {
                strLogEvent = "Message: " + message + ".\n";
            }
            return strLogEvent;
        }

        #endregion
    }
}
