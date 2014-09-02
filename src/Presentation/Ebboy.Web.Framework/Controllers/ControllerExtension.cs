using Ebboy.Core.Domain;
using Ebboy.Web.Framework.UI.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ebboy.Web.Framework.Controllers
{
    public static class ControllerExtension
    {
        /// <summary>
        /// 提示消息
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <param name="message">消息</param>
        /// 创 建 者：Loamen.com
        public static void Tips(this Controller controller, string message)
        {
            controller.TempData["scripts"] += JavascriptExtension.Tip(message);
        }

        /// <summary>
        /// 提示消息
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <param name="operation">业务操作反馈</param>
        /// 创 建 者：Loamen.com
        public static void Tips(this Controller controller, OperationResult operation)
        {
            controller.TempData["scripts"] += JavascriptExtension.Tip(operation.Message);
        }

        /// <summary>
        /// 提示消息
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <param name="operation">业务操作反馈</param>
        /// 创 建 者：Loamen.com
        public static void Notice(this Controller controller, string title, string message)
        {
            controller.TempData["scripts"] += JavascriptExtension.Notice(title, message);
        }
    }
}
