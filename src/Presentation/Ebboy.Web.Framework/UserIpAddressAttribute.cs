using Ebboy.Core;
using Ebboy.Core.Infrastructure;
using Ebboy.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ebboy.Web.Framework
{
    public class UserIpAddressAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 用户IP地址
        /// </summary>
        /// <param name="filterContext"></param>
        /// 创 建 者：Loamen.com
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null || filterContext.HttpContext == null || filterContext.HttpContext.Request == null)
                return;

            //子Action不执行
            if (filterContext.IsChildAction)
                return;

            //仅限Get请求
            if (!String.Equals(filterContext.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                return;

            var webHelper = EngineContext.Current.Resolve<IWebHelper>();

            //更新用户最后登陆IP地址
            string currentIpAddress = webHelper.GetCurrentIpAddress();
            if (!String.IsNullOrEmpty(currentIpAddress))
            {
                var workContext = EngineContext.Current.Resolve<IWorkContext>();
                var user = workContext.CurrentUser;
                if (user!= null && !currentIpAddress.Equals(user.LastIpAddress, StringComparison.InvariantCultureIgnoreCase))
                {
                    var userService = EngineContext.Current.Resolve<IMemberService>();
                    user.LastIpAddress = currentIpAddress;
                    userService.Update(user);
                }
            }
        }
    }
}
