using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Localization;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Localization
{
    [Validator(typeof(LanguageResourceValidator))]
    public partial class LanguageResourceModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.Configuration.Languages.Resources.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Languages.Resources.Fields.Value")]
        [AllowHtml]
        public string Value { get; set; }

        public int LanguageId { get; set; }
    }
}