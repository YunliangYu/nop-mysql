using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Orders
{
    public partial class OrderIncompleteReportLineModel : BaseSiteModel
    {
        [SiteResourceDisplayName("Admin.SalesReport.Incomplete.Item")]
        public string Item { get; set; }

        [SiteResourceDisplayName("Admin.SalesReport.Incomplete.Total")]
        public string Total { get; set; }

        [SiteResourceDisplayName("Admin.SalesReport.Incomplete.Count")]
        public int Count { get; set; }

        [SiteResourceDisplayName("Admin.SalesReport.Incomplete.View")]
        public string ViewLink { get; set; }
    }
}
