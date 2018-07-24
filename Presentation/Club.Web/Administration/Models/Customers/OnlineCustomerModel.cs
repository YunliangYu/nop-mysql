using System;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Customers
{
    public partial class OnlineCustomerModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.Customers.OnlineCustomers.Fields.CustomerInfo")]
        public string CustomerInfo { get; set; }

        [SiteResourceDisplayName("Admin.Customers.OnlineCustomers.Fields.IPAddress")]
        public string LastIpAddress { get; set; }

        [SiteResourceDisplayName("Admin.Customers.OnlineCustomers.Fields.Location")]
        public string Location { get; set; }

        [SiteResourceDisplayName("Admin.Customers.OnlineCustomers.Fields.LastActivityDate")]
        public DateTime LastActivityDate { get; set; }
        
        [SiteResourceDisplayName("Admin.Customers.OnlineCustomers.Fields.LastVisitedPage")]
        public string LastVisitedPage { get; set; }
    }
}