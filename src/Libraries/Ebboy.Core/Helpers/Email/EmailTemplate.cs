using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Core.Helpers.Email
{
    /// <summary>
    /// 邮件模版
    /// </summary>
    public abstract class EmailTemplate
    {
        /// <summary>
        /// 邮件主题
        /// </summary>
        public virtual string Title { set; get; }

        /// <summary>
        /// 邮件内容
        /// </summary>
        public virtual string Content { set; get; }

        /// <summary>
        /// 发件箱
        /// </summary>
        public virtual string FromEmailAddress { set; get; }

        /// <summary>
        /// 发件人
        /// </summary>
        public virtual string FromUser { set; get; }

        /// <summary>
        /// 是否以HTML格式发送
        /// </summary>
        public bool IsHtml { get; set; }

        /// <summary>
        /// 渲染
        /// </summary>
        public abstract void Render();

        /// <summary>
        /// 是否被渲染过
        /// </summary>
        bool isRender = false;

        /// <summary>
        /// 是否HTML
        /// </summary>
        /// <param name="mailAddress">邮件地址</param>
        public bool Send(params string[] mailAddress)
        {
            if (mailAddress.Length == 0) return false;

            if (!isRender) this.Render();

            if (!isRender) isRender = true;

            EmailModel model = new EmailModel();
            model.Title = this.Title;
            model.Content = this.Content;
            model.IsHtml = this.IsHtml;
            model.MailAddress = mailAddress;
            if (!string.IsNullOrEmpty(FromEmailAddress))
            {
                model.FromMailAddress = FromEmailAddress;
            }
            if (!string.IsNullOrEmpty(FromUser))
            {
                model.FromUser = FromUser;
            }

            return model.Send();
        }
    }
}
