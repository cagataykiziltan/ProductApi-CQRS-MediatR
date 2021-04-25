using System;
using ProductService.Application.ProductServices.Commands.Response;
using MediatR;

namespace ProductService.Application.ProductServices.Commands.Request
{
    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
       public Guid Id { get; set; }
    }
}
