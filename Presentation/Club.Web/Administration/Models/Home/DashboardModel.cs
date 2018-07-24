using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Home
{
    public partial class DashboardModel : BaseSiteModel
    {
        public bool IsLoggedInAsVendor { get; set; }
    }
}