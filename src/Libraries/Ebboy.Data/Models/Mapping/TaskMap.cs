using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BangBang.Data.Models.Mapping
{
    public class TaskMap : EntityTypeConfiguration<Task>
    {
        public TaskMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.TaskName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.InChargeName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CreateRealName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.FinishComment)
                .HasMaxLength(500);

            this.Property(t => t.ApproveComment)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Tasks");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TaskName).HasColumnName("TaskName");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.BeginDateUtc).HasColumnName("BeginDateUtc");
            this.Property(t => t.EndDateUtc).HasColumnName("EndDateUtc");
            this.Property(t => t.InCharge).HasColumnName("InCharge");
            this.Property(t => t.InChargeName).HasColumnName("InChargeName");
            this.Property(t => t.Members).HasColumnName("Members");
            this.Property(t => t.MemberNames).HasColumnName("MemberNames");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.CreatedOnUtc).HasColumnName("CreatedOnUtc");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreateRealName).HasColumnName("CreateRealName");
            this.Property(t => t.CompanyNo).HasColumnName("CompanyNo");
            this.Property(t => t.AppGuid).HasColumnName("AppGuid");
            this.Property(t => t.FinishDateUtc).HasColumnName("FinishDateUtc");
            this.Property(t => t.ApproveDateUtc).HasColumnName("ApproveDateUtc");
            this.Property(t => t.RejectDateUtc).HasColumnName("RejectDateUtc");
            this.Property(t => t.FinishComment).HasColumnName("FinishComment");
            this.Property(t => t.ApproveComment).HasColumnName("ApproveComment");
        }
    }
}
