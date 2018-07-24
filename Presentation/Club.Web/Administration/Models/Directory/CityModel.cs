using FluentValidation.Attributes;
using Club.Admin.Validators.Directory;
using Club.Web.Framework;
using Club.Web.Framework.Localization;
using Club.Web.Framework.Mvc;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Club.Admin.Models.Directory
{
    [Validator(typeof(CityValidator))]
    public partial class CityModel : BaseSiteEntityModel, ILocalizedModel<CityLocalizedModel>
    {
        public IList<CityLocalizedModel> Locales { get; set; }

        public CityModel()
        {
            Locales = new List<CityLocalizedModel>();
            Provinces = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.Configuration.Countries.Citys.Fields.ProvinceId")]
        public int StateProvinceId { get; set; }
        [SiteResourceDisplayName("Admin.Configuration.Countries.Citys.Fields.Name")]
        public string Name { get; set; }

        public int DisplayOrder { get; set; }

        public IList<SelectListItem> Provinces { get; set; }
    }

    public partial class CityLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Countries.Citys.Fields.Name")]
        public string CityName { get; set; }
    }
}
