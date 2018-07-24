using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Localization;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Topics
{
    public partial class TopicModel : BaseSiteEntityModel, ILocalizedModel<TopicLocalizedModel>
    {
        public TopicModel()
        {
            AvailableTopicTemplates = new List<SelectListItem>();
            Locales = new List<TopicLocalizedModel>();

            SelectedCustomerRoleIds = new List<int>();
            AvailableCustomerRoles = new List<SelectListItem>();

            SelectedStoreIds = new List<int>();
            AvailableStores = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.ContentManagement.Topics.Fields.SystemName")]
        [AllowHtml]
        public string SystemName { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Topics.Fields.IncludeInSitemap")]
        public bool IncludeInSitemap { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Topics.Fields.IncludeInTopMenu")]
        public bool IncludeInTopMenu { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Topics.Fields.IncludeInFooterColumn1")]
        public bool IncludeInFooterColumn1 { get; set; }
        [SiteResourceDisplayName("Admin.ContentManagement.Topics.Fields.IncludeInFooterColumn2")]
        public bool IncludeInFooterColumn2 { get; set; }
        [SiteResourceDisplayName("Admin.ContentManagement.Topics.Fields.IncludeInFooterColumn3")]
        public bool IncludeInFooterColumn3 { get; set; }
        [SiteResourceDisplayName("Admin.ContentManagement.Topics.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Topics.Fields.AccessibleWhenStoreClosed")]
        public bool AccessibleWhenStoreClosed { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Topics.Fields.IsPasswordProtected")]
        public bool IsPasswordProtected { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Topics.Fields.Password")]
        public string Password { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Topics.Fields.URL")]
        [AllowHtml]
        public string Url { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Topics.Fields.Title")]
        [AllowHtml]
        public string Title { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Topics.Fields.Body")]
        [AllowHtml]
        public string Body { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Topics.Fields.Published")]
        public bool Published { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Topics.Fields.TopicTemplate")]
        public int TopicTemplateId { get; set; }
        public IList<SelectListItem> AvailableTopicTemplates { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Topics.Fields.MetaKeywords")]
        [AllowHtml]
        public string MetaKeywords { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Topics.Fields.MetaDescription")]
        [AllowHtml]
        public string MetaDescription { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Topics.Fields.MetaTitle")]
        [AllowHtml]
        public string MetaTitle { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Topics.Fields.SeName")]
        [AllowHtml]
        public string SeName { get; set; }

        public IList<TopicLocalizedModel> Locales { get; set; }

        //store mapping
        [SiteResourceDisplayName("Admin.ContentManagement.Topics.Fields.LimitedToStores")]
        [UIHint("MultiSelect")]
        public IList<int> SelectedStoreIds { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }

        //ACL (customer roles)
        [SiteResourceDisplayName("Admin.ContentManagement.Topics.Fields.AclCustomerRoles")]
        [UIHint("MultiSelect")]
        public IList<int> SelectedCustomerRoleIds { get; set; }
        public IList<SelectListItem> AvailableCustomerRoles { get; set; }

    }

    public partial class TopicLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Topics.Fields.Title")]
        [AllowHtml]
        public string Title { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Topics.Fields.Body")]
        [AllowHtml]
        public string Body { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Topics.Fields.MetaKeywords")]
        [AllowHtml]
        public string MetaKeywords { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Topics.Fields.MetaDescription")]
        [AllowHtml]
        public string MetaDescription { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Topics.Fields.MetaTitle")]
        [AllowHtml]
        public string MetaTitle { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Topics.Fields.SeName")]
        [AllowHtml]
        public string SeName { get; set; }
    }
}