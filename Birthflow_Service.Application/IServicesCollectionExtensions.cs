using Birthflow_Application.Services;
using Birthflow_Domain.Interface;
using Birthflow_Infraestructure.Repositories;
using BirthflowService.Application.Interfaces;
using BirthflowService.Application.Services;
using BirthflowService.Domain.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_Application
{
    public static class IServicesCollectionExtensions
    {

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IPartographService, PartographService>();
            services.AddTransient<IUserTokenService, UserTokenService>();
            services.AddScoped<IMailService, GmailService>();
            return services;
        }
    }
}
