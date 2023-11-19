using system_control.Extensions;
using DAL.Extensions;
using BLL.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureSqlContext();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureBusinessLayerServices(builder.Configuration);
builder.Services.ConfigureDataAccessLayer();

builder.Services
    .AddAuthentication();

builder.Services.ConfigureIdentity();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

//app.UseCors("CorsPolicy");

app.UseExceptionHandlingMiddleware();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.MigrateDatabase();

app.Run();
