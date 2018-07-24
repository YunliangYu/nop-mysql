using FluentValidation;
using Club.Admin.Models.Polls;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Polls
{
    public partial class PollValidator : BaseSiteValidator<PollModel>
    {
        public PollValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.Polls.Fields.Name.Required"));
        }
    }
}