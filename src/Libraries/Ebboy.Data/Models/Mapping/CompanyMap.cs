using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BangBang.Data.Models.Mapping
{
    public class CompanyMap : EntityTypeConfiguration<Company>
    {
        public CompanyMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Domain)
                .HasMaxLength(50);

            this.Property(t => t.Abbreviation)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CompanyName)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.Address)
                .HasMaxLength(500);

            this.Property(t => t.Logo)
                .HasMaxLength(500);

            this.Property(t => t.Phone)
                .HasMaxLength(50);

            this.Property(t => t.Fax)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            this.Property(t => t.QQ)
                .HasMaxLength(20);

            this.Property(t => t.Weixin)
                .HasMaxLength(150);

            this.Property(t => t.Homepage)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Companies");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CompanyNo).HasColumnName("CompanyNo");
            this.Property(t => t.Domain).HasColumnName("Domain");
            this.Property(t => t.Abbreviation).HasColumnName("Abbreviation");
            this.Property(t => t.CompanyName).HasColumnName("CompanyName");
            this.Property(t => t.AddressId).HasColumnName("AddressId");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Logo).HasColumnName("Logo");
            this.Property(t => t.CompanyType).HasColumnName("CompanyType");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.QQ).HasColumnName("QQ");
            this.Property(t => t.Weixin).HasColumnName("Weixin");
            this.Property(t => t.Homepage).HasColumnName("Homepage");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.Deleted).HasColumnName("Deleted");
            this.Property(t => t.AdminUserId).HasColumnName("AdminUserId");
            this.Property(t => t.CreatedOnUtc).HasColumnName("CreatedOnUtc");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
        }
    }
}
