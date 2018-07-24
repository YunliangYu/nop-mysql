using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Catalog;
using Club.Web.Framework;
using Club.Web.Framework.Localization;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Catalog
{
    [Validator(typeof(ProductAttributeValidator))]
    public partial class ProductAttributeModel : BaseSiteEntityModel, ILocalizedModel<ProductAttributeLocalizedModel>
    {
        public ProductAttributeModel()
        {
            Locales = new List<ProductAttributeLocalizedModel>();
        }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.ProductAttributes.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.ProductAttributes.Fields.Description")]
        [AllowHtml]
        public string Description {get;set;}
        


        public IList<ProductAttributeLocalizedModel> Locales { get; set; }

        #region Nested classes

        public partial class UsedByProductModel : BaseSiteEntityModel
        {
            [SiteResourceDisplayName("Admin.Catalog.Attributes.ProductAttributes.UsedByProducts.Product")]
            public string ProductName { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Attributes.ProductAttributes.UsedByProducts.Published")]
            public bool Published { get; set; }
        }

        #endregion
    }

    public partial class ProductAttributeLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.ProductAttributes.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.ProductAttributes.Fields.Description")]
        [AllowHtml]
        public string Description {get;set;}
    }


    [Validator(typeof(PredefinedProductAttributeValueModelValidator))]
    public partial class PredefinedProductAttributeValueModel : BaseSiteEntityModel, ILocalizedModel<PredefinedProductAttributeValueLocalizedModel>
    {
        public PredefinedProductAttributeValueModel()
        {
            Locales = new List<PredefinedProductAttributeValueLocalizedModel>();
        }

        public int ProductAttributeId { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.ProductAttributes.PredefinedValues.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.ProductAttributes.PredefinedValues.Fields.PriceAdjustment")]
        public decimal PriceAdjustment { get; set; }
        [SiteResourceDisplayName("Admin.Catalog.Attributes.ProductAttributes.PredefinedValues.Fields.PriceAdjustment")]
        //used only on the values list page
        public string PriceAdjustmentStr { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.ProductAttributes.PredefinedValues.Fields.WeightAdjustment")]
        public decimal WeightAdjustment { get; set; }
        [SiteResourceDisplayName("Admin.Catalog.Attributes.ProductAttributes.PredefinedValues.Fields.WeightAdjustment")]
        //used only on the values list page
        public string WeightAdjustmentStr { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.ProductAttributes.PredefinedValues.Fields.Cost")]
        public decimal Cost { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.ProductAttributes.PredefinedValues.Fields.IsPreSelected")]
        public bool IsPreSelected { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.ProductAttributes.PredefinedValues.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        public IList<PredefinedProductAttributeValueLocalizedModel> Locales { get; set; }
    }
    public partial class PredefinedProductAttributeValueLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.ProductAttributes.PredefinedValues.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }
    }
}