using System.Web.Routing;
using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Cms
{
    public partial class RenderWidgetModel : BaseSiteModel
    {
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public RouteValueDictionary RouteValues { get; set; }
    }
}