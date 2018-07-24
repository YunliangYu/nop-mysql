using FluentValidation;
using Club.Web.Framework.Validators;
using Club.Web.Infrastructure.Installation;
using Club.Web.Models.Install;

namespace Club.Web.Validators.Install
{
    public partial class InstallValidator : BaseSiteValidator<InstallModel>
    {
        public InstallValidator(IInstallationLocalizationService locService)
        {
            RuleFor(x => x.AdminEmail).NotEmpty().WithMessage(locService.GetResource("AdminEmailRequired"));
            RuleFor(x => x.AdminEmail).EmailAddress();
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage(locService.GetResource("AdminPasswordRequired"));
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage(locService.GetResource("ConfirmPasswordRequired"));
            RuleFor(x => x.AdminPassword).Equal(x => x.ConfirmPassword).WithMessage(locService.GetResource("PasswordsDoNotMatch"));
            RuleFor(x => x.DataProvider).NotEmpty().WithMessage(locService.GetResource("DataProviderRequired"));
        }
    }
}