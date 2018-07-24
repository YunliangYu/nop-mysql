using System.Web.Mvc;
using Club.Web.Framework.Security;

namespace Club.Web.Controllers
{
    public partial class HomeController : BasePublicController
    {
        [SiteHttpsRequirement(SslRequirement.No)]
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}
