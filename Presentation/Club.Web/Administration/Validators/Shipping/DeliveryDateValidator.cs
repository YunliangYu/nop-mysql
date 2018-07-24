using FluentValidation;
using Club.Admin.Models.Shipping;
using Club.Core.Domain.Shipping;
using Club.Data;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Shipping
{
    public partial class DeliveryDateValidator : BaseSiteValidator<DeliveryDateModel>
    {
        public DeliveryDateValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Shipping.DeliveryDates.Fields.Name.Required"));

            SetDatabaseValidationRules<DeliveryDate>(dbContext);
        }
    }
}