using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Common
{
    public partial class SearchTermReportLineModel : BaseSiteModel
    {
        [SiteResourceDisplayName("Admin.SearchTermReport.Keyword")]
        public string Keyword { get; set; }

        [SiteResourceDisplayName("Admin.SearchTermReport.Count")]
        public int Count { get; set; }
    }
}
