using FluentValidation;
using Club.Services.Localization;
using Club.Web.Framework.Validators;
using Club.Web.Models.PrivateMessages;

namespace Club.Web.Validators.PrivateMessages
{
    public partial class SendPrivateMessageValidator : BaseSiteValidator<SendPrivateMessageModel>
    {
        public SendPrivateMessageValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage(localizationService.GetResource("PrivateMessages.SubjectCannotBeEmpty"));
            RuleFor(x => x.Message).NotEmpty().WithMessage(localizationService.GetResource("PrivateMessages.MessageCannotBeEmpty"));
        }
    }
}