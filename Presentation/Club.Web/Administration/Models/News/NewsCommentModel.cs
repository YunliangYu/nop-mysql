using System;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.News
{
    public partial class NewsCommentModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.ContentManagement.News.Comments.Fields.NewsItem")]
        public int NewsItemId { get; set; }
        [SiteResourceDisplayName("Admin.ContentManagement.News.Comments.Fields.NewsItem")]
        [AllowHtml]
        public string NewsItemTitle { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.News.Comments.Fields.Customer")]
        public int CustomerId { get; set; }
        [SiteResourceDisplayName("Admin.ContentManagement.News.Comments.Fields.Customer")]
        public string CustomerInfo { get; set; }

        [AllowHtml]
        [SiteResourceDisplayName("Admin.ContentManagement.News.Comments.Fields.CommentTitle")]
        public string CommentTitle { get; set; }

        [AllowHtml]
        [SiteResourceDisplayName("Admin.ContentManagement.News.Comments.Fields.CommentText")]
        public string CommentText { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.News.Comments.Fields.IsApproved")]
        public bool IsApproved { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.News.Comments.Fields.StoreName")]
        public int StoreId { get; set; }
        public string StoreName { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.News.Comments.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }
    }
}