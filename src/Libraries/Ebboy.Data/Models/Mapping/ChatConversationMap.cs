using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BangBang.Data.Models.Mapping
{
    public class ChatConversationMap : EntityTypeConfiguration<ChatConversation>
    {
        public ChatConversationMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ChatConversations");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.StartDateTime).HasColumnName("StartDateTime");
            this.Property(t => t.RoomId).HasColumnName("RoomId");

            // Relationships
            this.HasRequired(t => t.ChatRoom)
                .WithOptional(t => t.ChatConversation);

        }
    }
}
