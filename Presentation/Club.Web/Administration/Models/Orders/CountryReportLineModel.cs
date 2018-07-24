using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Orders
{
    public partial class CountryReportLineModel : BaseSiteModel
    {
        [SiteResourceDisplayName("Admin.SalesReport.Country.Fields.CountryName")]
        public string CountryName { get; set; }

        [SiteResourceDisplayName("Admin.SalesReport.Country.Fields.TotalOrders")]
        public int TotalOrders { get; set; }

        [SiteResourceDisplayName("Admin.SalesReport.Country.Fields.SumOrders")]
        public string SumOrders { get; set; }
    }
}