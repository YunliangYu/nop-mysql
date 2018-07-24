using FluentValidation;
using Club.Admin.Models.Discounts;
using Club.Core.Domain.Discounts;
using Club.Data;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Discounts
{
    public partial class DiscountValidator : BaseSiteValidator<DiscountModel>
    {
        public DiscountValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Promotions.Discounts.Fields.Name.Required"));

            SetDatabaseValidationRules<Discount>(dbContext);
        }
    }
}