using System.Collections.Generic;
using System.Linq;
using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Catalog
{
    public partial class TopMenuModel : BaseSiteModel
    {
        public TopMenuModel()
        {
            Categories = new List<CategorySimpleModel>();
            Topics = new List<TopMenuTopicModel>();
        }

        public IList<CategorySimpleModel> Categories { get; set; }
        public IList<TopMenuTopicModel> Topics { get; set; }

        public bool BlogEnabled { get; set; }
        public bool NewProductsEnabled { get; set; }
        public bool ForumEnabled { get; set; }

        public bool DisplayHomePageMenuItem { get; set; }
        public bool DisplayNewProductsMenuItem { get; set; }
        public bool DisplayProductSearchMenuItem { get; set; }
        public bool DisplayCustomerInfoMenuItem { get; set; }
        public bool DisplayBlogMenuItem { get; set; }
        public bool DisplayForumsMenuItem { get; set; }
        public bool DisplayContactUsMenuItem { get; set; }

        public bool HasOnlyCategories
        {
            get
            {
                return Categories.Any()
                       && !Topics.Any()
                       && !DisplayHomePageMenuItem
                       && !(DisplayNewProductsMenuItem && NewProductsEnabled)
                       && !DisplayProductSearchMenuItem
                       && !DisplayCustomerInfoMenuItem
                       && !(DisplayBlogMenuItem && BlogEnabled)
                       && !(DisplayForumsMenuItem && ForumEnabled)
                       && !DisplayContactUsMenuItem;
            }
        }

        #region Nested classes

        public class TopMenuTopicModel : BaseSiteEntityModel
        {
            public string Name { get; set; }
            public string SeName { get; set; }
        }

        #endregion
    }
}