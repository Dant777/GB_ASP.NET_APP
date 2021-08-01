using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Repository.DAL;
using DataLayer.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DataLayer
{
    public static class Registration
    {
        public static IServiceCollection RegisterDataLayer(this IServiceCollection services)
        {
            services.AddTransient<IPersonRepository, PersonRepository>();
            return services;
        }
    }
}
