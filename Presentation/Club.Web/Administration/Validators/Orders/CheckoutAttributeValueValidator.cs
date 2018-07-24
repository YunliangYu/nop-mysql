using FluentValidation;
using Club.Admin.Models.Orders;
using Club.Core.Domain.Orders;
using Club.Data;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Orders
{
    public partial class CheckoutAttributeValueValidator : BaseSiteValidator<CheckoutAttributeValueModel>
    {
        public CheckoutAttributeValueValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.Attributes.CheckoutAttributes.Values.Fields.Name.Required"));

            SetDatabaseValidationRules<CheckoutAttributeValue>(dbContext);
        }
    }
}