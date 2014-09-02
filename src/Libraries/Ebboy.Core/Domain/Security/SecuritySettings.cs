using Ebboy.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Core.Domain.Security
{
    public class SecuritySettings : ISettings
    {
        private string _encryptionKey;
        private const string key = "25126848FE0144F4A0E04D82066F25B7";//默认加密字符串
        /// <summary>
        /// 读取或设置密钥
        /// </summary>
        public string EncryptionKey
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_encryptionKey))
                    _encryptionKey = key;
                return _encryptionKey;
            }
            set { _encryptionKey = value; }
        }

    }
}
