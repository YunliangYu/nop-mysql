using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Common
{
    public partial class UrlRecordModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.System.SeNames.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.System.SeNames.EntityId")]
        public int EntityId { get; set; }

        [SiteResourceDisplayName("Admin.System.SeNames.EntityName")]
        public string EntityName { get; set; }

        [SiteResourceDisplayName("Admin.System.SeNames.IsActive")]
        public bool IsActive { get; set; }

        [SiteResourceDisplayName("Admin.System.SeNames.Language")]
        public string Language { get; set; }

        [SiteResourceDisplayName("Admin.System.SeNames.Details")]
        public string DetailsUrl { get; set; }
    }
}