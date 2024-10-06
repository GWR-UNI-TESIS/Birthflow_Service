using Birthflow_Application.Services;
using Birthflow_Domain.Interface;
using Birthflow_Infraestructure.Repositories;
using BirthflowService.Application.Interfaces;
using BirthflowService.Application.Services;
using BirthflowService.Application.Utils;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IPartographLogService, PartographLogService>();
            services.AddTransient<ICurvesGenerator, CurvesGenerator>();
            return services;
        }
    }
}
