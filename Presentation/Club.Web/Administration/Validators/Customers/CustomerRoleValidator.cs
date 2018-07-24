using FluentValidation;
using Club.Admin.Models.Customers;
using Club.Core.Domain.Customers;
using Club.Data;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Customers
{
    public partial class CustomerRoleValidator : BaseSiteValidator<CustomerRoleModel>
    {
        public CustomerRoleValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Customers.CustomerRoles.Fields.Name.Required"));

            SetDatabaseValidationRules<CustomerRole>(dbContext);
        }
    }
}