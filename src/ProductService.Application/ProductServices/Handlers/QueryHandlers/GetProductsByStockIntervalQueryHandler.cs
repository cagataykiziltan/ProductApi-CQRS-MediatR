using AutoMapper;
using ProductService.Application.Common.Interfaces;
using ProductService.Application.ProductServices.Queries.Request;
using ProductService.Application.ProductServices.Queries.Response;
using ProductService.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Application.ProductServices.Handlers.QueryHandlers
{

    public class GetProductsByStockIntervalQueryHandler : IRequestHandler<GetProductsByStockIntervalQueryRequest, List<GetProductQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetProductsByStockIntervalQueryHandler(IUnitOfWork unitOfWork,
                                                      IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //[LoggerAspect]
        public async Task<List<GetProductQueryResponse>> Handle(GetProductsByStockIntervalQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.MinStockQuantity < 0 || request.MaxStockQuantity < 0)
                throw new Exception(MessageConstants.StockQuantityCannotBeNegative);

            if (request.MinStockQuantity > request.MaxStockQuantity)
                throw new Exception(MessageConstants.MinStockCantBeBiggerThanMaxStock);

            var productList = await _unitOfWork.ProductRepository.GetByStockInterval(request.MinStockQuantity,request.MaxStockQuantity);

            var productResponseList = _mapper.Map<List<GetProductQueryResponse>>(productList);

            return productResponseList;
        }
    }
}
