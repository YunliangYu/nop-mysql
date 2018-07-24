using FluentValidation;
using Club.Core.Domain.Customers;
using Club.Services.Localization;
using Club.Web.Framework.Validators;
using Club.Web.Models.Customer;

namespace Club.Web.Validators.Customer
{
    public partial class ChangePasswordValidator : BaseSiteValidator<ChangePasswordModel>
    {
        public ChangePasswordValidator(ILocalizationService localizationService, CustomerSettings customerSettings)
        {
            RuleFor(x => x.OldPassword).NotEmpty().WithMessage(localizationService.GetResource("Account.ChangePassword.Fields.OldPassword.Required"));
            RuleFor(x => x.NewPassword).NotEmpty().WithMessage(localizationService.GetResource("Account.ChangePassword.Fields.NewPassword.Required"));
            RuleFor(x => x.NewPassword).Length(customerSettings.PasswordMinLength, 999).WithMessage(string.Format(localizationService.GetResource("Account.ChangePassword.Fields.NewPassword.LengthValidation"), customerSettings.PasswordMinLength));
            RuleFor(x => x.ConfirmNewPassword).NotEmpty().WithMessage(localizationService.GetResource("Account.ChangePassword.Fields.ConfirmNewPassword.Required"));
            RuleFor(x => x.ConfirmNewPassword).Equal(x => x.NewPassword).WithMessage(localizationService.GetResource("Account.ChangePassword.Fields.NewPassword.EnteredPasswordsDoNotMatch"));
        }}
}