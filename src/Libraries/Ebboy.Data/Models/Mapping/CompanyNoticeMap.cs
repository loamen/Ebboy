using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BangBang.Data.Models.Mapping
{
    public class CompanyNoticeMap : EntityTypeConfiguration<CompanyNotice>
    {
        public CompanyNoticeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.NoticeContent)
                .IsRequired();

            this.Property(t => t.NoticeType)
                .HasMaxLength(50);

            this.Property(t => t.PublishOrg)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.RealName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CompanyNotices");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.NoticeContent).HasColumnName("NoticeContent");
            this.Property(t => t.NoticeType).HasColumnName("NoticeType");
            this.Property(t => t.CompanyNo).HasColumnName("CompanyNo");
            this.Property(t => t.PublishOrg).HasColumnName("PublishOrg");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.RealName).HasColumnName("RealName");
            this.Property(t => t.SortIndex).HasColumnName("SortIndex");
            this.Property(t => t.Hits).HasColumnName("Hits");
            this.Property(t => t.IsTop).HasColumnName("IsTop");
            this.Property(t => t.CreatedOnUtc).HasColumnName("CreatedOnUtc");
            this.Property(t => t.EndDateUtc).HasColumnName("EndDateUtc");
        }
    }
}
