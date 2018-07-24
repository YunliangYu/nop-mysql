using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Settings
{
    public partial class SortOptionModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.Configuration.Settings.Catalog.SortOptions.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.Catalog.SortOptions.IsActive")]
        public bool IsActive { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.Catalog.SortOptions.DisplayOrder")]
        public int DisplayOrder { get; set; }
    }
}