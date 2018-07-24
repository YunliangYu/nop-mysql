using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Models.Common;
using Club.Admin.Validators.Shipping;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Shipping
{
    [Validator(typeof(WarehouseValidator))]
    public partial class WarehouseModel : BaseSiteEntityModel
    {
        public WarehouseModel()
        {
            this.Address = new AddressModel();
        }

        [SiteResourceDisplayName("Admin.Configuration.Shipping.Warehouses.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Shipping.Warehouses.Fields.AdminComment")]
        [AllowHtml]
        public string AdminComment { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Shipping.Warehouses.Fields.Address")]
        public AddressModel Address { get; set; }
    }
}