using Serilog;
using velosaurus_backend.Models;
using velosaurus_backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowAllPolicy",
                      p =>
                      {
                          p
                              //.WithOrigins("http://192.168.0.18:3000",
                              //                "http://localhost:3000",
                              //                "localhost:3000")
                              .AllowAnyHeader()
                              .AllowAnyOrigin()
                              .AllowAnyMethod();
                      });
});

// "WriteTo.Console" to also see in dev console during debugging
builder.Host.UseSerilog((context, configuration) => configuration.WriteTo.Console().ReadFrom.Configuration(context.Configuration));

// Register configuration instance to DI container, to which the appsettings.json section binds
builder.Services.Configure<TourDatabaseSettings>(builder.Configuration.GetSection("TourDatabase"));

builder.Services.AddSingleton<TourDatabaseService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("MyAllowAllPolicy");

app.MapControllers();

app.Run();
