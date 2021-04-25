
using AutoMapper;
using ProductService.Application.Common.Interfaces;
using ProductService.Application.ProductServices.Handlers.QueryHandlers;
using ProductService.Application.ProductServices.Queries.Request;
using ProductService.Domain.Products;
using ProductService.Domain.SeedWork;
using MediatR;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ProductService.Application.Tests.ProductHandlerTests.Queries
{
    public class GetProductByIdQueryHandlerTests
    {
        private readonly GetProductByIdQueryHandler _getProductByIdQueryHandler;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public GetProductByIdQueryHandlerTests()
        {
            var _mediatoR = new Mock<IMediator>();
            var _mockMapper = new Mock<IMapper>();
            var mockedProductRepository = new Mock<IProductRepository>();
            
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockUnitOfWork.Setup(x => x.ProductRepository).Returns(mockedProductRepository.Object);

            _getProductByIdQueryHandler = new GetProductByIdQueryHandler(_mockUnitOfWork.Object, _mockMapper.Object);
        }


        [Fact]
        public async Task GetProductByIdQueryHandlerAsync_WithNullParameter_ThrowsException()
        {
            //Arrange
            GetProductByIdQueryRequest command = null;

            //Act
            var actualException = await Assert.ThrowsAsync<Exception>(() => _getProductByIdQueryHandler.Handle(command, new CancellationToken()));

            //Assert
            Assert.Equal(MessageConstants.GetProductByIdQueryRequestNull, actualException.Message);

        }

        [Fact]
        public async Task GetProductByIdQueryHandlerAsync_WithNullId_ThrowsException()
        {
            //Arrange
            var command = new GetProductByIdQueryRequest { Id = Guid.Empty };

            //Act
            var actualException = await Assert.ThrowsAsync<Exception>(() => _getProductByIdQueryHandler.Handle(command, new CancellationToken()));

            //Assert
            Assert.Equal(MessageConstants.GetProductByIdQueryRequestIdNull, actualException.Message);

        }

        [Fact]
        public async Task GetProductByIdQueryHandlerAsync_WitNonExistingProduct_ThrowsException()
        {
            //Arrange
            var command = new GetProductByIdQueryRequest { Id = Guid.NewGuid() };
            _mockUnitOfWork.Setup(x => x.ProductRepository.GetById(command.Id)).Returns(Task.FromResult<Product>(null));

            //Act
            var actualException = await Assert.ThrowsAsync<Exception>(() => _getProductByIdQueryHandler.Handle(command, new CancellationToken()));

            //Assert
            Assert.Equal(MessageConstants.ProductNotFound, actualException.Message);

        }

    }
}
