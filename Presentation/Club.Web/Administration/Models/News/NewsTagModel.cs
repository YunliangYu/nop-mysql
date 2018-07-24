using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.News;
using Club.Web.Framework;
using Club.Web.Framework.Localization;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.News
{
    [Validator(typeof(NewsTagValidator))]
    public partial class NewsTagModel : BaseSiteEntityModel
    {
        public NewsTagModel()
        {
           
        }
        [SiteResourceDisplayName("Admin.ContentManagement.NewsTags.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.NewsTags.Fields.NewsCount")]
        public int NewsCount { get; set; }
    }
}