using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Settings;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Settings
{
    [Validator(typeof(SettingValidator))]
    public partial class SettingModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.Configuration.Settings.AllSettings.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.AllSettings.Fields.Value")]
        [AllowHtml]
        public string Value { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.AllSettings.Fields.StoreName")]
        public string Store { get; set; }
        public int StoreId { get; set; }
    }
}