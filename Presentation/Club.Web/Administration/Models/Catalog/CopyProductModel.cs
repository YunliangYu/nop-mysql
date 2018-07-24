using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Catalog
{
    public partial class CopyProductModel : BaseSiteEntityModel
    {

        [SiteResourceDisplayName("Admin.Catalog.Products.Copy.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Copy.CopyImages")]
        public bool CopyImages { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Copy.Published")]
        public bool Published { get; set; }

    }
}