using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ProductService.Application.Common.Interfaces;
using ProductService.Application.ProductServices.Queries.Request;
using ProductService.Application.ProductServices.Queries.Response;
using MediatR;

namespace ProductService.Application.ProductServices.Handlers.QueryHandlers
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, List<GetProductQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllProductQueryHandler(IUnitOfWork unitOfWork,
                                        IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //[LoggerAspect]
        public async Task<List<GetProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var productList = await _unitOfWork.ProductRepository.GetAll();
       
            var productResponseList = _mapper.Map<List<GetProductQueryResponse>>(productList);

            return productResponseList;
        }
    }
}