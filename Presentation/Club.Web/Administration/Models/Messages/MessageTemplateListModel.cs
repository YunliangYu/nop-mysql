using System.Collections.Generic;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Messages
{
    public partial class MessageTemplateListModel : BaseSiteModel
    {
        public MessageTemplateListModel()
        {
            AvailableStores = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.ContentManagement.MessageTemplates.List.SearchStore")]
        public int SearchStoreId { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }
    }
}