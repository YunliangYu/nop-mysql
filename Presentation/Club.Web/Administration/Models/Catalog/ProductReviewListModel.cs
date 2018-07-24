using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Catalog
{
    public partial class ProductReviewListModel : BaseSiteModel
    {
        public ProductReviewListModel()
        {
            AvailableStores = new List<SelectListItem>();
            AvailableApprovedOptions = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.Catalog.ProductReviews.List.CreatedOnFrom")]
        [UIHint("DateNullable")]
        public DateTime? CreatedOnFrom { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.ProductReviews.List.CreatedOnTo")]
        [UIHint("DateNullable")]
        public DateTime? CreatedOnTo { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.ProductReviews.List.SearchText")]
        [AllowHtml]
        public string SearchText { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.ProductReviews.List.SearchStore")]
        public int SearchStoreId { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.ProductReviews.List.SearchProduct")]
        public int SearchProductId { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.ProductReviews.List.SearchApproved")]
        public int SearchApprovedId { get; set; }

        //vendor
        public bool IsLoggedInAsVendor { get; set; }

        public IList<SelectListItem> AvailableStores { get; set; }
        public IList<SelectListItem> AvailableApprovedOptions { get; set; }
    }
}