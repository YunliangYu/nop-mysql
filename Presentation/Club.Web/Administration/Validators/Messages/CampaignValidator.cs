using FluentValidation;
using Club.Admin.Models.Messages;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Messages
{
    public partial class CampaignValidator : BaseSiteValidator<CampaignModel>
    {
        public CampaignValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Promotions.Campaigns.Fields.Name.Required"));

            RuleFor(x => x.Subject).NotEmpty().WithMessage(localizationService.GetResource("Admin.Promotions.Campaigns.Fields.Subject.Required"));

            RuleFor(x => x.Body).NotEmpty().WithMessage(localizationService.GetResource("Admin.Promotions.Campaigns.Fields.Body.Required"));
        }
    }
}