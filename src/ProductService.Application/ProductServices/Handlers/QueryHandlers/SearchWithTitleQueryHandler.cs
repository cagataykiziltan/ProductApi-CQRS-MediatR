using System;
using System.Collections.Generic;
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
    public class SearchByTitleQueryHandler : IRequestHandler<SearchByTitleQueryRequest, List<GetProductQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SearchByTitleQueryHandler(IUnitOfWork unitOfWork,
                                       IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //[LoggerAspect]
        public async Task<List<GetProductQueryResponse>> Handle(SearchByTitleQueryRequest searchByTitleQueryRequest, CancellationToken cancellationToken)
        {
            if (searchByTitleQueryRequest == null)
                throw new Exception(MessageConstants.SearchByTitleQueryRequestNull);

            if (searchByTitleQueryRequest.Title == null)
                throw new Exception(MessageConstants.SearchByTitleRequestTitleNull);

            var productList = await _unitOfWork.ProductRepository.SearchWithTitle(searchByTitleQueryRequest.Title);

            var productResponseList = _mapper.Map<List<GetProductQueryResponse>>(productList);

            return productResponseList;
        }

    
    }
}
