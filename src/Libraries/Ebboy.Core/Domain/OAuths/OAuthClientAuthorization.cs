using System;
using System.Collections.Generic;

namespace Ebboy.Core.Domain.OAuths
{
    public partial class OAuthClientAuthorization : BaseEntity
    {
        public string Token { get; set; }
        public System.DateTime CreatedOnUtc { get; set; }
        public int ClientId { get; set; }
        public string AccountId { get; set; }
        public string Scope { get; set; }
        public Nullable<System.DateTime> ExpirationDateUtc { get; set; }
        public virtual OAuthClient OAuthClient { get; set; }
    }
}
