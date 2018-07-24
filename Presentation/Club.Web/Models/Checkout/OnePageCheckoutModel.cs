using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Checkout
{
    public partial class OnePageCheckoutModel : BaseSiteModel
    {
        public bool ShippingRequired { get; set; }
        public bool DisableBillingAddressCheckoutStep { get; set; }
    }
}