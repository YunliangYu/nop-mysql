using FluentValidation;
using FluentValidation.Results;
using Club.Admin.Models.Catalog;
using Club.Core.Domain.Catalog;
using Club.Data;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Catalog
{
    public partial class ManufacturerValidator : BaseSiteValidator<ManufacturerModel>
    {
        public ManufacturerValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.Manufacturers.Fields.Name.Required"));
            RuleFor(x => x.PageSizeOptions).Must(ValidatorUtilities.PageSizeOptionsValidator).WithMessage(localizationService.GetResource("Admin.Catalog.Manufacturers.Fields.PageSizeOptions.ShouldHaveUniqueItems"));
            Custom(x =>
            {
                if (!x.AllowCustomersToSelectPageSize && x.PageSize <= 0)
                    return new ValidationFailure("PageSize", localizationService.GetResource("Admin.Catalog.Manufacturers.Fields.PageSize.Positive"));

                return null;
            });

            SetDatabaseValidationRules<Manufacturer>(dbContext);
        }
    }
}