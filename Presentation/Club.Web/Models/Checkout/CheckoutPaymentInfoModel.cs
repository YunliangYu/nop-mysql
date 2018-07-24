using System.Web.Routing;
using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Checkout
{
    public partial class CheckoutPaymentInfoModel : BaseSiteModel
    {
        public string PaymentInfoActionName { get; set; }
        public string PaymentInfoControllerName { get; set; }
        public RouteValueDictionary PaymentInfoRouteValues { get; set; }

        /// <summary>
        /// Used on one-page checkout page
        /// </summary>
        public bool DisplayOrderTotals { get; set; }
    }
}