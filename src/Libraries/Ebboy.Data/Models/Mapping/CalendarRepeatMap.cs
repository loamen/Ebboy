using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BangBang.Data.Models.Mapping
{
    public class CalendarRepeatMap : EntityTypeConfiguration<CalendarRepeat>
    {
        public CalendarRepeatMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("CalendarRepeats");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.RepeatType).HasColumnName("RepeatType");
            this.Property(t => t.EveryYear).HasColumnName("EveryYear");
            this.Property(t => t.EveryMonth).HasColumnName("EveryMonth");
            this.Property(t => t.EveryWeek).HasColumnName("EveryWeek");
            this.Property(t => t.EveryDay).HasColumnName("EveryDay");
            this.Property(t => t.IsWorkDay).HasColumnName("IsWorkDay");
            this.Property(t => t.Month).HasColumnName("Month");
            this.Property(t => t.Day).HasColumnName("Day");
            this.Property(t => t.DayOfWeekSequence).HasColumnName("DayOfWeekSequence");
            this.Property(t => t.DayOfWeek).HasColumnName("DayOfWeek");
            this.Property(t => t.CalendarEventId).HasColumnName("CalendarEventId");
            this.Property(t => t.BeginDateUtc).HasColumnName("BeginDateUtc");
            this.Property(t => t.EndDateUtc).HasColumnName("EndDateUtc");

            // Relationships
            this.HasRequired(t => t.CalendarEvent)
                .WithMany(t => t.CalendarRepeats)
                .HasForeignKey(d => d.CalendarEventId);

        }
    }
}
