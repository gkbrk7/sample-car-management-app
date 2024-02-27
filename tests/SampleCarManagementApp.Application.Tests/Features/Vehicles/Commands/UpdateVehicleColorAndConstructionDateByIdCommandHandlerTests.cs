using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SampleCarManagementApp.Application.Features.Vehicles.Commands.Update;
using SampleCarManagementApp.Application.Interfaces;
using SampleCarManagementApp.Domain.Entities;
using Xunit;

namespace SampleCarManagementApp.Application.Tests.Features.Vehicles.Commands
{
    public class UpdateVehicleColorAndConstructionDateByIdCommandHandlerTests
    {
        private readonly Mock<IVehicleRepositoryAsync> mockVehicleRepository = new();

        [Fact]
        public async void GetAsyncShouldReturnEntityNotFoundResultForRequestedVehicle()
        {
            // Arrange
            var id = new Random().Next(1, 50);
            var query = new UpdateVehicleColorAndConstructionDateByIdCommand(id, "Zwart", new DateOnly(2023, 02, 26));

            mockVehicleRepository
                .Setup(v => v.GetAsync(It.IsAny<Expression<Func<Vehicle, bool>>>(), CancellationToken.None))
                .Returns(Task.FromResult<Vehicle?>(null))
                .Verifiable();

            mockVehicleRepository
                .Setup(v => v.UpdateAsync(It.IsAny<Vehicle>(), CancellationToken.None))
                .Returns(Task.CompletedTask)
                .Verifiable();

            var handler = new UpdateVehicleColorAndConstructionDateByIdCommandHandler(mockVehicleRepository.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.Succeeded.Should().BeFalse();
            result.ErrorTypes.Should().Contain(Domain.Enums.ExceptionType.EntityNotFound);
            result.Message.Should().Be("Entity Not Found!");
            mockVehicleRepository.Verify(
                v => v.GetAsync(
                    It.IsAny<Expression<Func<Vehicle, bool>>>(),
                    CancellationToken.None),
                Times.Once()
            );
            mockVehicleRepository.Verify(
                v => v.UpdateAsync(
                    It.IsAny<Vehicle>(),
                    CancellationToken.None),
                Times.Never()
            );
        }

        [Fact]
        public async void UpdateAsyncShouldReturnSuccessResponseForRequestedVehicle()
        {
            // Arrange
            var id = new Random().Next(1, 50);
            var query = new UpdateVehicleColorAndConstructionDateByIdCommand(id, "Zwart", new DateOnly(2023, 02, 26));
            var vehicle = new Vehicle
            {
                Id = id,
                Color = "Grijs",
                Make = "Test Make",
                Model = "Test Model",
                ConstructionDate = new DateOnly(2020, 10, 01),
            };

            mockVehicleRepository
                .Setup(v => v.GetAsync(It.IsAny<Expression<Func<Vehicle, bool>>>(), CancellationToken.None))
                .ReturnsAsync(vehicle)
                .Verifiable();


            mockVehicleRepository
                .Setup(v => v.UpdateAsync(It.IsAny<Vehicle>(), CancellationToken.None))
                .Returns(Task.CompletedTask)
                .Verifiable();

            var handler = new UpdateVehicleColorAndConstructionDateByIdCommandHandler(mockVehicleRepository.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.Succeeded.Should().BeTrue();
            result.ErrorTypes.Should().BeEmpty();
            result.Message.Should().Be("Entity Has Been Updated Successfully.");

            mockVehicleRepository.Verify(
                v => v.GetAsync(
                    It.IsAny<Expression<Func<Vehicle, bool>>>(),
                    CancellationToken.None),
                Times.Once()
            );

            mockVehicleRepository.Verify(
               v => v.UpdateAsync(
                   It.Is<Vehicle>(v => v.Id.Equals(id) && v.Color!.Equals(query.Color) && v.ConstructionDate.Equals(query.ConstructionDate)),
                   CancellationToken.None),
               Times.Once()
           );
        }
    }
}