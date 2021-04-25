using System;

namespace ProductService.Application.ProductServices.Queries.Response
{
    public class GetProductQueryResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }

        public Category Category { get; set; }
    }

    public class Category
    {
        public string CategoryName { get;  set; }
        public bool IsActive { get;  set; }

    }
  
}
