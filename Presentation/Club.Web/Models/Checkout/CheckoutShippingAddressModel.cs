using System.Collections.Generic;
using Club.Web.Framework.Mvc;
using Club.Web.Models.Common;

namespace Club.Web.Models.Checkout
{
    public partial class CheckoutShippingAddressModel : BaseSiteModel
    {
        public CheckoutShippingAddressModel()
        {
            Warnings = new List<string>();
            ExistingAddresses = new List<AddressModel>();
            NewAddress = new AddressModel();
            PickupPoints = new List<CheckoutPickupPointModel>();
        }

        public IList<string> Warnings { get; set; }

        public IList<AddressModel> ExistingAddresses { get; set; }
        public AddressModel NewAddress { get; set; }
        public bool NewAddressPreselected { get; set; }

        public IList<CheckoutPickupPointModel> PickupPoints { get; set; }
        public bool AllowPickUpInStore { get; set; }
        public bool PickUpInStore { get; set; }
        public bool PickUpInStoreOnly { get; set; }
        public bool DisplayPickupPointsOnMap { get; set; }
        public string GoogleMapsApiKey { get; set; }
    }
}