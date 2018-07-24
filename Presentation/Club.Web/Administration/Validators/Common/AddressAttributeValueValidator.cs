using FluentValidation;
using Club.Admin.Models.Common;
using Club.Core.Domain.Common;
using Club.Data;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Common
{
    public partial class AddressAttributeValueValidator : BaseSiteValidator<AddressAttributeValueModel>
    {
        public AddressAttributeValueValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Address.AddressAttributes.Values.Fields.Name.Required"));

            SetDatabaseValidationRules<AddressAttributeValue>(dbContext);
        }
    }
}