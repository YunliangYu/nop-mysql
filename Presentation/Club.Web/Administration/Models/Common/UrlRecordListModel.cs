using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Common
{
    public partial class UrlRecordListModel : BaseSiteModel
    {
        [SiteResourceDisplayName("Admin.System.SeNames.Name")]
        [AllowHtml]
        public string SeName { get; set; }
    }
}