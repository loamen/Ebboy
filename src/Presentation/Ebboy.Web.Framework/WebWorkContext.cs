using Ebboy.Core;
using Ebboy.Core.Caching;
using Ebboy.Core.Domain.Users;
using Ebboy.Services.Users;
using System;
using System.Web;
using System.Web.Security;

namespace Ebboy.Web.Framework
{
    /// <summary>
    /// 上下文
    /// </summary>
    public partial class WebWorkContext : IWorkContext
    {
        #region 常量
        /// <summary>
        /// COOKIE NAME
        /// </summary>
        private const string UserCookieName = "Ebboy.user";
        #endregion

        #region 变量
        private readonly HttpContextBase _httpContext;
        private readonly IMemberService _userService;
        private readonly ICacheManager _cacheManager;

        private Member _cachedUser;
        #endregion

        #region 构造函数
        public WebWorkContext(
            ICacheManager cacheManager,
            HttpContextBase httpContextBase,
            IMemberService userService)
        {
            this._cacheManager = cacheManager;
            this._httpContext = httpContextBase;
            this._userService = userService;
        }
        #endregion

        #region 方法
        /// <summary>
        /// 获取用户COOKIE
        /// </summary>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        protected virtual HttpCookie GetUserCookie()
        {
            if (_httpContext == null || _httpContext.Request == null)
                return null;

            return _httpContext.Request.Cookies[UserCookieName];
        }

        /// <summary>
        /// 设置用户COOKIE
        /// </summary>
        /// <param name="userGuid"></param>
        /// 创 建 者：Loamen.com
        protected virtual void SetUserCookie(Guid userGuid)
        {
            if (_httpContext != null && _httpContext.Response != null)
            {
                var cookie = new HttpCookie(UserCookieName);
                cookie.HttpOnly = true;
                cookie.Value = userGuid.ToString();
                if (userGuid == Guid.Empty)
                {
                    cookie.Expires = DateTime.Now.AddMonths(-1);
                }
                else
                {
                    int cookieExpires = 24; //TODO 加到配置文件里 有效期3小时
                    cookie.Expires = DateTime.Now.AddHours(cookieExpires);
                }

                _httpContext.Response.Cookies.Remove(UserCookieName);
                _httpContext.Response.Cookies.Add(cookie);
            }
        }

        /// <summary>
        /// 清除用户COOKIE
        /// </summary>
        /// <param name="userGuid"></param>
        public virtual void ClearUserCookie()
        {
            if (_httpContext != null && _httpContext.Response != null)
            {
                if (_httpContext.Response.Cookies[UserCookieName] != null)
                {
                    _httpContext.Response.Cookies.Remove(UserCookieName);
                }
            }
        }
        #endregion

        #region 属性
        /// <summary>
        /// 读取或设置当前用户信息
        /// </summary>
        /// 创 建 者：Loamen.com
        public virtual Member CurrentUser
        {
            get
            {
                if (_cachedUser != null)
                {
                    if (_cachedUser.RealName == null)
                    {
                        _cachedUser.RealName = string.Empty;
                    }
                    return _cachedUser;
                }

                if (_cachedUser == null || _cachedUser.Deleted || !_cachedUser.Active)
                {
                    var userCookie = GetUserCookie();
                    if (userCookie != null && !String.IsNullOrEmpty(userCookie.Value))
                    {
                        Guid userGuid;
                        if (Guid.TryParse(userCookie.Value, out userGuid))
                        {
                            var userByCookie = _userService.GetUserByGuid(userGuid);
                            if (userByCookie != null)
                            {
                                _cachedUser = userByCookie; //TODO 缓存用户
                                if (_cachedUser.RealName == null)
                                {
                                    _cachedUser.RealName = string.Empty;
                                }
                            }
                        }
                    }
                }

                return _cachedUser;
            }
            set
            {
                if (value != null)
                {
                    FormsAuthentication.SetAuthCookie(value.UserGuid.ToString(), true); //设置登陆状态
                    SetUserCookie(value.UserGuid);
                }
                _cachedUser = value;
            }
        }

        /// <summary>
        /// 是否是系统管理员
        /// </summary>
        /// 创 建 者：Loamen.com
        public virtual bool IsSysAdmin { get; set; }
        #endregion
    }
}
