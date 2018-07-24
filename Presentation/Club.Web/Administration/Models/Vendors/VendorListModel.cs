using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Vendors
{
    public partial class VendorListModel : BaseSiteModel
    {
        [SiteResourceDisplayName("Admin.Vendors.List.SearchName")]
        [AllowHtml]
        public string SearchName { get; set; }
    }
}