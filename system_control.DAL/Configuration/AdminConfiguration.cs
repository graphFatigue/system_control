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
    internal class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("admins");

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
                .HasForeignKey<Admin>(s => s.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(c => c.DepartmentId)
                .HasColumnName("department_id");

            builder
                .HasOne(s => s.Department)
                .WithMany()
                .HasForeignKey(s => s.DepartmentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
