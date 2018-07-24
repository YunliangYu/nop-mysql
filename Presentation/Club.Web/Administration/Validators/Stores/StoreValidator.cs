using FluentValidation;
using Club.Admin.Models.Stores;
using Club.Core.Domain.Stores;
using Club.Data;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Stores
{
    public partial class StoreValidator : BaseSiteValidator<StoreModel>
    {
        public StoreValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Stores.Fields.Name.Required"));
            RuleFor(x => x.Url).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Stores.Fields.Url.Required"));

            SetDatabaseValidationRules<Store>(dbContext);
        }
    }
}