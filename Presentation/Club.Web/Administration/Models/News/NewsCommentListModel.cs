using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.News
{
    public partial class NewsCommentListModel : BaseSiteModel
    {
        public NewsCommentListModel()
        {
            AvailableApprovedOptions = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.ContentManagement.News.Comments.List.CreatedOnFrom")]
        [UIHint("DateNullable")]
        public DateTime? CreatedOnFrom { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.News.Comments.List.CreatedOnTo")]
        [UIHint("DateNullable")]
        public DateTime? CreatedOnTo { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.News.Comments.List.SearchText")]
        [AllowHtml]
        public string SearchText { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.News.Comments.List.SearchApproved")]
        public int SearchApprovedId { get; set; }

        public IList<SelectListItem> AvailableApprovedOptions { get; set; }
    }
}