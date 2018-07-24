using System;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Logging
{
    public partial class ActivityLogModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.Configuration.ActivityLog.ActivityLog.Fields.ActivityLogType")]
        public string ActivityLogTypeName { get; set; }
        [SiteResourceDisplayName("Admin.Configuration.ActivityLog.ActivityLog.Fields.Customer")]
        public int CustomerId { get; set; }
        [SiteResourceDisplayName("Admin.Configuration.ActivityLog.ActivityLog.Fields.Customer")]
        public string CustomerEmail { get; set; }
        [SiteResourceDisplayName("Admin.Configuration.ActivityLog.ActivityLog.Fields.Comment")]
        public string Comment { get; set; }
        [SiteResourceDisplayName("Admin.Configuration.ActivityLog.ActivityLog.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }
        [SiteResourceDisplayName("Admin.Customers.Customers.ActivityLog.IpAddress")]
        public string IpAddress { get; set; }
    }
}
