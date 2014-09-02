using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BangBang.Data.Models.Mapping
{
    public class UserApplicationMap : EntityTypeConfiguration<UserApplication>
    {
        public UserApplicationMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("UserApplications");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AppGuid).HasColumnName("AppGuid");
            this.Property(t => t.UserGuid).HasColumnName("UserGuid");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
