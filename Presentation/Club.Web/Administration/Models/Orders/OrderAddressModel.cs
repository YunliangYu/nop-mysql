using Club.Admin.Models.Common;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Orders
{
    public partial class OrderAddressModel : BaseSiteModel
    {
        public int OrderId { get; set; }

        public AddressModel Address { get; set; }
    }
}