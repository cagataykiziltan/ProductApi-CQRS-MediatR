using System;

namespace ProductService.Application.ProductServices.Commands.Response
{
    public class CreateProductCommandResponse
    {
        public Guid ProductId { get; set; }
        public bool IsSuccess { get; set; }
  
    }
}
