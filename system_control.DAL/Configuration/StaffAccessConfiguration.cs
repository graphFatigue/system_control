using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity;
using Core.Enum;

namespace DAL.Configuration
{
    internal class StaffAccessConfiguration : IEntityTypeConfiguration<StaffAccess>
    {
        public void Configure(EntityTypeBuilder<StaffAccess> builder)
        {
            builder.ToTable("staff_access",
                t =>
                t.HasCheckConstraint("CHK_staff_access_access_level", "access_level IN ('Allowed', 'Denied')"));

            builder
                .Property(c => c.RelationId)
                .HasColumnName("relation_id");

            builder.HasKey(b => b.RelationId);

            builder
                .Property(c => c.FirstStaffId)
                .HasColumnName("first_staff_id");

            builder
                .HasOne(s => s.FirstStaff)
                .WithMany(x => x.StaffAccesses)
                .HasForeignKey(s => s.FirstStaffId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(c => c.SecondStaffId)
                .HasColumnName("second_staff_id");

            builder
                .HasOne(s => s.SecondStaff)
                .WithMany()//(x => x.StaffAccesses)
                .HasForeignKey(s => s.SecondStaffId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(c => c.DepartmentId)
                .HasColumnName("department_id");

            builder
                .HasOne(s => s.Department)
                .WithMany(x => x.StaffAccesses)
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
