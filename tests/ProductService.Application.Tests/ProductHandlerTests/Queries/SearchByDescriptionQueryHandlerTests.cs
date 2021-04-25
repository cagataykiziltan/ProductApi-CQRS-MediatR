using AutoMapper;
using ProductService.Application.Common.Interfaces;
using ProductService.Application.ProductServices.Handlers.QueryHandlers;
using ProductService.Application.ProductServices.Queries.Request;
using ProductService.Domain.SeedWork;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ProductService.Application.Tests.ProductHandlerTests.Queries
{
    public class SearchByDescriptionQueryHandlerTests
    {
        private readonly SearchByDescriptionQueryHandler _searchByDescriptionQueryHandler;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public SearchByDescriptionQueryHandlerTests()
        {
            var _mediatoR = new Mock<IMediator>();
            var _mockMapper = new Mock<IMapper>();
            var mockedProductRepository = new Mock<IProductRepository>();

            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockUnitOfWork.Setup(x => x.ProductRepository).Returns(mockedProductRepository.Object);

            _searchByDescriptionQueryHandler = new SearchByDescriptionQueryHandler(_mockUnitOfWork.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task SearchByDescriptionQueryHandlerAsync_WithNullParameter_ThrowsException()
        {
            //Arrange
            SearchByDescriptionQueryRequest command = null;

            //Act
            var actualException = await Assert.ThrowsAsync<Exception>(() => _searchByDescriptionQueryHandler.Handle(command, new CancellationToken()));

            //Assert
            Assert.Equal(MessageConstants.SearchByDescriptionQueryRequestNull, actualException.Message);

        }

        [Fact]
        public async Task SearchByDescriptionQueryHandlerAsync_WithNullCategoryName_ThrowsException()
        {
            //Arrange
            var command = new SearchByDescriptionQueryRequest { Description = null };

            //Act
            var actualException = await Assert.ThrowsAsync<Exception>(() => _searchByDescriptionQueryHandler.Handle(command, new CancellationToken()));

            //Assert
            Assert.Equal(MessageConstants.SearchByDescriptionQueryRequestDescriptionNull, actualException.Message);

        }
    }
}
