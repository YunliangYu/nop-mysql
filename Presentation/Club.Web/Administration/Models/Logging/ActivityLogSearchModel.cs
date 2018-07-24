using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Logging
{
    public partial class ActivityLogSearchModel : BaseSiteModel
    {
        public ActivityLogSearchModel()
        {
            ActivityLogType = new List<SelectListItem>();
        }
        [SiteResourceDisplayName("Admin.Configuration.ActivityLog.ActivityLog.Fields.CreatedOnFrom")]
        [UIHint("DateNullable")]
        public DateTime? CreatedOnFrom { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.ActivityLog.ActivityLog.Fields.CreatedOnTo")]
        [UIHint("DateNullable")]
        public DateTime? CreatedOnTo { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.ActivityLog.ActivityLog.Fields.ActivityLogType")]
        public int ActivityLogTypeId { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.ActivityLog.ActivityLog.Fields.ActivityLogType")]
        public IList<SelectListItem> ActivityLogType { get; set; }
        
        [SiteResourceDisplayName("Admin.Customers.Customers.ActivityLog.IpAddress")]
        public string IpAddress { get; set; }
    }
}