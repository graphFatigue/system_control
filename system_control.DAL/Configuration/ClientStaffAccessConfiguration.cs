using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity;

namespace DAL.Configuration
{
    internal class ClientStaffAccessConfiguration : IEntityTypeConfiguration<ClientStaffAccess>
    {
        public void Configure(EntityTypeBuilder<ClientStaffAccess> builder)
        {
            builder.ToTable("client_staff_access",
                t =>
                t.HasCheckConstraint("CHK_client_staff_access_access_level", "access_level IN ('Allowed', 'Denied')"));

            builder
                .Property(c => c.RelationId)
                .HasColumnName("relation_id");

            builder.HasKey(b => b.RelationId);

            builder
                .Property(c => c.ClientId)
                .HasColumnName("client_id");

            builder
                .HasOne(s => s.Client)
                .WithMany(x => x.ClientStaffAccesses)
                .HasForeignKey(s => s.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(c => c.StaffId)
                .HasColumnName("staff_id");

            builder
                .HasOne(s => s.Staff)
                .WithMany(x => x.ClientStaffAccesses)
                .HasForeignKey(s => s.StaffId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(c => c.DepartmentId)
                .HasColumnName("department_id");

            builder
                .HasOne(s => s.Department)
                .WithMany(x => x.ClientStaffAccesses)
                .HasForeignKey(s => s.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(c => c.AccessLevel)
                .HasColumnName("access_level")
                .HasMaxLength(7)
                .HasColumnType("varchar(7)")
                .HasConversion<string>()
                .IsRequired();
        }
    }
}
