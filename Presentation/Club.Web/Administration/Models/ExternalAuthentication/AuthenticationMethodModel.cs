using System.Web.Mvc;
using System.Web.Routing;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.ExternalAuthentication
{
    public partial class AuthenticationMethodModel : BaseSiteModel
    {
        [SiteResourceDisplayName("Admin.Configuration.ExternalAuthenticationMethods.Fields.FriendlyName")]
        [AllowHtml]
        public string FriendlyName { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.ExternalAuthenticationMethods.Fields.SystemName")]
        [AllowHtml]
        public string SystemName { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.ExternalAuthenticationMethods.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.ExternalAuthenticationMethods.Fields.IsActive")]
        public bool IsActive { get; set; }



        public string ConfigurationActionName { get; set; }
        public string ConfigurationControllerName { get; set; }
        public RouteValueDictionary ConfigurationRouteValues { get; set; }
    }
}