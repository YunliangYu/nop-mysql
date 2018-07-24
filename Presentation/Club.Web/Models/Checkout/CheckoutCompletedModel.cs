using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Checkout
{
    public partial class CheckoutCompletedModel : BaseSiteModel
    {
        public int OrderId { get; set; }
        public string CustomOrderNumber { get; set; }
        public bool OnePageCheckoutEnabled { get; set; }
    }
}