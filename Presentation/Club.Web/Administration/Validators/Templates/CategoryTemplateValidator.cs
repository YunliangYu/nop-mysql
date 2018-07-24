using FluentValidation;
using Club.Admin.Models.Templates;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Templates
{
    public partial class CategoryTemplateValidator : BaseSiteValidator<CategoryTemplateModel>
    {
        public CategoryTemplateValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.Templates.Category.Name.Required"));
            RuleFor(x => x.ViewPath).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.Templates.Category.ViewPath.Required"));
        }
    }
}