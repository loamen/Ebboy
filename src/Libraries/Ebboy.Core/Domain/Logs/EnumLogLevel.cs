using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Ebboy.Core.Domain.Logs
{
    /// <summary>
    /// 日志等级
    /// </summary>
    public enum EnumLogLevel
    {
        /// <summary>
        /// Debug
        /// </summary>
        [Description("Debug")]
        Debug = 10,
        /// <summary>
        /// 信息
        /// </summary>
        [Description("信息")]
        Information = 20,
        /// <summary>
        /// 警告
        /// </summary>
        [Description("警告")]
        Warning = 30,
        /// <summary>
        /// 错误
        /// </summary>
        [Description("错误")]
        Error = 40,
        /// <summary>
        /// 严重
        /// </summary>
        [Description("严重")]
        Fatal = 50
    }
}
