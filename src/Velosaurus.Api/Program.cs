using Microsoft.EntityFrameworkCore;
using Serilog;
using Velosaurus.Api.Services;
using Velosaurus.Core.Middleware.ExceptionMiddleware;
using Velosaurus.DatabaseManager;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("TourDbConnectionString");
builder.Services.AddDbContext<TourDbContext>(options => { options.UseNpgsql(connectionString); });

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
//builder.Services.AddSingleton<ExceptionHandler>();


var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


// Register Middleware Code
app.UseMiddleware<ExceptionMiddleware>();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<TourDbContext>();
await context.Database.MigrateAsync();

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("MyAllowAllPolicy");
app.MapControllers();
app.Run();