using Ebboy.Core.Domain.Users;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ebboy.Data.Models.Mapping
{
    public class MemberMap : EntityTypeConfiguration<Member>
    {
        public MemberMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.Username)
                .HasMaxLength(150);

            this.Property(t => t.RealName)
                .HasMaxLength(50);

            this.Property(t => t.NickName)
                .HasMaxLength(50);

            this.Property(t => t.Avatar)
                .HasMaxLength(500);

            this.Property(t => t.Mobile)
                .HasMaxLength(50);

            this.Property(t => t.QQ)
                .HasMaxLength(20);

            this.Property(t => t.Weixin)
                .HasMaxLength(150);

            this.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.PasswordFormat)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.PasswordSalt)
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .HasMaxLength(500);

            this.Property(t => t.SystemName)
                .HasMaxLength(50);

            this.Property(t => t.LastIpAddress)
                .HasMaxLength(50);

            this.Property(t => t.Mood)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("SystemUsers");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserGuid).HasColumnName("UserGuid");
            this.Property(t => t.UserNo).HasColumnName("UserNo");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Username).HasColumnName("Username");
            this.Property(t => t.RealName).HasColumnName("RealName");
            this.Property(t => t.NickName).HasColumnName("NickName");
            this.Property(t => t.Sex).HasColumnName("Sex");
            this.Property(t => t.Avatar).HasColumnName("Avatar");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.QQ).HasColumnName("QQ");
            this.Property(t => t.Weixin).HasColumnName("Weixin");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.PasswordFormat).HasColumnName("PasswordFormat");
            this.Property(t => t.PasswordFormatId).HasColumnName("PasswordFormatId");
            this.Property(t => t.PasswordSalt).HasColumnName("PasswordSalt");
            this.Property(t => t.AdminComment).HasColumnName("AdminComment");
            this.Property(t => t.AddressId).HasColumnName("AddressId");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.Deleted).HasColumnName("Deleted");
            this.Property(t => t.IsSystemAccount).HasColumnName("IsSystemAccount");
            this.Property(t => t.SystemName).HasColumnName("SystemName");
            this.Property(t => t.LastIpAddress).HasColumnName("LastIpAddress");
            this.Property(t => t.CreatedOnUtc).HasColumnName("CreatedOnUtc");
            this.Property(t => t.LastLoginDateUtc).HasColumnName("LastLoginDateUtc");
            this.Property(t => t.LastActivityDateUtc).HasColumnName("LastActivityDateUtc");
            this.Property(t => t.Mood).HasColumnName("Mood");
        }
    }
}
