using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using DAL.Repository;

namespace DAL.config
{
    public static class ServiceConfig
    {
        public static void ConfigureDalServices(this IServiceCollection services)
        {
            services.AddTransient<IDatabaseAutomapperConfig, DatabaseAutomapperConfig>();
        }
    }
}
