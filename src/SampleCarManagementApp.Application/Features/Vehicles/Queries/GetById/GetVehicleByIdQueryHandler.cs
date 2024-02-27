using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SampleCarManagementApp.Application.Interfaces;
using SampleCarManagementApp.Application.Wrappers;
using SampleCarManagementApp.Domain.Enums;

namespace SampleCarManagementApp.Application.Features.Vehicles.Queries.GetById
{
    public class GetVehicleByIdQueryHandler(IVehicleRepositoryAsync vehicleRepositoryAsync) : IRequestHandler<GetVehicleByIdQuery, ApiResponse<GetVehicleByIdViewModel>>
    {
        private readonly IVehicleRepositoryAsync vehicleRepositoryAsync = vehicleRepositoryAsync;

        public async Task<ApiResponse<GetVehicleByIdViewModel>> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await vehicleRepositoryAsync.GetAsync(v => v.Id == request.Id, cancellationToken);

            if (data is null)
            {
                var response = ApiResponse<GetVehicleByIdViewModel>.Fail("Entity Not Found!");
                response.ErrorTypes = [ExceptionType.EntityNotFound];
                return response;
            }

            var model = new GetVehicleByIdViewModel(
                data.Id,
                data.Make,
                data.Model,
                data.ModelVersion,
                data.Color,
                data.Weight,
                data.RegistrationNumber,
                data.NumberOfDoors,
                data.ConstructionDate,
                data.BodyType,
                data.GearBox
            );

            return ApiResponse<GetVehicleByIdViewModel>.Success(model);
        }
    }
}