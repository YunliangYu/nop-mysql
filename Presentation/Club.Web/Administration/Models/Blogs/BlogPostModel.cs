using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Blogs;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Blogs
{
    [Validator(typeof(BlogPostValidator))]
    public partial class BlogPostModel : BaseSiteEntityModel
    {
        public BlogPostModel()
        {
            AvailableLanguages = new List<SelectListItem>();

            SelectedStoreIds = new List<int>();
            AvailableStores = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.ContentManagement.Blog.BlogPosts.Fields.Language")]
        public int LanguageId { get; set; }
        public IList<SelectListItem> AvailableLanguages { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Blog.BlogPosts.Fields.Language")]
        [AllowHtml]
        public string LanguageName { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Blog.BlogPosts.Fields.Title")]
        [AllowHtml]
        public string Title { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Blog.BlogPosts.Fields.Body")]
        [AllowHtml]
        public string Body { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Blog.BlogPosts.Fields.BodyOverview")]
        [AllowHtml]
        public string BodyOverview { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Blog.BlogPosts.Fields.AllowComments")]
        public bool AllowComments { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Blog.BlogPosts.Fields.Tags")]
        [AllowHtml]
        public string Tags { get; set; }

        public int ApprovedComments { get; set; }
        public int NotApprovedComments { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Blog.BlogPosts.Fields.StartDate")]
        [UIHint("DateTimeNullable")]
        public DateTime? StartDate { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Blog.BlogPosts.Fields.EndDate")]
        [UIHint("DateTimeNullable")]
        public DateTime? EndDate { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Blog.BlogPosts.Fields.MetaKeywords")]
        [AllowHtml]
        public string MetaKeywords { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Blog.BlogPosts.Fields.MetaDescription")]
        [AllowHtml]
        public string MetaDescription { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Blog.BlogPosts.Fields.MetaTitle")]
        [AllowHtml]
        public string MetaTitle { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Blog.BlogPosts.Fields.SeName")]
        [AllowHtml]
        public string SeName { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Blog.BlogPosts.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }


        //store mapping
        [SiteResourceDisplayName("Admin.ContentManagement.Blog.BlogPosts.Fields.LimitedToStores")]
        [UIHint("MultiSelect")]
        public IList<int> SelectedStoreIds { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }

    }
}