using System;

namespace Ebboy.Core.Caching
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class CacheExtensions
    {
        /// <summary>
        /// 获取缓存，如果缓存不存在，则通过指定方法获取并设置缓存60分钟。
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="cacheManager">缓存容器</param>
        /// <param name="key">关键字</param>
        /// <param name="acquire">获取缓存数据的方法</param>
        /// <returns></returns>
        public static T Get<T>(this ICacheManager cacheManager, string key, Func<T> acquire)
        {
            return Get(cacheManager, key, 60, acquire);
        }

        /// <summary>
        /// 获取缓存，如果缓存不存在，则通过指定方法获取并设置缓存。
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="cacheManager">缓存容器</param>
        /// <param name="key">关键字</param>
        /// <param name="cacheTime">缓存时间（单位分钟），0为不缓存。</param>
        /// <param name="acquire">获取缓存数据的方法</param>
        /// <returns></returns>
        public static T Get<T>(this ICacheManager cacheManager, string key, int cacheTime, Func<T> acquire) 
        {
            if (cacheManager.IsSet(key))
            {
                return cacheManager.Get<T>(key);
            }
            else
            {
                var result = acquire();
                if (cacheTime > 0)
                    cacheManager.Set(key, result, cacheTime);
                return result;
            }
        }

        /// <summary>
        /// 更新缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheManager"></param>
        /// <param name="key"></param>
        /// <param name="cacheTime"></param>
        /// <param name="acquire"></param>
        /// <returns></returns>
        public static T Update<T>(this ICacheManager cacheManager, string key, int cacheTime, Func<T> acquire)
        {
            if (cacheManager.IsSet(key))
            {
                cacheManager.Remove(key);
            }

            var result = acquire();
            if (cacheTime > 0)
                cacheManager.Set(key, result, cacheTime);
            return result;
        }
    }
}
