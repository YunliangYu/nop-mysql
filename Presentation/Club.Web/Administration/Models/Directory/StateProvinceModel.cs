using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Directory;
using Club.Web.Framework;
using Club.Web.Framework.Localization;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Directory
{
    [Validator(typeof(StateProvinceValidator))]
    public partial class StateProvinceModel : BaseSiteEntityModel, ILocalizedModel<StateProvinceLocalizedModel>
    {
        public StateProvinceModel()
        {
            Locales = new List<StateProvinceLocalizedModel>();
        }
        public int CountryId { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Countries.States.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Countries.States.Fields.Abbreviation")]
        [AllowHtml]
        public string Abbreviation { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Countries.States.Fields.Published")]
        public bool Published { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Countries.States.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        public IList<StateProvinceLocalizedModel> Locales { get; set; }
    }

    public partial class StateProvinceLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }
        
        [SiteResourceDisplayName("Admin.Configuration.Countries.States.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }
    }
}