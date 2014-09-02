using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BangBang.Data.Models.Mapping
{
    public class ChatMessageMap : EntityTypeConfiguration<ChatMessage>
    {
        public ChatMessageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.UserFromName)
                .HasMaxLength(50);

            this.Property(t => t.Body)
                .IsRequired();

            this.Property(t => t.UserToName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ChatMessages");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.RoomId).HasColumnName("RoomId");
            this.Property(t => t.ConversationId).HasColumnName("ConversationId");
            this.Property(t => t.UserFromId).HasColumnName("UserFromId");
            this.Property(t => t.UserFromName).HasColumnName("UserFromName");
            this.Property(t => t.Body).HasColumnName("Body");
            this.Property(t => t.DateTime).HasColumnName("DateTime");
            this.Property(t => t.UserToId).HasColumnName("UserToId");
            this.Property(t => t.UserToName).HasColumnName("UserToName");
            this.Property(t => t.IsNew).HasColumnName("IsNew");

            // Relationships
            this.HasOptional(t => t.ChatRoom)
                .WithMany(t => t.ChatMessages)
                .HasForeignKey(d => d.RoomId);
            this.HasRequired(t => t.SystemUser)
                .WithMany(t => t.ChatMessages)
                .HasForeignKey(d => d.UserFromId);
            this.HasOptional(t => t.SystemUser1)
                .WithMany(t => t.ChatMessages1)
                .HasForeignKey(d => d.UserToId);

        }
    }
}
