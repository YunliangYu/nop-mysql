using System.Collections.Generic;
using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Catalog
{
    public partial class CategoryNavigationModel : BaseSiteModel
    {
        public CategoryNavigationModel()
        {
            Categories = new List<CategorySimpleModel>();
        }

        public int CurrentCategoryId { get; set; }
        public List<CategorySimpleModel> Categories { get; set; }
    }
}