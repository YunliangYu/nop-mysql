using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Blogs
{
    public partial class BlogPostTagModel : BaseSiteModel
    {
        public string Name { get; set; }

        public int BlogPostCount { get; set; }
    }
}