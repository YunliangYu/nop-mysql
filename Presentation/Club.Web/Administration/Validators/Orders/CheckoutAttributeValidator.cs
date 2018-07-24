using FluentValidation;
using Club.Admin.Models.Orders;
using Club.Core.Domain.Orders;
using Club.Data;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Orders
{
    public partial class CheckoutAttributeValidator : BaseSiteValidator<CheckoutAttributeModel>
    {
        public CheckoutAttributeValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.Attributes.CheckoutAttributes.Fields.Name.Required"));

            SetDatabaseValidationRules<CheckoutAttribute>(dbContext);
        }
    }
}