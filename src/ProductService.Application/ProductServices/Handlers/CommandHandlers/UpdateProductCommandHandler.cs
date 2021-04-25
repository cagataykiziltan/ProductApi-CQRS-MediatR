using System;
using System.Threading;
using System.Threading.Tasks;
using ProductService.Application.Common.Aspects;
using ProductService.Application.Common.Interfaces;
using ProductService.Application.ProductServices.Commands.Request;
using ProductService.Application.ProductServices.Commands.Response;
using ProductService.Application.ProductServices.Events;
using ProductService.Domain.SeedWork;
using MediatR;

namespace ProductService.Application.ProductServices.Handlers.CommandHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        public UpdateProductCommandHandler(IUnitOfWork unitOfWork,
                                           IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        // [TransactionAspect]
        //[LoggerAspect]
        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest updateProductCommandRequest, CancellationToken cancellationToken)
        {
            if (updateProductCommandRequest == null)
                throw new Exception(MessageConstants.UpdateProductCommandRequestNull);

            if (updateProductCommandRequest.Id == Guid.Empty)
                throw new Exception(MessageConstants.UpdateProductCommandRequestIdNull);

            var product = await _unitOfWork.ProductRepository.GetById(updateProductCommandRequest.Id);

            if (product == null)
                throw new Exception(MessageConstants.ProductNotFound);

            product.ChangeStockQuantity(updateProductCommandRequest.StockQuantity);
            product.ChangeTitle(updateProductCommandRequest.Title);
            product.ChangeDescription(updateProductCommandRequest.Description);

            await _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.SaveChanges();

            await _mediator.Publish(new ProductUpdatedEvent(updateProductCommandRequest.Id,
                                                            updateProductCommandRequest.Title,
                                                            updateProductCommandRequest.Description,
                                                            updateProductCommandRequest.StockQuantity),
                                                            cancellationToken);

            return new UpdateProductCommandResponse() { IsSuccess = true, ProductId = product.Id };
        }

    }
}
