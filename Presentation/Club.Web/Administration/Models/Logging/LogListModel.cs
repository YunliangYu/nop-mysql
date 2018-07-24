using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Logging
{
    public partial class LogListModel : BaseSiteModel
    {
        public LogListModel()
        {
            AvailableLogLevels = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.System.Log.List.CreatedOnFrom")]
        [UIHint("DateNullable")]
        public DateTime? CreatedOnFrom { get; set; }

        [SiteResourceDisplayName("Admin.System.Log.List.CreatedOnTo")]
        [UIHint("DateNullable")]
        public DateTime? CreatedOnTo { get; set; }

        [SiteResourceDisplayName("Admin.System.Log.List.Message")]
        [AllowHtml]
        public string Message { get; set; }

        [SiteResourceDisplayName("Admin.System.Log.List.LogLevel")]
        public int LogLevelId { get; set; }


        public IList<SelectListItem> AvailableLogLevels { get; set; }
    }
}