using FluentValidation;
using Club.Admin.Models.Plugins;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Plugins
{
    public partial class PluginValidator : BaseSiteValidator<PluginModel>
    {
        public PluginValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.FriendlyName).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Plugins.Fields.FriendlyName.Required"));
        }
    }
}