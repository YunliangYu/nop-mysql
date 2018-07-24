using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Customers
{
    public partial class CustomerReportsModel : BaseSiteModel
    {
        public BestCustomersReportModel BestCustomersByOrderTotal { get; set; }
        public BestCustomersReportModel BestCustomersByNumberOfOrders { get; set; }
    }
}