using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Catalog;
using Club.Web.Framework;
using Club.Web.Framework.Localization;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Catalog
{
    [Validator(typeof(SpecificationAttributeValidator))]
    public partial class SpecificationAttributeModel : BaseSiteEntityModel, ILocalizedModel<SpecificationAttributeLocalizedModel>
    {
        public SpecificationAttributeModel()
        {
            Locales = new List<SpecificationAttributeLocalizedModel>();
        }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.SpecificationAttributes.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.SpecificationAttributes.Fields.DisplayOrder")]
        public int DisplayOrder {get;set;}


        public IList<SpecificationAttributeLocalizedModel> Locales { get; set; }

    }

    public partial class SpecificationAttributeLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.SpecificationAttributes.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }
    }
}