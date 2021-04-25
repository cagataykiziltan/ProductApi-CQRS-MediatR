using System.Collections.Generic;
using ProductService.Application.ProductServices.Queries.Response;
using MediatR;

namespace ProductService.Application.ProductServices.Queries.Request
{
    public class SearchByDescriptionQueryRequest : IRequest<List<GetProductQueryResponse>>
    {
        public string Description { get; set; }
    }
}
