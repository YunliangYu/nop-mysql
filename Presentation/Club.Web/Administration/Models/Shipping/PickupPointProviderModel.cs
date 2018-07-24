using System.Web.Mvc;
using System.Web.Routing;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Shipping
{
    public partial class PickupPointProviderModel : BaseSiteModel
    {
        [SiteResourceDisplayName("Admin.Configuration.Shipping.PickupPointProviders.Fields.FriendlyName")]
        [AllowHtml]
        public string FriendlyName { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Shipping.PickupPointProviders.Fields.SystemName")]
        [AllowHtml]
        public string SystemName { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Shipping.PickupPointProviders.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Shipping.PickupPointProviders.Fields.IsActive")]
        public bool IsActive { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Shipping.PickupPointProviders.Fields.Logo")]
        public string LogoUrl { get; set; }
        
        public string ConfigurationActionName { get; set; }
        public string ConfigurationControllerName { get; set; }
        public RouteValueDictionary ConfigurationRouteValues { get; set; }
    }
}