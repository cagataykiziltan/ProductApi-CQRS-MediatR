

using ProductService.Domain.SeedWork;

namespace ProductService.Domain.Products.Rules
{
    public class StockQuantityCannotBeLessThanMinStockQuantity : IBusinessRule
    {
        private readonly int _stockQuantity;
        private readonly int _minStockQuantity;
        public StockQuantityCannotBeLessThanMinStockQuantity(int stockQuantity,int minStockQuantity)
        {
            _stockQuantity = stockQuantity;
            _minStockQuantity = minStockQuantity;
        }

        public string Message => MessageConstants.StockQuantityCannotBeLessThanMinStockQuantity;

        public bool IsBroken() => _stockQuantity<_minStockQuantity;
    }
}
