using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.News;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.News
{
    [Validator(typeof(NewsItemValidator))]
    public partial class NewsItemModel : BaseSiteEntityModel
    {
        public NewsItemModel()
        {
            this.AvailableLanguages = new List<SelectListItem>();
            NewsPictureModels = new List<NewsPictureModel>();
            SelectedStoreIds = new List<int>();
            AvailableStores = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.Language")]
        public int LanguageId { get; set; }
        public IList<SelectListItem> AvailableLanguages { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.Language")]
        [AllowHtml]
        public string LanguageName { get; set; }

        //store mapping
        [SiteResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.LimitedToStores")]
        [UIHint("MultiSelect")]
        public IList<int> SelectedStoreIds { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.Title")]
        [AllowHtml]
        public string Title { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.Short")]
        [AllowHtml]
        public string Short { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.Full")]
        [AllowHtml]
        public string Full { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.AllowComments")]
        public bool AllowComments { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.StartDate")]
        [UIHint("DateTimeNullable")]
        public DateTime? StartDate { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.EndDate")]
        [UIHint("DateTimeNullable")]
        public DateTime? EndDate { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.MetaKeywords")]
        [AllowHtml]
        public string MetaKeywords { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.MetaDescription")]
        [AllowHtml]
        public string MetaDescription { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.MetaTitle")]
        [AllowHtml]
        public string MetaTitle { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.SeName")]
        [AllowHtml]
        public string SeName { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.Published")]
        public bool Published { get; set; }

        public int ApprovedComments { get; set; }
        public int NotApprovedComments { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }


        [SiteResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.NewsTags")]
        public string NewsTags { get; set; }


        //pictures

        //picture thumbnail
        [SiteResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.PictureThumbnailUrl")]
        public string PictureThumbnailUrl { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.News.NewsItems..Fields.NewsProgram")]
        public int NewsProgramId { get; set; }
        [SiteResourceDisplayName("Admin.ContentManagement.News.NewsItems..Fields.NewsProgram")]
        public string NewsProgramName { get; set; }
        public NewsPictureModel AddPictureModel { get; set; }
        public IList<NewsPictureModel> NewsPictureModels { get; set; }


        public partial class NewsPictureModel : BaseSiteEntityModel
        {
            public int NewsId { get; set; }

            [UIHint("Picture")]
            [SiteResourceDisplayName("Admin.ContentManagement.Newss.Pictures.Fields.Picture")]
            public int PictureId { get; set; }

            [SiteResourceDisplayName("Admin.ContentManagement.Newss.Pictures.Fields.Picture")]
            public string PictureUrl { get; set; }

            [SiteResourceDisplayName("Admin.ContentManagement.Newss.Pictures.Fields.DisplayOrder")]
            public int DisplayOrder { get; set; }

            [SiteResourceDisplayName("Admin.ContentManagement.Newss.Pictures.Fields.OverrideAltAttribute")]
            [AllowHtml]
            public string OverrideAltAttribute { get; set; }

            [SiteResourceDisplayName("Admin.ContentManagement.Newss.Pictures.Fields.OverrideTitleAttribute")]
            [AllowHtml]
            public string OverrideTitleAttribute { get; set; }
        }
    }
}