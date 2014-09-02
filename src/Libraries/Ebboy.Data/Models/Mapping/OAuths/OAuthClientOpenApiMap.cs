using Ebboy.Core.Domain.OAuths;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ebboy.Data.Models.Mapping
{
    public class OAuthClientOpenApiMap : EntityTypeConfiguration<OAuthClientOpenApi>
    {
        public OAuthClientOpenApiMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.OpenApi)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("OAuthClientOpenApis");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ClientId).HasColumnName("ClientId");
            this.Property(t => t.OpenApi).HasColumnName("OpenApi");

            // Relationships
            this.HasRequired(t => t.OAuthClient)
                .WithMany(t => t.OAuthClientOpenApis)
                .HasForeignKey(d => d.ClientId);

        }
    }
}
