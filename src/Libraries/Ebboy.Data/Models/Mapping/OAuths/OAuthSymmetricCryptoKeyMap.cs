using Ebboy.Core.Domain.OAuths;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ebboy.Data.Models.Mapping
{
    public class OAuthSymmetricCryptoKeyMap : EntityTypeConfiguration<OAuthSymmetricCryptoKey>
    {
        public OAuthSymmetricCryptoKeyMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Bucket)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.Handle)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.Secret)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("OAuthSymmetricCryptoKeys");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Bucket).HasColumnName("Bucket");
            this.Property(t => t.Handle).HasColumnName("Handle");
            this.Property(t => t.ExpiresUtc).HasColumnName("ExpiresUtc");
            this.Property(t => t.Secret).HasColumnName("Secret");
        }
    }
}
