using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Customers
{
    public partial class BestCustomerReportLineModel : BaseSiteModel
    {
        public int CustomerId { get; set; }
        [SiteResourceDisplayName("Admin.Customers.Reports.BestBy.Fields.Customer")]
        public string CustomerName { get; set; }

        [SiteResourceDisplayName("Admin.Customers.Reports.BestBy.Fields.OrderTotal")]
        public string OrderTotal { get; set; }

        [SiteResourceDisplayName("Admin.Customers.Reports.BestBy.Fields.OrderCount")]
        public decimal OrderCount { get; set; }
    }
}