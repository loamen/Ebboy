using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BangBang.Data.Models.Mapping
{
    public class CompanyEmployeeMap : EntityTypeConfiguration<CompanyEmployee>
    {
        public CompanyEmployeeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.CustomerNo)
                .HasMaxLength(50);

            this.Property(t => t.RealName)
                .HasMaxLength(50);

            this.Property(t => t.NickName)
                .HasMaxLength(50);

            this.Property(t => t.RemarkName)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(150);

            this.Property(t => t.Phone)
                .HasMaxLength(50);

            this.Property(t => t.Mobile)
                .HasMaxLength(50);

            this.Property(t => t.QQ)
                .HasMaxLength(50);

            this.Property(t => t.Weixin)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CompanyEmployees");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EmployeeGuid).HasColumnName("EmployeeGuid");
            this.Property(t => t.CustomerNo).HasColumnName("CustomerNo");
            this.Property(t => t.RealName).HasColumnName("RealName");
            this.Property(t => t.NickName).HasColumnName("NickName");
            this.Property(t => t.RemarkName).HasColumnName("RemarkName");
            this.Property(t => t.Sex).HasColumnName("Sex");
            this.Property(t => t.UserGuid).HasColumnName("UserGuid");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.QQ).HasColumnName("QQ");
            this.Property(t => t.Weixin).HasColumnName("Weixin");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Deleted).HasColumnName("Deleted");
            this.Property(t => t.IsAdmin).HasColumnName("IsAdmin");
            this.Property(t => t.CompanyNo).HasColumnName("CompanyNo");
            this.Property(t => t.CreatedOnUtc).HasColumnName("CreatedOnUtc");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
        }
    }
}
