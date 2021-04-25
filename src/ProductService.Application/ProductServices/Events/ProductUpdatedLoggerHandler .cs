using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Application.ProductServices.Events
{
       public class ProductUpdatedLoggerHandler : INotificationHandler<ProductUpdatedEvent>
    {
        private readonly ILogger<ProductUpdatedLoggerHandler> _logger;

        public ProductUpdatedLoggerHandler(ILogger<ProductUpdatedLoggerHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ProductUpdatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"New customer has been created at ");

            return Task.CompletedTask;
        }


    }
}
