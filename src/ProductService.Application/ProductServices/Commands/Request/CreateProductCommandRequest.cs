using ProductService.Application.ProductServices.Commands.Response;
using MediatR;

namespace ProductService.Application.ProductServices.Commands.Request
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public string Title { get;  set; }
        public string Description { get;  set; }
        public int StockQuantity { get;  set; }
           public int CategoryId { get; set; }
        }
    }

