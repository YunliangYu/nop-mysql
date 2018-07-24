using System.Collections.Generic;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Plugins
{
    public partial class PluginListModel : BaseSiteModel
    {
        public PluginListModel()
        {
            AvailableLoadModes = new List<SelectListItem>();
            AvailableGroups = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.Configuration.Plugins.LoadMode")]
        public int SearchLoadModeId { get; set; }
        [SiteResourceDisplayName("Admin.Configuration.Plugins.Group")]
        public string SearchGroup { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Plugins.LoadMode")]
        public IList<SelectListItem> AvailableLoadModes { get; set; }
        [SiteResourceDisplayName("Admin.Configuration.Plugins.Group")]
        public IList<SelectListItem> AvailableGroups { get; set; }
    }
}