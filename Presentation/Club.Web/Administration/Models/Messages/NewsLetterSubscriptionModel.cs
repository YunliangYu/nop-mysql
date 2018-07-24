using System;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Messages;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Messages
{
    [Validator(typeof(NewsLetterSubscriptionValidator))]
    public partial class NewsLetterSubscriptionModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.Promotions.NewsLetterSubscriptions.Fields.Email")]
        [AllowHtml]
        public string Email { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.NewsLetterSubscriptions.Fields.Active")]
        public bool Active { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.NewsLetterSubscriptions.Fields.Store")]
        public string StoreName { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.NewsLetterSubscriptions.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }
    }
}