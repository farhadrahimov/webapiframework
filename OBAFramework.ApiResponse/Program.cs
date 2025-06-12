using OBAFramework.ApiResponse.Infrastructure;
using OBAFramework.ApiResponse.Infrastructure.Middlewares;

LoggingConfiguration.ConfigureSerilog();
var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

services.AddProjectDependencies(configuration, builder);
// Add services to the container.
var app = builder.Build();

// Configure the HTTP request pipeline.
app.AddPipeline(app);

app.Run();