using FluentValidation;
using Club.Admin.Models.Catalog;
using Club.Core;
using Club.Core.Domain.Catalog;
using Club.Data;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Catalog
{
    public partial class ProductReviewValidator : BaseSiteValidator<ProductReviewModel>
    {
        public ProductReviewValidator(ILocalizationService localizationService, IDbContext dbContext, IWorkContext workContext)
        {
            var isLoggedInAsVendor = workContext.CurrentVendor != null;
            //vendor can edit "Reply text" only
            if (!isLoggedInAsVendor)
            {
                RuleFor(x => x.Title).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.ProductReviews.Fields.Title.Required"));
                RuleFor(x => x.ReviewText).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.ProductReviews.Fields.ReviewText.Required"));
            }

            SetDatabaseValidationRules<ProductReview>(dbContext);
        }
    }
}