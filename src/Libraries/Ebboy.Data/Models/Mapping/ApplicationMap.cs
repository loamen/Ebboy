using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BangBang.Data.Models.Mapping
{
    public class ApplicationMap : EntityTypeConfiguration<Application>
    {
        public ApplicationMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.AppName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Introduction)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(500);

            this.Property(t => t.Logo)
                .HasMaxLength(250);

            this.Property(t => t.Logo1)
                .HasMaxLength(250);

            this.Property(t => t.Logo2)
                .HasMaxLength(250);

            this.Property(t => t.Logo3)
                .HasMaxLength(250);

            this.Property(t => t.Logo4)
                .HasMaxLength(250);

            this.Property(t => t.Category)
                .HasMaxLength(250);

            this.Property(t => t.AppUrl)
                .HasMaxLength(250);

            this.Property(t => t.CallbackUrl)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Applications");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AppGuid).HasColumnName("AppGuid");
            this.Property(t => t.AppName).HasColumnName("AppName");
            this.Property(t => t.Introduction).HasColumnName("Introduction");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Logo).HasColumnName("Logo");
            this.Property(t => t.Logo1).HasColumnName("Logo1");
            this.Property(t => t.Logo2).HasColumnName("Logo2");
            this.Property(t => t.Logo3).HasColumnName("Logo3");
            this.Property(t => t.Logo4).HasColumnName("Logo4");
            this.Property(t => t.AppType).HasColumnName("AppType");
            this.Property(t => t.ApplicationType).HasColumnName("ApplicationType");
            this.Property(t => t.Category).HasColumnName("Category");
            this.Property(t => t.HtmlIntro).HasColumnName("HtmlIntro");
            this.Property(t => t.AppUrl).HasColumnName("AppUrl");
            this.Property(t => t.CallbackUrl).HasColumnName("CallbackUrl");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.CreatedOnUtc).HasColumnName("CreatedOnUtc");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
        }
    }
}
