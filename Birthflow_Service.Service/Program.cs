using Birthflow_Application;
using Birthflow_Infraestructure;
using Birthflow_Service.Infraestructure.DbContexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


var BirthContext = builder.Configuration.GetConnectionString("localDB");

builder.Services.AddDbContext<BirthflowDbContext>(x => x.UseSqlServer(BirthContext));

builder.Services.AddHttpContextAccessor();

// Add services
builder.Services.AddServices();

// Add Repositories
builder.Services.AddRepositories();

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Token"]))
    };

    options.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            var claimsIdentity = context.Principal?.Identity as ClaimsIdentity;
            var userName = claimsIdentity?.FindFirst(ClaimTypes.Name)?.Value;

            var email = claimsIdentity?.FindFirst("Email")?.Value;
            var userId = claimsIdentity?.FindFirst("UserId")?.Value;
            var isDeveloper = claimsIdentity?.FindFirst("IsDeveloper")?.Value;

            if (!string.IsNullOrEmpty(userName))
            {
                // Asigna el nombre de usuario a una variable global o contexto
                context.HttpContext.Items["UserName"] = userName;
                context.HttpContext.Items["Email"] = email;
                context.HttpContext.Items["UserId"] = userId;
                context.HttpContext.Items["IsDeveloper"] = isDeveloper;
            }

            return Task.CompletedTask;
        },
        OnAuthenticationFailed = context =>
        {
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync("{\"message\": \"Invalid token.\"}");
        }
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
