using Birthflow_Application;
using Birthflow_Infraestructure;
using Birthflow_Service.Infraestructure.DbContexts;
using BirthflowService.API;
using BirthflowService.Domain.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureJwtAuthentication(builder.Configuration);
builder.Services.ConfigureRouting(builder.Configuration);

var swaggerConfig = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("swashbuckle.json", optional: false, reloadOnChange: true)
    .Build();

builder.Services.ConfigureSwagger(swaggerConfig);
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault;
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddServices();
builder.Services.AddRepositories(); builder.Services.AddRepositories();

// Configuración de GmailOptions
builder.Services.Configure<GmailOptions>(
    builder.Configuration.GetSection(GmailOptions.GmailOptionsKey));

var app = builder.Build();

// Configurar el pipeline HTTP
app.ConfigurePipeline(swaggerConfig);

app.Run();