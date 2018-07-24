using System.Collections.Generic;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Catalog
{
    public partial class BulkEditListModel : BaseSiteModel
    {
        public BulkEditListModel()
        {
            AvailableCategories = new List<SelectListItem>();
            AvailableManufacturers = new List<SelectListItem>();
            AvailableProductTypes = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.Catalog.BulkEdit.List.SearchProductName")]
        [AllowHtml]
        public string SearchProductName { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.BulkEdit.List.SearchCategory")]
        public int SearchCategoryId { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.BulkEdit.List.SearchManufacturer")]
        public int SearchManufacturerId { get; set; }
        [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchProductType")]
        public int SearchProductTypeId { get; set; }
        public IList<SelectListItem> AvailableProductTypes { get; set; }
        

        public IList<SelectListItem> AvailableCategories { get; set; }
        public IList<SelectListItem> AvailableManufacturers { get; set; }
    }
}