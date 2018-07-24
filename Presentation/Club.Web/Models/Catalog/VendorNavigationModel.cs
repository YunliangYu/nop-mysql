using System.Collections.Generic;
using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Catalog
{
    public partial class VendorNavigationModel : BaseSiteModel
    {
        public VendorNavigationModel()
        {
            this.Vendors = new List<VendorBriefInfoModel>();
        }

        public IList<VendorBriefInfoModel> Vendors { get; set; }

        public int TotalVendors { get; set; }
    }

    public partial class VendorBriefInfoModel : BaseSiteEntityModel
    {
        public string Name { get; set; }

        public string SeName { get; set; }
    }
}