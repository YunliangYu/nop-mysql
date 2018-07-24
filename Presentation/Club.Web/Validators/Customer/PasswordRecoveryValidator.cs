using FluentValidation;
using Club.Services.Localization;
using Club.Web.Framework.Validators;
using Club.Web.Models.Customer;

namespace Club.Web.Validators.Customer
{
    public partial class PasswordRecoveryValidator : BaseSiteValidator<PasswordRecoveryModel>
    {
        public PasswordRecoveryValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResource("Account.PasswordRecovery.Email.Required"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));
        }}
}