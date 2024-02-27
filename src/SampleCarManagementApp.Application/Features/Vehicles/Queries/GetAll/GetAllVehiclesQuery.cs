using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SampleCarManagementApp.Application.Parameters;
using SampleCarManagementApp.Application.Wrappers;

namespace SampleCarManagementApp.Application.Features.Vehicles.Queries.GetAll
{
    public record GetAllVehiclesQuery(int PageNumber, int PageSize) : IRequest<ApiPagedResponse<IEnumerable<GetAllVehiclesViewModel>>>;
}