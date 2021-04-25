using System;

namespace ProductService.Application.ProductServices.Commands.Response
{
    public class UpdateProductCommandResponse
    {
        public Guid ProductId { get; set; }
        public bool IsSuccess { get; set; }
 
    }
}
