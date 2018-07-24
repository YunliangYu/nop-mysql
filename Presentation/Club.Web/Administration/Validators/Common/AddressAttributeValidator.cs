using FluentValidation;
using Club.Admin.Models.Common;
using Club.Core.Domain.Common;
using Club.Data;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Common
{
    public partial class AddressAttributeValidator : BaseSiteValidator<AddressAttributeModel>
    {
        public AddressAttributeValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Address.AddressAttributes.Fields.Name.Required"));

            SetDatabaseValidationRules<AddressAttribute>(dbContext);
        }
    }
}