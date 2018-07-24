using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Blogs
{
    public partial class BlogCommentListModel : BaseSiteModel
    {
        public BlogCommentListModel()
        {
            AvailableApprovedOptions = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.ContentManagement.Blog.Comments.List.CreatedOnFrom")]
        [UIHint("DateNullable")]
        public DateTime? CreatedOnFrom { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Blog.Comments.List.CreatedOnTo")]
        [UIHint("DateNullable")]
        public DateTime? CreatedOnTo { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Blog.Comments.List.SearchText")]
        [AllowHtml]
        public string SearchText { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Blog.Comments.List.SearchApproved")]
        public int SearchApprovedId { get; set; }

        public IList<SelectListItem> AvailableApprovedOptions { get; set; }
    }
}