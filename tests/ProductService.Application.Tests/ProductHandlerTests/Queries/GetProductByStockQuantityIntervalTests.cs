

using AutoMapper;
using ProductService.Application.Common.Interfaces;
using ProductService.Application.ProductServices.Handlers.QueryHandlers;
using ProductService.Application.ProductServices.Queries.Request;
using ProductService.Domain.SeedWork;
using MediatR;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ProductService.Application.Tests.ProductHandlerTests.Queries
{
    public class GetProductByStockQuantityIntervalTests
    {
        private readonly GetProductsByStockIntervalQueryHandler _getProductsByStockInterval;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public GetProductByStockQuantityIntervalTests()
        {
            var _mediatoR = new Mock<IMediator>();
            var _mockMapper = new Mock<IMapper>();
            var mockedProductRepository = new Mock<IProductRepository>();

            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockUnitOfWork.Setup(x => x.ProductRepository).Returns(mockedProductRepository.Object);

            _getProductsByStockInterval = new GetProductsByStockIntervalQueryHandler(_mockUnitOfWork.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetProductByStockQuantityIntervalHandlerAsync_WithNegativeStockQuantities_ThrowsException()
        {
            //Arrange
            var command = new GetProductsByStockIntervalQueryRequest {MinStockQuantity=-5,MaxStockQuantity=-3 };

            //Act
            var actualException = await Assert.ThrowsAsync<Exception>(() => _getProductsByStockInterval.Handle(command, new CancellationToken()));

            //Assert
            Assert.Equal(MessageConstants.StockQuantityCannotBeNegative, actualException.Message);

        }

        [Fact]
        public async Task GetProductByStockQuantityIntervalHandlerAsync_WithMinBiggerThanMaxQuantities_ThrowsException()
        {
            //Arrange
            var command = new GetProductsByStockIntervalQueryRequest { MinStockQuantity = 5, MaxStockQuantity = 3 };

            //Act
            var actualException = await Assert.ThrowsAsync<Exception>(() => _getProductsByStockInterval.Handle(command, new CancellationToken()));

            //Assert
            Assert.Equal(MessageConstants.MinStockCantBeBiggerThanMaxStock, actualException.Message);

        }

    }
}
