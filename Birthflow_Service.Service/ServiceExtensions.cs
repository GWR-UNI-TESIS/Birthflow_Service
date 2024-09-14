using Birthflow_Service.Infraestructure.DbContexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace BirthflowService.API
{
    public static class ServiceExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("localDB");
            services.AddDbContext<BirthflowDbContext>(x => x.UseSqlServer(connectionString));
        }

        public static void ConfigureJwtAuthentication(this IServiceCollection services, IConfiguration config)
        {
            var token = config["AppSettings:Token"];
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token))
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
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen();
        }
    }
}
