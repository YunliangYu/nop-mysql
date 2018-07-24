using Club.Web.Framework.Mvc;
using Club.Web.Models.Common;

namespace Club.Web.Models.Customer
{
    public partial class CustomerAddressEditModel : BaseSiteModel
    {
        public CustomerAddressEditModel()
        {
            this.Address = new AddressModel();
        }
        public AddressModel Address { get; set; }
    }
}