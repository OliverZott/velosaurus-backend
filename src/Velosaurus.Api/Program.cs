using Microsoft.EntityFrameworkCore;
using Serilog;
using Velosaurus.Api.Services;
using Velosaurus.DatabaseManager;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
// Add services to the container.

string? connectionString = builder.Configuration.GetConnectionString("TourDbConnectionString");
builder.Services.AddDbContext<TourDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer(); // https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowAllPolicy", p => p.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});

builder.Host.UseSerilog((context, configuration) =>
    configuration.WriteTo.Console().ReadFrom.Configuration(context.Configuration));

builder.Services.AddScoped<TourDatabaseService>();


WebApplication app = builder.Build();
// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

using IServiceScope scope = app.Services.CreateScope();
TourDbContext context = scope.ServiceProvider.GetRequiredService<TourDbContext>();
await context.Database.MigrateAsync();

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("MyAllowAllPolicy");
app.MapControllers();
app.Run();