using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SampleCarManagementApp.Application.Parameters;
using SampleCarManagementApp.Application.Wrappers;

namespace SampleCarManagementApp.Application.Features.Vehicles.Queries.GetById
{
    public record GetVehicleByIdQuery(int Id) : IRequest<ApiResponse<GetVehicleByIdViewModel>>;
}