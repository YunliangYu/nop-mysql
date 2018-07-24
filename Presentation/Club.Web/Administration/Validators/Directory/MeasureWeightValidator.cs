using FluentValidation;
using Club.Admin.Models.Directory;
using Club.Core.Domain.Directory;
using Club.Data;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Directory
{
    public partial class MeasureWeightValidator : BaseSiteValidator<MeasureWeightModel>
    {
        public MeasureWeightValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Shipping.Measures.Weights.Fields.Name.Required"));
            RuleFor(x => x.SystemKeyword).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Shipping.Measures.Weights.Fields.SystemKeyword.Required"));

            SetDatabaseValidationRules<MeasureWeight>(dbContext);
        }
    }
}