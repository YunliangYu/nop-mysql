using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Messages;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Messages
{
    [Validator(typeof(QueuedEmailValidator))]
    public partial class QueuedEmailModel: BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.System.QueuedEmails.Fields.Id")]
        public override int Id { get; set; }

        [SiteResourceDisplayName("Admin.System.QueuedEmails.Fields.Priority")]
        public string PriorityName { get; set; }

        [SiteResourceDisplayName("Admin.System.QueuedEmails.Fields.From")]
        [AllowHtml]
        public string From { get; set; }

        [SiteResourceDisplayName("Admin.System.QueuedEmails.Fields.FromName")]
        [AllowHtml]
        public string FromName { get; set; }

        [SiteResourceDisplayName("Admin.System.QueuedEmails.Fields.To")]
        [AllowHtml]
        public string To { get; set; }

        [SiteResourceDisplayName("Admin.System.QueuedEmails.Fields.ToName")]
        [AllowHtml]
        public string ToName { get; set; }

        [SiteResourceDisplayName("Admin.System.QueuedEmails.Fields.ReplyTo")]
        [AllowHtml]
        public string ReplyTo { get; set; }

        [SiteResourceDisplayName("Admin.System.QueuedEmails.Fields.ReplyToName")]
        [AllowHtml]
        public string ReplyToName { get; set; }

        [SiteResourceDisplayName("Admin.System.QueuedEmails.Fields.CC")]
        [AllowHtml]
        public string CC { get; set; }

        [SiteResourceDisplayName("Admin.System.QueuedEmails.Fields.Bcc")]
        [AllowHtml]
        public string Bcc { get; set; }

        [SiteResourceDisplayName("Admin.System.QueuedEmails.Fields.Subject")]
        [AllowHtml]
        public string Subject { get; set; }

        [SiteResourceDisplayName("Admin.System.QueuedEmails.Fields.Body")]
        [AllowHtml]
        public string Body { get; set; }

        [SiteResourceDisplayName("Admin.System.QueuedEmails.Fields.AttachmentFilePath")]
        [AllowHtml]
        public string AttachmentFilePath { get; set; }

        [SiteResourceDisplayName("Admin.System.QueuedEmails.Fields.AttachedDownload")]
        [UIHint("Download")]
        public int AttachedDownloadId { get; set; }

        [SiteResourceDisplayName("Admin.System.QueuedEmails.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        [SiteResourceDisplayName("Admin.System.QueuedEmails.Fields.SendImmediately")]
        public bool SendImmediately { get; set; }

        [SiteResourceDisplayName("Admin.System.QueuedEmails.Fields.DontSendBeforeDate")]
        [UIHint("DateTimeNullable")]
        public DateTime? DontSendBeforeDate { get; set; }

        [SiteResourceDisplayName("Admin.System.QueuedEmails.Fields.SentTries")]
        public int SentTries { get; set; }

        [SiteResourceDisplayName("Admin.System.QueuedEmails.Fields.SentOn")]
        public DateTime? SentOn { get; set; }

        [SiteResourceDisplayName("Admin.System.QueuedEmails.Fields.EmailAccountName")]
        [AllowHtml]
        public string EmailAccountName { get; set; }
    }
}