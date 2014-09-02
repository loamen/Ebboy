using Ebboy.Core.Domain.Logs;
using Ebboy.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Services.Logs
{
    public static class LoggerExtension
    {
        /// <summary>
        /// 记录BUG日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <param name="user"></param>
        public static void Debug(this ILogger logger, string message, Exception exception = null, Member user = null)
        {
            FilteredLog(logger, EnumLogLevel.Debug, message, exception, user);
        }

        /// <summary>
        /// 记录消息日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <param name="user"></param>
        public static void Information(this ILogger logger, string message, Exception exception = null, Member user = null)
        {
            FilteredLog(logger, EnumLogLevel.Information, message, exception, user);
        }

        /// <summary>
        /// 记录警告日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <param name="user"></param>
        public static void Warning(this ILogger logger, string message, Exception exception = null, Member user = null)
        {
            FilteredLog(logger, EnumLogLevel.Warning, message, exception, user);
        }

        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <param name="user"></param>
        public static void Error(this ILogger logger, string message, Exception exception = null, Member user = null)
        {
            FilteredLog(logger, EnumLogLevel.Error, message, exception, user);
        }

        /// <summary>
        /// 记录严重日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <param name="user"></param>
        public static void Fatal(this ILogger logger, string message, Exception exception = null, Member user = null)
        {
            FilteredLog(logger, EnumLogLevel.Fatal, message, exception, user);
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="level"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <param name="user"></param>
        private static void FilteredLog(ILogger logger, EnumLogLevel level, string message, Exception exception = null, Member user = null)
        {
            //don't log thread abort exception
            if ((exception != null) && (exception is System.Threading.ThreadAbortException))
                return;

            if (logger.IsEnabled(level))
            {
                string fullMessage = exception == null ? string.Empty : exception.ToString();
                logger.InsertLog(level, message, fullMessage, user);
            }
        }
    }
}
