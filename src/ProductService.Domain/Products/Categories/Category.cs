namespace ProductService.Domain.Products.Categories
{
    public class Category 
    {
       public int Id { get; set; }
       public string CategoryName { get; private set; }
       public bool IsActive { get; private set; } 
       public int MinStockQuantity { get; private set; }

        private Category()
        { }

        public static Category Create(int id,string categoryName,int minStockQuantity)
        {

            var category = new Category
            {
                Id = id,
                CategoryName = categoryName,
                MinStockQuantity = minStockQuantity,
                IsActive = true
            };

            return category;
        }


    }
}
