using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Blogs
{
    public partial class AddBlogCommentModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Blog.Comments.CommentText")]
        [AllowHtml]
        public string CommentText { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}