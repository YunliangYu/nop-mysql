using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Messages;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Messages
{
    [Validator(typeof(CampaignValidator))]
    public partial class CampaignModel : BaseSiteEntityModel
    {
        public CampaignModel()
        {
            this.AvailableStores = new List<SelectListItem>();
            this.AvailableCustomerRoles = new List<SelectListItem>();
            this.AvailableEmailAccounts = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.Promotions.Campaigns.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.Campaigns.Fields.Subject")]
        [AllowHtml]
        public string Subject { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.Campaigns.Fields.Body")]
        [AllowHtml]
        public string Body { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.Campaigns.Fields.Store")]
        public int StoreId { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.Campaigns.Fields.CustomerRole")]
        public int CustomerRoleId { get; set; }
        public IList<SelectListItem> AvailableCustomerRoles { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.Campaigns.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.Campaigns.Fields.DontSendBeforeDate")]
        [UIHint("DateTimeNullable")]
        public DateTime? DontSendBeforeDate { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.Campaigns.Fields.AllowedTokens")]
        public string AllowedTokens { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.Campaigns.Fields.EmailAccount")]
        public int EmailAccountId { get; set; }
        public IList<SelectListItem> AvailableEmailAccounts { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.Campaigns.Fields.TestEmail")]
        [AllowHtml]
        public string TestEmail { get; set; }
    }
}