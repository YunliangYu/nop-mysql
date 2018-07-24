using Club.Admin.Models.Directory;
using Club.Services.Localization;
using Club.Web.Framework.Validators;
using FluentValidation;

namespace Club.Admin.Validators.Directory
{
    public class CityValidator : BaseSiteValidator<CityModel>
    {
        public CityValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Countries.Citys.Fields.Name.Required"));
        }
    }
}