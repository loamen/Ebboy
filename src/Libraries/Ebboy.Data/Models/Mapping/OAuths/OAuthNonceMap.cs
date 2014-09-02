using Ebboy.Core.Domain.OAuths;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ebboy.Data.Models.Mapping
{
    public class OAuthNonceMap : EntityTypeConfiguration<OAuthNonce>
    {
        public OAuthNonceMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Context)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("OAuthNonces");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Context).HasColumnName("Context");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Timestamp).HasColumnName("Timestamp");
        }
    }
}
