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
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("clients");

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
                .HasForeignKey<Client>(s => s.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
