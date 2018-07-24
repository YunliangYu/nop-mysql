using System.Web.Mvc;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Catalog
{
    public partial class ProductSpecificationAttributeModel : BaseSiteEntityModel
    {
        public int AttributeTypeId { get; set; }

        [AllowHtml]
        public string AttributeTypeName { get; set; }

        public int AttributeId { get; set; }

        [AllowHtml]
        public string AttributeName { get; set; }

        [AllowHtml]
        public string ValueRaw { get; set; }

        public bool AllowFiltering { get; set; }

        public bool ShowOnProductPage { get; set; }

        public int DisplayOrder { get; set; }

        public int SpecificationAttributeOptionId { get; set; } 
    }
}