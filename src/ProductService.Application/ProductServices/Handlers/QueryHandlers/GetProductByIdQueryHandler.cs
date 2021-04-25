using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ProductService.Application.Common.Interfaces;
using ProductService.Application.ProductServices.Queries.Request;
using ProductService.Application.ProductServices.Queries.Response;
using ProductService.Domain.SeedWork;
using MediatR;

namespace ProductService.Application.ProductServices.Handlers.QueryHandlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, GetProductQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetProductByIdQueryHandler(IUnitOfWork unitOfWork,
                                          IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //[LoggerAspect]
        public async Task<GetProductQueryResponse> Handle(GetProductByIdQueryRequest getProductByIdQueryRequest, CancellationToken cancellationToken)
        {
            if (getProductByIdQueryRequest == null)
                throw new Exception(MessageConstants.GetProductByIdQueryRequestNull);

            if (getProductByIdQueryRequest.Id == Guid.Empty)
                throw new Exception(MessageConstants.GetProductByIdQueryRequestIdNull);

            var product = await _unitOfWork.ProductRepository.GetById(getProductByIdQueryRequest.Id);
 
            if (product == null)
                throw new Exception(MessageConstants.ProductNotFound);

            var productResponse = _mapper.Map<GetProductQueryResponse>(product);

            return productResponse;
        }
    }
}
