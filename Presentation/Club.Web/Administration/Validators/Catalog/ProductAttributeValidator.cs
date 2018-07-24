using FluentValidation;
using Club.Admin.Models.Catalog;
using Club.Core.Domain.Catalog;
using Club.Data;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Catalog
{
    public partial class ProductAttributeValidator : BaseSiteValidator<ProductAttributeModel>
    {
        public ProductAttributeValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.Attributes.ProductAttributes.Fields.Name.Required"));
            SetDatabaseValidationRules<ProductAttribute>(dbContext);
        }
    }
}