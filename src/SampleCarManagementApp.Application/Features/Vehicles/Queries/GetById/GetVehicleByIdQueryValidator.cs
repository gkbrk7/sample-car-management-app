using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using SampleCarManagementApp.Application.Interfaces;
using SampleCarManagementApp.Domain.Enums;

namespace SampleCarManagementApp.Application.Features.Vehicles.Queries.GetById
{
    public class GetVehicleByIdQueryValidator : AbstractValidator<GetVehicleByIdQuery>
    {
        private readonly IVehicleRepositoryAsync vehicleRepositoryAsync;

        public GetVehicleByIdQueryValidator(IVehicleRepositoryAsync vehicleRepositoryAsync)
        {
            this.vehicleRepositoryAsync = vehicleRepositoryAsync;

            RuleFor(r => r.Id)
                .GreaterThanOrEqualTo(1);
        }
    }
}