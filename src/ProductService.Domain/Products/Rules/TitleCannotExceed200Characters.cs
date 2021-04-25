

using ProductService.Domain.SeedWork;

namespace ProductService.Domain.Products.Rules
{
    public class TitleCannotExceed200Characters : IBusinessRule
    {
        private readonly string _title;
        public TitleCannotExceed200Characters(string title)
        {
            _title = title;
        }

        public string Message => MessageConstants.TitleCannotExceed200Characters;

        public bool IsBroken() => _title.Length > 200;
    }
}
