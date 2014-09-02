using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Web.Framework.UI.Scripts
{
    public partial class JavascriptExtension
    {
        private const string ScriptBegin = "\r\n<script type=\"text/javascript\">\r\n";
        private const string ScriptEnd = "\r\n</script>";
        private const string NoScript = "\r\n\r\n<noscript>Javascript Error...</noscript>";

        /// <summary>
        /// 提示
        /// </summary>
        /// <param name="message">提示内容</param>
        /// <returns>提示脚本</returns>
        /// 创 建 者：Loamen.com
        public static string Tip(string message)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(ScriptBegin);
            stringBuilder.Append("window.Start(function(){\n");
            stringBuilder.AppendFormat("artDialog.tips('{0}');", Replace(message));
            stringBuilder.Append("\n});");
            stringBuilder.Append(ScriptEnd);
            stringBuilder.Append(NoScript);

            return stringBuilder.ToString();
        }

        /// <summary>
        /// 提示
        /// </summary>
        /// <param name="message">提示内容</param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public static string Notice(string title, string message, int width = 220)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(ScriptBegin);
            stringBuilder.Append("window.Start(function(){\n");
            stringBuilder.AppendFormat("artDialog.notice({{title: '{0}',content: '{1}',width: {2},icon: 'face-sad',time: 5}});",
                Replace(title),
                Replace(message),
                width);
            stringBuilder.Append("\n});");
            stringBuilder.Append(ScriptEnd);
            stringBuilder.Append(NoScript);

            return stringBuilder.ToString();
        }

        /// <summary>
        /// 替换内容
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        private static string Replace(string message)
        {
            if (string.IsNullOrEmpty(message))
                return string.Empty;

            return message.Replace("'", "\'").Replace("\r\n", "");
        }
    }
}
