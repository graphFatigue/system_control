using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    internal class VisitConfiguration : IEntityTypeConfiguration<Visit>
    {
        public void Configure(EntityTypeBuilder<Visit> builder)
        {
            builder.ToTable("visits");

            builder
                .Property(c => c.Id)
                .HasColumnName("id");

            builder.HasKey(b => b.Id);

            builder
                .Property(c => c.ClientId)
                .HasColumnName("client_id");

            builder
                .HasOne(s => s.Client)
                .WithMany(x => x.Visits)
                .HasForeignKey(s => s.ClientId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(c => c.StaffId)
                .HasColumnName("staff_id");

            builder
                .HasOne(s => s.Staff)
                .WithMany(x => x.Visits)
                .HasForeignKey(s => s.StaffId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(c => c.RoomId)
                .HasColumnName("room_id");

            builder
                .HasOne(s => s.Room)
                .WithMany(x => x.Visits)
                .HasForeignKey(s => s.RoomId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(c => c.DateTime)
                .HasColumnName("date_time")
                .IsRequired();

            builder
                .Property(c => c.Purpose)
                .HasColumnType("varchar(120)")
                .HasMaxLength(120)
                .HasColumnName("purpose")
                .IsRequired();
        }
    }
}
