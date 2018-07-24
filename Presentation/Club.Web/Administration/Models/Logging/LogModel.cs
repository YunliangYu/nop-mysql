using System;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Logging
{
    public partial class LogModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.System.Log.Fields.LogLevel")]
        public string LogLevel { get; set; }

        [SiteResourceDisplayName("Admin.System.Log.Fields.ShortMessage")]
        [AllowHtml]
        public string ShortMessage { get; set; }

        [SiteResourceDisplayName("Admin.System.Log.Fields.FullMessage")]
        [AllowHtml]
        public string FullMessage { get; set; }

        [SiteResourceDisplayName("Admin.System.Log.Fields.IPAddress")]
        [AllowHtml]
        public string IpAddress { get; set; }

        [SiteResourceDisplayName("Admin.System.Log.Fields.Customer")]
        public int? CustomerId { get; set; }
        [SiteResourceDisplayName("Admin.System.Log.Fields.Customer")]
        public string CustomerEmail { get; set; }

        [SiteResourceDisplayName("Admin.System.Log.Fields.PageURL")]
        [AllowHtml]
        public string PageUrl { get; set; }

        [SiteResourceDisplayName("Admin.System.Log.Fields.ReferrerURL")]
        [AllowHtml]
        public string ReferrerUrl { get; set; }

        [SiteResourceDisplayName("Admin.System.Log.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }
    }
}