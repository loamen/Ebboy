using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Core.Helpers.Email
{
    // <summary>
    /// 邮件类
    /// </summary>
    public class EmailModel
    {
        private string fromMailAddress = ConfigurationManager.AppSettings["fromEmailAddress"];
        private string fromUser = ConfigurationManager.AppSettings["fromUserName"];
        private bool isHtml = true;
        private Encoding encoding = Encoding.UTF8;

        /// <summary>
        /// 发件人地址(用于显示)
        /// </summary>
        public string FromMailAddress
        {
            get { return this.fromMailAddress; }
            set { this.fromMailAddress = value; }
        }

        /// <summary>
        /// 邮件发送者显示名称
        /// </summary>
        public string FromUser
        {
            get { return this.fromUser; }
            set { this.fromUser = value; }
        }

        /// <summary>
        /// 邮件收件人地址集合
        /// </summary>
        public string[] MailAddress { set; get; }

        /// <summary>
        /// 邮件主题
        /// </summary>
        public string Title { set; get; }

        /// <summary>
        /// 邮件内容
        /// </summary>
        public string Content { set; get; }

        /// <summary>
        /// 是否以HTML格式发送
        /// </summary>
        public bool IsHtml
        {
            get { return this.isHtml; }
            set { this.isHtml = value; }
        }

        /// <summary>
        /// 邮件编码方式
        /// </summary>
        public Encoding EnCoding
        {
            get { return this.encoding; }
            set { this.encoding = value; }
        }
    }
}
