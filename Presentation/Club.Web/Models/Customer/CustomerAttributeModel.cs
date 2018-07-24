using System.Collections.Generic;
using Club.Core.Domain.Catalog;
using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Customer
{
    public partial class CustomerAttributeModel : BaseSiteEntityModel
    {
        public CustomerAttributeModel()
        {
            Values = new List<CustomerAttributeValueModel>();
        }

        public string Name { get; set; }

        public bool IsRequired { get; set; }

        /// <summary>
        /// Default value for textboxes
        /// </summary>
        public string DefaultValue { get; set; }

        public AttributeControlType AttributeControlType { get; set; }

        public IList<CustomerAttributeValueModel> Values { get; set; }

    }

    public partial class CustomerAttributeValueModel : BaseSiteEntityModel
    {
        public string Name { get; set; }

        public bool IsPreSelected { get; set; }
    }
}