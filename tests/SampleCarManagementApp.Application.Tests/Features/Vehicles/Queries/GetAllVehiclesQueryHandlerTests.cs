using System.Configuration;
using System.Linq.Expressions;
using SampleCarManagementApp.Application.Features.Vehicles.Queries.GetAll;
using SampleCarManagementApp.Application.Interfaces;

namespace SampleCarManagementApp.Application.Tests.Features.Vehicles.Queries
{
    public class GetAllVehiclesQueryHandlerTests
    {
        private readonly Mock<IVehicleRepositoryAsync> mockVehicleRepository = new();

        [Fact]
        public async void GetAllPaginatedAsyncShouldReturnEmptyPaginatedListOfVehicles()
        {
            // Arrange
            var query = new GetAllVehiclesQuery(1, 10);

            mockVehicleRepository
                .Setup(v => v.GetAllPaginatedAsync(It.IsAny<int>(), It.IsAny<int>(), default, CancellationToken.None))
                .ReturnsAsync([])
                .Verifiable();

            var handler = new GetAllVehiclesQueryHandler(mockVehicleRepository.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.Data.Should().BeEmpty();
            result.PageNumber.Should().Be(query.PageNumber);
            result.PageSize.Should().Be(query.PageSize);
            mockVehicleRepository.Verify(
                v => v.GetAllPaginatedAsync(
                    It.Is<int>(pn => pn.Equals(query.PageNumber)),
                    It.Is<int>(ps => ps.Equals(query.PageSize)),
                    default, CancellationToken.None),
                Times.Once()
            );
        }
    }
}