using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductService.Application.Common.Interfaces;
using ProductService.Domain.Products;

namespace ProductService.Infrastructure.DatabaseService
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products;
        public ProductRepository()
        {
            _products =new List<Product>();
        }

        public async Task<Product> GetById(Guid id)
        {
            return _products.FirstOrDefault(x => x.Id == id);
  
        }

        public async Task<List<Product>> GetByStockInterval(int minStockQuantity, int maxStockQuantity)
        {
            return _products.Where(x => x.StockQuantity>= minStockQuantity && x.StockQuantity <= maxStockQuantity).ToList();

        }
        public async Task<List<Product>> GetAll()
        {
            return _products;

        }
        public async Task Add(Product product)
        {
            _products.Add(product);
        }

        public async Task Update(Product product)
        {
          //update
        }

        public async Task Delete(Product product)
        {
           _products.Remove(product);
        }

        public async Task<List<Product>> SearchWithTitle(string title)
        {
          var products=  _products.Where(x => x.Title.ToLower().Contains(title.ToLower())).ToList();

          return products;
        }

        public async Task<List<Product>> SearchWithDescription(string description)
        {
            var products = _products.Where(x => x.Description.ToLower().Contains(description.ToLower())).ToList();

            return products;
        }

        public async Task<List<Product>> SearchWithCategoryName(string categoryName)
        {
            var products = _products.Where(x => x.Category.CategoryName.ToLower().Contains(categoryName.ToLower())).ToList();

            return products;
        }
    }
}
