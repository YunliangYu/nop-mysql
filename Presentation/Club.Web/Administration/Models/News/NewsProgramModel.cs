using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.News;
using Club.Web.Framework;
using Club.Web.Framework.Localization;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.News
{
    [Validator(typeof(NewsProgramValidator))]
    public partial class NewsProgramModel : BaseSiteEntityModel, ILocalizedModel<NewsProgramLocalizedModel>
    {
        public NewsProgramModel()
        {
            Locales = new List<NewsProgramLocalizedModel>();
        }
        [SiteResourceDisplayName("Admin.ContentManagement.NewsProgram.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.NewsProgram.Fields.NewsCount")]
        public int NewsCount { get; set; }

        public IList<NewsProgramLocalizedModel> Locales { get; set; }
    }

    public partial class NewsProgramLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.NewsProgram.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }
    }
}