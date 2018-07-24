using System.Collections.Generic;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Catalog
{
    public partial class CategoryListModel : BaseSiteModel
    {
        public CategoryListModel()
        {
            AvailableStores = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.Catalog.Categories.List.SearchCategoryName")]
        [AllowHtml]
        public string SearchCategoryName { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Categories.List.SearchStore")]
        public int SearchStoreId { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }
    }
}