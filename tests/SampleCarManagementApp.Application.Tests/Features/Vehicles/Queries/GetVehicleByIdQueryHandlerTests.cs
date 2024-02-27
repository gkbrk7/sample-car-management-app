using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using SampleCarManagementApp.Application.Features.Vehicles.Queries.GetById;
using SampleCarManagementApp.Application.Interfaces;
using SampleCarManagementApp.Domain.Entities;
using Xunit;

namespace SampleCarManagementApp.Application.Tests.Features.Vehicles.Queries
{
    public class GetVehicleByIdQueryHandlerTests
    {
        private readonly Mock<IVehicleRepositoryAsync> mockVehicleRepository = new();

        [Fact]
        public async void GetAsyncShouldReturnNullResultForRequestedId()
        {
            // Arrange
            var id = new Random().Next(1, 50);
            var query = new GetVehicleByIdQuery(id);

            mockVehicleRepository
                .Setup(v => v.GetAsync(It.IsAny<Expression<Func<Vehicle, bool>>>(), CancellationToken.None))
                .Returns(Task.FromResult<Vehicle?>(null))
                .Verifiable();

            var handler = new GetVehicleByIdQueryHandler(mockVehicleRepository.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.Data.Should().BeNull();
            result.Succeeded.Should().BeFalse();
            result.ErrorTypes.Should().Contain(Domain.Enums.ExceptionType.EntityNotFound);
            result.Message.Should().Be("Entity Not Found!");
            mockVehicleRepository.Verify(
                v => v.GetAsync(
                    It.IsAny<Expression<Func<Vehicle, bool>>>(),
                    CancellationToken.None),
                Times.Once()
            );
        }

        [Fact]
        public async void GetAsyncShouldReturnResultForRequestedId()
        {
            // Arrange
            var id = new Random().Next(1, 50);
            var query = new GetVehicleByIdQuery(id);
            var vehicle = new Vehicle
            {
                Id = id,
                Make = "Test Make",
                Model = "Test Model",
            };

            mockVehicleRepository
                .Setup(v => v.GetAsync(It.IsAny<Expression<Func<Vehicle, bool>>>(), CancellationToken.None))
                .ReturnsAsync(vehicle)
                .Verifiable();

            var handler = new GetVehicleByIdQueryHandler(mockVehicleRepository.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.Data.Should().NotBeNull();
            result.Data!.Id.Should().Be(id);
            result.Data!.Make.Should().Be("Test Make");
            result.Data!.Model.Should().Be("Test Model");
            result.Succeeded.Should().BeTrue();
            result.ErrorTypes.Should().BeEmpty();
            mockVehicleRepository.Verify(
                v => v.GetAsync(
                    It.IsAny<Expression<Func<Vehicle, bool>>>(),
                    CancellationToken.None),
                Times.Once()
            );
        }
    }
}