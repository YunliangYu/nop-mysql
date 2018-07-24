using FluentValidation;
using Club.Admin.Models.Catalog;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Catalog
{
    public partial class SpecificationAttributeValidator : BaseSiteValidator<SpecificationAttributeModel>
    {
        public SpecificationAttributeValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.Attributes.SpecificationAttributes.Fields.Name.Required"));
        }
    }
}