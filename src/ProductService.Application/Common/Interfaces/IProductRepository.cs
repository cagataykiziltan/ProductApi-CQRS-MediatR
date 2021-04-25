using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductService.Domain.Products;

namespace ProductService.Application.Common.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetById(Guid id);
        
        Task<List<Product>> GetByStockInterval(int minStockQuantity, int maxStockQuantity);
      
        Task<List<Product>> GetAll();
        Task Add(Product product);

        Task Update(Product product);

        Task Delete(Product product);

        Task<List<Product>> SearchWithTitle(string title);

        Task<List<Product>> SearchWithDescription(string description);

        Task<List<Product>> SearchWithCategoryName(string categoryName);
    }
}