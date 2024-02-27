using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SampleCarManagementApp.Application.Wrappers;

namespace SampleCarManagementApp.Application.Features.Vehicles.Commands.Update
{
    public record UpdateVehicleColorAndConstructionDateByIdCommand(
        int Id,
        string Color,
        DateOnly ConstructionDate
    ) : IRequest<ApiResponse<int>>;
}