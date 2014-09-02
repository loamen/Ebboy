using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Core.Net
{
    /// 接口名称：IHttpMethod
    /// <summary>
    /// 网络抓取数据
    /// </summary>
    /// <remarks>
    /// 网络抓取数据
    /// </remarks>
    /// 创 建 者：Loamen.com
    /// 创建日期：2012/12/28
    public interface IHttpMethod
    {
        /// 方法名：HttpGet
        /// <summary>
        /// HTTP GET方式请求数据.
        /// </summary>
        /// <remarks>
        /// HTTP GET方式请求数据.
        /// </remarks>
        /// <param name="url"></param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        string HttpGet(string url);

        /// 方法名：HttpGet
        /// <summary>
        /// HTTP GET方式请求数据.
        /// </summary>
        /// <remarks>
        /// HTTP GET方式请求数据.
        /// </remarks>
        /// <param name="url">URL</param>
        /// <param name="queryString">QueryString参数</param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        string HttpGet(string url, string queryString);

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
        string HttpGet(string url, IDictionary<object, object> dictionary);

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
        string HttpPost(string url);

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
        string HttpPost(string url, IDictionary<object, object> dictionary);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="queryString"></param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        string HttpPost(string url, string queryString);

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
        string Http(string url, string method, IDictionary<object, object> dictionary);
    }
}
