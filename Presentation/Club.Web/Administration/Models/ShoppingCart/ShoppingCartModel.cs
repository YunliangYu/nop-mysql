using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.ShoppingCart
{
    public partial class ShoppingCartModel : BaseSiteModel
    {
        [SiteResourceDisplayName("Admin.CurrentCarts.Customer")]
        public int CustomerId { get; set; }
        [SiteResourceDisplayName("Admin.CurrentCarts.Customer")]
        public string CustomerEmail { get; set; }

        [SiteResourceDisplayName("Admin.CurrentCarts.TotalItems")]
        public int TotalItems { get; set; }
    }
}