using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Club.Core.Domain.Catalog;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Catalog
{
    public partial class AddProductAttributeCombinationModel : BaseSiteModel
    {
        public AddProductAttributeCombinationModel()
        {
            ProductAttributes = new List<ProductAttributeModel>();
            Warnings = new List<string>();
        }
        
        [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.Fields.StockQuantity")]
        public int StockQuantity { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.Fields.AllowOutOfStockOrders")]
        public bool AllowOutOfStockOrders { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.Fields.Sku")]
        public string Sku { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.Fields.ManufacturerPartNumber")]
        public string ManufacturerPartNumber { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.Fields.Gtin")]
        public string Gtin { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.Fields.OverriddenPrice")]
        [UIHint("DecimalNullable")]
        public decimal? OverriddenPrice { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.Fields.NotifyAdminForQuantityBelow")]
        public int NotifyAdminForQuantityBelow { get; set; }

        public IList<ProductAttributeModel> ProductAttributes { get; set; }

        public IList<string> Warnings { get; set; }

        public int ProductId { get; set; }

        #region Nested classes

        public partial class ProductAttributeModel : BaseSiteEntityModel
        {
            public ProductAttributeModel()
            {
                Values = new List<ProductAttributeValueModel>();
            }

            public int ProductAttributeId { get; set; }

            public string Name { get; set; }

            public string TextPrompt { get; set; }

            public bool IsRequired { get; set; }

            public AttributeControlType AttributeControlType { get; set; }

            public IList<ProductAttributeValueModel> Values { get; set; }
        }

        public partial class ProductAttributeValueModel : BaseSiteEntityModel
        {
            public string Name { get; set; }

            public bool IsPreSelected { get; set; }
        }
        #endregion
    }
}