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
    internal class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable("organizations",
                t =>
                t.HasCheckConstraint("CHK_organization_type_organization", "type_organization IN ('Airport', 'Hospital', 'Bank', 'Shop', 'Gym')"));

            builder
                .Property(c => c.Id)
                .HasColumnName("id");

            builder.HasKey(b => b.Id);

            builder
                .Property(c => c.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasIndex(b => b.Name)
                .IsUnique();

            builder
                .Property(s => s.TypeOrganization)
                .HasColumnName("type_organization")
                .HasMaxLength(30)
                .HasColumnType("varchar(30)")
                .HasConversion<string>()
                .IsRequired();

            builder
                .Property(s => s.Country)
                .HasColumnName("country")
                .HasMaxLength(5)
                .HasColumnType("varchar(5)")
                .HasConversion<string>()
                .IsRequired();

            builder
                .Property(c => c.Description)
                .HasColumnType("varchar(300)")
                .HasMaxLength(300)
                .HasColumnName("description")
                .IsRequired();
        }
    }
}
