using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Web.Models.News
{
    public partial class AddNewsCommentModel : BaseSiteModel
    {
        [SiteResourceDisplayName("News.Comments.CommentTitle")]
        [AllowHtml]
        public string CommentTitle { get; set; }

        [SiteResourceDisplayName("News.Comments.CommentText")]
        [AllowHtml]
        public string CommentText { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}