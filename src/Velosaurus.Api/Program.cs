﻿using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text.Json;
using Velosaurus.Api.Repositories;
using Velosaurus.Core.Middleware.ExceptionMiddleware;
using Velosaurus.DatabaseManager;
using Velosaurus.DatabaseManager.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("ActivityDbConnectionString");
builder.Services.AddDbContext<VelosaurusDbContext>(options => { options.UseNpgsql(connectionString); });

builder.Services.AddControllers()
    .AddJsonOptions(o =>
    {
        o.JsonSerializerOptions.WriteIndented = true;
        o.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        o.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    });

builder.Services.AddEndpointsApiExplorer(); // https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowAllPolicy", p => p.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});

builder.Logging.ClearProviders();
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddScoped<IGenericRepository<Activity>, GenericRepository<Activity>>();
builder.Services.AddScoped<IGenericRepository<Location>, GenericRepository<Location>>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<IExceptionHandler, ExceptionHandler>();

// scan all assemblies for classes inheriting from AutoMapper’s Profile class and register them with AutoMapper.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


// Register Middleware components to the pipeline early to catch exceptions before other middleware
app.UseMiddleware<ExceptionMiddleware>();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<VelosaurusDbContext>();
await context.Database.MigrateAsync();

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("MyAllowAllPolicy");
app.MapControllers();
app.Run();