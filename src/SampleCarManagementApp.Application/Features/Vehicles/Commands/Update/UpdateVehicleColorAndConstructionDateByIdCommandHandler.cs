using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.VisualBasic;
using SampleCarManagementApp.Application.Interfaces;
using SampleCarManagementApp.Application.Wrappers;
using SampleCarManagementApp.Domain.Enums;

namespace SampleCarManagementApp.Application.Features.Vehicles.Commands.Update
{
    public class UpdateVehicleColorAndConstructionDateByIdCommandHandler : IRequestHandler<UpdateVehicleColorAndConstructionDateByIdCommand, ApiResponse<int>>
    {
        private readonly IVehicleRepositoryAsync vehicleRepositoryAsync;

        public UpdateVehicleColorAndConstructionDateByIdCommandHandler(IVehicleRepositoryAsync vehicleRepositoryAsync)
        {
            this.vehicleRepositoryAsync = vehicleRepositoryAsync;
        }
        public async Task<ApiResponse<int>> Handle(UpdateVehicleColorAndConstructionDateByIdCommand command, CancellationToken cancellationToken)
        {
            var entity = await vehicleRepositoryAsync.GetAsync(v => v.Id == command.Id, cancellationToken);
            if (entity is null)
            {
                var response = ApiResponse<int>.Fail("Entity Not Found!");
                response.ErrorTypes = [ExceptionType.EntityNotFound];
                return response;
            }

            entity.Color = command.Color;
            entity.ConstructionDate = command.ConstructionDate;

            await vehicleRepositoryAsync.UpdateAsync(entity, cancellationToken);

            return ApiResponse<int>.Success(entity.Id, "Entity Has Been Updated Successfully.");
        }
    }
}