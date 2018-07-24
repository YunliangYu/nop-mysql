using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Messages
{
    public partial class QueuedEmailListModel : BaseSiteModel
    {
        [SiteResourceDisplayName("Admin.System.QueuedEmails.List.StartDate")]
        [UIHint("DateNullable")]
        public DateTime? SearchStartDate { get; set; }

        [SiteResourceDisplayName("Admin.System.QueuedEmails.List.EndDate")]
        [UIHint("DateNullable")]
        public DateTime? SearchEndDate { get; set; }

        [SiteResourceDisplayName("Admin.System.QueuedEmails.List.FromEmail")]
        [AllowHtml]
        public string SearchFromEmail { get; set; }

        [SiteResourceDisplayName("Admin.System.QueuedEmails.List.ToEmail")]
        [AllowHtml]
        public string SearchToEmail { get; set; }

        [SiteResourceDisplayName("Admin.System.QueuedEmails.List.LoadNotSent")]
        public bool SearchLoadNotSent { get; set; }

        [SiteResourceDisplayName("Admin.System.QueuedEmails.List.MaxSentTries")]
        public int SearchMaxSentTries { get; set; }

        [SiteResourceDisplayName("Admin.System.QueuedEmails.List.GoDirectlyToNumber")]
        public int GoDirectlyToNumber { get; set; }
    }
}