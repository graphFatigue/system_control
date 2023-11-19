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
    internal class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.ToTable("staff");

            builder
                .Property(c => c.Id)
                .HasColumnName("id");

            builder.HasKey(b => b.Id);

            builder
                .Property(s => s.UserId)
                .HasColumnName("user_id");

            builder
                .HasOne(s => s.User)
                .WithOne()
                .HasForeignKey<Staff>(s => s.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(c => c.DateOfEmployment)
                .HasColumnName("date_of_employment")
                .IsRequired();

            builder
                .Property(c => c.DepartmentId)
                .HasColumnName("department_id");

            builder
                .HasOne(s => s.Department)
                .WithMany(x => x.Staff)
                .HasForeignKey(s => s.DepartmentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(c => c.Position)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .HasColumnName("position")
                .IsRequired();

        }
    }
}
