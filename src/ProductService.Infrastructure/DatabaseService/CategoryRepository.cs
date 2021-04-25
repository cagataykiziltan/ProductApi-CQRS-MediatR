
using ProductService.Application.Common.Interfaces;
using ProductService.Domain.Products.Categories;
using System.Collections.Generic;
using System.Linq;

namespace ProductService.Infrastructure.DatabaseService
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly List<Category> _categories;
        public CategoryRepository()
        {
            _categories = new List<Category> { Category.Create(1, "HouseHoldAppliences", 10), 
                                               Category.Create(2, "SmallAppliences", 15) };
        }
        public Category GetById(int id)
        {
            return _categories.FirstOrDefault(x=>x.Id==id);
        }
    }
}