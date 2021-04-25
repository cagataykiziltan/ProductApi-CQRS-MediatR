
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
    public class SearchByCategoryNameQueryHandlerTests
    {
        private readonly SearchByCategoryNameQueryHandler _searchByCategoryNameQueryHandler;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public SearchByCategoryNameQueryHandlerTests()
        {
            var _mediatoR = new Mock<IMediator>();
            var _mockMapper = new Mock<IMapper>();
            var mockedProductRepository = new Mock<IProductRepository>();

            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockUnitOfWork.Setup(x => x.ProductRepository).Returns(mockedProductRepository.Object);

            _searchByCategoryNameQueryHandler = new SearchByCategoryNameQueryHandler(_mockUnitOfWork.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task SearchByCategoryNameQueryHandlerAsync_WithNullParameter_ThrowsException()
        {
            //Arrange
            SearchByCategoryNameQueryRequest command = null;

            //Act
            var actualException = await Assert.ThrowsAsync<Exception>(() => _searchByCategoryNameQueryHandler.Handle(command, new CancellationToken()));

            //Assert
            Assert.Equal(MessageConstants.SearchByCategoryNameQueryRequestNull, actualException.Message);

        }

        [Fact]
        public async Task SearchByCategoryNameQueryHandlerAsync_WithNullCategoryName_ThrowsException()
        {
            //Arrange
            var command = new SearchByCategoryNameQueryRequest { CategoryName=null };

            //Act
            var actualException = await Assert.ThrowsAsync<Exception>(() => _searchByCategoryNameQueryHandler.Handle(command, new CancellationToken()));

            //Assert
            Assert.Equal(MessageConstants.SearchByCategoryNameQueryRequestCategoryNameNull, actualException.Message);

        }

    }
}
