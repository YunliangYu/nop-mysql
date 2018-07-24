using System.Collections.Generic;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Catalog
{
    public partial class ManufacturerListModel : BaseSiteModel
    {
        public ManufacturerListModel()
        {
            AvailableStores = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.Catalog.Manufacturers.List.SearchManufacturerName")]
        [AllowHtml]
        public string SearchManufacturerName { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Manufacturers.List.SearchStore")]
        public int SearchStoreId { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }
    }
}