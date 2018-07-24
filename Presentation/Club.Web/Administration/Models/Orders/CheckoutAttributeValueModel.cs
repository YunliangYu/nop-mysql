using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Orders;
using Club.Web.Framework;
using Club.Web.Framework.Localization;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Orders
{
    [Validator(typeof(CheckoutAttributeValueValidator))]
    public partial class CheckoutAttributeValueModel : BaseSiteEntityModel, ILocalizedModel<CheckoutAttributeValueLocalizedModel>
    {
        public CheckoutAttributeValueModel()
        {
            Locales = new List<CheckoutAttributeValueLocalizedModel>();
        }

        public int CheckoutAttributeId { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Values.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Values.Fields.ColorSquaresRgb")]
        [AllowHtml]
        public string ColorSquaresRgb { get; set; }
        public bool DisplayColorSquaresRgb { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Values.Fields.PriceAdjustment")]
        public decimal PriceAdjustment { get; set; }
        public string PrimaryStoreCurrencyCode { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Values.Fields.WeightAdjustment")]
        public decimal WeightAdjustment { get; set; }
        public string BaseWeightIn { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Values.Fields.IsPreSelected")]
        public bool IsPreSelected { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Values.Fields.DisplayOrder")]
        public int DisplayOrder {get;set;}

        public IList<CheckoutAttributeValueLocalizedModel> Locales { get; set; }

    }

    public partial class CheckoutAttributeValueLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Values.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }
    }
}