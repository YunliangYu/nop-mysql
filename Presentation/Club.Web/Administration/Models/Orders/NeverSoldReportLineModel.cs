using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Orders
{
    public partial class NeverSoldReportLineModel : BaseSiteModel
    {
        public int ProductId { get; set; }
        [SiteResourceDisplayName("Admin.SalesReport.NeverSold.Fields.Name")]
        public string ProductName { get; set; }
    }
}