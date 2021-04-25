using ProductService.Application.ProductServices.Commands.Response;
using MediatR;
using System;

namespace ProductService.Application.ProductServices.Commands.Request
{
    public class UpdateProductCommandRequest : IRequest<UpdateProductCommandResponse>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
    }
}
