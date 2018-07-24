using FluentValidation;
using Club.Admin.Models.Catalog;
using Club.Core.Domain.Catalog;
using Club.Data;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Catalog
{
    public partial class ProductAttributeValueModelValidator : BaseSiteValidator<ProductModel.ProductAttributeValueModel>
    {
        public ProductAttributeValueModelValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(localizationService.GetResource("Admin.Catalog.Products.ProductAttributes.Attributes.Values.Fields.Name.Required"));

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(1)
                .WithMessage(localizationService.GetResource("Admin.Catalog.Products.ProductAttributes.Attributes.Values.Fields.Quantity.GreaterThanOrEqualTo1"))
                .When(x => x.AttributeValueTypeId == (int)AttributeValueType.AssociatedToProduct && !x.CustomerEntersQty);

            RuleFor(x => x.AssociatedProductId)
                .GreaterThanOrEqualTo(1)
                .WithMessage(localizationService.GetResource("Admin.Catalog.Products.ProductAttributes.Attributes.Values.Fields.AssociatedProduct.Choose"))
                .When(x => x.AttributeValueTypeId == (int)AttributeValueType.AssociatedToProduct);

            SetDatabaseValidationRules<ProductAttributeValue>(dbContext);
        }
    }
}