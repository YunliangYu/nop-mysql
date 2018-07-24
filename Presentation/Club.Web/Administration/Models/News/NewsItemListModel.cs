using System.Collections.Generic;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.News
{
    public partial class NewsItemListModel : BaseSiteModel
    {
        public NewsItemListModel()
        {
            AvailableStores = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.ContentManagement.News.NewsItems.List.SearchStore")]
        public int SearchStoreId { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }
    }
}