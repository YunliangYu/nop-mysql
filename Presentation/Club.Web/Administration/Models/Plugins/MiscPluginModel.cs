using System.Web.Routing;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Plugins
{
    public partial class MiscPluginModel : BaseSiteModel
    {
        public string FriendlyName { get; set; }

        public string ConfigurationActionName { get; set; }
        public string ConfigurationControllerName { get; set; }
        public RouteValueDictionary ConfigurationRouteValues { get; set; }
    }
}