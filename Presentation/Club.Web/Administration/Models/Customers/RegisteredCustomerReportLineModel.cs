using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Customers
{
    public partial class RegisteredCustomerReportLineModel : BaseSiteModel
    {
        [SiteResourceDisplayName("Admin.Customers.Reports.RegisteredCustomers.Fields.Period")]
        public string Period { get; set; }

        [SiteResourceDisplayName("Admin.Customers.Reports.RegisteredCustomers.Fields.Customers")]
        public int Customers { get; set; }
    }
}