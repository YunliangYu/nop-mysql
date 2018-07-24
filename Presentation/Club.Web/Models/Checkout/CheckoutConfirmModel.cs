using System.Collections.Generic;
using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Checkout
{
    public partial class CheckoutConfirmModel : BaseSiteModel
    {
        public CheckoutConfirmModel()
        {
            Warnings = new List<string>();
        }

        public bool TermsOfServiceOnOrderConfirmPage { get; set; }
        public string MinOrderTotalWarning { get; set; }

        public IList<string> Warnings { get; set; }
    }
}