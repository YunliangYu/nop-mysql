using System.Web.Mvc;
using System.Web.Routing;
using Club.Core.Infrastructure;
using Club.Web.Framework;
using Club.Web.Framework.Controllers;
using Club.Web.Framework.Security;
using Club.Web.Framework.Seo;

namespace Club.Web.Controllers
{
    [CheckAffiliate]
    [StoreClosed]
    [PublicStoreAllowNavigation]
    [LanguageSeoCode]
    [SiteHttpsRequirement(SslRequirement.NoMatter)]
    [WwwRequirement]
    public abstract partial class BasePublicController : BaseController
    {
        protected virtual ActionResult InvokeHttp404()
        {
            // Call target Controller and pass the routeData.
            IController errorController = EngineContext.Current.Resolve<CommonController>();

            var routeData = new RouteData();
            routeData.Values.Add("controller", "Common");
            routeData.Values.Add("action", "PageNotFound");

            errorController.Execute(new RequestContext(this.HttpContext, routeData));

            return new EmptyResult();
        }

    }
}
