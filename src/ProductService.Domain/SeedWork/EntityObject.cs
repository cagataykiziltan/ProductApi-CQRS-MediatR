using System;


namespace ProductService.Domain.SeedWork
{
    public class EntityObject
    {
        public Guid Id { get; set; }
        protected static void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessRuleValidationException(rule);
            }
        }
    }
}
