using ProductService.Application.Common.Interfaces;
using ProductService.Application.ProductServices.Commands.Request;
using ProductService.Application.ProductServices.Queries.Request;
using ProductService.Infrastructure.DatabaseService;

using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ProductService.Infrastructure.DependencyRegistrar
{
    public static class ServiceRegistrar
    {
        public static void RegisterCustomServices(IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();

            services.AddMediatR(typeof(CreateProductCommandRequest).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteProductCommandRequest).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateProductCommandRequest).GetTypeInfo().Assembly);

            services.AddMediatR(typeof(GetAllProductQueryRequest).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetProductByIdQueryRequest).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(SearchByCategoryNameQueryRequest).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(SearchByDescriptionQueryRequest).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(SearchByTitleQueryRequest).GetTypeInfo().Assembly);
        }
    }
}
