using FluentValidation;
using Club.Admin.Models.Settings;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Settings
{
    public partial class SettingValidator : BaseSiteValidator<SettingModel>
    {
        public SettingValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Settings.AllSettings.Fields.Name.Required"));
        }
    }
}