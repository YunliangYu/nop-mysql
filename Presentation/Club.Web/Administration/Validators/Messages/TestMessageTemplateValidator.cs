using FluentValidation;
using Club.Admin.Models.Messages;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Messages
{
    public partial class TestMessageTemplateValidator : BaseSiteValidator<TestMessageTemplateModel>
    {
        public TestMessageTemplateValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.SendTo).NotEmpty();
            RuleFor(x => x.SendTo).EmailAddress().WithMessage(localizationService.GetResource("Admin.Common.WrongEmail"));
        }
    }
}