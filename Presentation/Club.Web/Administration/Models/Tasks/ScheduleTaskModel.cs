using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Tasks;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Tasks
{
    [Validator(typeof(ScheduleTaskValidator))]
    public partial class ScheduleTaskModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.System.ScheduleTasks.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.System.ScheduleTasks.Seconds")]
        public int Seconds { get; set; }

        [SiteResourceDisplayName("Admin.System.ScheduleTasks.Enabled")]
        public bool Enabled { get; set; }

        [SiteResourceDisplayName("Admin.System.ScheduleTasks.StopOnError")]
        public bool StopOnError { get; set; }

        [SiteResourceDisplayName("Admin.System.ScheduleTasks.LastStart")]
        public string LastStartUtc { get; set; }

        [SiteResourceDisplayName("Admin.System.ScheduleTasks.LastEnd")]
        public string LastEndUtc { get; set; }

        [SiteResourceDisplayName("Admin.System.ScheduleTasks.LastSuccess")]
        public string LastSuccessUtc { get; set; }
    }
}