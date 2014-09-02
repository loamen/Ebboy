using System;
using System.Collections.Generic;

namespace Ebboy.Core.Domain.OAuths
{
    public partial class OAuthSymmetricCryptoKey : BaseEntity
    {
        public string Bucket { get; set; }
        public string Handle { get; set; }
        public System.DateTime ExpiresUtc { get; set; }
        public byte[] Secret { get; set; }
    }
}
