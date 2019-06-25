using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using DAL.Repository;

namespace BLL.config
{
    public static class ServiceConfig
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IUserDal, UserDal>();
            services.AddTransient<ITaskDal, TaskDal>();
        }
    }
}
