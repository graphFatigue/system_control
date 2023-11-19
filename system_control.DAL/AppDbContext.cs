using Core.Entity;
using DAL.Configuration;
using DAL.Initializers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;

namespace DAL
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfigurationsFromAssembly(typeof(AdminConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(ClientConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(ClientStaffAccessConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(ClientAccessConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(DepartmentConfiguration).Assembly);

            builder.ApplyConfigurationsFromAssembly(typeof(RoomConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(StaffAccessConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(UserRoomConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(VisitConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(StaffConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(OrganizationConfiguration).Assembly);

            builder.Entity<Staff>()
                .Ignore(e => e.StaffAccesses);

            builder.Entity<Client>()
                .Ignore(e => e.ClientAccesses);

            base.OnModelCreating(builder);

            OrganizationsDataInitializer.SeedData(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-G9BFQFQ\\SQLEXPRESS;Initial Catalog=SystemControl; Encrypt=False;Integrated Security=True;");
            }
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<ClientAccess> ClientAccess { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientStaffAccess> ClientStaffAccess { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<StaffAccess> StaffAccess { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<UserRoom> UserRoom { get; set; }
        public DbSet<Visit> Visits { get; set; }

    }
}
