using System.Collections.Generic;
using Club.Admin.Models.Directory;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Shipping
{
    public partial class ShippingMethodRestrictionModel : BaseSiteModel
    {
        public ShippingMethodRestrictionModel()
        {
            AvailableShippingMethods = new List<ShippingMethodModel>();
            AvailableCountries = new List<CountryModel>();
            Restricted = new Dictionary<int, IDictionary<int, bool>>();
        }
        public IList<ShippingMethodModel> AvailableShippingMethods { get; set; }
        public IList<CountryModel> AvailableCountries { get; set; }

        //[country id] / [shipping method id] / [restricted]
        public IDictionary<int, IDictionary<int, bool>> Restricted { get; set; }
    }
}