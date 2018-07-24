using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Messages;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Messages
{
    [Validator(typeof(EmailAccountValidator))]
    public partial class EmailAccountModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.Configuration.EmailAccounts.Fields.Email")]
        [AllowHtml]
        public string Email { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.EmailAccounts.Fields.DisplayName")]
        [AllowHtml]
        public string DisplayName { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.EmailAccounts.Fields.Host")]
        [AllowHtml]
        public string Host { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.EmailAccounts.Fields.Port")]
        public int Port { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.EmailAccounts.Fields.Username")]
        [AllowHtml]
        public string Username { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.EmailAccounts.Fields.Password")]
        [AllowHtml]
        [DataType(DataType.Password)]
        [NoTrim]
        public string Password { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.EmailAccounts.Fields.EnableSsl")]
        public bool EnableSsl { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.EmailAccounts.Fields.UseDefaultCredentials")]
        public bool UseDefaultCredentials { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.EmailAccounts.Fields.IsDefaultEmailAccount")]
        public bool IsDefaultEmailAccount { get; set; }


        [SiteResourceDisplayName("Admin.Configuration.EmailAccounts.Fields.SendTestEmailTo")]
        [AllowHtml]
        public string SendTestEmailTo { get; set; }

    }
}