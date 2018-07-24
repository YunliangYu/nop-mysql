using FluentValidation;
using Club.Admin.Models.Tax;
using Club.Core.Domain.Tax;
using Club.Data;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Tax
{
    public partial class TaxCategoryValidator : BaseSiteValidator<TaxCategoryModel>
    {
        public TaxCategoryValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Tax.Categories.Fields.Name.Required"));

            SetDatabaseValidationRules<TaxCategory>(dbContext);
        }
    }
}