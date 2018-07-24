using FluentValidation;
using Club.Core.Domain.Customers;
using Club.Services.Localization;
using Club.Web.Framework.Validators;
using Club.Web.Models.Customer;

namespace Club.Web.Validators.Customer
{
    public partial class LoginValidator : BaseSiteValidator<LoginModel>
    {
        public LoginValidator(ILocalizationService localizationService, CustomerSettings customerSettings)
        {
            if (!customerSettings.UsernamesEnabled)
            {
                //login by email
                RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResource("Account.Login.Fields.Email.Required"));
                RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));
            }
        }
    }
}