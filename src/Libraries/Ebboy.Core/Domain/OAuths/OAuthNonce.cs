using System;
using System.Collections.Generic;

namespace Ebboy.Core.Domain.OAuths
{
    public partial class OAuthNonce : BaseEntity
    {
        public string Context { get; set; }
        public string Code { get; set; }
        public System.DateTime Timestamp { get; set; }
    }
}
