
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
    public class SearchByDescriptionQueryHandler : IRequestHandler<SearchByDescriptionQueryRequest, List<GetProductQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SearchByDescriptionQueryHandler(IUnitOfWork unitOfWork,
                                               IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //[LoggerAspect]
        public async  Task<List<GetProductQueryResponse>> Handle(SearchByDescriptionQueryRequest searchByDescriptionRequest, CancellationToken cancellationToken)
        {

            if (searchByDescriptionRequest == null)
                throw new Exception(MessageConstants.SearchByDescriptionQueryRequestNull);

            if (searchByDescriptionRequest.Description == null)
                throw new Exception(MessageConstants.SearchByDescriptionQueryRequestDescriptionNull);


            var productList = await _unitOfWork.ProductRepository.SearchWithDescription(searchByDescriptionRequest.Description);

            var productResponseList = _mapper.Map<List<GetProductQueryResponse>>(productList);

            return productResponseList;
        }

       
    }
}
