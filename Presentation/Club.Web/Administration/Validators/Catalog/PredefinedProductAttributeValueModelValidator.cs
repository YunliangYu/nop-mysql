using FluentValidation;
using Club.Admin.Models.Catalog;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Catalog
{
    public partial class PredefinedProductAttributeValueModelValidator : BaseSiteValidator<PredefinedProductAttributeValueModel>
    {
        public PredefinedProductAttributeValueModelValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(localizationService.GetResource("Admin.Catalog.Attributes.ProductAttributes.PredefinedValues.Fields.Name.Required"));
        }
    }
}