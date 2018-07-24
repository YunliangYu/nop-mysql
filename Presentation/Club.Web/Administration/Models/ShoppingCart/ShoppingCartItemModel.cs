using System;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.ShoppingCart
{
    public partial class ShoppingCartItemModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.CurrentCarts.Store")]
        public string Store { get; set; }
        [SiteResourceDisplayName("Admin.CurrentCarts.Product")]
        public int ProductId { get; set; }
        [SiteResourceDisplayName("Admin.CurrentCarts.Product")]
        public string ProductName { get; set; }
        public string AttributeInfo { get; set; }

        [SiteResourceDisplayName("Admin.CurrentCarts.UnitPrice")]
        public string UnitPrice { get; set; }
        [SiteResourceDisplayName("Admin.CurrentCarts.Quantity")]
        public int Quantity { get; set; }
        [SiteResourceDisplayName("Admin.CurrentCarts.Total")]
        public string Total { get; set; }
        [SiteResourceDisplayName("Admin.CurrentCarts.UpdatedOn")]
        public DateTime UpdatedOn { get; set; }
    }
}