using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Catalog
{
    public partial class LowStockProductModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.Name")]
        public string Name { get; set; }

        public string Attributes { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.ManageInventoryMethod")]
        public string ManageInventoryMethod { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.StockQuantity")]
        public int StockQuantity { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.Published")]
        public bool Published { get; set; }
    }
}