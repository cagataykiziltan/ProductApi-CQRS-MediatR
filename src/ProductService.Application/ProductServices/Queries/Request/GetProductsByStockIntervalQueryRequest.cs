using ProductService.Application.ProductServices.Queries.Response;
using MediatR;
using System.Collections.Generic;

namespace ProductService.Application.ProductServices.Queries.Request
{
    public class GetProductsByStockIntervalQueryRequest : IRequest<List<GetProductQueryResponse>>
    {
        public int MinStockQuantity { get; set; }
        public int MaxStockQuantity { get; set; }
    }
}
