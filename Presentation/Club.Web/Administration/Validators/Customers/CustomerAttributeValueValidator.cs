using FluentValidation;
using Club.Admin.Models.Customers;
using Club.Core.Domain.Customers;
using Club.Data;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Customers
{
    public partial class CustomerAttributeValueValidator : BaseSiteValidator<CustomerAttributeValueModel>
    {
        public CustomerAttributeValueValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Customers.CustomerAttributes.Values.Fields.Name.Required"));

            SetDatabaseValidationRules<CustomerAttributeValue>(dbContext);
        }
    }
}