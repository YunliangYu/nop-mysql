using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Customers;
using Club.Web.Framework;
using Club.Web.Framework.Localization;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Customers
{
    [Validator(typeof(CustomerAttributeValidator))]
    public partial class CustomerAttributeModel : BaseSiteEntityModel, ILocalizedModel<CustomerAttributeLocalizedModel>
    {
        public CustomerAttributeModel()
        {
            Locales = new List<CustomerAttributeLocalizedModel>();
        }

        [SiteResourceDisplayName("Admin.Customers.CustomerAttributes.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Customers.CustomerAttributes.Fields.IsRequired")]
        public bool IsRequired { get; set; }

        [SiteResourceDisplayName("Admin.Customers.CustomerAttributes.Fields.AttributeControlType")]
        public int AttributeControlTypeId { get; set; }
        [SiteResourceDisplayName("Admin.Customers.CustomerAttributes.Fields.AttributeControlType")]
        [AllowHtml]
        public string AttributeControlTypeName { get; set; }

        [SiteResourceDisplayName("Admin.Customers.CustomerAttributes.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }


        public IList<CustomerAttributeLocalizedModel> Locales { get; set; }

    }

    public partial class CustomerAttributeLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [SiteResourceDisplayName("Admin.Customers.CustomerAttributes.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

    }
}