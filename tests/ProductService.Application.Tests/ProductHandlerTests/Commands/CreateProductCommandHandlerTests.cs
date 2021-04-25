using ProductService.Application.Common.Interfaces;
using ProductService.Application.ProductServices.Commands.Request;
using ProductService.Application.ProductServices.Events;
using ProductService.Application.ProductServices.Handlers.CommandHandlers;
using ProductService.Domain.Products;
using ProductService.Domain.SeedWork;
using System.Threading.Tasks;
using MediatR;
using Moq;
using System;
using System.Threading;
using Xunit;
using ProductService.Domain.Products.Categories;

namespace ProductService.Application.Tests.ProductHandlerTests.Commands
{
    public class CreateProductCommandHandlerTests
    {
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMediator> _mediatoR;
        public CreateProductCommandHandlerTests()
        {
            _mediatoR = new Mock<IMediator>();

            var mockedProductRepository = new Mock<IProductRepository>();
            var mockedCategoryRepository = new Mock<ICategoryRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockUnitOfWork.Setup(x => x.ProductRepository).Returns(mockedProductRepository.Object);
            _mockUnitOfWork.Setup(x => x.CategoryRepository).Returns(mockedCategoryRepository.Object);

            _createProductCommandHandler = new CreateProductCommandHandler(_mockUnitOfWork.Object, _mediatoR.Object);
        }

        [Fact]
        public async Task CreateProductCommandHandlerAsync_WithNullParameter_ThrowsException()
        {
            //Arrange
            CreateProductCommandRequest command = null;

            //Act
            var actualException = await Assert.ThrowsAsync<Exception>(() => _createProductCommandHandler.Handle(command, new CancellationToken()));

            //Assert
            Assert.Equal(MessageConstants.CreateProductCommandRequestNull, actualException.Message);

        }

        [Fact]
        public async Task CreateProductCommandHandlerAsync_WithUnexistingCategory_ThrowsException()
        {
            //Arrange
            var createProductRequest = new CreateProductCommandRequest
            {
                Title = "testTitle",
                Description = "testDescription",
                StockQuantity = 15,
                CategoryId = 3
            };
     
            _mockUnitOfWork.Setup(x => x.CategoryRepository.GetById(createProductRequest.CategoryId)).Returns((Category)(null));
           

            //Act
            var actualException = await Assert.ThrowsAsync<Exception>(() => _createProductCommandHandler.Handle(createProductRequest, new CancellationToken())); 

            //Assert
            Assert.Equal(MessageConstants.CreateProductCommandRequestNull, actualException.Message); ;
            
        }
        [Fact]
        public async Task CreateProductCommandHandlerAsync_WithValidParameters_CreatesProduct()
        {
            //Arrange
            var createProductRequest = new CreateProductCommandRequest
            {
                Title = "testTitle",
                Description = "testDescription",
                StockQuantity = 15,
                CategoryId=1
            };
            _mockUnitOfWork.Setup(x => x.ProductRepository.Add(It.IsAny<Product>())).Verifiable();
            _mockUnitOfWork.Setup(x => x.CategoryRepository.GetById(createProductRequest.CategoryId)).Returns(Category.Create(1, "HouseHoldAppliences",10));
            _mockUnitOfWork.Setup(x => x.SaveChanges()).Verifiable();
            _mediatoR.Setup(x => x.Publish(new ProductCreatedEvent(Guid.NewGuid(), createProductRequest.Title, createProductRequest.Description, createProductRequest.StockQuantity), new CancellationToken())).Verifiable();
           
            //Act
            var createProductResponse = await _createProductCommandHandler.Handle(createProductRequest, new CancellationToken());

            //Assert
            Assert.True(createProductResponse.IsSuccess);

        }

    }
}
