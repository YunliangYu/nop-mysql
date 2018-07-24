using FluentValidation;
using Club.Services.Localization;
using Club.Web.Framework.Validators;
using Club.Web.Models.Boards;

namespace Club.Web.Validators.Boards
{
    public partial class EditForumPostValidator : BaseSiteValidator<EditForumPostModel>
    {
        public EditForumPostValidator(ILocalizationService localizationService)
        {            
            RuleFor(x => x.Text).NotEmpty().WithMessage(localizationService.GetResource("Forum.TextCannotBeEmpty"));
        }
    }
}