using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Templates;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Templates
{
    [Validator(typeof(ProductTemplateValidator))]
    public partial class ProductTemplateModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.System.Templates.Product.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.System.Templates.Product.ViewPath")]
        [AllowHtml]
        public string ViewPath { get; set; }

        [SiteResourceDisplayName("Admin.System.Templates.Product.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [SiteResourceDisplayName("Admin.System.Templates.Product.IgnoredProductTypes")]
        [AllowHtml]
        public string IgnoredProductTypes { get; set; }
    }
}