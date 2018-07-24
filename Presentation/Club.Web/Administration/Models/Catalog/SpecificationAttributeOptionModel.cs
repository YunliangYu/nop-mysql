using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Catalog;
using Club.Web.Framework;
using Club.Web.Framework.Localization;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Catalog
{
    [Validator(typeof(SpecificationAttributeOptionValidator))]
    public partial class SpecificationAttributeOptionModel : BaseSiteEntityModel, ILocalizedModel<SpecificationAttributeOptionLocalizedModel>
    {
        public SpecificationAttributeOptionModel()
        {
            Locales = new List<SpecificationAttributeOptionLocalizedModel>();
        }

        public int SpecificationAttributeId { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.SpecificationAttributes.Options.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.SpecificationAttributes.Options.Fields.ColorSquaresRgb")]
        [AllowHtml]
        public string ColorSquaresRgb { get; set; }
        [SiteResourceDisplayName("Admin.Catalog.Attributes.SpecificationAttributes.Options.Fields.EnableColorSquaresRgb")]
        public bool EnableColorSquaresRgb { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.SpecificationAttributes.Options.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.SpecificationAttributes.Options.Fields.NumberOfAssociatedProducts")]
        public int NumberOfAssociatedProducts { get; set; }
        
        public IList<SpecificationAttributeOptionLocalizedModel> Locales { get; set; }

    }

    public partial class SpecificationAttributeOptionLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.SpecificationAttributes.Options.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }
    }
}