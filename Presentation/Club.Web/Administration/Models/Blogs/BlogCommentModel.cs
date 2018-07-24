using System;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Blogs
{
    public partial class BlogCommentModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.ContentManagement.Blog.Comments.Fields.BlogPost")]
        public int BlogPostId { get; set; }
        [SiteResourceDisplayName("Admin.ContentManagement.Blog.Comments.Fields.BlogPost")]
        [AllowHtml]
        public string BlogPostTitle { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Blog.Comments.Fields.Customer")]
        public int CustomerId { get; set; }
        [SiteResourceDisplayName("Admin.ContentManagement.Blog.Comments.Fields.Customer")]
        public string CustomerInfo { get; set; }

        [AllowHtml]
        [SiteResourceDisplayName("Admin.ContentManagement.Blog.Comments.Fields.Comment")]
        public string Comment { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Blog.Comments.Fields.IsApproved")]
        public bool IsApproved { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Blog.Comments.Fields.StoreName")]
        public int StoreId { get; set; }
        public string StoreName { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Blog.Comments.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

    }
}