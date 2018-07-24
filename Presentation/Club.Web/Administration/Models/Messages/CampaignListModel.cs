using System.Collections.Generic;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Messages
{
    public class CampaignListModel : BaseSiteModel
    {
        public CampaignListModel()
        {
            AvailableStores = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.Promotions.Campaigns.List.Stores")]
        public int StoreId { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }
    }
}