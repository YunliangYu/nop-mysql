using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Common;
using Club.Web.Framework;
using Club.Web.Framework.Localization;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Common
{
    [Validator(typeof(AddressAttributeValidator))]
    public partial class AddressAttributeModel : BaseSiteEntityModel, ILocalizedModel<AddressAttributeLocalizedModel>
    {
        public AddressAttributeModel()
        {
            Locales = new List<AddressAttributeLocalizedModel>();
        }

        [SiteResourceDisplayName("Admin.Address.AddressAttributes.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Address.AddressAttributes.Fields.IsRequired")]
        public bool IsRequired { get; set; }

        [SiteResourceDisplayName("Admin.Address.AddressAttributes.Fields.AttributeControlType")]
        public int AttributeControlTypeId { get; set; }
        [SiteResourceDisplayName("Admin.Address.AddressAttributes.Fields.AttributeControlType")]
        [AllowHtml]
        public string AttributeControlTypeName { get; set; }

        [SiteResourceDisplayName("Admin.Address.AddressAttributes.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }


        public IList<AddressAttributeLocalizedModel> Locales { get; set; }

    }

    public partial class AddressAttributeLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [SiteResourceDisplayName("Admin.Address.AddressAttributes.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

    }
}