using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Orders
{
    public partial class OrderAverageReportLineSummaryModel : BaseSiteModel
    {
        [SiteResourceDisplayName("Admin.SalesReport.Average.OrderStatus")]
        public string OrderStatus { get; set; }

        [SiteResourceDisplayName("Admin.SalesReport.Average.SumTodayOrders")]
        public string SumTodayOrders { get; set; }
        
        [SiteResourceDisplayName("Admin.SalesReport.Average.SumThisWeekOrders")]
        public string SumThisWeekOrders { get; set; }

        [SiteResourceDisplayName("Admin.SalesReport.Average.SumThisMonthOrders")]
        public string SumThisMonthOrders { get; set; }

        [SiteResourceDisplayName("Admin.SalesReport.Average.SumThisYearOrders")]
        public string SumThisYearOrders { get; set; }

        [SiteResourceDisplayName("Admin.SalesReport.Average.SumAllTimeOrders")]
        public string SumAllTimeOrders { get; set; }
    }
}
