using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using system_control.Middleware;

namespace system_control.Extensions
{
    public static class AppExtensions
    {
        public static async Task<WebApplication> MigrateDatabase(this WebApplication webApp)
        {
            using var scope = webApp.Services.CreateScope();
            await using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            try
            {
                var pendingMigrations = await context.Database.GetPendingMigrationsAsync();
                var count = pendingMigrations.Count();

                if (count != 0)
                {
                    Console.WriteLine($"You have {count} pending migrations to apply.");
                    Console.WriteLine("Applying pending migrations now");
                    await context.Database.MigrateAsync();
                }

                var appliedMigrations = await context.Database.GetAppliedMigrationsAsync();
                var lastAppliedMigration = appliedMigrations.Last();

                Console.WriteLine($"You're on schema version: {lastAppliedMigration}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to apply pending migrations!");
                Console.WriteLine(ex);
            }

            return webApp;
        }

        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
