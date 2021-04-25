using System;
using System.Threading;
using System.Threading.Tasks;
using ProductService.Application.Common.Interfaces;
using ProductService.Application.ProductServices.Commands.Request;
using ProductService.Application.ProductServices.Commands.Response;
using ProductService.Application.ProductServices.Events;
using ProductService.Domain.Products;
using ProductService.Domain.SeedWork;
using MediatR;

namespace ProductService.Application.ProductServices.Handlers.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        public CreateProductCommandHandler(IUnitOfWork unitOfWork,
                                           IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        //[TransactionAspect]
        //[LoggerAspect]
        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest createProductCommandRequest, CancellationToken cancellationToken)
        {
            if (createProductCommandRequest == null)
                throw new Exception(MessageConstants.CreateProductCommandRequestNull);

            var category = _unitOfWork.CategoryRepository.GetById(createProductCommandRequest.CategoryId);

            if (category == null)
                throw new Exception(MessageConstants.CreateProductCommandRequestNull);

                
            var product = Product.Create(createProductCommandRequest.Description,
                                         createProductCommandRequest.StockQuantity,
                                         createProductCommandRequest.Title,
                                         category);

            await _unitOfWork.ProductRepository.Add(product);
            await _unitOfWork.SaveChanges();

            await _mediator.Publish(new ProductCreatedEvent(product.Id, product.Title, product.Description, product.StockQuantity), cancellationToken);

            return new CreateProductCommandResponse { IsSuccess = true, ProductId = product.Id };
        }
    }
}
