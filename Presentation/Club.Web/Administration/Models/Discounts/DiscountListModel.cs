using System.Collections.Generic;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Discounts
{
    public partial class DiscountListModel : BaseSiteModel
    {
        public DiscountListModel()
        {
            AvailableDiscountTypes = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.Promotions.Discounts.List.SearchDiscountCouponCode")]
        [AllowHtml]
        public string SearchDiscountCouponCode { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.Discounts.List.SearchDiscountName")]
        [AllowHtml]
        public string SearchDiscountName { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.Discounts.List.SearchDiscountType")]
        public int SearchDiscountTypeId { get; set; }
        public IList<SelectListItem> AvailableDiscountTypes { get; set; }
    }
}