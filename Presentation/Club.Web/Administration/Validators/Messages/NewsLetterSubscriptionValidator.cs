using FluentValidation;
using Club.Admin.Models.Messages;
using Club.Core.Domain.Messages;
using Club.Data;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Messages
{
    public partial class NewsLetterSubscriptionValidator : BaseSiteValidator<NewsLetterSubscriptionModel>
    {
        public NewsLetterSubscriptionValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResource("Admin.Promotions.NewsLetterSubscriptions.Fields.Email.Required"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Admin.Common.WrongEmail"));

            SetDatabaseValidationRules<NewsLetterSubscription>(dbContext);
        }
    }
}