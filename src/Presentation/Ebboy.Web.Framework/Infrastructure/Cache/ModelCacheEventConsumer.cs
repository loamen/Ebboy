using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Web.Framework.Infrastructure.Cache
{
    /// <summary>
    /// 表示层缓存类
    /// </summary>
    public partial class ModelCacheEventConsumer
    {
        /// <summary>
        /// 用户公司信息
        /// <para>
        /// {0}：用户GUID
        /// </para>
        /// </summary>
        public const string USER_COMPANIES_KEY = "Ebboy.user.companies-{0}";
    }
}
