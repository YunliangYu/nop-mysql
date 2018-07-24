using FluentValidation;
using Club.Admin.Models.Templates;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Templates
{
    public partial class TopicTemplateValidator : BaseSiteValidator<TopicTemplateModel>
    {
        public TopicTemplateValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.Templates.Topic.Name.Required"));
            RuleFor(x => x.ViewPath).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.Templates.Topic.ViewPath.Required"));
        }
    }
}