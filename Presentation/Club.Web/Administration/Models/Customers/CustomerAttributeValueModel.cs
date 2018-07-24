using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Customers;
using Club.Web.Framework;
using Club.Web.Framework.Localization;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Customers
{
    [Validator(typeof(CustomerAttributeValueValidator))]
    public partial class CustomerAttributeValueModel : BaseSiteEntityModel, ILocalizedModel<CustomerAttributeValueLocalizedModel>
    {
        public CustomerAttributeValueModel()
        {
            Locales = new List<CustomerAttributeValueLocalizedModel>();
        }

        public int CustomerAttributeId { get; set; }

        [SiteResourceDisplayName("Admin.Customers.CustomerAttributes.Values.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Customers.CustomerAttributes.Values.Fields.IsPreSelected")]
        public bool IsPreSelected { get; set; }

        [SiteResourceDisplayName("Admin.Customers.CustomerAttributes.Values.Fields.DisplayOrder")]
        public int DisplayOrder {get;set;}

        public IList<CustomerAttributeValueLocalizedModel> Locales { get; set; }

    }

    public partial class CustomerAttributeValueLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [SiteResourceDisplayName("Admin.Customers.CustomerAttributes.Values.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }
    }
}