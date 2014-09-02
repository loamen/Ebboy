using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ebboy.Core.Net
{
    /// 类名：HttpMethods
    /// <summary>
    /// 网络抓取数据
    /// </summary>
    /// <remarks>
    /// 网络抓取数据
    /// </remarks>
    /// 创 建 者：Loamen.com
    /// 创建日期：2012/12/28
    public class HttpMethod : IHttpMethod
    {
        #region Get

        /// 方法名：HttpGet
        /// <summary>
        /// HTTP GET方式请求数据.
        /// </summary>
        /// <remarks>
        /// HTTP GET方式请求数据.
        /// </remarks>
        /// <param name="url">URL</param>
        /// <returns>HTML内容</returns>
        /// 创 建 者：Loamen.com
        public virtual string HttpGet(string url)
        {
            return HttpGet(url, string.Empty);
        }

        /// 方法名：HttpGet
        /// <summary>
        /// HTTP GET方式请求数据.
        /// </summary>
        /// <remarks>
        /// HTTP GET方式请求数据.
        /// </remarks>
        /// <param name="url">URL</param>
        /// <param name="queryString"></param>
        /// <returns>HTML内容</returns>
        /// 创 建 者：Loamen.com
        public virtual string HttpGet(string url, string queryString)
        {
            return Http(url, WebRequestMethods.Http.Get, queryString);
        }

        /// 方法名：Http
        /// <summary>
        /// HTTP Get方式请求数据.
        /// </summary>
        /// <remarks>
        /// HTTP Get方式请求数据.
        /// </remarks>
        /// <param name="url">请求地址</param>
        /// <param name="dictionary">请求参数</param>
        /// <returns></returns>
        /// 创 建 者：黎强
        /// 创建日期：2013/01/16
        public virtual string HttpGet(string url, IDictionary<object, object> dictionary)
        {
            return Http(url, WebRequestMethods.Http.Get, dictionary);
        }

        #endregion

        #region Post

        /// 方法名：HttpHttpPost
        /// <summary>
        /// HTTP Post方式请求数据.
        /// </summary>
        /// <remarks>
        /// HTTP Post方式请求数据.
        /// </remarks>
        /// <param name="url">URL</param>
        /// <returns>HTML内容</returns>
        /// 创 建 者：黎强
        /// 创建日期：2013/01/16
        public virtual string HttpPost(string url)
        {
            return HttpPost(url, string.Empty);
        }

        /// <summary>
        /// HTTP Post方式请求数据.
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="queryString">参数</param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public virtual string HttpPost(string url, string queryString)
        {
            return Http(url, WebRequestMethods.Http.Post, queryString);
        }

        /// 方法名：HttpHttpPost
        /// <summary>
        /// HTTP Post方式请求数据.
        /// </summary>
        /// <remarks>
        /// HTTP Post方式请求数据.
        /// </remarks>
        /// <param name="url">URL</param>
        /// <param name="dictionary">请求参数</param>
        /// <returns>HTML内容</returns>
        public virtual string HttpPost(string url, IDictionary<object, object> dictionary)
        {
            return Http(url, WebRequestMethods.Http.Post, dictionary);
        }

        #endregion

        #region Http

        /// 方法名：Http
        /// <summary>
        /// HTTP 方式请求数据.
        /// </summary>
        /// <remarks>
        /// HTTP 方式请求数据.
        /// </remarks>
        /// <param name="url">请求地址</param>
        /// <param name="method">请求类型</param>
        /// <param name="dictionary">请求参数</param>
        /// <returns></returns>
        public virtual string Http(string url, string method, IDictionary<object, object> dictionary)
        {
            return DoGetOrPost(CreateParameterUrl(url, dictionary), method, "");
        }

        /// <summary>
        /// HTTP 方式请求数据.
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="method">请求类型</param>
        /// <param name="queryString">请求参数</param>
        /// <returns></returns>
        public virtual string Http(string url, string method, string queryString)
        {
            return DoGetOrPost(url, method, queryString);
        }

        /// <summary>
        ///  HTTP 方式请求数据.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="queryString">请求参数</param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        protected string DoGetOrPost(string url, string method, string queryString)
        {
            const string pattern = @"^(http(s)?:\/\/)?\w.+$"; //验证URL正确性 Don 2013-07-19
            var regex = new Regex(pattern);
            //格式化为Http格式的请求
            if (!regex.IsMatch(url))
            {
                url = String.Format("http://{0}", url);
            }

            //如果是Get请求，将参数写入Url中
            if ("get".Equals(method, StringComparison.CurrentCultureIgnoreCase))
            {
                url = CreateParameterUrl(url, queryString);
            }

            //初始化Http请求
            var request = (HttpWebRequest)WebRequest.Create(url);

            //设置Http参数
            request.Method = method;
            request.Accept = "*/*";
            request.Timeout = 60 * 1000;
            request.AllowAutoRedirect = false;
            request.ContentType = "application/x-www-form-urlencoded";

            //如果是Post请求，将请求参数写入请求中
            if ("post".Equals(method, StringComparison.CurrentCultureIgnoreCase) && !string.IsNullOrEmpty(queryString))
            {
                var bytes = Encoding.UTF8.GetBytes(queryString);
                request.ContentLength = bytes.Length;

                //写入请求内容
                using (var reqStream = request.GetRequestStream())
                {
                    reqStream.Write(bytes, 0, bytes.Length);
                    reqStream.Close();
                }
            }

            string responseStr = null;

            //获取返回值
            using (var response = request.GetResponse())
            {
                var stream = response.GetResponseStream();
                if (stream != null)
                {
                    var reader = new StreamReader(stream, Encoding.UTF8);
                    responseStr = reader.ReadToEnd();
                    reader.Close();
                }
            }

            return responseStr;
        }

        #endregion

        #region Helper

        /// <summary>
        /// 根据数据构造查询Url
        /// </summary>
        /// <param name="url">访问地址</param>
        /// <param name="dictionary">数据</param>
        /// <returns>构造好的字符串</returns>
        private string CreateParameterUrl(string url, IDictionary<object, object> dictionary)
        {
            //验证参数
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            if (dictionary == null || !dictionary.Any()) return url;

            var queryString = ToQueryString(dictionary);

            var uriBuilder = new UriBuilder(url);
            if (!String.IsNullOrWhiteSpace(uriBuilder.Query))
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
        /// 根据数据构造查询Url
        /// </summary>
        /// <param name="url">访问地址</param>
        /// <param name="queryString">参数</param>
        /// <returns>构造好的字符串</returns>
        private string CreateParameterUrl(string url, string queryString)
        {
            //验证参数
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
            if (string.IsNullOrEmpty(queryString)) return url;

            var uriBuilder = new UriBuilder(url);
            if (!String.IsNullOrWhiteSpace(uriBuilder.Query))
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
        private string ToQueryString(IDictionary<object, object> dictionary)
        {
            if (dictionary == null || !dictionary.Any()) return String.Empty;
            string queryString;
            var reqParams = dictionary.Where(m => m.Key != null && m.Value != null && !String.IsNullOrWhiteSpace(m.Value.ToString()))
                                      .Select(m => string.Format("{0}={1}", m.Key, m.Value));
            queryString = string.Join("&", reqParams.ToArray());
            return queryString;
        }

        #endregion
    }
}
