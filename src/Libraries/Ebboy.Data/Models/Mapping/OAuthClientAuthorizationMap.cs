using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BangBang.Data.Models.Mapping
{
    public class OAuthClientAuthorizationMap : EntityTypeConfiguration<OAuthClientAuthorization>
    {
        public OAuthClientAuthorizationMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Token)
                .HasMaxLength(500);

            this.Property(t => t.AccountId)
                .HasMaxLength(50);

            this.Property(t => t.Scope)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("OAuthClientAuthorizations");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Token).HasColumnName("Token");
            this.Property(t => t.CreatedOnUtc).HasColumnName("CreatedOnUtc");
            this.Property(t => t.ClientId).HasColumnName("ClientId");
            this.Property(t => t.AccountId).HasColumnName("AccountId");
            this.Property(t => t.Scope).HasColumnName("Scope");
            this.Property(t => t.ExpirationDateUtc).HasColumnName("ExpirationDateUtc");

            // Relationships
            this.HasRequired(t => t.OAuthClient)
                .WithMany(t => t.OAuthClientAuthorizations)
                .HasForeignKey(d => d.ClientId);

        }
    }
}
