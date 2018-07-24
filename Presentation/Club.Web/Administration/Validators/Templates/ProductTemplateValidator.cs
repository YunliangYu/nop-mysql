using FluentValidation;
using Club.Admin.Models.Templates;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Templates
{
    public partial class ProductTemplateValidator : BaseSiteValidator<ProductTemplateModel>
    {
        public ProductTemplateValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.Templates.Product.Name.Required"));
            RuleFor(x => x.ViewPath).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.Templates.Product.ViewPath.Required"));
        }
    }
}