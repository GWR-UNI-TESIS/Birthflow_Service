using Birthflow_Application.Services;
using Birthflow_Domain.Interface;
using Birthflow_Infraestructure.Repositories;
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
            services.AddTransient<IAuthServices, AuthServices>();
            //services.AddTransient<IAuthServices, AuthRepository>();

            return services;
        }
    }
}
