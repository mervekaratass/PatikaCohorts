using DataAccess.Abstracts;
using DataAccess.Concretes.InMemory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            services.AddSingleton<IMovieRepository,InMemoryMovieRepository>();
            return services;
        }
    }
}
