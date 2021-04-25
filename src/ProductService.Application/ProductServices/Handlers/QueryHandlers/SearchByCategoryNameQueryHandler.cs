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
 public class SearchByCategoryNameQueryHandler : IRequestHandler<SearchByCategoryNameQueryRequest, List<GetProductQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SearchByCategoryNameQueryHandler(IUnitOfWork unitOfWork,
                                                IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //[LoggerAspect]
        public async Task<List<GetProductQueryResponse>> Handle(SearchByCategoryNameQueryRequest searchByCategoryNameQueryRequest, CancellationToken cancellationToken)
        {
            if(searchByCategoryNameQueryRequest == null)
                throw new Exception(MessageConstants.SearchByCategoryNameQueryRequestNull);

            if (searchByCategoryNameQueryRequest.CategoryName == null)
                throw new Exception(MessageConstants.SearchByCategoryNameQueryRequestCategoryNameNull);

            var productList = await _unitOfWork.ProductRepository.SearchWithCategoryName(searchByCategoryNameQueryRequest.CategoryName);
           
            var productResponseList = _mapper.Map<List<GetProductQueryResponse>>(productList);

            return productResponseList;
        }

    }
}
