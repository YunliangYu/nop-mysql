using FluentValidation;
using Club.Admin.Models.Messages;
using Club.Core.Domain.Messages;
using Club.Data;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Messages
{
    public partial class MessageTemplateValidator : BaseSiteValidator<MessageTemplateModel>
    {
        public MessageTemplateValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.MessageTemplates.Fields.Subject.Required"));
            RuleFor(x => x.Body).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.MessageTemplates.Fields.Body.Required"));

            SetDatabaseValidationRules<MessageTemplate>(dbContext);
        }
    }
}