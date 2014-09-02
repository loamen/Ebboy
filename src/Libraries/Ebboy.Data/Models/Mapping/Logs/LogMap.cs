using Ebboy.Core.Domain.Logs;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ebboy.Data.Models.Mapping
{
    public class LogMap : EntityTypeConfiguration<Log>
    {
        public LogMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ShortMessage)
                .IsRequired();

            this.Property(t => t.IpAddress)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Logs");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.LogLevelId).HasColumnName("LogLevelId");
            this.Property(t => t.ShortMessage).HasColumnName("ShortMessage");
            this.Property(t => t.FullMessage).HasColumnName("FullMessage");
            this.Property(t => t.IpAddress).HasColumnName("IpAddress");
            this.Property(t => t.UserGuid).HasColumnName("UserGuid");
            this.Property(t => t.PageUrl).HasColumnName("PageUrl");
            this.Property(t => t.ReferrerUrl).HasColumnName("ReferrerUrl");
            this.Property(t => t.CreatedOnUtc).HasColumnName("CreatedOnUtc");
        }
    }
}
