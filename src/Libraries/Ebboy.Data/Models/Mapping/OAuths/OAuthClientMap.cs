using Ebboy.Core.Domain.OAuths;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ebboy.Data.Models.Mapping
{
    public class OAuthClientMap : EntityTypeConfiguration<OAuthClient>
    {
        public OAuthClientMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ClientIdentifier)
                .HasMaxLength(100);

            this.Property(t => t.ClientSecret)
                .HasMaxLength(100);

            this.Property(t => t.Callback)
                .HasMaxLength(250);

            this.Property(t => t.Name)
                .HasMaxLength(100);

            this.Property(t => t.SiteUrl)
                .HasMaxLength(100);

            this.Property(t => t.AccountName)
                .HasMaxLength(100);

            this.Property(t => t.AccountId)
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("OAuthClients");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AppGuid).HasColumnName("AppGuid");
            this.Property(t => t.ClientIdentifier).HasColumnName("ClientIdentifier");
            this.Property(t => t.ClientSecret).HasColumnName("ClientSecret");
            this.Property(t => t.Callback).HasColumnName("Callback");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ClientType).HasColumnName("ClientType");
            this.Property(t => t.SiteUrl).HasColumnName("SiteUrl");
            this.Property(t => t.AccountName).HasColumnName("AccountName");
            this.Property(t => t.AccountId).HasColumnName("AccountId");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.IsEnabled).HasColumnName("IsEnabled");
        }
    }
}
