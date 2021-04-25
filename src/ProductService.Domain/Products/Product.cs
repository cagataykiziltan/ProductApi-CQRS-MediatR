using System;
using ProductService.Domain.Products.Categories;
using ProductService.Domain.Products.Rules;
using ProductService.Domain.SeedWork;


namespace ProductService.Domain.Products
{
    public class Product : EntityObject
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Category Category { get; private set; }
        public int StockQuantity { get; private set; }

        private Product() { }

        public static Product Create(string description, int stockQuantity, string title,Category category)
        {
            CheckRule(new TitleCannotBeEmpty(title));
            CheckRule(new TitleCannotExceed200Characters(title));
            CheckRule(new DescriptionCannotBeNull(description));
            CheckRule(new StockQuantityCannotBeNegative(stockQuantity));
            CheckRule(new StockQuantityCannotBeLessThanMinStockQuantity(stockQuantity, category.MinStockQuantity));

            var product = new Product
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = description,
                Category = category,
                StockQuantity = stockQuantity
            };

            return product;
        }

        public void ChangeDescription(string description)
        {
            CheckRule(new DescriptionCannotBeNull(description));
           
            Description = description;
        }

        public void ChangeTitle(string title)
        {
            CheckRule(new TitleCannotBeEmpty(title));
            CheckRule(new TitleCannotExceed200Characters(title));

            Title = title;
        }

        public void ChangeStockQuantity(int stockQuantity)
        {
            CheckRule(new StockQuantityCannotBeNegative(stockQuantity));

            StockQuantity = stockQuantity;
        }
    }
}
