using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BangBang.Data.Models.Mapping
{
    public class SystemRegionMap : EntityTypeConfiguration<SystemRegion>
    {
        public SystemRegionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.NameSpell)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.Layer)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.LayerName)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("SystemRegions");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.RegionId).HasColumnName("RegionId");
            this.Property(t => t.ParentId).HasColumnName("ParentId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.NameSpell).HasColumnName("NameSpell");
            this.Property(t => t.Layer).HasColumnName("Layer");
            this.Property(t => t.LayerName).HasColumnName("LayerName");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Depth).HasColumnName("Depth");
            this.Property(t => t.HasChild).HasColumnName("HasChild");
            this.Property(t => t.Sort).HasColumnName("Sort");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.UpdateTime).HasColumnName("UpdateTime");
        }
    }
}
