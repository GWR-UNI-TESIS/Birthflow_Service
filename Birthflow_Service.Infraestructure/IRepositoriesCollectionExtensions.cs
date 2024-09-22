using Birthflow_Domain.Interface;
using Birthflow_Infraestructure.Repositories;
using BirthflowService.Domain.Interface;
using BirthflowService.Domain.Interfaces;
using BirthflowService.Infraestructure.Repositories;
using BirthflowService.Infraestructure.Repositories.Adapters;
using Microsoft.Extensions.DependencyInjection;

namespace Birthflow_Infraestructure
{
    public static class IRepositoriesCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAuthRepository, AuthRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPartographRepository, PartographRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IPasswordRepository, PasswordRepository>();
            services.AddScoped<IMailAdapter, GmailAdapter>();
            return services;
        }
    }
}
