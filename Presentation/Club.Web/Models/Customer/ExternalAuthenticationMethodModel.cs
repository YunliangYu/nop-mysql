using System.Web.Routing;
using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Customer
{
    public partial class ExternalAuthenticationMethodModel : BaseSiteModel
    {
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public RouteValueDictionary RouteValues { get; set; }
    }
}