using ProductService.Domain.Products.Categories;
using System.Collections.Generic;

namespace ProductService.Application.Common.Interfaces
{
    public interface ICategoryRepository
    {
        Category GetById(int id);
    }
}
