
using System;
using ProductService.Application.ProductServices.Queries.Response;
using MediatR;

namespace ProductService.Application.ProductServices.Queries.Request
{
    public  class GetProductByIdQueryRequest : IRequest<GetProductQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
