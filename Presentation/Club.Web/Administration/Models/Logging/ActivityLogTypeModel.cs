using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Logging
{
    public partial class ActivityLogTypeModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.Configuration.ActivityLog.ActivityLogType.Fields.Name")]
        public string Name { get; set; }
        [SiteResourceDisplayName("Admin.Configuration.ActivityLog.ActivityLogType.Fields.Enabled")]
        public bool Enabled { get; set; }
    }
}