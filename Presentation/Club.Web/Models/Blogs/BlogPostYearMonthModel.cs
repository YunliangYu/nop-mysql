using System.Collections.Generic;
using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Blogs
{
    public partial class BlogPostYearModel : BaseSiteModel
    {
        public BlogPostYearModel()
        {
            Months = new List<BlogPostMonthModel>();
        }
        public int Year { get; set; }
        public IList<BlogPostMonthModel> Months { get; set; }
    }
    public partial class BlogPostMonthModel : BaseSiteModel
    {
        public int Month { get; set; }

        public int BlogPostCount { get; set; }
    }
}