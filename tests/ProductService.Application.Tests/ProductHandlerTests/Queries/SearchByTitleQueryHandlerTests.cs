
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
    public class SearchByTitleQueryHandlerTests
    {
        private readonly SearchByTitleQueryHandler _searchByTitleQueryHandler;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public SearchByTitleQueryHandlerTests()
        {
            var _mediatoR = new Mock<IMediator>();
            var _mockMapper = new Mock<IMapper>();
            var mockedProductRepository = new Mock<IProductRepository>();

            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockUnitOfWork.Setup(x => x.ProductRepository).Returns(mockedProductRepository.Object);

            _searchByTitleQueryHandler = new SearchByTitleQueryHandler(_mockUnitOfWork.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task SearchByTitleQueryHandlerAsync_WithNullParameter_ThrowsException()
        {
            //Arrange
            SearchByTitleQueryRequest command = null;

            //Act
            var actualException = await Assert.ThrowsAsync<Exception>(() => _searchByTitleQueryHandler.Handle(command, new CancellationToken()));

            //Assert
            Assert.Equal(MessageConstants.SearchByTitleQueryRequestNull, actualException.Message);

        }

        [Fact]
        public async Task SearchByTitleQueryHandlerAsync_WithNullTitle_ThrowsException()
        {
            //Arrange
            var command = new SearchByTitleQueryRequest { Title = null };

            //Act
            var actualException = await Assert.ThrowsAsync<Exception>(() => _searchByTitleQueryHandler.Handle(command, new CancellationToken()));

            //Assert
            Assert.Equal(MessageConstants.SearchByTitleRequestTitleNull, actualException.Message);

        }
    }
}
