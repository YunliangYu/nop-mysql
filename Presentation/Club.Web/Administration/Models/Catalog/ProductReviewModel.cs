using System;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Catalog;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Catalog
{
    [Validator(typeof(ProductReviewValidator))]
    public partial class ProductReviewModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.Catalog.ProductReviews.Fields.Store")]
        public string StoreName { get; set; }
        [SiteResourceDisplayName("Admin.Catalog.ProductReviews.Fields.Product")]
        public int ProductId { get; set; }
        [SiteResourceDisplayName("Admin.Catalog.ProductReviews.Fields.Product")]
        public string ProductName { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.ProductReviews.Fields.Customer")]
        public int CustomerId { get; set; }
        [SiteResourceDisplayName("Admin.Catalog.ProductReviews.Fields.Customer")]
        public string CustomerInfo { get; set; }

        [AllowHtml]
        [SiteResourceDisplayName("Admin.Catalog.ProductReviews.Fields.Title")]
        public string Title { get; set; }

        [AllowHtml]
        [SiteResourceDisplayName("Admin.Catalog.ProductReviews.Fields.ReviewText")]
        public string ReviewText { get; set; }

        [AllowHtml]
        [SiteResourceDisplayName("Admin.Catalog.ProductReviews.Fields.ReplyText")]
        public string ReplyText { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.ProductReviews.Fields.Rating")]
        public int Rating { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.ProductReviews.Fields.IsApproved")]
        public bool IsApproved { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.ProductReviews.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        //vendor
        public bool IsLoggedInAsVendor { get; set; }
    }
}