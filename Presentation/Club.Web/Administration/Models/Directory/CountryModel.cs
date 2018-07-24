using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Directory;
using Club.Web.Framework;
using Club.Web.Framework.Localization;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Directory
{
    [Validator(typeof(CountryValidator))]
    public partial class CountryModel : BaseSiteEntityModel, ILocalizedModel<CountryLocalizedModel>
    {
        public CountryModel()
        {
            Locales = new List<CountryLocalizedModel>();

            SelectedStoreIds = new List<int>();
            AvailableStores = new List<SelectListItem>();
        }
        [SiteResourceDisplayName("Admin.Configuration.Countries.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Countries.Fields.AllowsBilling")]
        public bool AllowsBilling { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Countries.Fields.AllowsShipping")]
        public bool AllowsShipping { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Countries.Fields.TwoLetterIsoCode")]
        [AllowHtml]
        public string TwoLetterIsoCode { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Countries.Fields.ThreeLetterIsoCode")]
        [AllowHtml]
        public string ThreeLetterIsoCode { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Countries.Fields.NumericIsoCode")]
        public int NumericIsoCode { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Countries.Fields.SubjectToVat")]
        public bool SubjectToVat { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Countries.Fields.Published")]
        public bool Published { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Countries.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }




        [SiteResourceDisplayName("Admin.Configuration.Countries.Fields.NumberOfStates")]
        public int NumberOfStates { get; set; }

        public IList<CountryLocalizedModel> Locales { get; set; }


        //store mapping
        [SiteResourceDisplayName("Admin.Configuration.Countries.Fields.LimitedToStores")]
        [UIHint("MultiSelect")]
        public IList<int> SelectedStoreIds { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }
    }

    public partial class CountryLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Countries.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }
    }
}