using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Settings;
using Club.Web.Framework;
using Club.Web.Framework.Localization;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Settings
{
    [Validator(typeof(ReturnRequestActionValidator))]
    public partial class ReturnRequestActionModel : BaseSiteEntityModel, ILocalizedModel<ReturnRequestActionLocalizedModel>
    {
        public ReturnRequestActionModel()
        {
            Locales = new List<ReturnRequestActionLocalizedModel>();
        }

        [SiteResourceDisplayName("Admin.Configuration.Settings.Order.ReturnRequestActions.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.Order.ReturnRequestActions.DisplayOrder")]
        public int DisplayOrder { get; set; }

        public IList<ReturnRequestActionLocalizedModel> Locales { get; set; }
    }

    public partial class ReturnRequestActionLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.Order.ReturnRequestActions.Name")]
        [AllowHtml]
        public string Name { get; set; }

    }
}