using System;
using System.Collections.Generic;

namespace Ebboy.Core.Domain.OAuths
{
    public partial class OAuthClientOpenApi : BaseEntity
    {
        public int ClientId { get; set; }
        public string OpenApi { get; set; }
        public virtual OAuthClient OAuthClient { get; set; }
    }
}
