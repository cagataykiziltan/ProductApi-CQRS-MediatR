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
    public class DeleteProductCommandHandlerTests
    {
        private readonly DeleteProductCommandHandler _deleteProductCommandHandler;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMediator> _mediatoR;
        public DeleteProductCommandHandlerTests()
        {
            _mediatoR = new Mock<IMediator>();

            var mockedProductRepository = new Mock<IProductRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockUnitOfWork.Setup(x => x.ProductRepository).Returns(mockedProductRepository.Object);

            _deleteProductCommandHandler = new DeleteProductCommandHandler(_mockUnitOfWork.Object, _mediatoR.Object);
        }


        [Fact]
        public async Task DeleteProductCommandHandlerAsync_WithNullParameter_ThrowsException()
        {
            //Arrange
            DeleteProductCommandRequest command = null;

            //Act
            var actualException = await Assert.ThrowsAsync<Exception>(() => _deleteProductCommandHandler.Handle(command, new CancellationToken()));

            //Assert
            Assert.Equal(MessageConstants.DeleteProductCommandRequestNull, actualException.Message);

        }

        [Fact]
        public async Task DeleteProductCommandHandlerAsync_WithNullId_ThrowsException()
        {
            //Arrange
            var command = new DeleteProductCommandRequest { Id=Guid.Empty };

            //Act
            var actualException = await Assert.ThrowsAsync<Exception>(() => _deleteProductCommandHandler.Handle(command, new CancellationToken()));

            //Assert
            Assert.Equal(MessageConstants.DeleteProductCommandRequestIdNull, actualException.Message);

        }

        [Fact]
        public async Task DeleteProductCommandHandlerAsync_WitNonExistingProduct_ThrowsException()
        {
            //Arrange
            var command = new DeleteProductCommandRequest { Id = Guid.NewGuid() };
            _mockUnitOfWork.Setup(x => x.ProductRepository.GetById(command.Id)).Returns(Task.FromResult<Product>(null));
          
            //Act
            var actualException = await Assert.ThrowsAsync<Exception>(() => _deleteProductCommandHandler.Handle(command, new CancellationToken()));

            //Assert
            Assert.Equal(MessageConstants.ProductNotFound, actualException.Message);

        }

        [Fact]
        public async Task DeleteProductCommandHandlerAsync_WithValidParameters_DeleteProduct()
        {
            //Arrange
            var command = new DeleteProductCommandRequest { Id = Guid.NewGuid() };
            var product = Product.Create("testDescription", 15, "testTitle", Category.Create(1, "HouseHoldAppliences",10));
            _mockUnitOfWork.Setup(x => x.ProductRepository.GetById(command.Id)).Returns(Task.FromResult(product));
            _mockUnitOfWork.Setup(x => x.ProductRepository.Delete(product)).Verifiable();
            _mockUnitOfWork.Setup(x => x.SaveChanges()).Verifiable();

            //Act
            var actualResult =await _deleteProductCommandHandler.Handle(command, new CancellationToken());

            //Assert
            Assert.True(actualResult.IsSuccess);

        }

    }
}
