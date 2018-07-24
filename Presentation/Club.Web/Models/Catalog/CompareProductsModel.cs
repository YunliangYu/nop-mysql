using System.Collections.Generic;
using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Catalog
{
    public partial class CompareProductsModel : BaseSiteEntityModel
    {
        public CompareProductsModel()
        {
            Products = new List<ProductOverviewModel>();
        }
        public IList<ProductOverviewModel> Products { get; set; }

        public bool IncludeShortDescriptionInCompareProducts { get; set; }
        public bool IncludeFullDescriptionInCompareProducts { get; set; }
    }
}