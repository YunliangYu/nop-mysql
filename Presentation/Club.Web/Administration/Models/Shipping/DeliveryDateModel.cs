using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Shipping;
using Club.Web.Framework;
using Club.Web.Framework.Localization;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Shipping
{
    [Validator(typeof(DeliveryDateValidator))]
    public partial class DeliveryDateModel : BaseSiteEntityModel, ILocalizedModel<DeliveryDateLocalizedModel>
    {
        public DeliveryDateModel()
        {
            Locales = new List<DeliveryDateLocalizedModel>();
        }
        [SiteResourceDisplayName("Admin.Configuration.Shipping.DeliveryDates.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Shipping.DeliveryDates.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        public IList<DeliveryDateLocalizedModel> Locales { get; set; }
    }

    public partial class DeliveryDateLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Shipping.DeliveryDates.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

    }
}