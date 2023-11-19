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
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("departments");

            builder
                .Property(c => c.Id)
                .HasColumnName("id");

            builder.HasKey(b => b.Id);

            builder
                .Property(c => c.OrganizationId)
                .HasColumnName("organization_id");

            builder
                .HasOne(s => s.Organization)
                .WithMany(x => x.Departments)
                .HasForeignKey(s => s.OrganizationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(c => c.Address)
                .HasColumnType("varchar(400)")
                .HasMaxLength(400)
                .HasColumnName("address")
                .IsRequired();

            builder
                .HasIndex(c => c.Address)
                .IsUnique();
        }
    }
}
