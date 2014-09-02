using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ebboy.Core.Extensions
{
    public static class EnumerableExtension
    {
        /// <summary>
        /// 遍历枚举器
        /// </summary>
        /// <typeparam name="TSource">数据类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="action">数据处理</param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public static IEnumerable<TSource> Each<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            foreach (var item in source) action(item);

            return source;
        }

        #region SelectListItem 扩展

        /// <summary>
        /// 转换集合
        /// </summary>
        /// 创 建 者：Loamen.com
        public static IEnumerable<SelectListItem> ToSelectList<TSource, TText, TValue>(this IEnumerable<TSource> source, Func<TSource, TText> text, Func<TSource, TValue> value)
        {
            return ToSelectList(source, text, value, m => false);
        }

        /// <summary>
        /// 转换集合
        /// </summary>
        /// 创 建 者：Loamen.com
        public static IEnumerable<SelectListItem> ToSelectList<TSource, TText, TValue>(this IEnumerable<TSource> source, Func<TSource, TText> text, Func<TSource, TValue> value, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException("source");

            if (text == null) throw new ArgumentNullException("text");

            if (value == null) throw new ArgumentNullException("value");

            return source.Select(current => new SelectListItem
            {
                Text = string.Concat(text(current)),
                Value = string.Concat(value(current)),
                Selected = predicate(current)
            });
        }

        #endregion
    }
}
