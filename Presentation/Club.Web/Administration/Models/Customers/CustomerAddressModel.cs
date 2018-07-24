using Club.Admin.Models.Common;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Customers
{
    public partial class CustomerAddressModel : BaseSiteModel
    {
        public int CustomerId { get; set; }

        public AddressModel Address { get; set; }
    }
}