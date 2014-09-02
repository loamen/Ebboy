using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BangBang.Data.Models.Mapping
{
    public class ChatRoomUserMap : EntityTypeConfiguration<ChatRoomUser>
    {
        public ChatRoomUserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ChatRoomUsers");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.RoomId).HasColumnName("RoomId");
            this.Property(t => t.UserId).HasColumnName("UserId");

            // Relationships
            this.HasRequired(t => t.ChatRoom)
                .WithMany(t => t.ChatRoomUsers)
                .HasForeignKey(d => d.RoomId);
            this.HasRequired(t => t.SystemUser)
                .WithMany(t => t.ChatRoomUsers)
                .HasForeignKey(d => d.UserId);

        }
    }
}
