using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace SampleCarManagementApp.Application.Features.Vehicles.Commands.Update
{
    public class UpdateVehicleColorAndConstructionDateByIdCommandValidator : AbstractValidator<UpdateVehicleColorAndConstructionDateByIdCommand>
    {
        public UpdateVehicleColorAndConstructionDateByIdCommandValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .GreaterThanOrEqualTo(1);

            RuleFor(r => r.Color)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.");

            RuleFor(r => r.ConstructionDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .InclusiveBetween(new DateOnly(1885, 1, 1), DateOnly.FromDateTime(DateTime.UtcNow))
                .WithMessage("{PropertyName} must be in between " + new DateOnly(1885, 1, 1).ToString() + " and " + DateOnly.FromDateTime(DateTime.UtcNow).ToString());
        }
    }
}