using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Core.Extensions
{
    /// <summary>
    /// 时间日期扩展
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// 转化为某时区时间
        /// </summary>
        /// <param name="dateTime"></param>
        ///  <param name="dateTime"></param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public static DateTime ToTimeZoneDateTime(this DateTime dateTime,string timeZoneId)
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId); //查找时区

            return TimeZoneInfo.ConvertTime(dateTime, timeZone);
        }

        /// <summary>
        /// 转化成UTC时间
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public static DateTime AsUtc(this DateTime dateTime)
        {
            if (dateTime.Kind == DateTimeKind.Unspecified)
            {
                return new DateTime(dateTime.Ticks, DateTimeKind.Utc);
            }

            return dateTime.ToUniversalTime();
        }

        /// <summary>
        /// 将Unix时间戳转换为DateTime类型时间
        /// </summary>
        /// <param name="timestamp">double 型数字</param>
        /// <returns>时间</returns>
        public static DateTime ToUtcTime(this double timestamp)
        {
            var time = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(timestamp);
            return time;
        }

        /// <summary>
        /// DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name="utcTime">UTC时间</param>
        /// <returns>double</returns>
        public static int ToUnixTimestamp(this DateTime utcTime)
        {
            var timeSpan = (utcTime - new DateTime(1970, 1, 1, 0, 0, 0));
            return (int)timeSpan.TotalSeconds;
        }
    }
}
