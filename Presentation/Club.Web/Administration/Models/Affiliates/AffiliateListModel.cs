using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Affiliates
{
    public partial class AffiliateListModel : BaseSiteModel
    {
        [SiteResourceDisplayName("Admin.Affiliates.List.SearchFirstName")]
        [AllowHtml]
        public string SearchFirstName { get; set; }

        [SiteResourceDisplayName("Admin.Affiliates.List.SearchLastName")]
        [AllowHtml]
        public string SearchLastName { get; set; }

        [SiteResourceDisplayName("Admin.Affiliates.List.SearchFriendlyUrlName")]
        [AllowHtml]
        public string SearchFriendlyUrlName { get; set; }

        [SiteResourceDisplayName("Admin.Affiliates.List.LoadOnlyWithOrders")]
        public bool LoadOnlyWithOrders { get; set; }
        [SiteResourceDisplayName("Admin.Affiliates.List.OrdersCreatedFromUtc")]
        [UIHint("DateNullable")]
        public DateTime? OrdersCreatedFromUtc { get; set; }
        [SiteResourceDisplayName("Admin.Affiliates.List.OrdersCreatedToUtc")]
        [UIHint("DateNullable")]
        public DateTime? OrdersCreatedToUtc { get; set; }
    }
}