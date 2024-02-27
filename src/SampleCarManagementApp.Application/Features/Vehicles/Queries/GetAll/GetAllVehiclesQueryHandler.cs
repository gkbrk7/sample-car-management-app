using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SampleCarManagementApp.Application.Interfaces;
using SampleCarManagementApp.Application.Wrappers;

namespace SampleCarManagementApp.Application.Features.Vehicles.Queries.GetAll
{
    public class GetAllVehiclesQueryHandler(IVehicleRepositoryAsync vehicleRepositoryAsync) : IRequestHandler<GetAllVehiclesQuery, ApiPagedResponse<IEnumerable<GetAllVehiclesViewModel>>>
    {
        private readonly IVehicleRepositoryAsync vehicleRepositoryAsync = vehicleRepositoryAsync;

        public async Task<ApiPagedResponse<IEnumerable<GetAllVehiclesViewModel>>> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
        {
            var result = await vehicleRepositoryAsync.GetAllPaginatedAsync(request.PageNumber, request.PageSize, default, cancellationToken);

            var data = result.Select(entity => new GetAllVehiclesViewModel(entity.Id, entity.Make, entity.Model, entity.Color, entity.ConstructionDate, entity.GearBox));

            return ApiPagedResponse<IEnumerable<GetAllVehiclesViewModel>>.PagedSuccess(data, request.PageNumber, request.PageSize);
        }
    }
}