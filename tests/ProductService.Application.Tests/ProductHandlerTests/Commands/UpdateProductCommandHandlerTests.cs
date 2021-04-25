using ProductService.Application.Common.Interfaces;
using ProductService.Application.ProductServices.Commands.Request;
using ProductService.Application.ProductServices.Handlers.CommandHandlers;
using ProductService.Domain.Products;
using ProductService.Domain.Products.Categories;
using ProductService.Domain.SeedWork;
using MediatR;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ProductService.Application.Tests.ProductHandlerTests.Commands
{
    public class UpdateProductCommandHandlerTests
    {
        private readonly UpdateProductCommandHandler _updateProductCommandHandler;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMediator> _mediatoR;
      
        public UpdateProductCommandHandlerTests()
        {
            _mediatoR = new Mock<IMediator>();

            var mockedProductRepository = new Mock<IProductRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockUnitOfWork.Setup(x => x.ProductRepository).Returns(mockedProductRepository.Object);

            _updateProductCommandHandler = new UpdateProductCommandHandler(_mockUnitOfWork.Object, _mediatoR.Object);
        }


        [Fact]
        public async Task UpdateProductCommandHandlerAsync_WithNullParameter_ThrowsException()
        {
            //Arrange
            UpdateProductCommandRequest command = null;

            //Act
            var actualException = await Assert.ThrowsAsync<Exception>(() => _updateProductCommandHandler.Handle(command, new CancellationToken()));

            //Assert
            Assert.Equal(MessageConstants.UpdateProductCommandRequestNull, actualException.Message);

        }

        [Fact]
        public async Task UpdateProductCommandHandlerAsync_WithNullId_ThrowsException()
        {
            //Arrange
            var command = new UpdateProductCommandRequest { Id = Guid.Empty };

            //Act
            var actualException = await Assert.ThrowsAsync<Exception>(() => _updateProductCommandHandler.Handle(command, new CancellationToken()));

            //Assert
            Assert.Equal(MessageConstants.UpdateProductCommandRequestIdNull, actualException.Message);

        }

        [Fact]
        public async Task UpdateProductCommandHandlerAsync_WitNonExistingProduct_ThrowsException()
        {
            //Arrange
            var command = new UpdateProductCommandRequest { Id = Guid.NewGuid() };
            _mockUnitOfWork.Setup(x => x.ProductRepository.GetById(command.Id)).Returns(Task.FromResult<Product>(null));

            //Act
            var actualException = await Assert.ThrowsAsync<Exception>(() => _updateProductCommandHandler.Handle(command, new CancellationToken()));

            //Assert
            Assert.Equal(MessageConstants.ProductNotFound, actualException.Message);

        }

        [Fact]
        public async Task UpdateProductCommandHandlerAsync_WithValidParameters_UpdateProduct()
        {
            //Arrange
            var command = new UpdateProductCommandRequest { Id = Guid.NewGuid(), Description="oldDescription", StockQuantity= 5, Title="oldTitle" };
            var product = Product.Create("newDescription", 15, "newTitle", Category.Create(1, "HouseHoldAppliences", 10));
          
            _mockUnitOfWork.Setup(x => x.ProductRepository.GetById(command.Id)).Returns(Task.FromResult(product));
            _mockUnitOfWork.Setup(x => x.ProductRepository.Update(product)).Verifiable();
            _mockUnitOfWork.Setup(x => x.SaveChanges()).Verifiable();

            //Act
            var actualResult = await _updateProductCommandHandler.Handle(command, new CancellationToken());

            //Assert
            Assert.True(actualResult.IsSuccess);

        }

    }
}
