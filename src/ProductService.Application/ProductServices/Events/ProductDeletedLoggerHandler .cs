using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Application.ProductServices.Events
{
    public class ProductDeletedLoggerHandler : INotificationHandler<ProductDeletedEvent>
    {
        private readonly ILogger<ProductDeletedLoggerHandler> _logger;

        public ProductDeletedLoggerHandler(ILogger<ProductDeletedLoggerHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ProductDeletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"New customer has been created at ");

            return Task.CompletedTask;
        }
    }
}
