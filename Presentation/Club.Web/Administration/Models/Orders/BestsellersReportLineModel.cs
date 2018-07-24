using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Orders
{
    public partial class BestsellersReportLineModel : BaseSiteModel
    {
        public int ProductId { get; set; }
        [SiteResourceDisplayName("Admin.SalesReport.Bestsellers.Fields.Name")]
        public string ProductName { get; set; }

        [SiteResourceDisplayName("Admin.SalesReport.Bestsellers.Fields.TotalAmount")]
        public string TotalAmount { get; set; }

        [SiteResourceDisplayName("Admin.SalesReport.Bestsellers.Fields.TotalQuantity")]
        public decimal TotalQuantity { get; set; }
    }
}