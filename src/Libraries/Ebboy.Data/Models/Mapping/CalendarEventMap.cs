using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BangBang.Data.Models.Mapping
{
    public class CalendarEventMap : EntityTypeConfiguration<CalendarEvent>
    {
        public CalendarEventMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.EventName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(250);

            this.Property(t => t.Address)
                .HasMaxLength(250);

            this.Property(t => t.ArticleId)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CalendarEvents");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CompanyNo).HasColumnName("CompanyNo");
            this.Property(t => t.EventName).HasColumnName("EventName");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.BeginDateUtc).HasColumnName("BeginDateUtc");
            this.Property(t => t.EndDateUtc).HasColumnName("EndDateUtc");
            this.Property(t => t.IsAllDay).HasColumnName("IsAllDay");
            this.Property(t => t.AppGuid).HasColumnName("AppGuid");
            this.Property(t => t.ArticleId).HasColumnName("ArticleId");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.MarkId).HasColumnName("MarkId");
            this.Property(t => t.RepeatType).HasColumnName("RepeatType");
            this.Property(t => t.CanShare).HasColumnName("CanShare");
            this.Property(t => t.IsAlert).HasColumnName("IsAlert");
            this.Property(t => t.AlertMinitus).HasColumnName("AlertMinitus");
            this.Property(t => t.UserGuid).HasColumnName("UserGuid");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedOnUtc).HasColumnName("CreatedOnUtc");
        }
    }
}
