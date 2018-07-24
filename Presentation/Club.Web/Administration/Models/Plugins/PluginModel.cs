using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Plugins;
using Club.Web.Framework;
using Club.Web.Framework.Localization;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Plugins
{
    [Validator(typeof(PluginValidator))]
    public partial class PluginModel : BaseSiteModel, ILocalizedModel<PluginLocalizedModel>
    {
        public PluginModel()
        {
            Locales = new List<PluginLocalizedModel>();

            SelectedStoreIds = new List<int>();
            AvailableStores = new List<SelectListItem>();
            SelectedCustomerRoleIds = new List<int>();
            AvailableCustomerRoles = new List<SelectListItem>();
        }
        [SiteResourceDisplayName("Admin.Configuration.Plugins.Fields.Group")]
        [AllowHtml]
        public string Group { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Plugins.Fields.FriendlyName")]
        [AllowHtml]
        public string FriendlyName { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Plugins.Fields.SystemName")]
        [AllowHtml]
        public string SystemName { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Plugins.Fields.Version")]
        [AllowHtml]
        public string Version { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Plugins.Fields.Author")]
        [AllowHtml]
        public string Author { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Plugins.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Plugins.Fields.Configure")]
        public string ConfigurationUrl { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Plugins.Fields.Installed")]
        public bool Installed { get; set; }
        
        [AllowHtml]
        public string Description { get; set; }

        public bool CanChangeEnabled { get; set; }
        [SiteResourceDisplayName("Admin.Configuration.Plugins.Fields.IsEnabled")]
        public bool IsEnabled { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Plugins.Fields.Logo")]
        public string LogoUrl { get; set; }

        public IList<PluginLocalizedModel> Locales { get; set; }

        //ACL (customer roles)
        [SiteResourceDisplayName("Admin.Configuration.Plugins.Fields.AclCustomerRoles")]
        [UIHint("MultiSelect")]
        public IList<int> SelectedCustomerRoleIds { get; set; }
        public IList<SelectListItem> AvailableCustomerRoles { get; set; }

        //store mapping
        [SiteResourceDisplayName("Admin.Configuration.Plugins.Fields.LimitedToStores")]
        [UIHint("MultiSelect")]
        public IList<int> SelectedStoreIds { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }
    }
    public partial class PluginLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Plugins.Fields.FriendlyName")]
        [AllowHtml]
        public string FriendlyName { get; set; }
    }
}