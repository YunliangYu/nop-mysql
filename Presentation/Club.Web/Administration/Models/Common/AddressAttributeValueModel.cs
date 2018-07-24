using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Common;
using Club.Web.Framework;
using Club.Web.Framework.Localization;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Common
{
    [Validator(typeof(AddressAttributeValueValidator))]
    public partial class AddressAttributeValueModel : BaseSiteEntityModel, ILocalizedModel<AddressAttributeValueLocalizedModel>
    {
        public AddressAttributeValueModel()
        {
            Locales = new List<AddressAttributeValueLocalizedModel>();
        }

        public int AddressAttributeId { get; set; }

        [SiteResourceDisplayName("Admin.Address.AddressAttributes.Values.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Address.AddressAttributes.Values.Fields.IsPreSelected")]
        public bool IsPreSelected { get; set; }

        [SiteResourceDisplayName("Admin.Address.AddressAttributes.Values.Fields.DisplayOrder")]
        public int DisplayOrder {get;set;}

        public IList<AddressAttributeValueLocalizedModel> Locales { get; set; }

    }

    public partial class AddressAttributeValueLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [SiteResourceDisplayName("Admin.Address.AddressAttributes.Values.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }
    }
}