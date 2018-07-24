using FluentValidation;
using Club.Admin.Models.Settings;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Settings
{
    public partial class ReturnRequestActionValidator : BaseSiteValidator<ReturnRequestActionModel>
    {
        public ReturnRequestActionValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Settings.Order.ReturnRequestActions.Name.Required"));
        }
    }
}