using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Settings
{
    public class AllSettingsListModel : BaseSiteModel
    {
        [SiteResourceDisplayName("Admin.Configuration.Settings.AllSettings.SearchSettingName")]
        public string SearchSettingName { get; set; }
        [SiteResourceDisplayName("Admin.Configuration.Settings.AllSettings.SearchSettingValue")]
        public string SearchSettingValue { get; set; }
    }
}