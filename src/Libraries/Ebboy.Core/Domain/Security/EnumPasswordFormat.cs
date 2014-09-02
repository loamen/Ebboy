using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Core.Domain.Security
{
    public enum EnumPasswordFormat : int
    {
        /// <summary>
        /// 明文
        /// </summary>
        [Description("明文")]
        Clear = 0,
        /// <summary>
        /// Hash 加密
        /// </summary>
        [Description("Hash 加密")]
        Hashed = 1,
        /// <summary>
        /// 密钥 Hash 加密
        /// </summary>
        [Description("密钥 Hash 加密")]
        Encrypted = 2,
        /// <summary>
        /// 密钥 MD5 加密
        /// </summary>
        [Description("密钥 MD5 加密")]
        MD5 = 3
    }
}
