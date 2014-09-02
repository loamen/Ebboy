using Ebboy.Core;
using Ebboy.Core.Infrastructure;
using Ebboy.Services.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;

namespace Ebboy.Web.Framework.Controllers
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class UserAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public UserAuthorizeAttribute()
        {
        }

        /// <summary>
        /// 权限认证
        /// </summary>
        /// <param name="filterContext"></param>
        /// 创 建 者：Loamen.com
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //上下文为空
            if (filterContext == null) throw new ArgumentNullException("filterContext");
            //Action设置为跳过拦截器设置
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)) return;
            //Controller设置为跳过拦截器设置
            if (filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)) return;
            //用户为验证则跳转至登录页面
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult(String.Format("{0}?returnUrl={1}",
                    FormsAuthentication.LoginUrl,
                    filterContext.HttpContext.Server.UrlEncode(filterContext.HttpContext.Request.Url.ToString())));
                return;
            }
            //验证用户访问权限
            if (this.Authorize(filterContext)) return;
            //无访问权限
            filterContext.Result = new RedirectResult(FormsAuthentication.LoginUrl);
        }

        /// <summary>
        /// 验证用户是否拥有访问权限
        /// </summary>
        /// <param name="filterContext">认证上下文</param>
        /// <returns>验证结果</returns>
        /// 创 建 者：Loamen.com
        protected virtual bool Authorize(AuthorizationContext filterContext)
        {
            var _workContext = EngineContext.Current.Resolve<IWorkContext>();
            return _workContext.CurrentUser != null; //TODO 用户验证
        }
    }
}
