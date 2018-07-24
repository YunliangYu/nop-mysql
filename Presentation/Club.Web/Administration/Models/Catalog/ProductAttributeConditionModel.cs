using System.Collections.Generic;
using Club.Core.Domain.Catalog;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Catalog
{
    public partial class ProductAttributeConditionModel : BaseSiteModel
    {
        public ProductAttributeConditionModel()
        {
            ProductAttributes = new List<ProductAttributeModel>();
        }

        [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Condition.EnableCondition")]
        public bool EnableCondition { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Condition.Attributes")]
        public int SelectedProductAttributeId { get; set; }
        public IList<ProductAttributeModel> ProductAttributes { get; set; }

        public int ProductAttributeMappingId { get; set; }

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