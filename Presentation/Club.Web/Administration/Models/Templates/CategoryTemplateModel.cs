using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Templates;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Templates
{
    [Validator(typeof(CategoryTemplateValidator))]
    public partial class CategoryTemplateModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.System.Templates.Category.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.System.Templates.Category.ViewPath")]
        [AllowHtml]
        public string ViewPath { get; set; }

        [SiteResourceDisplayName("Admin.System.Templates.Category.DisplayOrder")]
        public int DisplayOrder { get; set; }
    }
}