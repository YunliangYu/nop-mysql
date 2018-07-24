using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Catalog;
using Club.Web.Framework;
using Club.Web.Framework.Localization;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Catalog
{
    [Validator(typeof(ProductTagValidator))]
    public partial class ProductTagModel : BaseSiteEntityModel, ILocalizedModel<ProductTagLocalizedModel>
    {
        public ProductTagModel()
        {
            Locales = new List<ProductTagLocalizedModel>();
        }
        [SiteResourceDisplayName("Admin.Catalog.ProductTags.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.ProductTags.Fields.ProductCount")]
        public int ProductCount { get; set; }

        public IList<ProductTagLocalizedModel> Locales { get; set; }
    }

    public partial class ProductTagLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.ProductTags.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }
    }
}