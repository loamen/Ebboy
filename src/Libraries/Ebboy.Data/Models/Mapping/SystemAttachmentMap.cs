using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BangBang.Data.Models.Mapping
{
    public class SystemAttachmentMap : EntityTypeConfiguration<SystemAttachment>
    {
        public SystemAttachmentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Title)
                .HasMaxLength(50);

            this.Property(t => t.ModuleName)
                .HasMaxLength(50);

            this.Property(t => t.FuncName)
                .HasMaxLength(50);

            this.Property(t => t.ArticleId)
                .HasMaxLength(50);

            this.Property(t => t.FileName)
                .HasMaxLength(50);

            this.Property(t => t.FileDomain)
                .HasMaxLength(50);

            this.Property(t => t.FilePath)
                .HasMaxLength(255);

            this.Property(t => t.FileExt)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SystemAttachments");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserGuid).HasColumnName("UserGuid");
            this.Property(t => t.AppGuid).HasColumnName("AppGuid");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ModuleName).HasColumnName("ModuleName");
            this.Property(t => t.FuncName).HasColumnName("FuncName");
            this.Property(t => t.ArticleId).HasColumnName("ArticleId");
            this.Property(t => t.FileName).HasColumnName("FileName");
            this.Property(t => t.FileDomain).HasColumnName("FileDomain");
            this.Property(t => t.FilePath).HasColumnName("FilePath");
            this.Property(t => t.FileExt).HasColumnName("FileExt");
            this.Property(t => t.FileSize).HasColumnName("FileSize");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.CreateDateOnUtc).HasColumnName("CreateDateOnUtc");
        }
    }
}
