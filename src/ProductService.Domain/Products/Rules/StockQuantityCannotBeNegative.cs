using ProductService.Domain.SeedWork;

namespace ProductService.Domain.Products.Rules
{
    public class StockQuantityCannotBeNegative : IBusinessRule
    {
        private readonly double _stockQuantity;
        public StockQuantityCannotBeNegative(double stockQuantity)
        {
            _stockQuantity = stockQuantity;
        }

        public string Message => MessageConstants.StockQuantityCannotBeNegative;

        public bool IsBroken() => _stockQuantity < 0;
    }
}
