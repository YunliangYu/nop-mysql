using FluentValidation;
using Club.Admin.Models.Localization;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Localization
{
    public partial class LanguageResourceValidator : BaseSiteValidator<LanguageResourceModel>
    {
        public LanguageResourceValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Languages.Resources.Fields.Name.Required"));
            RuleFor(x => x.Value).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Languages.Resources.Fields.Value.Required"));
        }
    }
}