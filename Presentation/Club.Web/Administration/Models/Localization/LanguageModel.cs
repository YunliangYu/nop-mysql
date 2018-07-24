using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Localization;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Localization
{
    [Validator(typeof(LanguageValidator))]
    public partial class LanguageModel : BaseSiteEntityModel
    {
        public LanguageModel()
        {
            AvailableCurrencies = new List<SelectListItem>();
            SelectedStoreIds = new List<int>();
            AvailableStores = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.Configuration.Languages.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Languages.Fields.LanguageCulture")]
        [AllowHtml]
        public string LanguageCulture { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Languages.Fields.UniqueSeoCode")]
        [AllowHtml]
        public string UniqueSeoCode { get; set; }
        
        //flags
        [SiteResourceDisplayName("Admin.Configuration.Languages.Fields.FlagImageFileName")]
        public string FlagImageFileName { get; set; }


        [SiteResourceDisplayName("Admin.Configuration.Languages.Fields.Rtl")]
        public bool Rtl { get; set; }

        //default currency
        [SiteResourceDisplayName("Admin.Configuration.Languages.Fields.DefaultCurrency")]
        [AllowHtml]
        public int DefaultCurrencyId { get; set; }
        public IList<SelectListItem> AvailableCurrencies { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Languages.Fields.Published")]
        public bool Published { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Languages.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }


        //store mapping
        [SiteResourceDisplayName("Admin.Configuration.Languages.Fields.LimitedToStores")]
        [UIHint("MultiSelect")]
        public IList<int> SelectedStoreIds { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }

        // search
        public LanguageResourcesListModel Search { get; set; }
    }
}