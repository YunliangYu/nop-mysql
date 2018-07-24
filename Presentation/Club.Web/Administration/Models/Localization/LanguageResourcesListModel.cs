using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Localization
{
    public class LanguageResourcesListModel : BaseSiteModel
    {
        [SiteResourceDisplayName("Admin.Configuration.Languages.Resources.SearchResourceName")]
        public string SearchResourceName { get; set; }
        [SiteResourceDisplayName("Admin.Configuration.Languages.Resources.SearchResourceValue")]
        public string SearchResourceValue { get; set; }
    }
}