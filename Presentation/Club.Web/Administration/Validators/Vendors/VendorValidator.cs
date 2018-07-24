using FluentValidation;
using FluentValidation.Results;
using Club.Admin.Models.Vendors;
using Club.Core.Domain.Vendors;
using Club.Data;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Vendors
{
    public partial class VendorValidator : BaseSiteValidator<VendorModel>
    {
        public VendorValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Vendors.Fields.Name.Required"));

            RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResource("Admin.Vendors.Fields.Email.Required"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Admin.Common.WrongEmail"));
            RuleFor(x => x.PageSizeOptions).Must(ValidatorUtilities.PageSizeOptionsValidator).WithMessage(localizationService.GetResource("Admin.Vendors.Fields.PageSizeOptions.ShouldHaveUniqueItems"));
            Custom(x =>
            {
                if (!x.AllowCustomersToSelectPageSize && x.PageSize <= 0)
                    return new ValidationFailure("PageSize", localizationService.GetResource("Admin.Vendors.Fields.PageSize.Positive"));

                return null;
            });

            SetDatabaseValidationRules<Vendor>(dbContext);
        }
    }
}