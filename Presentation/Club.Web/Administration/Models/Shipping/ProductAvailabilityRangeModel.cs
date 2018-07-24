using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Shipping;
using Club.Web.Framework;
using Club.Web.Framework.Localization;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Shipping
{
    [Validator(typeof(ProductAvailabilityRangeValidator))]
    public partial class ProductAvailabilityRangeModel : BaseSiteEntityModel, ILocalizedModel<ProductAvailabilityRangeLocalizedModel>
    {
        public ProductAvailabilityRangeModel()
        {
            Locales = new List<ProductAvailabilityRangeLocalizedModel>();
        }

        [SiteResourceDisplayName("Admin.Configuration.Shipping.ProductAvailabilityRanges.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Shipping.ProductAvailabilityRanges.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        public IList<ProductAvailabilityRangeLocalizedModel> Locales { get; set; }
    }

    public partial class ProductAvailabilityRangeLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Shipping.ProductAvailabilityRanges.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }
    }
}