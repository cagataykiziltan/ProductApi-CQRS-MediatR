
using ProductService.Domain.SeedWork;

namespace ProductService.Domain.Products.Rules
{
    public class DescriptionCannotBeNull : IBusinessRule
    {
        private readonly string _description;
        public DescriptionCannotBeNull(string description)
        {
            _description = description;
        }

        public string Message => MessageConstants.DescriptionCannotBeNull;

        public bool IsBroken() => string.IsNullOrEmpty(_description);
    }
}
