using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Checkout
{
    public partial class CheckoutProgressModel : BaseSiteModel
    {
        public CheckoutProgressStep CheckoutProgressStep { get; set; }
    }

    public enum CheckoutProgressStep
    {
        Cart,
        Address,
        Shipping,
        Payment,
        Confirm,
        Complete
    }
}