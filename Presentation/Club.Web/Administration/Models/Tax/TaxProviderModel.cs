using System.Web.Mvc;
using System.Web.Routing;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Tax
{
    public partial class TaxProviderModel : BaseSiteModel
    {
        [SiteResourceDisplayName("Admin.Configuration.Tax.Providers.Fields.FriendlyName")]
        [AllowHtml]
        public string FriendlyName { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Tax.Providers.Fields.SystemName")]
        [AllowHtml]
        public string SystemName { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Tax.Providers.Fields.IsPrimaryTaxProvider")]
        public bool IsPrimaryTaxProvider { get; set; }





        public string ConfigurationActionName { get; set; }
        public string ConfigurationControllerName { get; set; }
        public RouteValueDictionary ConfigurationRouteValues { get; set; }
    }
}