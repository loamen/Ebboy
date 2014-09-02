using System;
using System.Collections.Generic;

namespace Ebboy.Core.Domain.Provinces
{
    public partial class ProvinceCity : BaseEntity
    {
        public System.Guid RegionId { get; set; }
        public Nullable<System.Guid> ParentId { get; set; }
        public string Name { get; set; }
        public string NameSpell { get; set; }
        public string Layer { get; set; }
        public string LayerName { get; set; }
        public string Code { get; set; }
        public int Depth { get; set; }
        public bool HasChild { get; set; }
        public int Sort { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime UpdateTime { get; set; }
    }
}
