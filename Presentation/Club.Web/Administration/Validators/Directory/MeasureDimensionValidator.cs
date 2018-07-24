using FluentValidation;
using Club.Admin.Models.Directory;
using Club.Core.Domain.Directory;
using Club.Data;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Directory
{
    public partial class MeasureDimensionValidator : BaseSiteValidator<MeasureDimensionModel>
    {
        public MeasureDimensionValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Shipping.Measures.Dimensions.Fields.Name.Required"));
            RuleFor(x => x.SystemKeyword).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Shipping.Measures.Dimensions.Fields.SystemKeyword.Required"));

            SetDatabaseValidationRules<MeasureDimension>(dbContext);
        }
    }
}