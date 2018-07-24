using System.Collections.Generic;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Orders
{
    public partial class GiftCardListModel : BaseSiteModel
    {
        public GiftCardListModel()
        {
            ActivatedList = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.GiftCards.List.CouponCode")]
        [AllowHtml]
        public string CouponCode { get; set; }

        [SiteResourceDisplayName("Admin.GiftCards.List.RecipientName")]
        [AllowHtml]
        public string RecipientName { get; set; }

        [SiteResourceDisplayName("Admin.GiftCards.List.Activated")]
        public int ActivatedId { get; set; }
        [SiteResourceDisplayName("Admin.GiftCards.List.Activated")]
        public IList<SelectListItem> ActivatedList { get; set; }
    }
}