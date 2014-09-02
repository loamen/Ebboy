using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ebboy.Core.Extensions
{
    public static class ObjectExtension
    {
        /// <summary>
        /// 把对象类型转化为指定类型，转化失败时返回该类型默认值
        /// </summary>
        /// <typeparam name="T"> 动态类型 </typeparam>
        /// <param name="value"> 要转化的源对象 </param>
        /// <returns> 转化后的指定类型的对象，转化失败返回类型的默认值 </returns>
        /// 创 建 者：Loamen.com
        public static T CastTo<T>(this object value)
        {
            object result;
            Type type = typeof(T);
            try
            {
                if (type.IsEnum)
                {
                    result = Enum.Parse(type, value.ToString());
                }
                else if (type == typeof(Guid))
                {
                    result = Guid.Parse(value.ToString());
                }
                else
                {
                    result = Convert.ChangeType(value, type);
                }
            }
            catch
            {
                result = default(T);
            }

            return (T)result;
        }

        /// <summary>
        ///     把对象类型转化为指定类型，转化失败时返回指定的默认值
        /// </summary>
        /// <typeparam name="T"> 动态类型 </typeparam>
        /// <param name="value"> 要转化的源对象 </param>
        /// <param name="defaultValue"> 转化失败返回的指定默认值 </param>
        /// <returns> 转化后的指定类型对象，转化失败时返回指定的默认值 </returns>
        /// 创 建 者：Loamen.com
        public static T CastTo<T>(this object value, T defaultValue)
        {
            object result;
            Type type = typeof(T);
            try
            {
                result = type.IsEnum ? Enum.Parse(type, value.ToString()) : Convert.ChangeType(value, type);
            }
            catch
            {
                result = defaultValue;
            }
            return (T)result;
        }

        /// <summary>
        /// 圆角切换半角
        /// </summary>
        /// <param name="str">输入字符</param>
        /// <returns>切换后字符</returns>
        /// 创 建 者：Loamen.com
        public static string ToEnglishNumber(this string str)
        {
            char[] chars = str.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == 12288)
                {
                    chars[i] = (char)32;
                    continue;
                }

                if (chars[i] > 65280 && chars[i] < 65375) chars[i] = (char)(chars[i] - 65248);
            }

            return new string(chars);
        }

        /// <summary>
        /// 获取类型和对象名称
        /// </summary>
        /// <param name="value">对象值</param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public static String ToTypeString(this object value)
        {
            return value.GetType().Name + "." + value.ToString();
        }

        /// <summary>
        /// 将字典转化为下拉项的数组
        /// </summary>
        /// <param name="dictionary">字典</param>
        /// <returns>下拉项的数组</returns>
        /// 创 建 者：Loamen.com
        public static IEnumerable<SelectListItem> ToSelectList(this IEnumerable<KeyValuePair<string, string>> dictionary)
        {
            return dictionary.Select(m => new SelectListItem
            {
                Text = m.Value,
                Value = m.Key
            });
        }

        /// <summary>
        /// 根据数据构造查询Url
        /// </summary>
        /// <param name="url">访问地址</param>
        /// <param name="dictionary">数据</param>
        /// <returns>构造好的字符串</returns>
        /// 创 建 者：Loamen.com
        public static string ToQueryString(this IEnumerable<KeyValuePair<object, object>> dictionary, UriBuilder uriBuilder)
        {
            if (dictionary == null || dictionary.Count() == 0) return uriBuilder.ToString();

            string queryString = dictionary.ToQueryString();

            if (!String.IsNullOrEmpty(uriBuilder.Query))
            {
                uriBuilder.Query = string.Concat(uriBuilder.Query.TrimStart('?'), "&", queryString);
            }
            else
            {
                uriBuilder.Query = queryString;
            }

            return uriBuilder.ToString();
        }

        /// <summary>
        /// 将字典对象转换成查询参数形式
        /// </summary>
        /// <param name="dictionary">字典对象</param>
        /// <returns>查询参数</returns>
        /// 创 建 者：Loamen.com
        public static string ToQueryString(this IEnumerable<KeyValuePair<object, object>> dictionary, bool isEncode = false)
        {
            if (dictionary == null || dictionary.Count() == 0) return String.Empty;

            string queryString = string.Empty;

            var reqParams = dictionary.Where(m => m.Key != null && m.Value != null && !String.IsNullOrEmpty(m.Value.ToString()))
                                      .Select(m => string.Format("{0}={1}", m.Key, isEncode && m.Value != null ? Uri.EscapeDataString(m.Value.ToString()) : m.Value));

            queryString = string.Join("&", reqParams.ToArray());

            return queryString;
        }

        /// <summary>
        /// 将字典转化为表单
        /// </summary>
        /// <param name="dictionary">字典</param>
        /// <param name="visible">是否显示表单</param>
        /// <param name="autoSubmit">是否自动提交</param>
        /// <returns>表单</returns>
        /// 创 建 者：Loamen.com
        public static string ToFormString(this IEnumerable<KeyValuePair<object, object>> dictionary, bool visible = true, bool autoSubmit = true)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("<form id='formsubmit' action='{0}' method='{1}' name='formsubmit'>",
                dictionary.First(m => m.Key.ToString() == "action").Value, dictionary.First(m => m.Key.ToString() == "method").Value);
            string inputType = visible ? "block" : "none";
            foreach (KeyValuePair<object, object> item in dictionary)
            {
                builder.AppendFormat("<input type='text' name='{1}' value='{2}' style='display:{0};' />", inputType, item.Key, item.Value);
            }
            builder.AppendFormat("<input type='submit' value='提交' style='display:{0};'></form>", inputType);
            if (autoSubmit) builder.Append("<script>document.forms['formsubmit'].submit();</script>");
            return builder.ToString();
        }
    }
}
