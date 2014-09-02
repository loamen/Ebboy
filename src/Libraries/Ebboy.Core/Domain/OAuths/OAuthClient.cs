using System;
using System.Collections.Generic;

namespace Ebboy.Core.Domain.OAuths
{
    public partial class OAuthClient : BaseEntity
    {
        public OAuthClient()
        {
            this.OAuthClientAuthorizations = new List<OAuthClientAuthorization>();
            this.OAuthClientOpenApis = new List<OAuthClientOpenApi>();
        }
        public System.Guid AppGuid { get; set; }
        public string ClientIdentifier { get; set; }
        public string ClientSecret { get; set; }
        public string Callback { get; set; }
        public string Name { get; set; }
        public int ClientType { get; set; }
        public string SiteUrl { get; set; }
        public string AccountName { get; set; }
        public string AccountId { get; set; }
        public string Address { get; set; }
        public bool IsEnabled { get; set; }
        public virtual ICollection<OAuthClientAuthorization> OAuthClientAuthorizations { get; set; }
        public virtual ICollection<OAuthClientOpenApi> OAuthClientOpenApis { get; set; }
    }
}
