using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace SampleCarManagementApp.Application.Features.Vehicles.Queries.GetAll
{
    public class GetAllVehiclesQueryValidator : AbstractValidator<GetAllVehiclesQuery>
    {
        public GetAllVehiclesQueryValidator()
        {
            RuleFor(r => r.PageNumber)
                .GreaterThanOrEqualTo(1)
                .WithMessage("{PropertyName} must be greater than 0");

            RuleFor(r => r.PageSize)
                .GreaterThanOrEqualTo(1)
                .WithMessage("{PropertyName} must be greater than 0");
        }
    }
}