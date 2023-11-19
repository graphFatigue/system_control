using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using DAL;
using Core.Entity;

namespace system_control.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services)
        {

            /*var connectionString = 
                              $"Server={Environment.GetEnvironmentVariable("DB_HOST")};" +
                              $"Database={Environment.GetEnvironmentVariable("DB_NAME")};" +
                              $"User Id={Environment.GetEnvironmentVariable("USER_ID")};" +
                              $"Password={Environment.GetEnvironmentVariable("SA_PASSWORD")};" +
                              "Encrypt=False";*/

            var anotherString =
                "Data Source=DESKTOP-G9BFQFQ\\SQLEXPRESS;Initial Catalog=SystemControl; Encrypt=False;Integrated Security=True;";

            services.AddDbContext<AppDbContext>(opts =>
                opts
                    .UseLazyLoadingProxies()
                    .UseSqlServer(anotherString));
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<User>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 4;
                o.User.RequireUniqueEmail = true;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole<int>),
                builder.Services);

            builder.AddSignInManager<SignInManager<User>>();

            builder.AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
        }

        public static void ConfigureFluentValidation(
            this IServiceCollection services)
        {
            //services.AddFluentValidationAutoValidation();
            //services.AddValidatorsFromAssemblyContaining<CreateClubModelValidator>();
            //services.AddValidatorsFromAssemblyContaining<UpdateClubModelValidator>();
            //services.AddValidatorsFromAssemblyContaining<CreateCoachModelValidator>();
            //services.AddValidatorsFromAssemblyContaining<UpdateCoachModelValidator>();
            //services.AddValidatorsFromAssemblyContaining<CreateJudgeModelValidator>();
            //services.AddValidatorsFromAssemblyContaining<UpdateJudgeModelValidator>();
        }
    }
}
