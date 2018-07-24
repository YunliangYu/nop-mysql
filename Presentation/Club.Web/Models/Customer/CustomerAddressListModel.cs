using System.Collections.Generic;
using Club.Web.Framework.Mvc;
using Club.Web.Models.Common;

namespace Club.Web.Models.Customer
{
    public partial class CustomerAddressListModel : BaseSiteModel
    {
        public CustomerAddressListModel()
        {
            Addresses = new List<AddressModel>();
        }

        public IList<AddressModel> Addresses { get; set; }
    }
}