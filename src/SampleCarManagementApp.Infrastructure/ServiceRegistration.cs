using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SampleCarManagementApp.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using SampleCarManagementApp.Application.Interfaces;
using SampleCarManagementApp.Infrastructure.Repositories;

namespace SampleCarManagementApp.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddScoped<IVehicleRepositoryAsync, VehicleRepositoryAsync>();
        }
    }
}