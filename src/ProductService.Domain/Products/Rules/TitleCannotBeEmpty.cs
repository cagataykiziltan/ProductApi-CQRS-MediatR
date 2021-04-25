
using ProductService.Domain.SeedWork;

namespace ProductService.Domain.Products.Rules
{
    public class TitleCannotBeEmpty : IBusinessRule
    {
        private readonly string _title;
        public TitleCannotBeEmpty(string title)
        {
            _title = title;
        }

        public string Message => MessageConstants.TitleCannotBeNull;

        public bool IsBroken() => string.IsNullOrEmpty(_title);
    }
}
