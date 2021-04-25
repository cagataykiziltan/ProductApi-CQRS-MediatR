using MediatR;
using System;

namespace ProductService.Application.ProductServices.Events
{
    public  class ProductDeletedEvent : INotification
    {
        public Guid Id { get;private set; }

        public ProductDeletedEvent(Guid id)
        {
            Id = id;
        }
    }

  
}
