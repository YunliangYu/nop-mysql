using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Stores;
using Club.Web.Framework;
using Club.Web.Framework.Localization;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Stores
{
    [Validator(typeof(StoreValidator))]
    public partial class StoreModel : BaseSiteEntityModel, ILocalizedModel<StoreLocalizedModel>
    {
        public StoreModel()
        {
            Locales = new List<StoreLocalizedModel>();
            AvailableLanguages = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.Configuration.Stores.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Stores.Fields.Url")]
        [AllowHtml]
        public string Url { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Stores.Fields.SslEnabled")]
        public virtual bool SslEnabled { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Stores.Fields.SecureUrl")]
        [AllowHtml]
        public virtual string SecureUrl { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Stores.Fields.Hosts")]
        [AllowHtml]
        public string Hosts { get; set; }

        //default language
        [SiteResourceDisplayName("Admin.Configuration.Stores.Fields.DefaultLanguage")]
        [AllowHtml]
        public int DefaultLanguageId { get; set; }
        public IList<SelectListItem> AvailableLanguages { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Stores.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Stores.Fields.CompanyName")]
        [AllowHtml]
        public string CompanyName { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Stores.Fields.CompanyAddress")]
        [AllowHtml]
        public string CompanyAddress { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Stores.Fields.CompanyPhoneNumber")]
        [AllowHtml]
        public string CompanyPhoneNumber { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Stores.Fields.CompanyVat")]
        [AllowHtml]
        public string CompanyVat { get; set; }


        public IList<StoreLocalizedModel> Locales { get; set; }
    }

    public partial class StoreLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Stores.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }
    }
}