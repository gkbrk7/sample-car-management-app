using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleCarManagementApp.Application.Interfaces;
using SampleCarManagementApp.Domain.Entities;
using SampleCarManagementApp.Infrastructure.Contexts;

namespace SampleCarManagementApp.Infrastructure.Repositories
{
    public class VehicleRepositoryAsync(ApplicationDbContext dbContext) : GenericRepositoryAsync<Vehicle>(dbContext), IVehicleRepositoryAsync
    {
        private readonly DbSet<Vehicle> vehicles = dbContext.Set<Vehicle>();
    }
}