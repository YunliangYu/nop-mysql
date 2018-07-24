using FluentValidation;
using Club.Services.Localization;
using Club.Web.Framework.Validators;
using Club.Web.Models.Boards;

namespace Club.Web.Validators.Boards
{
    public partial class EditForumTopicValidator : BaseSiteValidator<EditForumTopicModel>
    {
        public EditForumTopicValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage(localizationService.GetResource("Forum.TopicSubjectCannotBeEmpty"));
            RuleFor(x => x.Text).NotEmpty().WithMessage(localizationService.GetResource("Forum.TextCannotBeEmpty"));
        }
    }
}