using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Catalog
{
    public partial class ProductTagModel : BaseSiteEntityModel
    {
        public string Name { get; set; }

        public string SeName { get; set; }

        public int ProductCount { get; set; }
    }
}