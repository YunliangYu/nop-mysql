using FluentValidation;
using Club.Admin.Models.Polls;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Polls
{
    public partial class PollAnswerValidator : BaseSiteValidator<PollAnswerModel>
    {
        public PollAnswerValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.Polls.Answers.Fields.Name.Required"));
        }
    }
}