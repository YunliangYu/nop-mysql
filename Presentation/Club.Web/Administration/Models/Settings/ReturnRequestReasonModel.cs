using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Settings;
using Club.Web.Framework;
using Club.Web.Framework.Localization;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Settings
{
    [Validator(typeof(ReturnRequestReasonValidator))]
    public partial class ReturnRequestReasonModel : BaseSiteEntityModel, ILocalizedModel<ReturnRequestReasonLocalizedModel>
    {
        public ReturnRequestReasonModel()
        {
            Locales = new List<ReturnRequestReasonLocalizedModel>();
        }

        [SiteResourceDisplayName("Admin.Configuration.Settings.Order.ReturnRequestReasons.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.Order.ReturnRequestReasons.DisplayOrder")]
        public int DisplayOrder { get; set; }

        public IList<ReturnRequestReasonLocalizedModel> Locales { get; set; }
    }

    public partial class ReturnRequestReasonLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.Order.ReturnRequestReasons.Name")]
        [AllowHtml]
        public string Name { get; set; }

    }
}