using System;
using System.Collections.Generic;

namespace Ebboy.Core.Domain.Logs
{
    public partial class Log : BaseEntity
    {
        public EnumLogLevel LogLevelId { get; set; }
        public string ShortMessage { get; set; }
        public string FullMessage { get; set; }
        public string IpAddress { get; set; }
        public Nullable<System.Guid> UserGuid { get; set; }
        public string PageUrl { get; set; }
        public string ReferrerUrl { get; set; }
        public System.DateTime CreatedOnUtc { get; set; }
    }
}
