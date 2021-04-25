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
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        public DeleteProductCommandHandler(IUnitOfWork unitOfWork,
                                           IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        //[TransactionAspect]
        //[LoggerAspect]
        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest deleteProductCommandRequest, CancellationToken cancellationToken)
        {
            if (deleteProductCommandRequest == null)
                throw new Exception(MessageConstants.DeleteProductCommandRequestNull);
           
            if (deleteProductCommandRequest.Id == Guid.Empty)
                throw new Exception(MessageConstants.DeleteProductCommandRequestIdNull);

            var product = await _unitOfWork.ProductRepository.GetById(deleteProductCommandRequest.Id);

            if (product == null)
                throw new Exception(MessageConstants.ProductNotFound);

            await _unitOfWork.ProductRepository.Delete(product);
            await _unitOfWork.SaveChanges();

            await _mediator.Publish(new ProductDeletedEvent(deleteProductCommandRequest.Id), cancellationToken);

            return new DeleteProductCommandResponse { IsSuccess = true };      
        }
    }

}
