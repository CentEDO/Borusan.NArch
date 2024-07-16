using Application.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceRegistration(this IServiceCollection services)
        {
            //builder.services.AddPersistenceServices();
            //services.AddDbContext<BorusanDbContext>();
            //services.AddScoped<IBrandRepository,EfBrandRepository>();
            services.AddDbContext<BorusanDbContext>();
            services.AddScoped<IModelRepository, EfModelRepository>();
            services.AddScoped<ICarRepository, EfCarRepository>();
            services.AddScoped<IFuelRepository, EfFuelRepository>();
            services.AddScoped<ITransmissionRepository, EfTransmissionRepository>();
            services.AddScoped<IColorRepository, EfColorRepository>();
            services.AddScoped<IBrandRepository, EfBrandRepository>();
            services.AddScoped<IUserRepository, EfUserRepository>();

            return services;
        }
    }
}
