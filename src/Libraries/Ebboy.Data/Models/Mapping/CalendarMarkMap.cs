using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BangBang.Data.Models.Mapping
{
    public class CalendarMarkMap : EntityTypeConfiguration<CalendarMark>
    {
        public CalendarMarkMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Color)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.MarkName)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("CalendarMarks");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Color).HasColumnName("Color");
            this.Property(t => t.MarkName).HasColumnName("MarkName");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedOnUtc).HasColumnName("CreatedOnUtc");
        }
    }
}
