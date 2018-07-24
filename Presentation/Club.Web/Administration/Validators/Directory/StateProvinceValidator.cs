using FluentValidation;
using Club.Admin.Models.Directory;
using Club.Core.Domain.Directory;
using Club.Data;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Directory
{
    public partial class StateProvinceValidator : BaseSiteValidator<StateProvinceModel>
    {
        public StateProvinceValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Countries.States.Fields.Name.Required"));

            SetDatabaseValidationRules<StateProvince>(dbContext);
        }
    }
}