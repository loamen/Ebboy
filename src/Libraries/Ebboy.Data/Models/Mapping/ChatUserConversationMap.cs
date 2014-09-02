using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BangBang.Data.Models.Mapping
{
    public class ChatUserConversationMap : EntityTypeConfiguration<ChatUserConversation>
    {
        public ChatUserConversationMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ChatUserConversations");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.ConversationId).HasColumnName("ConversationId");

            // Relationships
            this.HasRequired(t => t.ChatConversation)
                .WithMany(t => t.ChatUserConversations)
                .HasForeignKey(d => d.ConversationId);
            this.HasRequired(t => t.SystemUser)
                .WithMany(t => t.ChatUserConversations)
                .HasForeignKey(d => d.UserId);

        }
    }
}
