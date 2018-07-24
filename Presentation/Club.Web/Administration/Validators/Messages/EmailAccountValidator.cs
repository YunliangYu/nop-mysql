using FluentValidation;
using Club.Admin.Models.Messages;
using Club.Core.Domain.Messages;
using Club.Data;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Messages
{
    public partial class EmailAccountValidator : BaseSiteValidator<EmailAccountModel>
    {
        public EmailAccountValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Admin.Common.WrongEmail"));
            
            RuleFor(x => x.DisplayName).NotEmpty();

            SetDatabaseValidationRules<EmailAccount>(dbContext);
        }
    }
}