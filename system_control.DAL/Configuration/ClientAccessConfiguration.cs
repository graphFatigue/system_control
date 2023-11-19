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
    internal class ClientAccessConfiguration : IEntityTypeConfiguration<ClientAccess>
    {
        public void Configure(EntityTypeBuilder<ClientAccess> builder)
        {
            builder.ToTable("client_access",
                t =>
                t.HasCheckConstraint("CHK_client_access_access_level", "access_level IN ('Allowed', 'Denied')"));

            builder
                .Property(c => c.RelationId)
                .HasColumnName("relation_id");

            builder.HasKey(b => b.RelationId);

            builder
                .Property(c => c.FirstClientId)
                .HasColumnName("first_client_id");

            builder
                .HasOne(s => s.FirstClient)
                .WithMany(x => x.ClientAccesses)
                .HasForeignKey(s => s.FirstClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(c => c.SecondClientId)
                .HasColumnName("second_client_id");

            builder
                .HasOne(s => s.SecondClient)
                .WithMany()//(x => x.ClientAccesses)
                .HasForeignKey(s => s.SecondClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(c => c.DepartmentId)
                .HasColumnName("department_id");

            builder
                .HasOne(s => s.Department)
                .WithMany(x => x.ClientAccesses)
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
