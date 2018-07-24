using FluentValidation;
using Club.Services.Localization;
using Club.Web.Framework.Validators;
using Club.Web.Models.Vendors;

namespace Club.Web.Validators.Vendors
{
    public partial class VendorInfoValidator : BaseSiteValidator<VendorInfoModel>
    {
        public VendorInfoValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Account.VendorInfo.Name.Required"));

            RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResource("Account.VendorInfo.Email.Required"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));
        }
    }
}