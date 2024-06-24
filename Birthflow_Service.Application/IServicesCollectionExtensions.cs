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
            return services;
        }
    }
}
