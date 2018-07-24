using System.Collections.Generic;
using Club.Core.Domain.Catalog;
using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Common
{
    public partial class AddressAttributeModel : BaseSiteEntityModel
    {
        public AddressAttributeModel()
        {
            Values = new List<AddressAttributeValueModel>();
        }

        public string Name { get; set; }

        public bool IsRequired { get; set; }

        /// <summary>
        /// Default value for textboxes
        /// </summary>
        public string DefaultValue { get; set; }

        public AttributeControlType AttributeControlType { get; set; }

        public IList<AddressAttributeValueModel> Values { get; set; }
    }

    public partial class AddressAttributeValueModel : BaseSiteEntityModel
    {
        public string Name { get; set; }

        public bool IsPreSelected { get; set; }
    }
}