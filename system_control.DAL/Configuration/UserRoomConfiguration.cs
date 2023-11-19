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
    internal class UserRoomConfiguration : IEntityTypeConfiguration<UserRoom>
    {
        public void Configure(EntityTypeBuilder<UserRoom> builder)
        {
            builder.ToTable("user_room",
                t =>
                t.HasCheckConstraint("CHK_user_room_access_level", "access_level IN ('Allowed', 'Denied')"));

            builder
                .Property(c => c.RelationId)
                .HasColumnName("relation_id");

            builder.HasKey(b => b.RelationId);

            builder
                .Property(c => c.UserId)
                .HasColumnName("user_id");

            builder
                .HasOne(s => s.User)
                .WithMany(x => x.UserRooms)
                .HasForeignKey(s => s.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(c => c.RoomId)
                .HasColumnName("room_id");

            builder
                .HasOne(s => s.Room)
                .WithMany(x => x.UserRooms)
                .HasForeignKey(s => s.RoomId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(c => c.AccessLevel)
                .HasColumnName("access_level")
                .HasMaxLength(7)
                .HasColumnType("varchar(7)")
                .HasConversion<string>()
                .HasDefaultValue(AccessLevel.Allowed);
        }
    }
}
