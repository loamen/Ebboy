using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;

namespace Ebboy.Web.Framework.Models
{
    [DataContract]
    public class ResultJson
    {       

        public ResultJson()
        {
        }

        /// <summary>
        /// 编号
        /// </summary>
        [DataMember]
        public int code { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        [DataMember]
        public string message { get; set; }

        /// <summary>
        /// 数据结果
        /// </summary>
        [DataMember]
        public object data { get; set; }

        /// <summary>
        /// 返回JSON结果
        /// </summary>
        /// <returns></returns>
        public string JsonText
        {
            get 
            {
                var jss = new JavaScriptSerializer();
                var ht = new Hashtable();
                ht.Add("code", code);
                ht.Add("data", data);
                ht.Add("message", message);

                return jss.Serialize(ht); 
            }
        }
    }
}
