using Birthflow_Domain.Interface;
using Birthflow_Infraestructure.Repositories;
using BirthflowService.Domain.Interface;
using BirthflowService.Infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_Infraestructure
{
    public static class IRepositoriesCollectionExtensions
    {

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAuthRepository, AuthRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPartographRepository, PartographRepository>();
            return services;
        }
    }
}
