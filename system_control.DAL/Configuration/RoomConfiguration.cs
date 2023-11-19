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
    internal class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("rooms",
                t => t.HasCheckConstraint("CHK_rooms_floor", "floor > 0 AND floor < 120"));

            builder
                .Property(c => c.Id)
                .HasColumnName("id");

            builder.HasKey(b => b.Id);

            builder
                .Property(c => c.Number)
                .HasColumnName("number");

            builder
                .Property(d => d.Floor)
                .HasColumnName("floor")
                .IsRequired();

            builder
                .Property(c => c.DepartmentId)
                .HasColumnName("department_id");

            builder
                .HasOne(s => s.Department)
                .WithMany(x => x.Rooms)
                .HasForeignKey(s => s.DepartmentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
