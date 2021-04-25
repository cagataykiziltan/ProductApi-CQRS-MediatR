using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Application.ProductServices.Events
{
    public class ProductCreatedLoggerHandler : INotificationHandler<ProductCreatedEvent>
    {
        private readonly ILogger<ProductCreatedLoggerHandler> _logger;

        public ProductCreatedLoggerHandler(ILogger<ProductCreatedLoggerHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"New customer has been created at ");

            return Task.CompletedTask;
        }

      
    }
}
