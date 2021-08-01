using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinesLogiclayer.Services;
using BussinesLogiclayer.Services.Interfaces;


namespace BussinesLogiclayer
{
    public static class Registration
    {
        public static IServiceCollection RegisterBusineLogic(this IServiceCollection services)
        {
            services.AddTransient<IPersonService, PersonService>();
            return services;
        }
    }
}
