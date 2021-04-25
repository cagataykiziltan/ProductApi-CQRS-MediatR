using MediatR;
using System;

namespace ProductService.Application.ProductServices.Events
{
    public class ProductCreatedEvent : INotification
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int StockQuantity { get; private set; }
        public ProductCreatedEvent(Guid id,string title, string description, int stockQuantity)
        {
            Id = id;
            Title = title;
            Description = description;
            StockQuantity = stockQuantity;
        }
    }
}
