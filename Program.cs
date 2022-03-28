using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ResolucaoDepencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<DatabaseLogger>();
builder.Services.AddScoped<EventLogger>();
builder.Services.AddScoped<FileLogger>();

builder.Services.AddTransient<Func<ServiceEnum, ICustomLogger>>(serviceProvider => key =>
{
    switch (key)
    {
        case ServiceEnum.Database: 
            return serviceProvider.GetRequiredService<DatabaseLogger>();
        case ServiceEnum.Event:
            return serviceProvider.GetRequiredService<EventLogger>();
        case ServiceEnum.File:
            return serviceProvider.GetRequiredService<FileLogger>();
        default:
            return serviceProvider.GetRequiredService<FileLogger>();
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
