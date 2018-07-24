using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Shipping;
using Club.Web.Framework;
using Club.Web.Framework.Localization;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Shipping
{
    [Validator(typeof(ShippingMethodValidator))]
    public partial class ShippingMethodModel : BaseSiteEntityModel, ILocalizedModel<ShippingMethodLocalizedModel>
    {
        public ShippingMethodModel()
        {
            Locales = new List<ShippingMethodLocalizedModel>();
        }
        [SiteResourceDisplayName("Admin.Configuration.Shipping.Methods.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Shipping.Methods.Fields.Description")]
        [AllowHtml]
        public string Description { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Shipping.Methods.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        public IList<ShippingMethodLocalizedModel> Locales { get; set; }
    }

    public partial class ShippingMethodLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Shipping.Methods.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Shipping.Methods.Fields.Description")]
        [AllowHtml]
        public string Description { get; set; }

    }
}