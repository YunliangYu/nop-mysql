using System.Collections.Generic;
using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Catalog
{
    public class CategorySimpleModel : BaseSiteEntityModel
    {
        public CategorySimpleModel()
        {
            SubCategories = new List<CategorySimpleModel>();
        }

        public string Name { get; set; }

        public string SeName { get; set; }

        public int? NumberOfProducts { get; set; }

        public bool IncludeInTopMenu { get; set; }

        public List<CategorySimpleModel> SubCategories { get; set; }
    }
}