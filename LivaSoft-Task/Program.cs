using LivaSoft_Task.Context;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.InMemory;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseInMemoryDatabase("livaDb")
);

//Logger 
Logger log = new LoggerConfiguration()
	.WriteTo.File("Logs/log.txt")
	.MinimumLevel.Information()
	.CreateLogger();
builder.Host.UseSerilog(log);

builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(m => m.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
