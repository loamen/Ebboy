using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Core.Domain
{
    public class OperationResult
    {
        /// <summary>
        /// 错误列表
        /// </summary>
        public IList<string> Errors { get; set; }

        public OperationResult()
        {
            this.Errors = new List<string>();
        }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success
        {
            get { return (this.Errors.Count == 0); }
        }

        /// <summary>
        /// 返回成功消息
        /// </summary>
        public string Message { get; set; }

        public void AddError(string error)
        {
            this.Errors.Add(error);
        }

        /// <summary>
        /// 返回结果实体
        /// </summary>
        public object Data { get; set; }
    }
}
