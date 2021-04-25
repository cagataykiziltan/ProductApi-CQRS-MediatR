using System.Collections.Generic;
using ProductService.Application.ProductServices.Queries.Response;
using MediatR;

namespace ProductService.Application.ProductServices.Queries.Request
{
    public class SearchByCategoryNameQueryRequest : IRequest<List<GetProductQueryResponse>>
    {
        public string CategoryName { get; set; }
    }
}
