using ApiMIddleware.Middleware;
using BuisnessLogicLayer.FluentValidation;
using CodeBlocksMiddleware;
using DataAccessLayer;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore; 
using NLog;
using NLog.Web;
using Serilog;
using Serilog.Settings.Configuration;


//added Nlog
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddValidatorsFromAssemblyContaining<EmployeeValidator>()
    .AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

// Create the 'Logs' folder if it doesn't exist
var logsFolderPath = Path.Combine(builder.Environment.ContentRootPath, "Logs");
if (!Directory.Exists(logsFolderPath))
{
    Directory.CreateDirectory(logsFolderPath);
}

//if you want to to write events through existing NLog infrastructure
//var logger = new LoggerConfiguration()
//    .WriteTo.NLog()
//    .CreateLogger();

//adding configuration file for serilog
//var configuration = new ConfigurationBuilder()
//    .AddJsonFile("serilogAppsettings.json")// todo: edit json file to fix logging via json
//    .Build();

//adding serilog
Log.Logger = new LoggerConfiguration()
    //.ReadFrom.Configuration(configuration)
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("Logs/seriLogs-.txt", rollingInterval:RollingInterval.Day)
    .CreateLogger();
    
builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging(); 

app.UseHttpsRedirection();

app.UseJsonExceptionMiddleware();

app.UseLogExceptionMiddlevare();

app.UseCors("corsapp");

app.UseAuthorization();

app.MapControllers();

app.Run();
