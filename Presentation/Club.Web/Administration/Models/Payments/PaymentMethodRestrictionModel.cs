using System.Collections.Generic;
using Club.Admin.Models.Directory;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Payments
{
    public partial class PaymentMethodRestrictionModel : BaseSiteModel
    {
        public PaymentMethodRestrictionModel()
        {
            AvailablePaymentMethods = new List<PaymentMethodModel>();
            AvailableCountries = new List<CountryModel>();
            Resticted = new Dictionary<string, IDictionary<int, bool>>();
        }
        public IList<PaymentMethodModel> AvailablePaymentMethods { get; set; }
        public IList<CountryModel> AvailableCountries { get; set; }

        //[payment method system name] / [customer role id] / [resticted]
        public IDictionary<string, IDictionary<int, bool>> Resticted { get; set; }
    }
}