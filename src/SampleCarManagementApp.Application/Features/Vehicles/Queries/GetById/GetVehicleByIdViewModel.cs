using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SampleCarManagementApp.Application.Parameters;
using SampleCarManagementApp.Application.Wrappers;

namespace SampleCarManagementApp.Application.Features.Vehicles.Queries.GetById
{
    public record GetVehicleByIdViewModel(
        int Id,
        string Make,
        string Model,
        string? ModelVersion,
        string? Color,
        int? Weight,
        string? RegistrationNumber,
        int? NumberOfDoors,
        DateOnly? ConstructionDate,
        string? BodyType,
        string? GearBox
    );
}