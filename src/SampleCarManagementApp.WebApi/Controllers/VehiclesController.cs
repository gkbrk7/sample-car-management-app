using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleCarManagementApp.Application.Features.Vehicles.Commands.Update;
using SampleCarManagementApp.Application.Features.Vehicles.Queries.GetAll;
using SampleCarManagementApp.Application.Features.Vehicles.Queries.GetById;
using SampleCarManagementApp.Application.Parameters;
using SampleCarManagementApp.Application.Wrappers;

namespace SampleCarManagementApp.WebApi.Controllers
{
    [ApiVersion("1.0")]
    public class VehiclesController : BaseApiController
    {
        [HttpGet(nameof(GetAll))]
        [ProducesResponseType(typeof(ApiPagedResponse<IEnumerable<GetAllVehiclesViewModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] RequestParameter request)
        {
            var response = await Mediator.Send(new GetAllVehiclesQuery(request.PageNumber, request.PageSize));
            return Ok(response);
        }

        [HttpGet(nameof(GetById))]
        [ProducesResponseType(typeof(ApiResponse<GetVehicleByIdViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await Mediator.Send(new GetVehicleByIdQuery(id));
            return Ok(response);
        }

        [HttpPut(nameof(UpdateColorAndConstructionDateById))]
        [ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateColorAndConstructionDateById([FromBody] UpdateVehicleColorAndConstructionDateByIdCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}