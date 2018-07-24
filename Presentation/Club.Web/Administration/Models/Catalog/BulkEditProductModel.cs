using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Catalog
{
    public partial class BulkEditProductModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.Catalog.BulkEdit.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.BulkEdit.Fields.SKU")]
        [AllowHtml]
        public string Sku { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.BulkEdit.Fields.Price")]
        public decimal Price { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.BulkEdit.Fields.OldPrice")]
        public decimal OldPrice { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.BulkEdit.Fields.ManageInventoryMethod")]
        public string ManageInventoryMethod { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.BulkEdit.Fields.StockQuantity")]
        public int StockQuantity { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.BulkEdit.Fields.Published")]
        public bool Published { get; set; }
    }
}